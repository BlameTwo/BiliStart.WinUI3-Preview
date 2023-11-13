namespace Views;

public sealed partial class TotalPage : Page
{
    public TotalPage()
    {
        this.InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (e.Parameter is AppNavigationPageArgs value)
        {
            this.ViewModel = (TotalViewModel)value.ViewModel;
            this.ViewModel.NavigationService.BaseFrame = this.framebase;
            this.ViewModel.NavigationViewService.Register(this.navigation);
        }
    }

    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
        this.ViewModel.NavigationService.BaseFrame = null;
        this.ViewModel.NavigationViewService.UnRegister();
        base.OnNavigatedFrom(e);
    }

    public TotalViewModel ViewModel { get; private set; }
}
