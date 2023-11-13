/*
 2023.7.9
此类主要解耦VM层面的对话框服务，并通过接口的方式赋值对话框VM
 */
using IAppContracts.IUserControlsViewModels;

namespace AppContractService.Services;

public sealed class DialogManager : IDialogManager, IAppService
{
    public DialogManager(IWindowManager windowManager)
    {
        WindowManager = windowManager;
    }

    public IWindowManager WindowManager { get; }
    public string ServiceID { get; set; } = nameof(DialogManager);

    public async void ShowLogin() =>
        await ShowDialog<LoginDialog>(AppService.GetService<LoginViewModel>(), null);

    public async void ShowToken() =>
        await ShowDialog<TokenDialog>(AppService.GetService<TokenViewModel>(), null);

    public async void ShowDownload() =>
        await ShowDialog<AddDownloadDialog>(AppService.GetService<AddDownloadViewModel>(), null);

    public async void ShowDownloadItemSession(string guid) =>
        await ShowDialog<DownloadItemDialog>(AppService.GetService<DownloadItemViewModel>(), guid);

    async Task ShowDialog<T>(object vm, object value)
        where T : ContentDialog, IShowDialog
    {
        var dialog = AppService.GetService<T>();
        if (dialog is IShowDialog show)
        {
            show.ToViewModel(vm, value);
        }
        await WindowManager.ShowDialog(dialog);
    }
}
