namespace ViewModels.DialogViewModels;

public sealed partial class DownloadItemViewModel : ObservableObject
{
    public DownloadItemViewModel(IDownloadService downloadService, IWindowManager windowManager)
    {
        DownloadService = downloadService;
        WindowManager = windowManager;
    }

    [ObservableProperty]
    string _Guid;

    [ObservableProperty]
    BiliDownload _BiliItem;

    [RelayCommand]
    void Close()
    {
        WindowManager.CloseDialog();
    }

    public IDownloadService DownloadService { get; }
    public IWindowManager WindowManager { get; }

    public void RefershDownloadItem(string guid)
    {
        this.BiliItem = DownloadService.GetDownloadItem(guid);
        this.Guid = guid;
    }
}
