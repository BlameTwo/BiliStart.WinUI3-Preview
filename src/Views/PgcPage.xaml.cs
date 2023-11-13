namespace Views;

public sealed partial class PgcPage : Page
{
    public PgcPage()
    {
        this.InitializeComponent();
    }

    public ViewModels.PageViewModels.PgcViewModel ViewModel { get; private set; }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (e.Parameter is AppNavigationPageArgs args)
        {
            this.ViewModel = (ViewModels.PageViewModels.PgcViewModel)args.ViewModel;
            this.ViewModel.NavigationViewService.Register(navigationbase);
            this.ViewModel.NavigationService.BaseFrame = this.framebase;
        }
    }

    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
        this.ViewModel.NavigationViewService.UnRegister();
        this.ViewModel.NavigationService.BaseFrame = null;
        base.OnNavigatedFrom(e);
    }
}
