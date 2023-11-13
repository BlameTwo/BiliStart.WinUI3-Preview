namespace Views.TotalPages;

public sealed partial class HotPage : Page
{
    public HotPage()
    {
        this.InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (e.Parameter is AppNavigationPageArgs args)
        {
            this.ViewModel = (HotViewModel)args.ViewModel;
            this.ViewModel.IsActive = true;
        }
    }

    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
        this.ViewModel.IsActive = false;
        this.ViewModel.TokenSource.Cancel();
        this.ViewModel = null;
        base.OnNavigatedFrom(e);
    }

    public HotViewModel ViewModel { get; private set; }
}
