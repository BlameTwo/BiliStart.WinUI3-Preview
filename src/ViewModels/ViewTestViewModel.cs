using ViewConverter.Models.Messager;

namespace ViewModels;

public sealed partial class ViewTestViewModel : PageViewModelBase
{
    public ViewTestViewModel(
        IRootNavigationMethod rootNavigationMethod,
        IVideoProvider videoProvider,
        ISearchProvider searchProvider
    )
        : base(rootNavigationMethod)
    {
        VideoProvider = videoProvider;
        SearchProvider = searchProvider;
    }

    [RelayCommand]
    async Task Loaded()
    {
        var result = await SearchProvider.GetSearchAllAsync("天气之子", 20);
        this.Items = result.Item.ToObservableCollection();
    }

    [ObservableProperty]
    ObservableCollection<SearchModelItem> _Items;

    [RelayCommand]
    void AddData() { }

    public IVideoProvider VideoProvider { get; }
    public ISearchProvider SearchProvider { get; }
}
