namespace ViewModels.PageViewModels;

public sealed partial class SearchRankViewModel
    : PageViewModelBase,
        IAppService,
        IRecipient<TotalRefresh>
{
    public SearchRankViewModel(
        IBiliServiceProvider biliServiceProvider,
        IRootNavigationMethod rootNavigationMethod
    )
        : base(rootNavigationMethod)
    {
        BiliServiceProvider = biliServiceProvider;
    }

    [RelayCommand]
    void Loaded()
    {
        refersh();
    }

    private async void refersh()
    {
        var result = await BiliServiceProvider.GetSearchRankListAsync(this.TokenSource.Token);
        this.Items = result.Data.Lists.ToObservableCollection();
    }

    public void Receive(TotalRefresh message)
    {
        if (message.isrfresh)
            refersh();
    }

    [ObservableProperty]
    ObservableCollection<HotSearchData> _Items;

    public string ServiceID { get; set; } = "HotSearchRank";
    public IBiliServiceProvider BiliServiceProvider { get; }
}
