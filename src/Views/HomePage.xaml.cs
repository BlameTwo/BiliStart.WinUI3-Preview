using Microsoft.UI.Input;
using Microsoft.Windows.AppNotifications;
using Microsoft.Windows.AppNotifications.Builder;

namespace Views;

public sealed partial class HomePage : Page
{
    public HomePage()
    {
        this.InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (e.Parameter is AppNavigationPageArgs value)
        {
            this.ViewModel = (HomeViewModel)value.ViewModel;
        }
    }

    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
        this.ViewModel.TokenSource.Cancel();
        base.OnNavigatedFrom(e);
    }

    public HomeViewModel ViewModel { get; private set; }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        this.gridview.GoScrollTop();
    }
}
