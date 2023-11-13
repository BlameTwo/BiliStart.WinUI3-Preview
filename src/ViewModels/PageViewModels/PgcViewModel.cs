using Microsoft.Extensions.DependencyInjection;

namespace ViewModels.PageViewModels;

public sealed partial class PgcViewModel : PageViewModelBase
{
    public PgcViewModel(
        IRootNavigationMethod rootNavigationMethod,
        [FromKeyedServices(NavHostingConfig.PgcNavView)]
            INavigationViewService navigationViewService,
        [FromKeyedServices(NavHostingConfig.PgcNav)] INavigationService navigationService
    )
        : base(rootNavigationMethod)
    {
        NavigationViewService = navigationViewService;
        NavigationService = navigationService;
        NavigationService.NavigatedEvent += NavigationService_PGCNavigatedEvent;
    }

    private void NavigationService_PGCNavigatedEvent(
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

    [RelayCommand]
    void Loaded()
    {
        NavigationService.NavigationTo(
            typeof(ViewModels.PageViewModels.MovieViewModel).FullName,
            App.Models.PgcNavModel.Movie
        );
    }

    [ObservableProperty]
    object _SelectItem;

    public INavigationViewService NavigationViewService { get; }
    public INavigationService NavigationService { get; }
}
