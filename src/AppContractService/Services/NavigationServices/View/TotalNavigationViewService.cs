using AppContractService.Services.ServiceBase;

namespace AppContractService.Services.NavigationServices.View;

public sealed class TotalNavigationViewService : NavigationViewServiceBase
{
    public TotalNavigationViewService(
        [FromKeyedServices(App.Models.NavHostingConfig.TotalNav)]
            INavigationService navigationService,
        IPageService pageService
    )
        : base(navigationService, pageService) { }
}
