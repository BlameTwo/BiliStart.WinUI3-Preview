namespace AppContractService.Services.NavigationServices.View;

public sealed partial class MainNavigationViewService : NavigationViewServiceBase
{
    public MainNavigationViewService(
        [FromKeyedServices(App.Models.NavHostingConfig.MainNav)]
            INavigationService navigationService,
        IPageService pageService
    )
        : base(navigationService, pageService) { }
}
