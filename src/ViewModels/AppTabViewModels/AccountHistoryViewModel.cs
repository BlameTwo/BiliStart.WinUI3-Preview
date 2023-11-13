using IAppContracts.SegmentedContract;
using Microsoft.Extensions.DependencyInjection;

namespace ViewModels.AppTabViewModels;

public sealed partial class AccountHistoryViewModel : RootViewModelBases
{
    public AccountHistoryViewModel(
        IRootNavigationMethod rootNavigationMethod,
        [FromKeyedServices(NavHostingConfig.RootNav)] INavigationService navigationService,
        [FromKeyedServices(NavHostingConfig.AccountHistoryNav)]
            INavigationService accountHistorynavigationService,
        [FromKeyedServices(NavHostingConfig.AccountHistoryView)]
            ISegmentedNavigationView accountHistoryNavigationview,
        IAccountProvider accountProvider,
        IAccountFactory accountFactory
    )
        : base(rootNavigationMethod, navigationService)
    {
        AccountHistoryNavigationService = accountHistorynavigationService;
        AccountHistoryNavigationViewService = accountHistoryNavigationview;
        AccountProvider = accountProvider;
        AccountFactory = accountFactory;
    }

    [RelayCommand]
    void Refresh()
        => WeakReferenceMessenger.Default.Send<AccountHistoryRefresh>(new(true));


    public INavigationService AccountHistoryNavigationService { get; }
    public ISegmentedNavigationView AccountHistoryNavigationViewService { get; }
    public IAccountProvider AccountProvider { get; }
    public IAccountFactory AccountFactory { get; }
}
