using CommunityToolkit.Mvvm.Input;
using INetwork.IProviders;
using Microsoft.UI.Xaml.Media.Imaging;
using System.Threading;

namespace IAppContracts.IUserControlsViewModels;

public interface ILauncherLoginViewModel
{
    public ILoginProvider LoginProvider { get; }

    BitmapImage QRImage { get; set; }

    CancellationTokenSource TokenSource { get; set; }

    IAsyncRelayCommand LoadedCommand { get; }

    IAsyncRelayCommand RefershQrCommand { get; }
}
