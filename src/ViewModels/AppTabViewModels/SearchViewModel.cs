using Bilibili.Polymer.App.Search.V1;
using CommunityToolkit.WinUI.Collections;
using IAppContracts.ItemsViewModels;
using Microsoft.Extensions.DependencyInjection;
using Network.Models.Enum;

namespace ViewModels.AppTabViewModels;

public sealed partial class SearchViewModel : RootViewModelBases, IAppService
{
    public SearchViewModel(
        [FromKeyedServices(NavHostingConfig.RootNav)] INavigationService navigationService,
        ISearchProvider searchProvider,
        ITipShow tipShow,
        IRootNavigationMethod rootNavigationMethod,
        ILocalSetting localSetting,
        IVideoItemFactory videoItemFactory
    )
        : base(rootNavigationMethod, navigationService)
    {
        SearchProvider = searchProvider;
        TipShow = tipShow;
        LocalSetting = localSetting;
        VideoItemFactory = videoItemFactory;
    }

    public bool isFirstload = true;

    int _page;

    string _next = "";

    bool isend = false;

    int _searchItemcount;

    [ObservableProperty]
    Nav _SelectNavitem;

    int _type { get; set; }

    async partial void OnSelectNavitemChanged(Nav? oldValue, Nav newValue)
    {
        isend = false;
        if (newValue == null)
            return;
        await refersh(newValue.Type, false);
    }

    bool allrefersh;

    private List<SearchModelItem> _allitem;

    /// <summary>
    /// 刷新
    /// </summary>
    /// <param name="value">选择的搜索类型</param>
    /// <param name="isadd">是否为新加</param>
    async Task refersh(int value, bool isadd)
    {
        if (isend)
        {
            TipShow.ShowMessage("没有了~o(*￣▽￣*)ブ", Symbol.Like);
            return;
        }
        if (SearchItems == null)
            SearchItems = new();
        SelectOrder = null;
        IsLoaded = true;
        SearchModel model = null;
        if (value == -1)
        {
            allrefersh = isadd;
            SelectOrder = OrderBy[0];
            return;
        }
        if (!isadd)
            this._next = string.Empty;
        model = await SearchProvider.GetSearchTypeAsync(
            this.Keyword,
            value,
            this._searchItemcount,
            _next,TokenSource.Token
        );
        this.isend = model.IsEnd;
        if (model.IsEnd == false)
            this._next = model.Next;
        if (!isadd)
        {
            this.SearchItems.Clear();
            this.SearchItems = VideoItemFactory
                .CreateSearchItems(model.Item)
                .ToObservableCollection();
        }
        else
        {
            this.SearchItems.ObservableAddRange(VideoItemFactory.CreateSearchItems(model.Item));
        }
        this.Fillterenable = false;
        AllMenuShow = Visibility.Collapsed;
        if (this.SearchItems == null || this.SearchItems.Count == 0)
        {
            ItemShow = Visibility.Collapsed;
            ErrorShow = Visibility.Visible;
        }
        else
        {
            ItemShow = Visibility.Visible;
            ErrorShow = Visibility.Collapsed;
        }
        IsLoaded = false;
    }

    [RelayCommand]
    async Task Loaded()
    {
        _searchItemcount = Convert.ToInt32(
            (await LocalSetting.ReadConfig(SettingName.SearchItems)).ToString()
        );
    }

    [RelayCommand]
    async Task AddData()
    {
        if(!IsLoaded)
            await refersh(this.SelectNavitem.Type, true);
    }



    [ObservableProperty]
    ObservableCollection<ISearchItemViewModel> _SearchItems;

    [ObservableProperty]
    ObservableCollection<Nav> _Navs;

    [ObservableProperty]
    Visibility _ErrorShow = Visibility.Collapsed;

    [ObservableProperty]
    Visibility _AllMenuShow = Visibility.Visible;

    [ObservableProperty]
    Visibility _ItemShow = Visibility.Visible;

    [ObservableProperty]
    List<SearchOrderBy> _OrderBy = SearchOrderBy.Defatul();

    [ObservableProperty]
    SearchOrderBy _SelectOrder;

    partial void OnSelectOrderChanged(SearchOrderBy? oldValue, SearchOrderBy newValue)
    {
        if (newValue == null)
            return;
        if (oldValue == null && newValue == null)
            return;

        if (oldValue != null && newValue != null)
        {
            if (oldValue!.Name != newValue.Name)
                allrefersh = false;
            else
                allrefersh = true;
        }
        refershallAsync(newValue!, allrefersh);
    }

    private async void refershallAsync(SearchOrderBy by, bool isadd)
    {
        if (isend == true)
        {
            TipShow.ShowMessage("没有了~o(*￣▽￣*)ブ", Symbol.Like);
            return;
        }
        if (!isadd)
            this._next = "";
        IsLoaded = true;
        AllMenuShow = Visibility.Visible;
        var model = (
            await SearchProvider.GetSearchAllAsync(this.Keyword, _searchItemcount, _next, by.Type,TokenSource.Token)
        );
        this._next = model.IsEnd ? "" : model.Next;
        this.isend = model.IsEnd;
        if (isadd)
            this.SearchItems.ObservableAddRange(VideoItemFactory.CreateSearchItems(model.Item));
        else
            this.SearchItems = VideoItemFactory
                .CreateSearchItems(model.Item)
                .ToObservableCollection();
        this.Fillterenable = true;
        IsLoaded = false;
    }

    [ObservableProperty]
    string _keyword;

    [ObservableProperty]
    bool _datashow = false;

    [ObservableProperty]
    bool _fillterenable;

    [ObservableProperty]
    bool _IsLoaded;

    public string ServiceID { get; set; } = "SearchVM";
    public ISearchProvider SearchProvider { get; }
    public ITipShow TipShow { get; }
    public ILocalSetting LocalSetting { get; }
    public IVideoItemFactory VideoItemFactory { get; }

    async partial void OnKeywordChanged(string value)
    {
        this.SelectNavitem = null;
        this.Title = $"全站搜索：{value}";
        if (!isFirstload)
            return;
        isFirstload = false;
        var result = (
            await SearchProvider.GetSearchAllAsync(this.Keyword, _searchItemcount, _next,  SearchOrderByEnum.Default,TokenSource.Token)
        );
        this.Navs = result.NavHeader.ToObservableCollection();
        Navs.Insert(0, new Nav() { Name = "全部", Type = -1 });
        this.SelectNavitem = Navs[0];
    }
}



