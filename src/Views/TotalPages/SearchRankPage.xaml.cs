namespace Views.TotalPages;

public sealed partial class SearchRankPage : Page
{
    public SearchRankPage()
    {
        this.InitializeComponent();
    }

    public SearchRankViewModel ViewModel { get; set; }

    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
        this.ViewModel.IsActive = false;
        this.ViewModel.TokenSource.Cancel();
        this.ViewModel = null;
        base.OnNavigatedFrom(e);
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (e.Parameter is AppNavigationPageArgs args)
        {
            this.ViewModel = (SearchRankViewModel)args.ViewModel;
        }
    }
}
