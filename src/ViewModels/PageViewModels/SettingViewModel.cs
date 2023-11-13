namespace ViewModels.PageViewModels;

public sealed partial class SettingViewModel : PageViewModelBase, IAppService
{
    public SettingViewModel(
        IThemeService<BiliApplication> themeService,
        ILocalSetting localSetting,
        IAccountProvider accountProvider,
        IWindowManager windowManager,
        IRootNavigationMethod rootNavigationMethod
    )
        : base(rootNavigationMethod)
    {
        IsActive = true;
        this.AccountProvider = accountProvider;
        WindowManager = windowManager;
        ThemeService = themeService;
        LocalSetting = localSetting;
    }

    /// <summary>
    /// 标识读取参数
    /// </summary>
    public bool IsFirstRead = true;

    [RelayCommand]
    async Task Loaded()
    {
        await InitData();
        this.IsFirstRead = false;
    }

    private async Task InitData()
    {
        var lifeconfig = (await LocalSetting.ReadConfig(SettingName.AppExitMode)).ToString();
        string themeconfig = (await LocalSetting.ReadConfig(SettingName.Theme)).ToString()!;
        string appdrop = (await LocalSetting.ReadConfig(SettingName.AppBackup)).ToString()!;
        this.SearchAddItem = Convert.ToInt32(
            (await LocalSetting.ReadConfig(SettingName.SearchItems)).ToString()
        );
        if (lifeconfig == "Exit")
            this.LifeIndex = 0;
        else
            this.LifeIndex = 1;

        if (themeconfig == "Dark")
            this.ThemeIndex = 1;
        else if (themeconfig == "Light")
            this.ThemeIndex = 0;
        else if (themeconfig == "Default")
            this.ThemeIndex = 2;

        if (appdrop == "Mica")
            this.BackdropIndex = 0;
        else if (appdrop == "Acrylic")
            this.BackdropIndex = 1;
        else if (appdrop == "MicaAlt")
            this.BackdropIndex = 2;
        else
            this.BackdropIndex = 3;
    }

    [RelayCommand]
    void ChangedTheme(string theme)
    {
        switch (theme)
        {
            case "Light":
                ThemeService.SetThemeAsync(Microsoft.UI.Xaml.ElementTheme.Light);
                break;
            case "Dark":
                ThemeService.SetThemeAsync(Microsoft.UI.Xaml.ElementTheme.Dark);
                break;
            case "System Default":
                ThemeService.SetThemeAsync(Microsoft.UI.Xaml.ElementTheme.Default);
                break;
        }
    }

    [RelayCommand]
    async Task ChangedBackup(string backup)
    {
        WindowManager.SetWindowBackup(backup);
        await LocalSetting.SaveConfig(SettingName.AppBackup, backup);
    }

    [RelayCommand]
    async Task ChangedLife(ComboBoxItem mode)
    {
        await LocalSetting.SaveConfig(SettingName.AppExitMode, mode.Tag);
    }

    public async Task ChangedSearchItem(double value)
    {
        await LocalSetting.SaveConfig(SettingName.SearchItems, value);
    }

    [ObservableProperty]
    int _LifeIndex;

    [ObservableProperty]
    int _BackdropIndex;

    [ObservableProperty]
    int _ThemeIndex;

    [ObservableProperty]
    int _SearchAddItem;


    public string ServiceID { get; set; } = "SettingViewModel";
    public IAccountProvider AccountProvider { get; }
    public IWindowManager WindowManager { get; }
    public IThemeService<BiliApplication> ThemeService { get; }
    public ILocalSetting LocalSetting { get; }
}
