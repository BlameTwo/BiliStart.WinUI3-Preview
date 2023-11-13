namespace Views.TotalPages;

public sealed partial class RankPage : Page
{
    public RankPage()
    {
        this.InitializeComponent();
    }

    public RankViewModel ViewModel { get; private set; }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (e.Parameter is AppNavigationPageArgs args)
        {
            this.ViewModel = (RankViewModel)args.ViewModel;
        }
    }

    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
        this.ViewModel.IsActive = false;
        this.ViewModel.TokenSource.Cancel();
        this.ViewModel = null;
        base.OnNavigatedFrom(e);
    }
}
