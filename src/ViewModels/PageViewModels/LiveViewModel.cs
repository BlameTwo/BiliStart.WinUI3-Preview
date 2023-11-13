using IAppContracts.ItemsViewModels;
using Network.Models.Live;
using ViewConverter.Models.Live.Extentrions;

namespace ViewModels.PageViewModels;

public sealed partial class LiveViewModel : PageViewModelBase
{
    public ILiveProvider LiveProvider { get; }
    public ITipShow TipShow { get; }
    public IBIliDocument BIliDocument { get; }
    public IWindowManager WindowManager { get; }
    public ILiveItemFactory LiveItemFactory { get; }
    public ITabCreateMethodService TabCreateMethodService { get; }

    int _pageIndex = 1;

    public LiveViewModel(
        IRootNavigationMethod rootNavigationMethod,
        ILiveProvider liveProvider,
        ITipShow tipShow,
        IBIliDocument bIliDocument,
        IWindowManager windowManager,
        ILiveItemFactory liveItemFactory,
        ITabCreateMethodService tabCreateMethodService
    )
        : base(rootNavigationMethod)
    {
        this.Title = "直播页面";
        LiveProvider = liveProvider;
        TipShow = tipShow;
        BIliDocument = bIliDocument;
        WindowManager = windowManager;
        LiveItemFactory = liveItemFactory;
        TabCreateMethodService = tabCreateMethodService;
    }

    [RelayCommand]
    async Task Loaded()
    {
        //await initClient();
        var result = await LiveProvider.GetLiveFeedDataAsync(_pageIndex);
        MyLikeCard = result.Data.FormatMyLike();
        LiveCardLists = LiveItemFactory
            .CreateLivePageItems(result.Data.FormatList())
            .ToObservableCollection();
        LiveHotTag = result.Data.FormatHotTag();
        _pageIndex++;
    }

    [RelayCommand]
    void GoLiveTagPage()
    {
        //RootNavigationMethod.NavigationToLiveTag();
        TabCreateMethodService.GoLiveTagTab();
    }

    [ObservableProperty]
    LiveCardList _MyLikeCard = null;

    [ObservableProperty]
    ObservableCollection<ILivePageItemViewModel> _LiveCardLists = new();

    [ObservableProperty]
    LiveCardList _LiveHotTag = new();

    [RelayCommand]
    async Task AddItemsAsync()
    {
        var result = await LiveProvider.GetLiveFeedDataAsync(_pageIndex);
        LiveCardLists.ObservableAddRange(
            LiveItemFactory.CreateLivePageItems(result.Data.FormatList())
        );
        _pageIndex++;
    }


    /*
    直播间消息为:
    INTERACT_WORD5
    ENTRY_EFFECT
    ONLINE_RANK_V2
    DANMU_MSG
    ONLINE_RANK_COUNT
    WATCHED_CHANGE
    STOP_LIVE_ROOM_LIST
    WIDGET_BANNER
    ROOM_REAL_TIME_MESSAGE_UPDATE
    LIKE_INFO_V3_CLICK
    LIKE_INFO_V3_UPDATE
    NOTICE_MSG
     */
}
