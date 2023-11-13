using CommunityToolkit.Mvvm.Messaging;
using ViewConverter.Models;
using static ViewConverter.Models.Messager.DownloadMessager;

namespace ViewModels.PageViewModels;

public partial class DownloadViewModel : ObservableRecipient
{
    [ObservableProperty]
    string _title;

    public DownloadViewModel(
        IDownloadService downloadService,
        IDialogManager dialogManager,
        IWindowManager windowManager
    )
    {
        DownloadService = downloadService;
        DialogManager = dialogManager;
        WindowManager = windowManager;
        this.Title = "下载页面";
        ShowNewCommand = new RelayCommand(() =>
        {
            DialogManager.ShowDownload();
        });
        this.Items = DownloadService.GetBiliDownloads();
        //注册方式
        WeakReferenceMessenger.Default.Register<RefershDownloadList>(
            this,
            (r, m) => refershlist(r, m)
        );
    }

    private async void refershlist(object r, RefershDownloadList m)
    {
        this.Items = DownloadService.GetBiliDownloads();
    }

    [RelayCommand]
    void Loaded() { }

    public void SelectionChangedItem(BiliDownload item)
    {
        DialogManager.ShowDownloadItemSession(item.Guid.ToString());
    }

    public IDownloadService DownloadService { get; }
    public IDialogManager DialogManager { get; }

    [ObservableProperty]
    ObservableCollection<BiliDownload> _Items;

    [ObservableProperty]
    Visibility _NewDownloadViewModel;

    public IWindowManager WindowManager { get; }

    public IRelayCommand ShowNewCommand { get; }
}
