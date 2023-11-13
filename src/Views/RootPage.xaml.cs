namespace Views;

public sealed partial class RootPage : Page
{
    public RootPage(RootViewModel rootViewModel)
    {
        this.ViewModel = rootViewModel;
        this.InitializeComponent();
        ViewModel.NavigationService.BaseFrame = this.RootFrame;
        ViewModel.TipShow.Owner = this.grid;
    }

    public RootViewModel ViewModel { get; private set; }

    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
        this.ViewModel.WindowManager.InitPage(this);
        this.ViewModel.WindowManager.InitPopupParent(this.grid);
    }
}
