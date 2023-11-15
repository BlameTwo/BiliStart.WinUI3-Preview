using AppContractService.Services.SegmentedNavigationServices;
using AppServices;
using IAppContracts.ItemsViewModels.Dynamics;
using IAppContracts.IUserControlsViewModels.LiveControlsViewModels;
using IAppContracts.SegmentedContract;
using IAppContracts.TabViewContract;
using IAppInterface.Services;
using ViewModels;
using ViewModels.AppTabViewModels;
using ViewModels.ContentPopupViewModels;
using ViewModels.ItemViewModels.Dynamics;
using ViewModels.ToolViewModels;
using Views.AccountHistoryPages;
using Views.ContentPopups;
using Views.TabViews;

namespace AppContractService;

/// <summary>
/// 注册容器的分部方法
/// </summary>
static partial class AppService
{
    /// <summary>
    /// 注册页面
    /// </summary>
    /// <param name="hostBuilder">容器接口</param>
    /// <returns>返回加入注册后的容器接口</returns>
    public static IHostBuilder RegisterPage(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices(
            (contenxt, service) =>
            {
                service.AddTransient<RootPage>();
                service.AddTransient<RootViewModel>();
                service.AddTransient<ShellPage>();
                service.AddTransient<ShellViewModel>();
                service.AddTransient<HomePage>();
                service.AddTransient<HomeViewModel>();
                service.AddTransient<SettingPage>();
                service.AddTransient<SettingViewModel>();
                service.AddTransient<TotalPage>();
                service.AddTransient<TotalViewModel>();
                service.AddTransient<RankPage>();
                service.AddTransient<RankViewModel>();
                service.AddTransient<HotPage>();
                service.AddTransient<HotViewModel>();
                service.AddTransient<MusicRankPage>();
                service.AddTransient<MusicRankViewModel>();
                service.AddTransient<SearchRankPage>();
                service.AddTransient<SearchRankViewModel>();
                service.AddTransient<DownloadPage>();
                service.AddTransient<DownloadViewModel>();
                service.AddTransient<MoviePage>();
                service.AddTransient<MovieViewModel>();
                service.AddTransient<PgcPage>();
                service.AddTransient<PgcViewModel>();
                service.AddTransient<HotHistoryPage>();
                service.AddTransient<HotHistoryViewModel>();

                service.AddTransient<LivePage>();
                service.AddTransient<LiveViewModel>();

                #region 加载UI组件的一个页面，不属于View项目中
                service.AddTransient<LauncherPage>();
                service.AddTransient<LauncherViewModel>();
                #endregion

                service.AddTransient<ViewTestPage>();
                service.AddTransient<ViewTestViewModel>();

                service.AddTransient<AboutPage>();
                service.AddTransient<AboutViewModel>();

                service.AddTransient<VideoHistoryPage>();
                service.AddTransient<AccountHistoryVideoViewModel>();

                service.AddTransient<LiveHistoryPage>();
                service.AddTransient<LiveHistoryViewModel>();

                #region 跳转
                service.AddTransient<MainControlView>();
                service.AddTransient<AccountSpaceControlView>();
                service.AddTransient<ViewModels.AppTabViewModels.AccountSpaceViewModel>();
                service.AddTransient<PlayerControlView>();
                service.AddTransient<ViewModels.AppTabViewModels.PlayerViewModel>();
                service.AddTransient<ViewModels.AppTabViewModels.MainViewModel>();

                service.AddTransient<PgcPlayerControlView>();
                service.AddTransient<ViewModels.AppTabViewModels.PgcPlayerViewModel>();

                service.AddTransient<SearchControlView>();
                service.AddTransient<ViewModels.AppTabViewModels.SearchViewModel>();

                service.AddTransient<AccountHistoryControlView>();
                service.AddTransient<ViewModels.AppTabViewModels.AccountHistoryViewModel>();

                service.AddTransient<LiveTagControlView>();
                service.AddTransient<ViewModels.AppTabViewModels.LiveTagViewModel>();

                service.AddTransient<LivePlayerControlView>();
                service.AddTransient<ViewModels.AppTabViewModels.LivePlayerViewModel>();

                service.AddTransient<
                    ILiveTagItemViewModel,
                    ViewModels.UserControlViewModels.LiveTagItemViewModel
                >();

                service.AddTransient<AccountDynamicControlView>();
                service.AddTransient<AccountDynamicViewModel>();
                #endregion
            }
        );
        return hostBuilder;
    }

