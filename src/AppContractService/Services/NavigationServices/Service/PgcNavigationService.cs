using AppContractService.Services.ServiceBase;

namespace AppContractService.Services.NavigationServices.Service;

public sealed partial class PgcNavigationService : NavigationServiceBase
{
    public PgcNavigationService(IPageService pageService)
        : base(pageService) { }

    
}
