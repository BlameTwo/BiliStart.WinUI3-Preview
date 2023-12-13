using App.Models.MediaPlayerArgs;
using IAppContracts.TabViewContract;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using ViewConverter.Models.Messager;

namespace ViewModels.AppTabViewModels;

public partial class PlayerViewModel
    : PlayerViewModelBases,
        IRecipient<PlayerCommonData>,
        IRecipient<PlayerGoBackMain>
{
    long _cid = 0;

    string key = "";
    public IVideoProvider VideoProvider { get; }
    public IUserControlViewModelFactory UserControlViewModelFactory { get; }
    public IReplyProvider ReplyProvider { get; }
    public ITabViewService TabViewService { get; }
    public IDanmakuProvider DanmakuProvider { get; }

    #region 绑定属性
    [ObservableProperty]
    VideoPlayerArgs _Base;

    [ObservableProperty]
    VideoInfo _Videoinfo;

    [ObservableProperty]
    PlayerView _ViewReply;

    [ObservableProperty]
    ObservableCollection<Support_Formats> _Qualitylist = new();

    [ObservableProperty]
    bool _Isloaded = true;
        
    [ObservableProperty]
    Visibility _PlayerRelatesVisibility = Visibility.Visible;

    [ObservableProperty]
    Visibility _PlayerPageNavitemVisibility = Visibility.Visible;

    [ObservableProperty]
    Visibility _PlayerCommandVisibility = Visibility.Collapsed;

    [ObservableProperty]
    Visibility _PlayerPagesVisibility = Visibility.Collapsed;

    [ObservableProperty]
    Visibility _PlayerReplyCommonsVisibility = Visibility.Collapsed;

    [ObservableProperty]
    IPlayerRelatesViewModel _PlayerRelatesVm = null;

    [ObservableProperty]
    IPlayerReplysViewModel _PlayerReplysVm = null;

    [ObservableProperty]
    IPlayerReplysCommonsViewModel _PlayerCommonsViewModel = null;

    [ObservableProperty]
    IPlayerPagesModel _PlayerPagesVm = null;

    public PlayerViewModel(
        IRootNavigationMethod rootNavigationMethod,
        [FromKeyedServices(NavHostingConfig.RootNav)] INavigationService navigationService,
        IMediaCreater mediaCreater,
        IDanmakuProvider danmakuProvider,
        IWindowManager windowManager,
        ICurrent current,
        ILogger logger,
        ITipShow tipShow,
        IVideoProvider videoProvider,
        IUserControlViewModelFactory userControlViewModelFactory,
        IReplyProvider replyProvider,
        ITabViewService tabViewService
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
        VideoProvider = videoProvider;
        UserControlViewModelFactory = userControlViewModelFactory;
        ReplyProvider = replyProvider;
        TabViewService = tabViewService;
        DanmakuProvider = danmakuProvider;
    }
    #endregion

    [RelayCommand]
    void ClipLine()
    {
        var package = new DataPackage();
        package.SetText(this.ViewReply.ShareLink);
        Clipboard.SetContent(package);
    }

    public void SetDanmakuControl(IDanmakuControl biliDanmakuControl)
    {
        this.DanmakuControl = biliDanmakuControl;
    }

    private void Element_TransportQualityListChanged(object source, object SelectItem)
    {
        QualityMetadata((Support_Formats)SelectItem);
    }

    private async void Element_PlayerProgressChanged(object source, TimeSpan time) =>
        await RefershDanmaku(this.ViewReply.Aid, this._cid, time);

    public async void RefershMediaPlayer(VideoPlayerArgs value)
    {
        this.key = $"{typeof(PlayerViewModel).FullName}+{value.Aid}";
        this.TabViewService.UpDateTitle(key, "正在加载视频……");
        if (value.Aid != null)
        {
            this.ViewReply = await VideoProvider.GetVideoViewAsync(
                Network.Models.Enum.VideoTypeEnum.Av,
                value.Aid.ToString(),
                this.TokenSource.Token
            );
        }
        if(ViewReply == null)
        {
            this.ViewReply = await VideoProvider.GetVideoViewAsync(
                Network.Models.Enum.VideoTypeEnum.Bv,
                value.Bvid,
                TokenSource.Token
            );
        }
        if (ViewReply.PlayerPages.Count == 1)
        {
            this.PlayerPageNavitemVisibility = Visibility.Visible;
        }

        this.Title = ViewReply.PlayerSession.Title;
        if(value.SpaceCid!= null)
            this.PlayerPagesVm = UserControlViewModelFactory.CreatePlayerPages(this.ViewReply,(long)value.SpaceCid);
        else
            this.PlayerPagesVm = UserControlViewModelFactory.CreatePlayerPages(this.ViewReply, ViewReply.FirstCid);
        this.PlayerRelatesVm = UserControlViewModelFactory.CreatePlayerRelates(this.ViewReply);
        this.PlayerReplysVm = UserControlViewModelFactory.CreatePlayerReplays(
            await ReplyProvider.GetReplyListAsync(this.ViewReply.Aid),
            this.ViewReply.Aid,
            Network.Models.Enum.ReplyOrderEnum.Hot,
            Network.Models.Enum.CommentType.Video
        );
        if (value.SpaceCid != null)
            this.PlayerPagesVm.SpaceCid = (long)value.SpaceCid;
        WindowManager.SetWindowTitle(this.Title);
        Logger.LogWrite<PlayerViewModel>($"更改系统控制器显示，标题为{ViewReply.PlayerSession.Title}");
        this.TabViewService.UpDateTitle(key, ViewReply.PlayerSession.Title);
        this.TabViewService.UpDateProgressRing(key, Visibility.Collapsed);
    }

    /// <summary>
    /// 更换清晰度
    /// </summary>
    /// <param name="support"></param>
    public async void QualityMetadata(Support_Formats support)
    {
        //AV1解码器位置
        MediaPlayer player = null;
        foreach (var item in Videoinfo.Dash.DashVideos)
        {
            if (item.ID != support.Quality)
                continue;
            if (item.Codecs.StartsWith("hev"))
            {
                player = await MediaCreater.CreateMediaSourceAsync(
                    item,
                    this.Videoinfo.Dash.DashAudio[0]
                );
            }
            else if (item.Codecs.StartsWith("avc"))
            {
                player = await MediaCreater.CreateMediaSourceAsync(
                    item,
                    this.Videoinfo.Dash.DashAudio[0]
                );
            }
        }
        this.Element.SetMediaPlayer(player);
        Logger.LogWrite<PlayerViewModel>(
            $"更换清晰度：{support.New_description},清晰度代码:{support.Quality},解码器{support.Codec}"
        );
    }

    public override void _loadEd(IDashMediaPlayerElement element)
    {
        this.Element = element;
        this.DanmakuControl = Element.DanmakeControl;
        this.Element.PlayOpenedEvent += Element_PlayOpenedEvent;
        this.Element.PlayerProgressChanged += Element_PlayerProgressChanged;
        this.Element.TransportQualityListChanged += Element_TransportQualityListChanged;
    }

    public async Task PagesMetadata(ViewPage page)
    {
        this.Videoinfo = (
            await VideoProvider.GetVideoDashSourceAsync(
                Network.Models.Enum.VideoTypeEnum.Bv,
                page.Cid,
                ViewReply.Bvid
            )
        ).Data;
        Qualitylist.ObservableAddRange(Videoinfo.Support_Formats);
        bool islogin = await Current.IsLoginAsync();
        Support_Formats selectitem = null;
        foreach (var item in Qualitylist)
        {
            if (islogin == true && item.Quality == 80)
            {
                selectitem = item;
            }
            else if (islogin == false && item.Quality == 16)
            {
                selectitem = item;
            }
            if (selectitem != null)
            {
                this.Element.QualitySelectItem = selectitem;
                var danmaku = await DanmakuProvider.GetVideoDanmakuAsync(
                    ViewReply.Aid,
                    page.Cid,
                    1
                );
                this.DanmakuList = danmaku.ToObservableCollection();
                this._cid = page.Cid;
                Logger.LogWrite<PlayerViewModel>("视频页面切换分集");
                break;
            }
            else
                continue;
        }
    }

    private void Element_PlayOpenedEvent(object source)
    {
        if (source is bool value && value)
        {
            this.Isloaded = false;
            this.Element.RefreshSystemVideoTitle(
                this.ViewReply.PlayerSession.Title,
                this.ViewReply.PlayerSession.Desc,
                this.ViewReply.PlayerSession.Cover
            );
            Logger.LogWrite<PlayerViewModel>("视频播放器缓冲结束");
        }
    }

    public override async void DanmakuSend(string content)
    {
        var result = await this.DanmakuProvider.SendDanmaku(
            content,
            this.ViewReply.Aid,
            this._cid,
            1,
            System.Convert.ToInt64(this.Element.MediaPlayer.Position.TotalMilliseconds),
            16777215,
            DanmakuType.Scrool
        );
        Logger.LogWrite<PlayerViewModel>("发送弹幕");
    }

    public async void Receive(PlayerCommonData message)
    {
        var result = await ReplyProvider.GetReplyCommentAsync(message.DataSource);
        if (message.OpenEnum == CommonOpenEnum.Open)
        {
            this.PlayerCommandVisibility = Visibility.Collapsed;
            this.PlayerRelatesVisibility = Visibility.Collapsed;
            this.PlayerReplyCommonsVisibility = Visibility.Visible;
            this.PlayerCommonsViewModel = UserControlViewModelFactory.CreateCommons(
                result,
                message.type
            );
        }
    }

    public void Receive(PlayerGoBackMain message)
    {
        if (message.flage)
        {
            this.PlayerCommandVisibility = Visibility.Visible;
            this.PlayerRelatesVisibility = Visibility.Collapsed;
            this.PlayerReplyCommonsVisibility = Visibility.Collapsed;
        }
    }
}
