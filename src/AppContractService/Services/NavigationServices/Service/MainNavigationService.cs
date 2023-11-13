using AppContractService.Services.ServiceBase;

namespace AppContractService.Services.NavigationServices.Service;

public sealed partial class MainNavigationService : NavigationServiceBase
{
    /// <summary>
    /// 默认构造函数
    /// </summary>
    /// <param name="navigationService"></param>
    /// <param name="pageService"></param>
    public MainNavigationService(IPageService pageService)
        : base(pageService) { }
}