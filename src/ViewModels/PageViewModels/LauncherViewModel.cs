using IAppContracts.ItemsViewModels;
using LanguageExt.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Windowing;
using Windows.UI.WebUI;
using WinUIEx.Messaging;

namespace ViewModels.PageViewModels;

public partial class LauncherViewModel : ObservableRecipient, IRecipient<LoginMessager>
{
    public LauncherViewModel(
        IWindowManager windowManager,
        [FromKeyedServices(NavHostingConfig.RootNav)] INavigationService navigationService,
        ILocalSetting localSetting,
        ICurrent current,
        IAccountProvider accountProvider,
        IDialogManager dialogManager,
        ITokenManager tokenManager,
        IUserControlViewModelFactory userControlViewModelFactory,
        IBiliServiceProvider biliServiceProvider,
        IThirdApiProvider thirdApiProvider
    )
    {
        WindowManager = windowManager;
        NavigationService = navigationService;
        LocalSetting = localSetting;
        Current = current;
        AccountProvider = accountProvider;
        DialogManager = dialogManager;
        TokenManager = tokenManager;
        UserControlViewModelFactory = userControlViewModelFactory;
        BiliServiceProvider = biliServiceProvider;
        ThirdApiProvider = thirdApiProvider;
        WindowManager.GetWindow().AppWindow.TitleBar.ExtendsContentIntoTitleBar = true;
        this.LauncherLoginVM = UserControlViewModelFactory.CreateLauncherLoginViewModel();
        this.IsActive = true;
    }

    public IWindowManager WindowManager { get; }
    public INavigationService NavigationService { get; }
    public ILocalSetting LocalSetting { get; }
    public ICurrent Current { get; }
    public IAccountProvider AccountProvider { get; }
    public IDialogManager DialogManager { get; }
    public ITokenManager TokenManager { get; }
    public IUserControlViewModelFactory UserControlViewModelFactory { get; }
    public IBiliServiceProvider BiliServiceProvider { get; }
    public IThirdApiProvider ThirdApiProvider { get; }
    public IAppProtocolSetupService AppProtocolSetup { get; }
    public bool AutoLoginCheck { get; private set; }

    public CancellationTokenSource TokenSource { get; private set; } = new();

    [ObservableProperty]
    string _WallpaperImage;

    [ObservableProperty]
    string _TipText;

    [ObservableProperty]
    ObservableCollection<ITokenItemViewModel> _InfoList = new();

    [ObservableProperty]
    ITokenItemViewModel _TokenSelectItem;

    [ObservableProperty]
    ILauncherLoginViewModel _LauncherLoginVM;

    partial void OnTokenSelectItemChanged(ITokenItemViewModel value) { }

    [RelayCommand]
    async Task GetLogin()
    {
        this.AutoLoginCheck = (
            (JsonElement)await LocalSetting.ReadConfig(SettingName.AutoLoginCheck)
        ).GetBoolean();
        if (WindowManager.GetAppWindow().Presenter is OverlappedPresenter opr)
        {
            //这里关闭最大化和最小化按钮
            opr.IsMaximizable = false;
            opr.IsMinimizable = false;
        }
        TipText = "检查登录……";
        //YurikoWallpaper
        //this.WallpaperImage = (await ThirdApiProvider.GetYurikoWallpaper()).Link;
        var wallpaper = await BiliServiceProvider.GetAppBrandListAsync();
        Random dom = new();
        var domvalue= dom.Next(0, wallpaper.Count-1);
        this.WallpaperImage = wallpaper.AllWallpaper[domvalue].Thumb;
        IDictionary<AccountToken, string>? tokenlist = await TokenManager.GetTokenList();
        if (tokenlist.Count == 0)
        {
            IsVisibility = false;
            return;
        }

        IsVisibility = true;
        foreach (var item in tokenlist)
        {
            InfoList.Add(
                UserControlViewModelFactory.CreateTokenItemViewModel(item.Key, item.Value)
            );
        }
        this.TokenSelectItem = InfoList[0];
        if (AutoLoginCheck)
        {
            var result = (await LocalSetting.ReadConfig(App.Models.SettingName.Token));
            if (result != null)
                Current.TokenName = Convert.ToInt64(result.ToString());
            NavigationService.NavigationTo(typeof(ShellViewModel).FullName);
        }
    }

    [ObservableProperty]
    bool _IsVisibility;

    [RelayCommand]
    void GoAppMain()
    {
        this.Current.TokenName = this.TokenSelectItem.MyData.Mid;
        NavigationService.NavigationTo(typeof(ShellViewModel).FullName);
    }

    //这里用来接收登录返回的信息
    public void Receive(LoginMessager message)
    {
        this.Current.TokenName = message.token.Mid;
        NavigationService.NavigationTo(typeof(ShellViewModel).FullName);
    }
}
