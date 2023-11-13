using IAppContracts.ItemsViewModels;

namespace ViewModels.PageViewModels;

public sealed partial class RankViewModel : PageViewModelBase, IAppService, IRecipient<TotalRefresh>
{
    public RankViewModel(
        IVideoProvider videoProvider,
        ITidProvider tidProvider,
        IRootNavigationMethod rootNavigationMethod,
        IVideoItemFactory videoItemFactory
    )
        : base(rootNavigationMethod)
    {
        IsActive = true;
        VideoProvider = videoProvider;
        TidProvider = tidProvider;
        VideoItemFactory = videoItemFactory;
        VideoProvider.RankMaxPs = 35;
    }

    private int _pn = 1;
    private int _tid = 0;

    [RelayCommand]
    public async Task AddData()
    {
        _pn++;
        await _adddata();
    }

    public string ServiceID { get; set; } = string.Empty;
    public IVideoProvider VideoProvider { get; }
    public ITidProvider TidProvider { get; }
    public IVideoItemFactory VideoItemFactory { get; }

    async void refersh(int tid)
    {
        _pn = 1;
        var result = await VideoProvider.GetRankListAsync(_pn, tid, this.TokenSource.Token);
        this.Items = VideoItemFactory.CreateVideoRankItems(result).ToObservableCollection();
    }

    async Task _adddata()
    {
        var result = await VideoProvider.GetRankListAsync(_pn, _tid, this.TokenSource.Token);
        this.Items.ObservableAddRange(VideoItemFactory.CreateVideoRankItems(result));
    }


    async void refershtid()
    {
        var tidlist = await TidProvider.GetTidIconListAsync(this.TokenSource.Token);
        var ranklist = TidProvider.FormatRank(tidlist.Data);
        ranklist.Insert(
            0,
            new()
            {
                Tid = 0,
                Uri = "bilibili://rank/",
                Logo =
                    "http://i0.hdslb.com/bfs/archive/34f46c749054b1c3c157b0c1c09a5ef2b3539204.png",
                Name = "全区排行榜"
            }
        );
        this.Tids = ranklist;
    }

    [ObservableProperty]
    ObservableCollection<IVideoRankItemViewModel> _Items = new();

    [ObservableProperty]
    List<TidData> _Tids = new();

    [ObservableProperty]
    int _selectcidindex;

    [RelayCommand]
    void Loaded()
    {
        refershtid();
        this.Selectcidindex = 0;
    }

    [RelayCommand]
    void SelectionTid(TidData data)
    {
        if (data != null)
        {
            refersh(data.Tid);
            this._tid = data.Tid;
        }
    }

    public void Receive(TotalRefresh message)
    {
        if (message.key == "Rank" || message.isrfresh == true)
        {
            refersh(0);
            refershtid();
        }
    }
}
