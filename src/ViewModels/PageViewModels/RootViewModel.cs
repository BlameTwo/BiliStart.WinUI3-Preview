using Microsoft.Extensions.DependencyInjection;

namespace ViewModels.PageViewModels;

public sealed partial class RootViewModel : ObservableRecipient, IAppService
{
    public RootViewModel(
        [FromKeyedServices(NavHostingConfig.RootNav)] INavigationService navigationService,
        ITipShow tipShow,
        IUserControlViewModelFactory userControlViewModelFactory,IWindowManager windowManager
    )
    {
        NavigationService = navigationService;
        TipShow = tipShow;
        UserControlViewModelFactory = userControlViewModelFactory;
        WindowManager = windowManager;
    }

    [RelayCommand]
    void Loaded()
    {
        this.BiliStartNotifyViewModel = UserControlViewModelFactory.CreateNotifyIconViewModel(this);
    }

    [ObservableProperty]
    IBiliStartNotifyViewModel _BiliStartNotifyViewModel;

    public string ServiceID { get; set; } = "RootVM";
    public INavigationService NavigationService { get; }
    public ITipShow TipShow { get; }
    public IUserControlViewModelFactory UserControlViewModelFactory { get; }
    public IWindowManager WindowManager { get; }
}