    /// <summary>
    /// 注册对话框
    /// </summary>
    /// <param name="hostBuilder">容器接口</param>
    /// <returns>返回加入注册后的容器接口</returns>
    public static IHostBuilder RegisterDialog(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices(
            (context, service) =>
            {
                service.AddTransient<LoginDialog>();
                service.AddTransient<LoginViewModel>();
                service.AddTransient<TokenDialog>();
                service.AddTransient<TokenViewModel>();
                service.AddTransient<AddDownloadDialog>();
                service.AddTransient<AddDownloadViewModel>();
                service.AddTransient<DownloadItemDialog>();
                service.AddTransient<DownloadItemViewModel>();
            }
        );
        return hostBuilder;
    }

    /// <summary>
    /// 注册网络服务
    /// </summary>
    /// <param name="hostBuilder">容器接口</param>
    /// <returns>返回加入注册后的容器接口</returns>
    public static IHostBuilder RegisterNetwork(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices(
            (contenxt, service) =>
            {
                //请求头组装
                service.AddSingleton<IRequestMessage, RequestMessage>();
                //Http验证拓展
                service.AddSingleton<IHttpExtensions, HttpExtensions>();
                //登录控制器
                service.AddSingleton<ILoginProvider, LoginProvider>();
                //搜索服务控制器
                service.AddTransient<ISearchProvider, SearchProvider>();
                //普通视频控制器
                service.AddSingleton<IVideoProvider, VideoProvider>();
                //账户控制器
                service.AddSingleton<IAccountProvider, AccountProvider>();
                //账户消息控制器
                service.AddSingleton<IMessagerProvider, MessagerProvider>();
                //流媒体控制器
                service.AddSingleton<IBangumiProvider, BangumiProvider>();
                //Http控制器
                service.AddSingleton<IHttpClientProvider, HttpClientProvider>();
                //分区控制器
                service.AddSingleton<ITidProvider, TidProvider>();
                //弹幕控制器
                service.AddSingleton<IDanmakuProvider, DanmakuProvider>();
                //B站的订阅服务控制器
                service.AddSingleton<IBiliServiceProvider, BiliServiceProvider>();
                //号码转换控制器
                service.AddSingleton<IAvToBvConverter, AvToBvConverter>();
                //回复控制器
                service.AddSingleton<IReplyProvider, ReplyProvider>();
                //当前Token所需的验证变量
                service.AddSingleton<ICurrent, Current>();
                //二次Token获取接口
                service.AddSingleton<IAccountTokenSet, AccountTokenSet>();
                //Token管理
                service.AddSingleton<ITokenManager, TokenManager>();
                //B站数据序列化转换
                service.AddSingleton<IBIliDocument, BIliDocument>();
                //非BiliBili的API
                service.AddSingleton<IThirdApiProvider, ThirdApiProvider>();
                //直播相关控制器
                service.AddSingleton<ILiveProvider, LiveProvider>();
                //主页TabView相关
                service.AddSingleton<ITabViewService, TabViewService>();
                service.AddSingleton<ITabUserControlService, TabUserControlService>();
                service.AddSingleton<ITabCreateMethodService, TabCreateMethodService>();

                #region 工厂接口
                //用户控件 工厂
                service.AddSingleton<IUserControlViewModelFactory, UserControlViewModelFactory>();
                //社区信息 工厂
                service.AddSingleton<ICommunityFactory, CommunityFactory>();
                //流媒体数据 工厂
                service.AddSingleton<IPgcDataViewModelFactory, PgcDataViewModelFactory>();
                //B站订阅服务的数据转换 工厂
                service.AddSingleton<IServiceDataFactory, ServiceDataFactory>();
                //视频子项数据转换 工厂
                service.AddSingleton<IVideoItemFactory, VideoItemFactory>();
                //直播子项数据转换 工厂
                service.AddSingleton<ILiveItemFactory, LiveItemFactory>();
                //用户子项数据转换 工厂
                service.AddSingleton<IAccountFactory, AccountFactory>();
                #endregion
            }
        );
        return hostBuilder;
    }

