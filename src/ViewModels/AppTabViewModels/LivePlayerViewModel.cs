using IAppContracts.TabViewContract;
using Microsoft.Extensions.DependencyInjection;
using Network.Models.Live;
using Serilog;
using System.Diagnostics;
using ViewConverter.Models.Live.Message;

namespace ViewModels.AppTabViewModels;

public sealed partial class LivePlayerViewModel : PlayerViewModelBases
{
    public LivePlayerViewModel(
        IRootNavigationMethod rootNavigationMethod,
        [FromKeyedServices(NavHostingConfig.RootNav)] INavigationService navigationService,
        IMediaCreater mediaCreater,
        IDanmakuProvider danmakuProvider,
        IWindowManager windowManager,
        ICurrent current,
        ILogger logger,
        ITipShow tipShow,
        ILiveProvider liveProvider,
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
        LiveProvider = liveProvider;
        TabViewService = tabViewService;
    }

    public ILiveProvider LiveProvider { get; }
    public ITabViewService TabViewService { get; }

    private long _roomid;
    ILiveClient _client = null;
    CancellationTokenSource _tokensource = null;

    string _key = "";

    public void RefershDataAsync(long data)
    {
        this._roomid = data;
        _key = $"{typeof(ViewModels.AppTabViewModels.LivePlayerViewModel).FullName}+{data}";
    }

    [RelayCommand]
    void RefershLiveAsync() { }

    /// <summary>
    /// 初始化直播消息监听
    /// </summary>
    /// <returns></returns>
    private async Task initClient()
    {
        _tokensource = new();
        var result = await LiveProvider.GetLiveDanmakuInfoAsync(Convert.ToInt32(_roomid));
        this._client = LiveProvider.CreateClient(result.Data, Convert.ToInt32(_roomid));
        _client.LogOutputEvent += (source, message) =>
        {
            Debug.WriteLine(message);
        };
        _client.ServerMessageEvent += async (source, message) =>
        {
            AutoScrollToBottom = true;
            message.TryGetProperty("cmd", out var value);
            string val = value.GetString()!;
            if (val == "INTERACT_WORD")
            {
                LiveMessageData<INTERACT_WORD>? intearct =
                    await LiveProvider.BIliDocument.JsonDeserializeAsync<
                        LiveMessageData<INTERACT_WORD>
                    >(message.GetRawText());
                WindowManager.TryDispatcherAction(() =>
                {
                    this.DanmakuList.Add(intearct.Data);
                });
            }
            else if (val == "DANMU_MSG")
            {
                DANMU_MSG? msg = await LiveProvider.BIliDocument.JsonDeserializeAsync<DANMU_MSG>(
                    message.GetRawText()
                );
                WindowManager.TryDispatcherAction(() =>
                {
                    this.DanmakuList.Add(msg);
                });
            }
            WindowManager.TryDispatcherAction(() =>
            {
                if (DanmakuList.Count > 100)
                    DanmakuList.Clear();
            });
        };

        _client.ServerConnectionEvent += (source, IsConnection) =>
        {
            WindowManager.TryDispatcherAction(() =>
            {
                if (IsConnection)
                {
                    TipShow.ShowMessage("服务器连接成功", Symbol.Accept);
                }
            });
        };

        _client.ServerCloseEvent += (source, message) =>
        {
            WindowManager.TryDispatcherAction(() =>
            {
                TipShow.ShowMessage("服务器已断开", Symbol.Accept);
            });
        };
        await _client.Connection();
    }

    [ObservableProperty]
    LiveRoomDetailDataModel _DataBase = new();

    [ObservableProperty]
    ObservableCollection<ILiveMessageModel> _DanmakuList = new();

    [ObservableProperty]
    ObservableCollection<GQnDesc> _QualityList = new();

    [ObservableProperty]
    GQnDesc _QualitySelectItem = new();

    [ObservableProperty]
    bool _AutoScrollToBottom = true;

    [ObservableProperty]
    LiveUrlDataModel _UrlDataModel = null;

    public async Task CloseAsync()
    {
        if (_client != null)
        {
            await _client.CloseAsync();
        }
        await this.Element.CloseAsync();
    }

    public void FindScrollViewer(DependencyObject parent)
    {
        var childCount = VisualTreeHelper.GetChildrenCount(parent);
        for (var i = 0; i < childCount; i++)
        {
            var child = VisualTreeHelper.GetChild(parent, i);
        }
    }

    public override async void _loadEd(IDashMediaPlayerElement element)
    {
        this.Element = element;
        Element.TransportQualityListChanged += Element_TransportQualityListChanged;
        var info = await LiveProvider.GetLiveRoomInfoAsync(_roomid);
        this.DataBase = info.Data;
        var result = await LiveProvider.GetLiveRoomUrlInfoAsync(_roomid);
        this.UrlDataModel = result.Data;
        if(result.Data == null) 
        {
            TipShow.ShowMessage("错误的直播信息", Symbol.Emoji);
            return;
        }
        this.QualityList = result.Data.LivePlayurlInfo.Playurl.GQnDesc.ToObservableCollection();
        await initClient();
        this.Element.QualitySelectItem = QualityList[0];

        TabViewService.UpDateProgressRing(_key, Visibility.Collapsed);
    }

    private async void Element_TransportQualityListChanged(object source, object SelectItem)
    {
        if (SelectItem == null)
            return;
        if (SelectItem is GQnDesc desc)
        {
            this.UrlDataModel = (
                await LiveProvider.GetLiveRoomUrlInfoAsync(_roomid, desc.Qn, false)
            ).Data;
            LiveCodec codec = null;
            foreach (var item in UrlDataModel.LivePlayurlInfo.Playurl.LiveStream)
            {
                if (item.ProtocolName == "http_hls")
                {
                    codec = item.Format[0].Codec[0];
                }
            }
            if (codec == null)
                return;
            string url2 = $"{codec.UrlInfo[0].Host}/{codec.BaseUrl}/{codec.UrlInfo[0].Extra}";
            this.Element.SetMediaPlayer(await MediaCreater.CreateLiveMediaSourceAsync(url2));
        }
    }

    public override void DanmakuSend(string content) { }
}
