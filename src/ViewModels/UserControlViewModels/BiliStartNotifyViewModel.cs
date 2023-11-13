using Microsoft.Extensions.DependencyInjection;
using System.Drawing;

namespace ViewModels.UserControlViewModels;

public partial class BiliStartNotifyViewModel : ObservableObject, IBiliStartNotifyViewModel
{
    public BiliStartNotifyViewModel(
        IWindowManager windowManager,
        [FromKeyedServices(NavHostingConfig.MainNav)] INavigationService MainnavigationService,
        [FromKeyedServices(NavHostingConfig.RootNav)] INavigationService RootnavigationService
    )
    {
        this.RootNavigationService = RootnavigationService;
        this.MainNavigationService = MainnavigationService;
        WindowManager = windowManager;
    }

    public IWindowManager WindowManager { get; }

    public INavigationService MainNavigationService { get; }

    public INavigationService RootNavigationService { get; }

    [RelayCommand]
    void Show()
    {
        this.WindowManager.SetWindowHide();
    }

    [RelayCommand]
    void Exit()
    {
        System.Environment.Exit(0);
    }

    public bool? _isshow { get; set; }

    [RelayCommand]
    void GoHome()
    {
        if (_isshow == false)
        {
            this.WindowManager.SetWindowHide();
        }
        this.RootNavigationService.NavigationTo(typeof(ShellViewModel).FullName);
    }

    public void SetData(object value) { }
}
