using Serilog;

namespace ViewModels.Bases;

/// <summary>
/// 播放页面ViewModel基类
/// </summary>
public abstract partial class PlayerViewModelBases : RootViewModelBases
{
    public PlayerViewModelBases(
        IRootNavigationMethod rootNavigationMethod,
        INavigationService navigationService,
        IMediaCreater mediaCreater,
        IDanmakuProvider danmakuProvider,
        IWindowManager windowManager,
        ICurrent current,
        ILogger logger,
        ITipShow tipShow
    )
        : base(rootNavigationMethod, navigationService)
    {
        MediaCreater = mediaCreater;
        DanmakuProvider = danmakuProvider;
        WindowManager = windowManager;
        Current = current;
        Logger = logger;
        TipShow = tipShow;
    }

    /// <summary>
    /// 加载方法
    /// </summary>
    /// <param name="element"></param>
    public abstract void _loadEd(IDashMediaPlayerElement element);

    public abstract void DanmakuSend(string content);

    [ObservableProperty]
    ObservableCollection<DanmakuSession> _DanmakuList = new();

    [RelayCommand]
    void Loaded(IDashMediaPlayerElement element)
    {
        _loadEd(element);
        Element.DanmakuSend += Element_DanmakuSend;
        Logger.LogWrite<PlayerViewModelBases>("媒体控件加载完成");
    }

    private void Element_DanmakuSend(DanmakuType type, string content) => DanmakuSend(content);

    /// <summary>
    /// 媒体播放器
    /// </summary>
    public IDashMediaPlayerElement Element { get; set; }

    TimeSpan timeSinceLastRefresh = TimeSpan.Zero;

    /// <summary>
    /// 检查是否刷新弹幕
    /// </summary>
    /// <param name="time">当前进度</param>
    /// <param name="pagesize">out传值，刷新的页数</param>
    /// <returns></returns>
    internal bool ShouldRefreshData(TimeSpan time, out int pagesize)
    {
        // 判断上次刷新时间是否为默认值（第一次刷新）
        if (timeSinceLastRefresh == TimeSpan.Zero)
        {
            timeSinceLastRefresh = time;
            pagesize = 1;
            return true;
        }

        // 计算时间差
        TimeSpan timeDifference = time - timeSinceLastRefresh;

        // 判断是否满足6分钟的条件或者用户进行了回退操作
        if (timeDifference.TotalMinutes >= 6 || time < timeSinceLastRefresh)
        {
            timeSinceLastRefresh = time;
            pagesize = (int)Math.Ceiling(time.TotalMinutes / 6);
            return true;
        }
        pagesize = -1;
        return false;
    }

    internal async Task RefershDanmaku(long aid, long cid, TimeSpan time, int danmakupage = -1)
    {
        if (ShouldRefreshData(time, out danmakupage))
        {
            this.DanmakuList = (
                await DanmakuProvider.GetVideoDanmakuAsync(aid, cid, danmakupage)
            ).ToObservableCollection();
            Logger.LogWrite<PlayerViewModelBases>("刷新当前弹幕池");
        }
        var danmakulist = DanmakuList.Where(
            p =>
                p.Progress.TotalSeconds > time.TotalSeconds
                && p.Progress.TotalSeconds - time.TotalSeconds < 0.5
        );
        foreach (var item in danmakulist.ToList())
        {
            if (item.Mode == DanmakuType.Top)
            {
                this.DanmakuControl.AddTopDanmaku(item);
            }
            else if (item.Mode == DanmakuType.Scrool)
            {
                this.DanmakuControl.AddScrollDanmaku(item);
            }
            else if (item.Mode == DanmakuType.Bottom)
            {
                this.DanmakuControl.AddBottomDanmaku(item);
            }
            DanmakuList.Remove(item);
        }
    }

    /// <summary>
    /// 弹幕控件
    /// </summary>
    public IDanmakuControl DanmakuControl { get; set; }
    public IMediaCreater MediaCreater { get; }
    public IDanmakuProvider DanmakuProvider { get; }
    public IWindowManager WindowManager { get; }
    public ICurrent Current { get; }
    public ILogger Logger { get; }
    public ITipShow TipShow { get; }
}
