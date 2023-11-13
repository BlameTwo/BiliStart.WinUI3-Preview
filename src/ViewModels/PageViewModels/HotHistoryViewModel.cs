using IAppContracts.ItemsViewModels;
using Lib.Helper;
using Network.Models.Totals.HotHistory;
using Serilog;

namespace ViewModels.PageViewModels;

public sealed partial class HotHistoryViewModel : PageViewModelBase, IRecipient<TotalRefresh>
{
    public HotHistoryViewModel(
        IRootNavigationMethod root,
        IVideoProvider videoProvider,
        IServiceDataFactory serviceDataFactory,
        IWindowManager windowManager,
        ITipShow tipShow,
        ILogger logger,IVideoItemFactory videoItemFactory
    )
        : base(root)
    {
        VideoProvider = videoProvider;
        ServiceDataFactory = serviceDataFactory;
        WindowManager = windowManager;
        TipShow = tipShow;
        Logger = logger;
        VideoItemFactory = videoItemFactory;
    }

    public IVideoProvider VideoProvider { get; }
    public IServiceDataFactory ServiceDataFactory { get; }
    public IWindowManager WindowManager { get; }
    public ITipShow TipShow { get; }
    public ILogger Logger { get; }
    public IVideoItemFactory VideoItemFactory { get; }

    [RelayCommand]
    async Task Loaded()
    {
        var result = await VideoProvider.GetHotHistoryNavigationAsync(this.TokenSource.Token);
        ServiceDataFactory
            .FormatHotHistoryNavigation(result.Data)
            .ForEach(
                (val) =>
                {
                    this.HotHistoryNavigations.Add(val);
                }
            );
        if (this.SelectPageItem == null)
            this.SelectPageItem = this.HotHistoryNavigations[0];
    }

    [ObservableProperty]
    HotHistoryNavigation _SelectPageItem;

    [ObservableProperty]
    ObservableCollection<HotHistoryNavigation> _HotHistoryNavigations = new();

    async partial void OnSelectPageItemChanged(
        HotHistoryNavigation? oldValue,
        HotHistoryNavigation newValue
    )
    {
        HotHistyryItems.Clear();
        if (newValue == null)
            return;
        ResultCode<HotHistoryNavigationModel>? test = await VideoProvider.GetHotHistoryModelAsync(
            newValue.Id,
            this.TokenSource.Token
        );

        var result = await VideoProvider.GetHotHistoryItemAsync(
            newValue.Id,
            test.Data,
            this.TokenSource.Token
        );
        this.HotHistyryItems = VideoItemFactory.CreateHotHistoryItems(result.Data.Cards.Last().Item).ToObservableCollection();
    }

    [ObservableProperty]
    ObservableCollection<IHotHistoryItemViewModel> _HotHistyryItems = new();

    

    public async void Receive(TotalRefresh message)
    {
        HotHistyryItems.Clear();
        if (SelectPageItem == null)
            return;
        ResultCode<HotHistoryNavigationModel>? test = await VideoProvider.GetHotHistoryModelAsync(
            SelectPageItem.Id,
            this.TokenSource.Token
        );
        var result = await VideoProvider.GetHotHistoryItemAsync(
            SelectPageItem.Id,
            test.Data,
            this.TokenSource.Token
        );
        TipShow.ShowMessage("刷新完毕", Symbol.Accept);
        Logger.LogWrite<HotHistoryViewModel>($"每周必看数据刷新为：{SelectPageItem.Name}");
    }
}
