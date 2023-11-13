using Google.Protobuf.WellKnownTypes;
using IAppContracts.ItemsViewModels;

namespace ViewModels.ItemViewModels;

public sealed partial class SearchItemViewModel : ObservableObject, ISearchItemViewModel
{
    public SearchItemViewModel(ITabCreateMethodService tabCreateMethodService)
    {
        TabCreateMethodService = tabCreateMethodService;
    }

    [ObservableProperty]
    SearchModelItem _Base;

    public ITabCreateMethodService TabCreateMethodService { get; }

    [RelayCommand]
    void GoAction()
    {
        if (Base.Source.Goto == "bangumi" || Base.Source.Goto == "movie")
            TabCreateMethodService.GoNavigationPgcPlayer(Base.MovieItem.SSID);
        else if (Base.Source.Goto == "av")
        {
            TabCreateMethodService.GoNavigationPlayer(
                new VideoPlayerArgs()
                {
                    Aid = Base.VideoItem.Av,
                    Bvid = Base.VideoItem.Bvid,
                }
            );
        }
    }

    public void SetData(SearchModelItem value)
    {
        this.Base = value;
    }
}
