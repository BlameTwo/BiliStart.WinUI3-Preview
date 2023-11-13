using Bilibili.App.Nativeact.V1;
using IAppContracts;
using IAppContracts.TabViewContract;
using Microsoft.Extensions.DependencyInjection;

namespace ViewModels.AppTabViewModels;

public partial class MainViewModel : PageViewModelBase
{
    public MainViewModel(
        [FromKeyedServices(NavHostingConfig.MainNav)] INavigationService mainNavigationService,
        [FromKeyedServices(NavHostingConfig.MainNavView)]
            INavigationViewService mainNavigationViewService,
        ITabViewService tabViewService,IRootNavigationMethod rootNavigationMethod
    ):base(rootNavigationMethod)
    {
        MainNavigationService = mainNavigationService;
        MainNavigationViewService = mainNavigationViewService;
        MainNavigationService.NavigatedEvent += NavigationService_AppNavigatedEvent;
        TabViewService = tabViewService;
    }

    [RelayCommand]
    void Loaded() 
    {
        TabViewService.UpDateProgressRing(Key, Visibility.Collapsed);
    }

    string Key => typeof(MainViewModel).FullName!;

    private void NavigationService_AppNavigatedEvent(
        object sender,
        Microsoft.UI.Xaml.Navigation.NavigationEventArgs e
    )
    {
        var selectedItem = MainNavigationViewService.GetSelectItem(e.SourcePageType);

        if (selectedItem != null)
        {
            this.NavigaitonSelectItem = selectedItem;
        }
    }

    [ObservableProperty]
    object _NavigaitonSelectItem;

    public INavigationService MainNavigationService { get; }

    public INavigationViewService MainNavigationViewService { get; }
    public ITabViewService TabViewService { get; }
}
