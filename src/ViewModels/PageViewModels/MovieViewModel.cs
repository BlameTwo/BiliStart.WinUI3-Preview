using IAppContracts.ItemsViewModels;
using Network.Models.Bangumi;

namespace ViewModels.PageViewModels;

public sealed partial class MovieViewModel : PageViewModelBase
{
    public MovieViewModel(
        IRootNavigationMethod rootNavigationMethod,
        IBangumiProvider bangumiProvider,
        IPgcDataViewModelFactory pgcDataViewModelFactory
    )
        : base(rootNavigationMethod)
    {
        BangumiProvider = bangumiProvider;
        PgcDataViewModelFactory = pgcDataViewModelFactory;
    }

    public IBangumiProvider BangumiProvider { get; }
    public IPgcDataViewModelFactory PgcDataViewModelFactory { get; }

    private BangumiCursor _cursor = null;

    string _Pagetitle;

    public async Task Refersh(string title, bool isrefersh)
    {
        if (isrefersh)
        {
            _cursor = null;
            PgcSource.Clear();
        }
        BangumiModel Data = null;
        if (title == null)
            return;
        this._Pagetitle = title;
        if (title == PgcNavModel.Movie)
        {
            Title = "电影";
            Data = (await BangumiProvider.GetMoviePageInfoAsync(_cursor)).Result;
        }
        else if (title == PgcNavModel.TVPlayer)
        {
            Title = "电视剧";
            Data = (await BangumiProvider.GetDTVPageInfoAsync(_cursor)).Result;
        }
        else if (title == PgcNavModel.MoviePlayer)
        {
            Title = "综艺";
            Data = (await BangumiProvider.GetVarietyPageInfoAsync(_cursor)).Result;
        }
        else if (title == PgcNavModel.MovieREC)
        {
            Title = "纪录片";
            Data = (await BangumiProvider.GetDocumentaryPageInfoAsync(_cursor)).Result;
        }

        foreach (var item in Data.Modules)
        {
            if (item.Style == "common_feed")
            {
                foreach (var obj in item.Items)
                {
                    var result = PgcDataViewModelFactory.CreatePgcItem(obj);
                    this.PgcSource.Add(result);
                }
                this._cursor = Data.Cursor;
            }
        }
    }

    /// <summary>
    /// Find找到的数据
    /// </summary>
    [ObservableProperty]
    ObservableCollection<IPgcItemViewModel> _PgcSource =
        new ObservableCollection<IPgcItemViewModel>();

    [RelayCommand]
    async Task AddData()
    {
        await this.Refersh(this._Pagetitle, false);
    }

    /// <summary>
    /// 更新游标
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    int GetCursor(BangumiModel model)
    {
        foreach (var item in model.Modules)
        {
            if (item.Style != "common_feed")
                continue;
            return item.Items.Count;
        }
        return 0;
    }
}
