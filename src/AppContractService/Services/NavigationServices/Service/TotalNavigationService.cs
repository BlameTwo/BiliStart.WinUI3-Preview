using AppContractService.Services.ServiceBase;

namespace AppContractService.Services.NavigationServices.Service;

public sealed partial class TotalNavigationService : NavigationServiceBase
{
    public TotalNavigationService(IPageService pageService)
        : base(pageService) { }
}
