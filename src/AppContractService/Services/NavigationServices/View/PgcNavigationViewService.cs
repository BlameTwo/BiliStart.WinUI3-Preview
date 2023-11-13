using AppContractService.Services.ServiceBase;

namespace AppContractService.Services.NavigationServices.View;

public sealed class PgcNavigationViewService : NavigationViewServiceBase
{
    public PgcNavigationViewService(
        [FromKeyedServices(App.Models.NavHostingConfig.PgcNav)]
            INavigationService navigationService,
        IPageService pageService
    )
        : base(navigationService, pageService) { }

}
