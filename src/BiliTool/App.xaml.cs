using Microsoft.UI.Xaml;
using IAppContracts;
using Microsoft.UI.Xaml.Media;
using Microsoft.Windows.AppLifecycle;
using System;
using AppContractService;
using System.Diagnostics;
using App.Models.Enum;

namespace BiliTool
{
    public partial class App : BiliApplication
    {
        private AppInstance appInstance;

        public App()
        {
            this.InitializeComponent();
        }

        protected async override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            appInstance = AppInstance.FindOrRegisterForKey(
            "BiliStartTool"
        );
            appInstance.Activated += AppInstance_Activated;
            if (appInstance.IsCurrent)
            {
                var eventargs = Microsoft.Windows.AppLifecycle.AppInstance
                   .GetCurrent()
                   .GetActivatedEventArgs();
                this.MainWindow = new WinUIEx.WindowEx();
                AppService.InitService(this);
                AppService.GetService<IWindowManager>().InitWindow(this.MainWindow);
                AppService.GetService<IWindowManager>().BiliApplication = this;
                AppService.GetService<IAppResources<BiliApplication>>().InitResouces(this);
                var result = AppService.GetService<IAppActivationService<BiliApplication>>();
                result.ActivationProtocolSetup(eventargs);
                await result.ActivationAsync(this,SetupEnum.Tool);
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
            throw new NotImplementedException();
        }
    }
}
