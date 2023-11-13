
using Views.TabViews.Bases;
using ViewModels.AppTabViewModels;
namespace Views.TabViews;

public sealed partial class MainControlView : MainControlBase
{
    public MainControlView()
    {
        this.InitializeComponent();
        Loaded += MainControlView_Loaded;
    }

    private void MainControlView_Loaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        this.ViewModel.MainNavigationService.BaseFrame = this.appframe;
        this.ViewModel.MainNavigationViewService.Register(this.navigation);
        if (IsFirstLoad == true)
        {
            this.ViewModel.MainNavigationService.NavigationTo(typeof(HomeViewModel).FullName);
            IsFirstLoad = false;
        }
    }

    bool IsFirstLoad = true;

    private void navigation_DisplayModeChanged(NavigationView sender, NavigationViewDisplayModeChangedEventArgs args)
    {
        if(sender.DisplayMode == NavigationViewDisplayMode.Minimal)
        {
            sender.IsPaneToggleButtonVisible = true;
        }
        else
        {
            sender.IsPaneToggleButtonVisible = false;
        }
    }
}
