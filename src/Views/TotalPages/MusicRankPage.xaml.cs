namespace Views.TotalPages;

public sealed partial class MusicRankPage : ViewerPageBase
{
    public MusicRankPage()
    {
        this.InitializeComponent();
    }

    private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
    {
        ToggleSwitch toggleSwitch = sender as ToggleSwitch;
        if (toggleSwitch != null)
        {
            if (toggleSwitch.IsOn != ViewModel.IsRegister)
            {
                ViewModel.IsRegister = toggleSwitch.IsOn;
            }
        }
    }

    public void ToViewModel(object type)
    {
        this.ViewModel = (MusicRankViewModel)type;
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (e.Parameter is AppNavigationPageArgs args)
        {
            this.ViewModel = (MusicRankViewModel)args.ViewModel;
        }
    }

    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
        this.ViewModel.IsActive = false;
        this.ViewModel.TokenSource.Cancel();
        this.ViewModel = null;
        base.OnNavigatedFrom(e);
    }

    public MusicRankViewModel ViewModel { get; private set; }
}
