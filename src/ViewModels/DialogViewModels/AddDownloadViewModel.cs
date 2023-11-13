using BiliNetWork;
using CommunityToolkit.Mvvm.Messaging;
using Network.Models.Enum;
using static ViewConverter.Models.Messager.DownloadMessager;

namespace ViewModels.DialogViewModels;

public partial class AddDownloadViewModel : ObservableObject
{
    public AddDownloadViewModel(
        IWindowManager windowManager,
        IVideoProvider videoProvider,
        IAvToBvConverter avToBvConverter,
        IDownloadService downloadService
    )
    {
        WindowManager = windowManager;
        VideoProvider = videoProvider;
        AvToBvConverter = avToBvConverter;
        DownloadService = downloadService;
        this.CloseCommand = new RelayCommand(() =>
        {
            WindowManager.CloseDialog();
        });
        this.SearchCommand = new AsyncRelayCommand(async () => await search());
    }

    private async Task search()
    {
        this.Qualitys.Clear();
        this.Pages.Clear();
        long av = 0;
        VideoTypeEnum typeEnum = VideoTypeEnum.Av;
        long.TryParse(this.ID, out av);
        if (ID.StartsWith("bv") || ID.StartsWith("BV"))
        {
            typeEnum = VideoTypeEnum.Bv;
            av = AvToBvConverter.Dec(ID);
        }
        this.View = await VideoProvider.GetVideoViewAsync(VideoTypeEnum.Av, av.ToString());
        if (View != null)
            this.CoverPast = Visibility.Collapsed;
        this.Pic = View.PlayerSession.Cover;
        foreach (var page in View.PlayerPages)
        {
            Pages.Add(new DownloadPages(page));
        }
        var info = await VideoProvider.GetVideoDashSourceAsync(
            VideoTypeEnum.Av,
            View.FirstCid,
            av.ToString()
        );
        this.Qualitys = GetDownloadQuality(info.Data.Dash.DashVideos);
        this.SelectQuality = Qualitys[0];
    }

    public ObservableCollection<DownloadQuality> GetDownloadQuality(List<DashVideo> video)
    {
        List<int> quality = new();
        ObservableCollection<DownloadQuality> qualitylist = new();
        foreach (var item in video)
        {
            if (item.BaseUrl == null)
                continue;
            //清除掉空的下载权限
            if (quality.Contains(item.ID))
                continue;
            //筛选是否已经存在
            quality.Add(item.ID);
            qualitylist.Add(GetQuality(item.ID));
        }
        return qualitylist;
    }

    private DownloadQuality GetQuality(int type)
    {
        switch (type)
        {
            case 16:
                return new() { QualityId = 16, Title = "360清晰度" };
            case 32:
                return new() { QualityId = 32, Title = "480清晰度" };
            case 64:
                return new() { QualityId = 64, Title = "720清晰度" };
            case 80:
                return new() { QualityId = 80, Title = "1080清晰度" };
            case 112:
                return new() { QualityId = 116, Title = "1080+清晰度" };
            case 116:
                return new() { QualityId = 116, Title = "1080P 60清晰度" };
            case 120:
                return new() { QualityId = 120, Title = "4K超清" };
            case 125:
                return new() { QualityId = 125, Title = "HDR 真彩色" };
            case 126:
                return new() { QualityId = 126, Title = "杜比世界" };
            case 127:
                return new() { QualityId = 127, Title = "8K超高清" };
        }
        return new() { Title = "空的清晰度", QualityId = -1 };
    }

    [RelayCommand]
    async void AddDownload()
    {
        List<ViewPage> pages = new();
        foreach (var item in this.Pages)
        {
            if ((bool)item.IsDownload!)
                pages.Add(item.Page);
        }
        var result = await DownloadService.AddDownload(
            this.View.Aid,
            pages,
            this.SelectQuality.QualityId
        );
        WeakReferenceMessenger.Default.Send(new RefershDownloadList(true, true));
        WindowManager.CloseDialog();
    }

    [ObservableProperty]
    string _ID;

    [ObservableProperty]
    string _Pic;

    [ObservableProperty]
    PlayerView _View;

    [ObservableProperty]
    DownloadQuality _SelectQuality;

    [ObservableProperty]
    ObservableCollection<DownloadQuality> _Qualitys = new();

    [ObservableProperty]
    ObservableCollection<DownloadPages> _Pages = new();

    [ObservableProperty]
    Visibility _CoverPast = Visibility.Visible;

    public IRelayCommand CloseCommand { get; }
    public IWindowManager WindowManager { get; }
    public IVideoProvider VideoProvider { get; }
    public IAvToBvConverter AvToBvConverter { get; }
    public IDownloadService DownloadService { get; }
    public IAsyncRelayCommand SearchCommand { get; }
}
