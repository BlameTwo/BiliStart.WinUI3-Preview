namespace Views;

public sealed partial class SettingPage : Page
{
    public SettingPage()
    {
        this.InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (e.Parameter is AppNavigationPageArgs values)
        {
            this.ViewModel = (SettingViewModel)values.ViewModel;
        }
    }

    public SettingViewModel ViewModel { get; private set; }

    public void ToViewModel(object type)
    {
        this.ViewModel = (SettingViewModel)type;
    }

    private async void Searchitemnumber_ValueChanged(
        NumberBox sender,
        NumberBoxValueChangedEventArgs args
    )
    {
        if (ViewModel.IsFirstRead == false)
            await this.ViewModel.ChangedSearchItem(args.NewValue);
    }
}
