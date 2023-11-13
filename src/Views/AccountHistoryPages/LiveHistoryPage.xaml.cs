namespace Views.AccountHistoryPages;

public sealed partial class LiveHistoryPage : Page
{
    public LiveHistoryPage()
    {
        this.InitializeComponent();
    }

    public LiveHistoryViewModel ViewModel { get; private set; }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (e.Parameter is AppNavigationPageArgs args)
        {
            this.ViewModel = (LiveHistoryViewModel)args.ViewModel;
            this.ViewModel.IsActive = true;
        }
    }

    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
        this.ViewModel.TokenSource.Cancel();
        base.OnNavigatedFrom(e);
    }


}
