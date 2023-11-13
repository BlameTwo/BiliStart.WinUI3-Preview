using IAppContracts.ItemsViewModels;
using ViewConverter.Models.Messager;

namespace ViewModels.PageViewModels;

public sealed partial class HotViewModel : PageViewModelBase, IAppService, IRecipient<TotalRefresh>
{
    public HotViewModel(
        IVideoProvider videoProvider,
        IWindowManager windowManager,
        IRootNavigationMethod rootNavigationMethod,
        IVideoItemFactory videoItemFactory
    )
        : base(rootNavigationMethod)
    {
        VideoProvider = videoProvider;
        WindowManager = windowManager;
        VideoItemFactory = videoItemFactory;
    }

    long idx = 0;

    [RelayCommand]
    public async Task AddData()
    {
        var result = await VideoProvider.GetHotListAsync(idx, this.TokenSource.Token);
        this.Cards.ObservableAddRange(VideoItemFactory.CreateVideoHotItems(result.HotVideo));
        this.idx = result.Idx;
    }

    [RelayCommand]
    async void Loaded()
    {
        refersh();
    }

    async void refersh()
    {
        var result = await VideoProvider.GetHotListAsync(idx, this.TokenSource.Token);
        this.Cards = VideoItemFactory.CreateVideoHotItems(result.HotVideo).ToObservableCollection();
        this.idx = result.Idx;
    }

    public void Receive(TotalRefresh message)
    {
        if (message.isrfresh)
            this.refersh();
    }

    [ObservableProperty]
    ObservableCollection<IVideoHotItemViewModel> _Cards = new();
    public string ServiceID { get; set; } = "热门";
    public IVideoProvider VideoProvider { get; }
    public IWindowManager WindowManager { get; }
    public IVideoItemFactory VideoItemFactory { get; }
    public INavigationService NavigationService { get; }
}
