using Microsoft.UI.Xaml.Controls;
using ViewModels.ToolViewModels;
namespace Views;

public sealed partial class ToolRootPage : Page
{
    public ToolRootPage()
    {
        this.InitializeComponent();
        Loaded += ToolRootPage_Loaded;
    }

    private void ToolRootPage_Loaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        this.titleBar.Window = ViewModel.WindowManager.GetWindow();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (e.Parameter is AppNavigationPageArgs value)
        {
            this.ViewModel = (ToolRootViewModel)value.ViewModel;
        }
    }

    public ToolRootViewModel ViewModel { get; private set; }
}