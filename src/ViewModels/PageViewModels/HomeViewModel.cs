using IAppContracts;
using IAppContracts.ItemsViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Windows.AppNotifications.Builder;
using Microsoft.Windows.AppNotifications;
using Network.Models.ThirdApi;

namespace ViewModels.PageViewModels;

public sealed partial class HomeViewModel : PageViewModelBase, IAppService
{
    public HomeViewModel(
        IVideoProvider videoProvider,
        IThirdApiProvider thirdApiProvider,
        ILocalSetting localSetting,
        IWindowManager windowManager,
        [FromKeyedServices(NavHostingConfig.MainNav)] INavigationService navigationService,
        IRootNavigationMethod rootNavigationMethod,
        IHttpClientProvider  httpClientProvider,
        IVideoItemFactory videoItemFactory,
        ITipShow tipShow
    )
        : base(rootNavigationMethod)
    {
        Title = "推荐（你喜欢看到）";
        this.VideoProvider = videoProvider;
        ThirdApiProvider = thirdApiProvider;
        LocalSetting = localSetting;
        WindowManager = windowManager;
        NavigationService = navigationService;
        HttpClientProvider = httpClientProvider;
        VideoItemFactory = videoItemFactory;
        TipShow = tipShow;
    }

    string idx = null,
        hash = null;

    [RelayCommand]
    async Task AddItem()
    {
        var result = await VideoProvider.GetHomeVideoAsync(false, idx, hash, TokenSource.Token);
        this.Videos.ObservableAddRange(VideoItemFactory.CreateVideoHomeItems(result.Items));
        this.idx = result.Idx.ToString();
        this.hash = result.Hash;
    }

    [RelayCommand]
    void Refresh()
    {
        refesh(true);
    }

    [RelayCommand]
    async Task DownloadWallpaper()
    {
        var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); 
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, this.YurikotoWallpaper.Link);
        var response = await this.HttpClientProvider.SendAsync(request, this.TokenSource.Token);
        var flage =  await FileHelper.StreamSaveToFile(await response.Content.ReadAsStreamAsync(),desktop+"/Wallpaper.jpg") ;
        if(flage == true)
        {
            TipShow.ShowMessage("下载壁纸完毕", Symbol.Download);
        }
        else
        {
            TipShow.ShowMessage("下载壁纸出错", Symbol.Download);
        }
    }

    async void refesh(bool isAdd)
    {
        var result = await VideoProvider.GetHomeVideoAsync(
            true,
            null,
            null,
            this.TokenSource.Token
        );
        if (isAdd)
        {
            Videos.ObservableAddRange(VideoItemFactory.CreateVideoHomeItems(result.Items).ToObservableCollection());
        }
        else
        {
            Videos = VideoItemFactory.CreateVideoHomeItems(result.Items).ToObservableCollection();
        }
        
        this.BannerItems.ObservableAddRange(result.BannerItems.Where((val) => val.Static != null));
        this.idx = result.Idx.ToString();
        this.hash = result.Hash;
    }

    bool isNew = true;

    [RelayCommand]
    async Task Loaded()
    {
        this.WindowManager.ChangedMinWidth(500);
        this.WindowManager.ChangedMinHeight(250);
        this.WindowManager.SetWindowSize(500, 1000);
        this.WindowManager.SetWindowResizable(true);
        refesh(false);
        refesh(true);
        this.YurikotoWallpaper = await ThirdApiProvider.GetYurikoWallpaper(TokenSource.Token);
        this.EveryDay = await ThirdApiProvider.GetEveryDayAsync(TokenSource.Token);
        this.EveryDayTotal = await ThirdApiProvider.GetEveryDayTotalAsync(
            EveryDay.Uuid,
            TokenSource.Token
        );
    }


    [ObservableProperty]
    Visibility _IsMainWay = Visibility.Visible;

    [RelayCommand]
    void GoSetting()
    {
        NavigationService.NavigationTo(typeof(SettingViewModel).FullName);
    }

    [ObservableProperty]
    HomeVideoModel _Recommand;

    [ObservableProperty]
    YurikotoWallpaperModel _YurikotoWallpaper;

    [ObservableProperty]
    string _BingWallpaperUrl;

    [ObservableProperty]
    EveryDayModel _EveryDay;

    [ObservableProperty]
    EveryDayTotalModel _EveryDayTotal;

    [ObservableProperty]
    ObservableCollection<IVideoHomeItemViewModel> _Videos = new();

    [ObservableProperty]
    ObservableCollection<HomeBannerItem> _BannerItems = new();

    public IVideoProvider VideoProvider { get; }
    public IThirdApiProvider ThirdApiProvider { get; }
    public ILocalSetting LocalSetting { get; }
    public IWindowManager WindowManager { get; }
    public INavigationService NavigationService { get; }
    public IHttpClientProvider HttpClientProvider { get; }
    public IVideoItemFactory VideoItemFactory { get; }
    public ITipShow TipShow { get; }
    public string ServiceID { get; set; } = "首页推荐";
}
