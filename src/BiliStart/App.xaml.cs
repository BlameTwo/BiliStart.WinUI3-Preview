using IAppContracts;
using AppContractService;
using Microsoft.Windows.AppLifecycle;
using System.Diagnostics;
using System;
using Windows.ApplicationModel.Activation;
using INetwork;
using System.Threading.Tasks;
using Serilog;
using LanguageExt;
using static System.Runtime.InteropServices.JavaScript.JSType;
using App.Models.MediaPlayerArgs;
namespace BiliStart;

public partial class App:BiliApplication
{
    public App()
    {
        this.InitializeComponent();
        this.UnhandledException += App_UnhandledException;
    }

    private async void App_UnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
    {
        e.Handled = true;
        var log = AppService.GetService<ILogger>();
        log.Information(e.Message);
        var tip = AppService.GetService<ITipShow>();
        tip.ShowMessage(e.Message, Microsoft.UI.Xaml.Controls.Symbol.Clear);
        await Task.Delay(TimeSpan.FromSeconds(3));
        AppService.GetService<IHttpClientProvider>().InitClient();
    }

    AppInstance appInstance = null;
    protected async override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
    {
        appInstance = AppInstance.FindOrRegisterForKey(
            "BiliStart"
        );
        appInstance.Activated += AppInstance_Activated;
        if (appInstance.IsCurrent)
        {
            var eventargs = Microsoft.Windows.AppLifecycle.AppInstance
               .GetCurrent()
               .GetActivatedEventArgs();

            this.MainWindow = new MainWindow();
            AppService.InitService(this);
            AppService.GetService<IWindowManager>().InitWindow(this.MainWindow);
            AppService.GetService<IWindowManager>().BiliApplication = this;
            AppService.GetService<IAppResources<BiliApplication>>().InitResouces(this);
            var result = AppService.GetService<IAppActivationService<BiliApplication>>();
            result.ActivationProtocolSetup(eventargs);
            await result.ActivationAsync(this);
        }
        else
        {
            var eventargs = AppInstance
                .GetCurrent()
                .GetActivatedEventArgs();
            await appInstance.RedirectActivationToAsync(eventargs);
            Process.GetCurrentProcess().Kill();
        }
    }

    private void AppInstance_Activated(object sender, AppActivationArguments e)
    {
        if (e.Kind == ExtendedActivationKind.Protocol)
        {
            var data = e.Data as ProtocolActivatedEventArgs; 
            AppService.GetService<IAppProtocolSetupService>().Invoke(data.Uri);
        }
    }
}
