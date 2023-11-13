using IAppContracts.TabViewContract;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Windowing;
using ViewModels.ItemViewModels;

namespace ViewModels.PageViewModels;

public partial class ShellViewModel
    : ObservableRecipient,
        IAppService,
        IRecipient<LoginMessager>,
        IRecipient<ChangedNavigationContentImage>,
        IRecipient<TokenSwitchMessager>,
        IRecipient<WindowMaxMesssager>
{
    public ShellViewModel(
        IAccountProvider accountProvider,
        ICurrent current,
        ISearchProvider searchProvider,
        IMessagerProvider messagerProvider,
        IWindowManager windowManager,
        ITipShow tipShow,
        ITokenManager tokenManager,
        ILocalSetting localSetting,
        IDialogManager dialogManager,
        IRootNavigationMethod rootNavigationMethod,
        [FromKeyedServices(NavHostingConfig.MainNav)] INavigationService navigationService,
        [FromKeyedServices(NavHostingConfig.MainNavView)]
            INavigationViewService navigationViewService,
        [FromKeyedServices(NavHostingConfig.RootNav)] INavigationService rootNavigationService,
        IUserControlViewModelFactory userControlViewModelFactory,
        IAppProtocolSetupService appProtocolSetup,
        ITabViewService tabViewService,
        ITabCreateMethodService tabCreateMethodService
    )
    {
        IsActive = true;
        this.NavigationService = navigationService;
        LocalSetting = localSetting;
        DialogManager = dialogManager;
        RootNavigationMethod = rootNavigationMethod;
        this.NavigationViewService = navigationViewService;
        RootNavigationService = rootNavigationService;
        UserControlViewModelFactory = userControlViewModelFactory;
        AppProtocolSetup = appProtocolSetup;
        TabViewService = tabViewService;
        TabCreateMethodService = tabCreateMethodService;
        this.WindowManager = windowManager;
        this.TipShow = tipShow;
        TokenManager = tokenManager;
        AccountProvider = accountProvider;
        Current = current;
        SearchProvider = searchProvider;
        MessagerProvider = messagerProvider;
    }

    [RelayCommand]
    void ShowAddLogin()
    {
        DialogManager.ShowLogin();
    }

    [RelayCommand]
    async Task Loaded()
    {
        this.Islogin = await Current.IsLoginAsync();
        if (await Current.IsLoginAsync())
        {
            var result = (await AccountProvider.GetAccountTopNavigationAsync()).Data;
            this.Userdata = result;
        }
        var ipresult = await this.AccountProvider.GetAccountIpAsync();
        this.Ip = ipresult.Data;
        NavigationService.NavigationTo(typeof(HomeViewModel).FullName);
        WindowManager.GetAppWindow().TitleBar.IconShowOptions = Microsoft
            .UI
            .Windowing
            .IconShowOptions
            .ShowIconAndSystemMenu;
        this.ChatViewModel = UserControlViewModelFactory.CreateBiliChatViewModel();
        AppProtocolSetup.Invoke();

        this.TabViewService.GoToView(
            new(
                typeof(ViewModels.AppTabViewModels.MainViewModel).FullName,
                "首页",
                false,
                "\uE10F",
                typeof(ViewModels.AppTabViewModels.MainViewModel).FullName
            )
        );

        if (WindowManager.GetAppWindow().Presenter is OverlappedPresenter opr)
        {
            //这里关闭最大化和最小化按钮
            opr.IsMaximizable = true;
            opr.IsMinimizable = true;
        }
    }


    [RelayCommand]
    void GoDynamic()
    {
        TabCreateMethodService.GoMyDynamic();
    }

    [ObservableProperty]
    IpModel _Ip;

    [ObservableProperty]
    SearchDefaultWorld _DefaultWorld;

    [ObservableProperty]
    IBIliChatViewModel _ChatViewModel;

    [ObservableProperty]
    Visibility _TabVisibility = Visibility.Visible;

    [RelayCommand]
    void GoSearch(string keyword)
    {
        string _key = "";
        if (keyword == null || keyword == "")
            _key = this.DefaultWorld.KeyWorld;
        else
            _key = keyword;
        TabCreateMethodService.GoNavigationSearch(_key);
    }

    [RelayCommand]
    async Task GoAccountSpace()
    {
        TabCreateMethodService.GoAccountSpace((await TokenManager.GetToken(Current.TokenName)).Mid);
    }

    [RelayCommand]
    void GoAccountHistory()
    {
        TabCreateMethodService.GoAccountHistory();
    }

    async void RefreshData()
    {
        this.Userdata = (await AccountProvider.GetAccountTopNavigationAsync()).Data;
        this.Message = (await MessagerProvider.GetAccountMessageAsync()).Data;
        Messagecount += Message.sys_msg;
    }

    [RelayCommand]
    async void ShowLoginDialog()
    {
        if (!await Current.IsLoginAsync())
            DialogManager.ShowLogin();
        else
        {
            RefreshData();
        }
    }

    [RelayCommand]
    async void ShowTokenDialog()
    {
        DialogManager.ShowToken();
    }

    [ObservableProperty]
    int _Messagecount = 0;

    [ObservableProperty]
    AccountMessage _message = new();

    [ObservableProperty]
    MyData _Userdata =
        new()
        {
            Face_Image = "https://i0.hdslb.com/bfs/face/member/noface.jpg@240w_240h_1c_1s.webp",
            Name = "请登录"
        };

    [ObservableProperty]
    string _logintext = "立即登录";

    [ObservableProperty]
    object? _SelectItem;

    [ObservableProperty]
    bool _islogin = false;

    [ObservableProperty]
    BitmapImage _imagesrc;

    [ObservableProperty]
    double _backOpacity;

    partial void OnIsloginChanged(bool value)
    {
        if (value)
            this.Logintext = "退出登录";
        else
            this.Logintext = "立即登录";
    }

    bool IsLoginAsync() => this.Islogin;

    public async void Receive(LoginMessager message)
    {
        TipShow.ShowMessage(
            $"登录成功！,欢迎:{message.token.Mid}",
            Microsoft.UI.Xaml.Controls.Symbol.GoToToday
        );
        await LocalSetting.SaveConfig(App.Models.SettingName.Token, message.token.Mid);
        if (await Current.IsLoginAsync() is bool val && val)
        {
            RefreshData();
            this.Islogin = val;
        }
    }

    int oldimagesrc = -1;
    double oldimageopacity = 0.0;

    public void Receive(ChangedNavigationContentImage message)
    {
        if (message.isenable)
        {
            if (oldimagesrc != message.imagename)
            {
                this.oldimagesrc = message.imagename;
                this.Imagesrc = new BitmapImage(
                    (new Uri(@$"ms-appx://Views/ViewResource/{message.imagename}.jpg"))
                );
            }
            if (oldimageopacity != message.opacity)
            {
                this.BackOpacity = message.opacity;
                this.oldimageopacity = message.opacity;
            }
        }
        else
        {
            this.BackOpacity = 0;
            this.Imagesrc = null;
        }
    }

    public void Receive(TokenSwitchMessager message)
    {
        RefreshData();
        if (message.token == null)
            TipShow.ShowMessage("未登录", Microsoft.UI.Xaml.Controls.Symbol.Delete);
    }

    public void Receive(WindowMaxMesssager message)
    {
        if (message.IsMax)
        {
            this.TabVisibility = Visibility.Collapsed;
        }
        else
        {
            this.TabVisibility = Visibility.Visible;
        }
    }

    public IWindowManager WindowManager { get; }
    public ITipShow TipShow { get; }
    public ITokenManager TokenManager { get; }
    public INavigationService NavigationService { get; }
    public ILocalSetting LocalSetting { get; }
    public IDialogManager DialogManager { get; }
    public IRootNavigationMethod RootNavigationMethod { get; }
    public INavigationViewService NavigationViewService { get; }
    public INavigationService RootNavigationService { get; }
    public IUserControlViewModelFactory UserControlViewModelFactory { get; }
    public IAppProtocolSetupService AppProtocolSetup { get; }
    public ITabViewService TabViewService { get; }
    public ITabCreateMethodService TabCreateMethodService { get; }
    public string ServiceID { get; set; } = "MainVM";
    public IAccountProvider AccountProvider { get; }
    public ICurrent Current { get; }
    public ISearchProvider SearchProvider { get; }
    public IMessagerProvider MessagerProvider { get; }
}
