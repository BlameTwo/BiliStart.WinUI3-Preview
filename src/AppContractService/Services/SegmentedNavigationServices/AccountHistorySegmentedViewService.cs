using CommunityToolkit.WinUI.Controls;
using IAppContracts.SegmentedContract;

namespace AppContractService.Services.SegmentedNavigationServices;

public class AccountHistorySegmentedViewService : SegmentedNavigationViewServiceBase
{
    public AccountHistorySegmentedViewService(
        [FromKeyedServices(NavHostingConfig.AccountHistoryNav)]
        INavigationService navigationService, 
        IPageService pageService) : base(navigationService, pageService)
    {

    }
}
