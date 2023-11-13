using Bilibili.App.Interface.V1;
using IAppContracts.ItemsViewModels;

namespace ViewModels.PageViewModels;

public partial class LiveHistoryViewModel : PageViewModelBase
{
    private Cursor _cursor;

    public LiveHistoryViewModel(
        IRootNavigationMethod rootNavigationMethod,
        IAccountProvider accountProvider,
        IAccountFactory accountFactory
    )
        : base(rootNavigationMethod)
    {
        Title = "Live";
        AccountProvider = accountProvider;
        AccountFactory = accountFactory;
    }

    public IAccountProvider AccountProvider { get; }
    public IAccountFactory AccountFactory { get; }

    [RelayCommand]
    async Task Loaded() 
    {
        var result = await AccountProvider.GetAccountLiveHistoryAsync(this._cursor,this.TokenSource.Token);
        var acc = AccountFactory.CreateLiveHistoryItems(result.Lives);
        this.LiveList = acc.ToObservableCollection();
    }


    [ObservableProperty]
    ObservableCollection<IAccountHistoryLiveItemViewModel> _LiveList;
}