    /// <summary>
    /// 注册拓展
    /// </summary>
    /// <param name="hostBuilder">容器接口</param>
    /// <returns>返回加入注册后的容器接口</returns>
    public static IHostBuilder RegisterExtensions(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices(
            (context, service) =>
            {
                service.AddSingleton<ILocalSetting, LocalSetting>();
                service.AddSingleton<
                    IThemeService<BiliApplication>,
                    ThemeService<BiliApplication>
                >();
                service.AddSingleton<
                    IAppActivationService<BiliApplication>,
                    AppActivationService<BiliApplication>
                >();
                service.AddSingleton<IWindowManager, Services.WindowManager>();
                service.AddSingleton<IDialogManager, DialogManager>();
                service.AddSingleton<IPageService, PageService>();
                service.AddSingleton<ITipShow, TipShow>();
                service.AddSingleton<IAppProtocolSetupService, AppProtocolSetupService>();
                service.AddSingleton<IAppNotificationService, AppNotificationService>();

                #region 特殊导航注入




                #endregion
                service.AddSingleton<IMediaCreater, MediaCreater>();
                service.AddSingleton<IRootNavigationMethod, RootNavigationMethod>();
                service.AddSingleton<ISearchDataTemplateManager, SearchDataTemplateManager>();
                service.AddSingleton<IDownloadService, DownloadService>();

                service.AddSingleton<IBiliStartNotifyViewModel, BiliStartNotifyViewModel>();
                service.AddTransient<ILauncherLoginViewModel, LoginViewModel>();
                service.AddSingleton<IFactoryBase, FactoryBase>();
                service.AddSingleton<IAppResources<BiliApplication>, AppResource>();

                service.AddSingleton<IFFmpegFormatService, FFmpegFormatService>();

                #region 文件模块
                service.AddSingleton<
                    IFileEncryptionProviderService,
                    FileEncryptionProviderService
                >();
                #endregion

                #region 转换器
                service.AddSingleton<IVideoViewModelConverter, VideoViewModelConverter>();
                service.AddSingleton<IPlayerViewModelConverter, PlayerViewModelConverter>();
                service.AddSingleton<IBiliDataViewModelConverter, BiliDataViewModelConverter>();
                service.AddSingleton<IAccountHistoryConverter, AccountHistoryConverter>();
                service.AddSingleton<IAccountDynamicConverter, AccountDynamicConverter>();
                #endregion
            }
        );
        return hostBuilder;
    }

    /// <summary>
    /// 注册应用导航
    /// </summary>
    /// <param name="hostBuilder"></param>
    /// <returns></returns>
    public static IHostBuilder RegisterAppNavigation(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices(
            (context, service) =>
            {
                service.AddKeyedSingleton<INavigationViewService, MainNavigationViewService>(
                    NavHostingConfig.MainNavView
                );
                service.AddKeyedSingleton<INavigationViewService, TotalNavigationViewService>(
                    NavHostingConfig.TotalNavView
                );
                service.AddKeyedSingleton<INavigationViewService, PgcNavigationViewService>(
                    NavHostingConfig.PgcNavView
                );

                service.AddKeyedSingleton<INavigationService, RootNavigationService>(
                    NavHostingConfig.RootNav
                );
                service.AddKeyedSingleton<INavigationService, MainNavigationService>(
                    NavHostingConfig.MainNav
                );
                service.AddKeyedSingleton<INavigationService, TotalNavigationService>(
                    NavHostingConfig.TotalNav
                );
                service.AddKeyedSingleton<INavigationService, PgcNavigationService>(
                    NavHostingConfig.PgcNav
                );

                #region 使用Segmented控件作为导航的注入
                service.AddKeyedSingleton<INavigationService, AccountHistoryNavigationService>(
                    NavHostingConfig.AccountHistoryNav
                );

                service.AddKeyedSingleton<
                    ISegmentedNavigationView,
                    AccountHistorySegmentedViewService
                >(NavHostingConfig.AccountHistoryView);
                #endregion
            }
        );
        return hostBuilder;
    }

