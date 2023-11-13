using BiliStart.WinUI3.UI.Controls;
using BiliStart.WinUI3.UI.PageBase;
using ViewModels;

namespace Views;

public sealed partial class ViewTestPage : Page
{
    public ViewTestPage()
    {
        this.InitializeComponent();
    }

    public ViewTestViewModel ViewModel { get; private set; }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (e.Parameter is AppNavigationPageArgs value)
        {
            this.ViewModel = (ViewTestViewModel)value.ViewModel;
        }
    }
}
