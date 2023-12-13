using IAppContracts;

namespace ViewModels.DialogViewModels;

public sealed partial class LoginViewModel : ObservableRecipient, ILauncherLoginViewModel
{
    public LoginViewModel(
        IWindowManager windowManager,
        ILoginProvider loginProvider,
        IAccountTokenSet accountTokenSet,
        ICurrent current,
        ITokenManager tokenManager,
        ILocalSetting localSetting,
        IAppNotificationService appNotificationService
    )
    {
        WindowManager = windowManager;
        LoginProvider = loginProvider;
        AccountTokenSet = accountTokenSet;
        Current = current;
        TokenManager = tokenManager;
        LocalSetting = localSetting;
        AppNotificationService = appNotificationService;
        TokenSource = new();
    }

    DispatcherTimer timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(1) };

    [RelayCommand]
    void CloseMe()
    {
        WindowManager.CloseDialog();
    }

    [RelayCommand]
    async Task RefershQr() => await refersh();

    [ObservableProperty]
    BitmapImage _QRImage;

    public CancellationTokenSource TokenSource { get; set; }

    [RelayCommand]
    async Task Loaded()
    {
        await refersh();
    }

    private string qrkey;

    async Task refersh()
    {
        timer.Stop();
        timer.Tick -= Timer_Tick;
        var qrresult = await LoginProvider.RefQRAsync(TokenSource.Token);
        if (qrresult == null)
            return;
        qrkey = qrresult.Data.QRKey;
        this.QRImage = await QrConverter.Convert(qrresult.Data.PicUrl);
        timer.Tick += Timer_Tick;
        timer.Start();
    }

    [ObservableProperty]
    string _tipmessage;

    private async void Timer_Tick(object sender, object e)
    {
        if (TokenSource.Token.IsCancellationRequested)
        {
            timer.Stop();
            timer.Tick -= Timer_Tick;
            return;
        }
        var loginresult = await LoginProvider.PollAutoQRAsync(qrkey, TokenSource.Token);
        switch (loginresult.Check)
        {
            case Network.Models.Accounts.Checkenum.OnTime:
                Tipmessage = "二维码超时，请刷新";
                await Task.Delay(2000);
                Tipmessage = "";
                return;
            case Network.Models.Accounts.Checkenum.Yes:
                Tipmessage = "已扫码，请等待";
                await Task.Delay(2000);
                Tipmessage = "";
                break;
            case Network.Models.Accounts.Checkenum.No:
                return;
            case Network.Models.Accounts.Checkenum.YesOrNo:
                return;
        }
        var token = JsonSerializer.Deserialize<AccountToken>(loginresult.Body!);
        if (token == null)
            return;
        goLogin(token);
    }

    private async void goLogin(AccountToken token)
    {
        AccountToken sourcetoken = (AccountToken)token.Clone();
        //第一次为临时token
        await TokenManager.SaveToken(token);
        Current.TokenName = token.Mid;
        Savetoken(token.Mid);
        //ToDo B站修改了Third 获取
        //var result = await AccountTokenSet.GotoThird();
        //var newaccess = await AccountTokenSet.GetAccessKeyToken(result);
        sourcetoken.AccessToken = token.SECCDATA;
        sourcetoken.LastTokenSaveTime = DateTimeOffset.Now.ToString();
        //第二次为刷新的token
        await TokenManager.SaveToken(sourcetoken);
        Current.TokenName = sourcetoken.Mid;
        Savetoken(sourcetoken.Mid);
        timer.Stop();
        timer.Tick -= Timer_Tick;
        var flage = await TokenManager.SaveToken(sourcetoken);
        WindowManager.CloseDialog();
        WeakReferenceMessenger.Default.Send<LoginMessager>(new(sourcetoken, true));
        await AppNotificationService.SendLoginToken(sourcetoken);
    }

    private async void Savetoken(long value)
    {
        if (value == 0)
            return;
        await LocalSetting.SaveConfig(SettingName.Token, value);
    }

    public IWindowManager WindowManager { get; }
    public ILoginProvider LoginProvider { get; }
    public IAccountTokenSet AccountTokenSet { get; }
    public ICurrent Current { get; }
    public ITokenManager TokenManager { get; }
    public ILocalSetting LocalSetting { get; }
    public IAppNotificationService AppNotificationService { get; }
}
