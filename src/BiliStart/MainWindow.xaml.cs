using App.Models;
using AppContractService;
using IAppContracts;
using Microsoft.UI.Xaml;
using WinUIEx;

namespace BiliStart;

public sealed partial class MainWindow : WindowEx
{
    public MainWindow()
    {
        this.InitializeComponent();
        this.SetTitleBar(null);
        this.AppWindow.SetIcon(FilePath.AppPath + "/Assets/icon.ico");
        this.AppWindow.Closing += AppWindow_Closing;

    }
    private async void AppWindow_Closing(
    Microsoft.UI.Windowing.AppWindow sender,
    Microsoft.UI.Windowing.AppWindowClosingEventArgs args
)
    {
        args.Cancel = true;
        var result = await AppService
            .GetService<ILocalSetting>()
            .ReadConfig(SettingName.AppExitMode);
        if (result.ToString() == "Exit")
        {
            System.Environment.Exit(0);
        }
        else
        {
            AppService.GetService<IWindowManager>().SetWindowHide();
        }
    }
}
