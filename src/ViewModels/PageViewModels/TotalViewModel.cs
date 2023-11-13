using Microsoft.Extensions.DependencyInjection;

namespace ViewModels.PageViewModels;

public sealed partial class TotalViewModel : PageViewModelBase, IAppService
{
    public TotalViewModel(
        [FromKeyedServices(NavHostingConfig.TotalNav)] INavigationService navigationService,
        [FromKeyedServices(NavHostingConfig.TotalNavView)]
            INavigationViewService navigationViewService,
        IRootNavigationMethod rootNavigationMethod
    )
        : base(rootNavigationMethod)
    {
        NavigationService = navigationService;
        NavigationViewService = navigationViewService;
        NavigationService.NavigatedEvent += NavigationService_TotalNavigatedEvent;
    }

    private void NavigationService_TotalNavigatedEvent(
        object sender,
        Microsoft.UI.Xaml.Navigation.NavigationEventArgs e
    )
    {
        var selectedItem = NavigationViewService.GetSelectItem(e.SourcePageType);
        if (selectedItem != null)
        {
            SelectItem = selectedItem;
        }
    }

    [ObservableProperty]
    object _SelectItem;

    [RelayCommand]
    void MakeRefresh()
    {
        WeakReferenceMessenger.Default.Send<TotalRefresh>(new("Rank", true));
    }

    [RelayCommand]
    void Loaded()
    {
        NavigationService.NavigationTo(typeof(HotViewModel).FullName);
    }

    public INavigationService NavigationService { get; }
    public INavigationViewService NavigationViewService { get; }
    public string ServiceID { get; set; } = "综合页面";
}
