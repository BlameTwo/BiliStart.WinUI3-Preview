
namespace Views.AccountHistoryPages;

public sealed partial class VideoHistoryPage : Page
{
    public VideoHistoryPage()
    {
        this.InitializeComponent();
    }

    public AccountHistoryVideoViewModel ViewModel { get; private set; }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (e.Parameter is AppNavigationPageArgs args)
        {
            this.ViewModel = (AccountHistoryVideoViewModel)args.ViewModel;
            this.ViewModel.IsActive = true;
        }
    }


    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
        this.ViewModel.IsActive = false;
        this.ViewModel.TokenSource.Cancel();
        base.OnNavigatedFrom(e);
    }

}
