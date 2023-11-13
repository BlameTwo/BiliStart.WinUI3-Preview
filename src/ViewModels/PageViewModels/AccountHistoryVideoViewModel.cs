
using Bilibili.App.Interface.V1;
using IAppContracts.Factorys;
using IAppContracts.ItemsViewModels;
using ViewConverter.Models.AccountHistory;

namespace ViewModels.PageViewModels;

public sealed partial class AccountHistoryVideoViewModel : PageViewModelBase,IRecipient<AccountHistoryRefresh>
{
    public AccountHistoryVideoViewModel(IRootNavigationMethod rootNavigationMethod,IAccountProvider accountProvider,IAccountFactory accountFactory) : 
        base(rootNavigationMethod)
    {
        AccountProvider = accountProvider;
        AccountFactory = accountFactory;
    }


    [RelayCommand]
    async Task AddData()
    {
        int count = this.Items.Count;
        AccountVideoHistoryModel? result = await AccountProvider.GetAccountHistoryAsync(Cursor);
        this.Items.ObservableAddRange(AccountFactory.CreateHistoryItems(result.Videos));
        this.Cursor = result.Cursor;
    }


    [RelayCommand]
    async Task Loaded(object data)
    {
        await RefreshAsync();
    }

    async Task RefreshAsync()
    {
        this.Cursor = null;
        AccountVideoHistoryModel? result = await AccountProvider.GetAccountHistoryAsync(
            this.Cursor,
            "archive",
            TokenSource.Token
        );
        this.Cursor = result.Cursor;
        this.Items = AccountFactory.CreateHistoryItems(result.Videos).ToObservableCollection();
    }

    string GetTag(int value) =>
        value == 0
            ? "archive"
            : value == 1
                ? "live"
                : "article";

    public async void Receive(AccountHistoryRefresh message)
    {
        await RefreshAsync();
    }

    [ObservableProperty]
    ObservableCollection<IAccountVideoHistoryItemViewModel> _Items;

    public IAccountProvider AccountProvider { get; }
    public IAccountFactory AccountFactory { get; }


    public Cursor Cursor { get; private set; } = null;
}
