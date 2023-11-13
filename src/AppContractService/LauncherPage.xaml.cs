using CommunityToolkit.WinUI.Helpers;

namespace AppContractService
{
    public sealed partial class LauncherPage : Page
    {
        public LauncherPage()
        {
            this.InitializeComponent();
            Loaded += LauncherPage_Loaded;
        }

        private async void LauncherPage_Loaded(object sender, RoutedEventArgs e)
        {
            var result = await ViewModel.LocalSetting.ReadConfig(SettingName.AutoLoginCheck);
            this.AutoLoginCheck.IsChecked = ((JsonElement)result).GetBoolean();
            this.ViewModel.WindowManager.SetWindowSize(650,450);
            this.ViewModel.WindowManager.SetWindowResizable(false);
        }

        public LauncherViewModel ViewModel { get; private set; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is AppNavigationPageArgs value)
            {
                this.ViewModel = (LauncherViewModel)value.ViewModel;
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            ViewModel.IsActive = false;
            ViewModel.TokenSource.Cancel();
            ViewModel.LauncherLoginVM.TokenSource.Cancel();
            ViewModel = null;
            base.OnNavigatedFrom(e);
        }

        private async void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            await this.ViewModel.LocalSetting.SaveConfig(SettingName.AutoLoginCheck, AutoLoginCheck.IsChecked);
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if(this.ActualWidth < 700)
            {
                Grid.SetColumnSpan(this.BackImage, 2);
                Grid.SetColumn(this.Switch, 0);
                Grid.SetColumn(this.loginView, 0);
                Grid.SetColumn(this.HeaderText, 0);
            }
            else
            {
                Grid.SetColumnSpan(this.BackImage, 1);
                Grid.SetColumn(this.Switch, 1);
                Grid.SetColumn(this.loginView, 1);
                Grid.SetColumn(this.HeaderText, 1);
            }
        }
    }
}
