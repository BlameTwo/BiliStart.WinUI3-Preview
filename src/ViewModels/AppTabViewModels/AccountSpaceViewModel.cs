using IAppContracts.TabViewContract;
using System.Security.Cryptography;

namespace ViewModels.AppTabViewModels;

public partial class AccountSpaceViewModel : PageViewModelBase
{

    public AccountSpaceViewModel(
        IRootNavigationMethod rootNavigationMethod,
        IAccountProvider accountProvider,
        ITabViewService tabViewService
    )
        : base(rootNavigationMethod)
    {
        AccountProvider = accountProvider;
        TabViewService = tabViewService;
    }

    public IAccountProvider AccountProvider { get; }
    public ITabViewService TabViewService { get; }

    [ObservableProperty]
    long _Mid;

    string Key = "";

    public async void RefershAccount()
    {
        this.Key = $"{typeof(AccountSpaceViewModel)}+{Mid}";
        this.Space = (await AccountProvider.GetAccountSpaceAsync(Mid)).Data;
        var icon = new ImageIconSource() { ImageSource = new BitmapImage(new Uri(Space.Card.Face)) };
        this.TabViewService.UpDateIcon(
            Key,icon
        );
        this.TabViewService.UpDateTitle(Key, Space.Card.Name+"的空间");
    }

    [ObservableProperty]
    MySpace _Space;


    [RelayCommand]
    void GoChangedSing()
    {

    }
}
