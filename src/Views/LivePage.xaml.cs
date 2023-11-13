using Network.Models.Live;

namespace Views;


public sealed partial class LivePage : Page
{
    public LivePage()
    {
        this.InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (e.Parameter is AppNavigationPageArgs value)
        {
            this.ViewModel = (LiveViewModel)value.ViewModel;
        }
    }

    public LiveViewModel ViewModel { get; set; }
}
