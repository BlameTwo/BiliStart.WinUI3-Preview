using IAppContracts.TabViewContract;
using Microsoft.Extensions.DependencyInjection;
using Network.Models.Bangumi;
using Serilog;
using ViewConverter.Models.Messager;

namespace ViewModels.AppTabViewModels;

public sealed partial class PgcPlayerViewModel
    : PlayerViewModelBases,
        IRecipient<PlayerCommonData>,
        IRecipient<PlayerGoBackMain>,
        IRecipient<OpenPgcSession>
{
    public PgcPlayerViewModel(
        IRootNavigationMethod rootNavigationMethod,
        [FromKeyedServices(NavHostingConfig.RootNav)] INavigationService navigationService,
        IMediaCreater mediaCreater,
        IDanmakuProvider danmakuProvider,
        IWindowManager windowManager,
        ICurrent current,
        IBangumiProvider bangumiProvider,
        IReplyProvider replyProvider,
        IPgcDataViewModelFactory pgcDataViewModelFactory,
        ICommunityFactory communityFactory,
        IUserControlViewModelFactory userControlViewModelFactory,
        ILogger logger,
        ITipShow tipShow,ITabViewService tabViewService
    )
        : base(
            rootNavigationMethod,
            navigationService,
            mediaCreater,
            danmakuProvider,
            windowManager,
            current,
            logger,
            tipShow
        )
    {
        BangumiProvider = bangumiProvider;
        ReplyProvider = replyProvider;
        PgcDataViewModelFactory = pgcDataViewModelFactory;
        CommunityFactory = communityFactory;
        UserControlViewModelFactory = userControlViewModelFactory;
        TabViewService = tabViewService;
    }


    [ObservableProperty]
    long _MSID;

    [ObservableProperty]
    IPgcPagesViewModel _PgcPagesViewModel;

    [ObservableProperty]
    IPlayerReplysViewModel _PgcPlayerReplyViewModel;

    [ObservableProperty]
    IPlayerReplysCommonsViewModel _PgcPlayerCommonsViewModel;

    [ObservableProperty]
    bool _SessionOpen;

    Dash PgcDash { get; set; }

    [ObservableProperty]
    Visibility _PgcPagesVisibility;

    [ObservableProperty]
    Visibility _PgcReplyVisibility;

    [ObservableProperty]
    Visibility _PgcReplyCommentVisibility = Visibility.Collapsed;

    [ObservableProperty]
    ObservableCollection<Support_Formats> _QualityLists = new();

    [ObservableProperty]
    BangumiDetilyModel _DataBase;

    [ObservableProperty]
    IPgcSessionViewModel _PgcSessionViewModel;

    public IBangumiProvider BangumiProvider { get; }
    public IReplyProvider ReplyProvider { get; }
    public IPgcDataViewModelFactory PgcDataViewModelFactory { get; }
    public ICommunityFactory CommunityFactory { get; }
    public IUserControlViewModelFactory UserControlViewModelFactory { get; }
    public ITabViewService TabViewService { get; }
    public string Key { get; private set; }

    public override void _loadEd(IDashMediaPlayerElement element)
    {
        this.Element = element;
        this.DanmakuControl = element.DanmakeControl;
        this.Element.TransportQualityListChanged += Element_TransportQualityListChanged;
        this.Element.PlayerProgressChanged += Element_PlayerProgressChanged;
        this.Element.PlayOpenedEvent += Element_PlayOpenedEvent;
    }

    private void Element_PlayOpenedEvent(object source)
    {
        this.TabViewService.UpDateProgressRing(Key, Visibility.Collapsed);
    }

    Data_Episodes _nowPage = null;

    private async void Element_PlayerProgressChanged(object source, TimeSpan time) =>
        await RefershDanmaku(this._nowPage.Aid, this._nowPage.Cid, time);

    private async void Element_TransportQualityListChanged(object source, object SelectItem)
    {
        this.TabViewService.UpDateProgressRing(Key, Visibility.Visible);
        if (SelectItem == null)
            return;
        if (SelectItem is Support_Formats val)
        {
            MediaPlayer mediaplayer = null;
            if (PgcDash == null)
            {
                TipShow.ShowMessage("未获取到流媒体信息", Symbol.Clear);
                return;
            }
            foreach (var item in this.PgcDash.DashVideos)
            {
                if (item.ID == val.Quality)
                {
                    mediaplayer = await MediaCreater.CreateMediaSourceAsync(
                        item,
                        this.PgcDash.DashAudio[0]
                    );
                }
            }
            this.Element.SetMediaPlayer(mediaplayer);
        }
    }

    public async Task RefershDataAsync(long data)
    {
        this.MSID = data;
        this.Key = $"{typeof(PgcPlayerViewModel).FullName}+{MSID}";
        this.Title = data.ToString();
        this.DataBase = (await BangumiProvider.GetBangumiViewInfoAsync(data.ToString())).Data;
        this.PgcPagesViewModel = PgcDataViewModelFactory.CreatePgcPageViewModel(DataBase);
        this.TabViewService.UpDateProgressRing(Key, Visibility.Collapsed);
        this.TabViewService.UpDateTitle(Key, DataBase.SeasonTitle);
    }

    public async Task RefershDashAsync(object selectionItem)
    {
        this.QualityLists.Clear();
        this.PgcDash = null;
        this.Element.QualitySelectItem = null;
        if (selectionItem is Data_Episodes data)
        {
            var result = (
                await BangumiProvider.GetBangumiUrlInfoAsync(data.Aid, data.Epid, data.Cid)
            );
            this.PgcDash = result.Result.Dash;
            this.QualityLists = this.FormatQuality(result.Result.PgcSupport_Formats, true)
                .ToObservableCollection();
            this.Element.QualitySelectItem = this.QualityLists[0];
            var reply = await ReplyProvider.GetReplyListAsync(data.Aid);
            this.PgcPlayerReplyViewModel = UserControlViewModelFactory.CreatePlayerReplays(
                reply,
                data.Aid,
                Network.Models.Enum.ReplyOrderEnum.Hot,
                Network.Models.Enum.CommentType.Video
            );
            this._nowPage = data;
        }
    }

    List<Support_Formats> FormatQuality(
        List<PgcSupport_formats> values,
        bool islogin,
        bool isvip = true
    )
    {
        List<Support_Formats> result = new();
        foreach (var item in values)
        {
            if (islogin == false)
                continue;
            if (!isvip && item.NeedVip)
                continue;
            result.Add(
                new()
                {
                    Quality = item.Quality,
                    Codec = item.Codec,
                    Display_Desc = item.Display_Desc,
                    Format = item.Format,
                    New_description = item.New_description,
                    SuperScript = item.SuperScript
                }
            );
        }
        return result;
    }

    public async void Receive(PlayerCommonData message)
    {
        var result = await ReplyProvider.GetReplyCommentAsync(message.DataSource);
        if (message.OpenEnum == CommonOpenEnum.Open)
        {
            this.PgcPagesVisibility = Visibility.Collapsed;
            this.PgcReplyVisibility = Visibility.Collapsed;
            this.PgcReplyCommentVisibility = Visibility.Visible;
            this.PgcPlayerCommonsViewModel = UserControlViewModelFactory.CreateCommons(
                result,
                message.type
            );
        }
    }

    public void Receive(PlayerGoBackMain message)
    {
        if (message.flage)
        {
            this.PgcPagesVisibility = Visibility.Collapsed;
            this.PgcReplyVisibility = Visibility.Visible;
            this.PgcReplyCommentVisibility = Visibility.Collapsed;
        }
    }

    public void Receive(OpenPgcSession message)
    {
        this.SessionOpen = message.isOpen;
        this.PgcSessionViewModel = (IPgcSessionViewModel)message.sender;
    }

    public override async void DanmakuSend(string content)
    {
        var result = await this.DanmakuProvider.SendDanmaku(
            content,
            this._nowPage.Aid,
            _nowPage.Cid,
            1,
            System.Convert.ToInt64(this.Element.MediaPlayer.Position.TotalMilliseconds),
            16777215,
            DanmakuType.Scrool
        );
    }

}