    /// <summary>
    /// 注册Item的视图模型
    /// </summary>
    /// <param name="hostBuilder">容器接口</param>
    /// <returns>返回加入注册后的容器接口</returns>
    public static IHostBuilder RegisterItemVM(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices(
            (context, service) =>
            {
                service.AddTransient<IPlayerRelatesViewModel, PlayerRelatesViewModel>();
                service.AddTransient<IPlayerReplysCommonsViewModel, PlayerReplysCommonsViewModel>();
                service.AddTransient<IPlayerReplysViewModel, PlayerReplysViewModel>();
                service.AddTransient<IPlayerPagesModel, PlayerPagesModel>();

                service.AddTransient<IReplyMainItemViewModel, ReplyMainItemViewModel>();
                service.AddTransient<IReplyCommentItemViewModel, ReplyCommentItemViewModel>();
                service.AddTransient<IPgcSessionViewModel, PgcSessionViewModel>();
                service.AddTransient<IBIliChatViewModel, BiliChatViewModel>();
                service.AddTransient<IHotHistoryItemViewModel, HotHistoryItemViewModel>();
                service.AddTransient<
                    ILiveTagViewModel,
                    ViewModels.UserControlViewModels.LiveTagViewModel
                >();
                service.AddTransient<IDynamicItemViewModel, DynamicItemViewModel>();
                service.AddTransient<IDynamicForwardItemViewModel, DynamicForwardItemViewModel>();

                #region 界面上的Item

                service.AddTransient<IVideoHotItemViewModel, VideoHotItemViewModel>();
                service.AddTransient<IVideoRankItemViewModel, VideoRankItemViewModel>();
                service.AddTransient<ISearchItemViewModel, SearchItemViewModel>();
                service.AddTransient<IVideoHomeItemViewModel, VideoHomeItemViewModel>();
                #endregion

                #region PgcItem
                service.AddTransient<IPgcPagesViewModel, PgcPagesViewModel>();
                service.AddTransient<IPgcItemViewModel, PgcItemViewModel>();
                #endregion


                #region LiveItem
                service.AddTransient<ILivePageItemViewModel, LivePageItemViewModel>();
                service.AddTransient<ILiveTagAreaItemViewModel, LiveTagAreaItemViewModel>();
                service.AddTransient<ILiveTagAreaIndexViewModel, LiveTagAreaIndexViewModel>();
                #endregion

                service.AddTransient<IAccountVideoHistoryItemViewModel, AccountVideoHistoryItemViewModel>();
                service.AddTransient<IAccountHistoryLiveItemViewModel, AccountHistoryLiveItemViewModel>();

                service.AddTransient<ITokenItemViewModel, TokenItemViewModel>();
            }
        );
        return hostBuilder;
    }

    /// <summary>
    /// 注册日志系统
    /// </summary>
    /// <param name="hostBuilder">容器接口</param>
    /// <returns>返回加入注册后的容器接口</returns>
    public static IHostBuilder RegisterLog(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices(
            (context, service) =>
            {
                //创建日志系统，按天记录日志，日志保存时间为2天，最大日志文件为31个，一个文件的最大byte为52428800
                FilePath.PluginPath.CheckFolder();
                var log = new LoggerConfiguration().MinimumLevel
                    .Verbose()
                    .WriteTo.File(
                        $"{App.Models.FilePath.LogPath}/app.log",
                        rollingInterval: RollingInterval.Day,
                        retainedFileCountLimit: 31,
                        retainedFileTimeLimit: TimeSpan.FromDays(2),
                        rollOnFileSizeLimit: true,
                        fileSizeLimitBytes: 52428800
                    )
                    .CreateLogger();
                service.AddSingleton<ILogger>(log);
            }
        );
        return hostBuilder;
    }

    /// <summary>
    /// 注册弹出框
    /// </summary>
    /// <param name="hostBuilder"></param>
    /// <returns></returns>
    public static IHostBuilder RegisterPopup(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices(
            (context, service) =>
            {
                service.AddTransient<ImagePopup>();
                service.AddTransient<ImagePopupViewModels>();
                service.AddTransient<IPopupManagerService, PopupManagerService>();
            }
        );
        return hostBuilder;
    }

    /// <summary>
    /// 注册工具应用
    /// </summary>
    /// <param name="hostBuilder"></param>
    /// <returns></returns>
    public static IHostBuilder RegisterToolApp(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices((context, service) =>
        {
            service.AddTransient<ToolRootPage>();
            service.AddTransient<ToolRootViewModel>();
        });
        return hostBuilder;
    }
}
