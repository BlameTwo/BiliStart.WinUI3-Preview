/*
 2023.7.9
AppActivationService功能：
主要做启动前的配置工作，例如Token的获取，Theme主题切换等等，


2023.7.28
加入了启动模式LauncerMode，现分为插件管理器模式和应用模式启动
 */
using App.Models.Enum;
using Bilibili.Polymer.App.Search.V1;
using Microsoft.Windows.AppLifecycle;
using Microsoft.Windows.AppNotifications;
using Serilog;
using Windows.ApplicationModel.Activation;

namespace AppContractService.Services;

public sealed class AppActivationService<T> : IAppActivationService<T>
    where T : BiliApplication, IAppService
{
    private SetupEnum _setupType;

    public AppActivationService(
        IThemeService<T> themeService,
        [FromKeyedServices(NavHostingConfig.RootNav)] INavigationService navigationService,
        ILogger logger,
        IAppProtocolSetupService appProtocolSetup
    )
    {
        this.ThemeService = themeService;
        NavigationService = navigationService;
        Logger = logger;
        AppProtocolSetup = appProtocolSetup;
    }

    public string ServiceID { get; set; } = "AppActivationService";
    public IThemeService<T> ThemeService { get; }
    public INavigationService NavigationService { get; }
    public ILogger Logger { get; }
    public IAppProtocolSetupService AppProtocolSetup { get; }

    public async Task ActivationAsync(T app, SetupEnum type)
    {
        this._setupType = type;
        await StartupApplication(app);
    }

    async Task StartupApplication(T app)
    {

        Logger.LogWrite<AppActivationService<BiliApplication>>("容器注入完毕窗体开始加载");
        ILocalSetting Setting = AppService.GetService<ILocalSetting>();
        Dictionary<string, object> values = new();
        values.Add(SettingName.Theme, "Default");
        values.Add(SettingName.AppBackup, "Mica");
        values.Add(SettingName.AppExitMode, "Exit");
        values.Add(SettingName.AutoLoginCheck, false);
        values.Add(SettingName.SearchItems, 30);
        await Setting.InitSetting(values);
        Page page = AppService.GetService<RootPage>();
        app.MainWindow.Content = null;
        app.MainWindow.Content = page;
        app.MainWindow.Activate();
        NavigationService.NavigationTo(typeof(LauncherViewModel).FullName);
        await InitAsync(app);
        var themestr = (await Setting.ReadConfig(SettingName.AppBackup)).ToString();
        if (themestr is string str)
        {
            switch (str)
            {
                case "Mica":
                    app.MainWindow.SystemBackdrop = new MicaBackdrop()
                    {
                        Kind = Microsoft.UI.Composition.SystemBackdrops.MicaKind.Base
                    };
                    break;
                case "MicaAlt":
                    app.MainWindow.SystemBackdrop = new MicaBackdrop()
                    {
                        Kind = Microsoft.UI.Composition.SystemBackdrops.MicaKind.BaseAlt
                    };
                    break;
                case "Acrylic":
                    app.MainWindow.SystemBackdrop = new DesktopAcrylicBackdrop();
                    break;
            }
        }
        await StartupAsync();
    }


    /// <summary>
    /// 修改主题等效果的启动过程
    /// </summary>
    /// <returns></returns>
    private async Task StartupAsync()
    {
        await ThemeService.SetRequestedThemeAsync();
        Logger.LogWrite<AppActivationService<BiliApplication>>("前置启动完毕");
    }


    /// <summary>
    /// 初始化服务以及最基础的东西
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    private async Task InitAsync(T app)
    {
        var httpclient = AppService.GetService<IHttpClientProvider>();
        httpclient.InitClient();
        await ThemeService.InitializeAsync(app);
    }

    public void ActivationProtocolSetup(AppActivationArguments args)
    {
        if (args.Kind == ExtendedActivationKind.Protocol)
        {
            AppProtocolSetup.SaveUri((args.Data as ProtocolActivatedEventArgs).Uri);
        }
    }

    public SetupEnum GetSetupType() => _setupType;
}
