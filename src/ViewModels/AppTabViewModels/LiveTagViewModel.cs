using IAppContracts.Factorys;
using IAppContracts.ItemsViewModels;
using IAppContracts.IUserControlsViewModels.LiveControlsViewModels;
using IAppContracts.TabViewContract;
using Network.Models.Live;

namespace ViewModels.AppTabViewModels;

public partial class LiveTagViewModel
    : PageViewModelBase,
        IRecipient<LiveTagItemBack>,
        IRecipient<LiveTagItemGo>
{
    public LiveTagViewModel(
        IRootNavigationMethod rootNavigationMethod,
        ILiveProvider liveProvider,
        ILiveItemFactory liveItemFactory,
        IUserControlViewModelFactory userControlViewModelFactory,
        ITabViewService tabViewService
    )
        : base(rootNavigationMethod)
    {
        Title = "直播标签";
        LiveProvider = liveProvider;
        LiveItemFactory = liveItemFactory;
        UserControlViewModelFactory = userControlViewModelFactory;
        TabViewService = tabViewService;
    }

    [RelayCommand]
    async Task LoadedAsync()
    {
        var result = await LiveProvider.GetLiveTagDataAsync();
        if (result == null)
            return;
        this.NavListItems = result.Data.List.ToObservableCollection();
        this.SelectionItem = NavListItems[0];
        TabViewService.UpDateProgressRing(_key, Visibility.Collapsed);
    }

    [ObservableProperty]
    ObservableCollection<LiveTagList> _NavListItems = new();

    [ObservableProperty]
    LiveTagList _SelectionItem = null;

    [ObservableProperty]
    ObservableCollection<ILiveTagAreaItemViewModel> _AreaItems = new();

    [RelayCommand]
    void TagSelection(LiveTagList val)
    {
        this.AreaItems = LiveItemFactory
            .CreateLiveTagAreaItems(val.AreaList)
            .ToObservableCollection();
    }

    public void Receive(LiveTagItemBack message)
    {
        if (message.isBack)
        {
            TabItemVisibility = Visibility.Collapsed;
            TabVisibility = Visibility.Visible;
        }
        else
        {
            TabItemVisibility = Visibility.Visible;
            TabVisibility = Visibility.Collapsed;
        }

        TabViewService.UpDateTitle(_key, $"直播标签");
        TabViewService.UpDateIcon(_key, new FontIconSource
        {
            FontFamily = new FontFamily("Segoe Fluent Icons"),
            Glyph = "\uF6BA"
        });
    }

    public async void Receive(LiveTagItemGo message)
    {
        this.LiveTagItemVM = await UserControlViewModelFactory.CreateLiveTagItemViewModel(
            message.data
        );
        TabItemVisibility = Visibility.Visible;
        TabVisibility = Visibility.Collapsed;
        TabViewService.UpDateTitle(_key,$"{message.data.Name} 直播");
        TabViewService.UpDateIcon(_key, new ImageIconSource() { ImageSource = new BitmapImage(new(message.data.Pic))});
    }

    string _key = typeof(LiveTagViewModel).FullName!;

    [ObservableProperty]
    ILiveTagItemViewModel _LiveTagItemVM;

    [ObservableProperty]
    Visibility _TabItemVisibility = Visibility.Collapsed;

    [ObservableProperty]
    Visibility _TabVisibility = Visibility.Visible;

    public ILiveProvider LiveProvider { get; }
    public ILiveItemFactory LiveItemFactory { get; }
    public IUserControlViewModelFactory UserControlViewModelFactory { get; }
    public ITabViewService TabViewService { get; }
}
