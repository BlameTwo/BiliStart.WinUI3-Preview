using IAppContracts.ItemsViewModels.Dynamics;
using ViewConverter.Models.Dynamic;

namespace ViewModels.AppTabViewModels;

public partial class AccountDynamicViewModel : PageViewModelBase
{
    public AccountDynamicViewModel(
        IRootNavigationMethod rootNavigationMethod,
        IAccountProvider accountProvider,IAccountFactory accountFactory
    )
        : base(rootNavigationMethod)
    {
        AccountProvider = accountProvider;
        AccountFactory = accountFactory;
    }

    ~AccountDynamicViewModel()
    {

    }

    public IAccountProvider AccountProvider { get; }
    public IAccountFactory AccountFactory { get; }

    bool _IsFirstLoad = true;
    string _historyOffset = "";
    string _businessId = "";

    [RelayCommand]
    async Task Loaded()
    {
        if (!_IsFirstLoad)
            return;
        var result = await AccountProvider.GetAccountAllDynamicAsync(
            _historyOffset,
            _businessId,
            TokenSource.Token
        );
        this.UpList = result.DynamicUpList;
        this.DynamicLists = AccountFactory.CreateDynamicItems(result.DynamicItems).ToObservableCollection();
        this._historyOffset = result.HistoryOffset;
        this._businessId = result.Businessid;
    }

    [ObservableProperty]
    ObservableCollection<IDynamicItemViewModel> _DynamicLists;

    [ObservableProperty]
    DynamicUpList _UpList;


    [RelayCommand]
    async Task AddData()
    {
        var result = await AccountProvider.GetAccountAllDynamicAsync(
            _historyOffset,
            _businessId,
            TokenSource.Token
        );
        this.DynamicLists.ObservableAddRange(AccountFactory.CreateDynamicItems(result.DynamicItems)); 
        this._historyOffset = result.HistoryOffset;
        this._businessId = result.Businessid;
    }
}
