using CommunityToolkit.Mvvm.Input;
using IAppContracts.Bases;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;

namespace IAppContracts.IUserControlsViewModels;

public interface IBiliStartNotifyViewModel : IUserControlVMBase<object>
{
    public IWindowManager WindowManager { get; }

    public bool? _isshow { get; set; }

    public IRelayCommand ShowCommand { get; }
    public IRelayCommand ExitCommand { get; }

    public IRelayCommand GoHomeCommand { get; }
    public INavigationService MainNavigationService { get; }

    public INavigationService RootNavigationService { get; }
}
