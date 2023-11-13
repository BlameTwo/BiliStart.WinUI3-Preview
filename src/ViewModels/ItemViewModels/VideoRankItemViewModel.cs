using Google.Protobuf.WellKnownTypes;
using IAppContracts.ItemsViewModels;

namespace ViewModels.ItemViewModels;

public partial class VideoRankItemViewModel : ObservableObject, IVideoRankItemViewModel
{
    public VideoRankItemViewModel(
        IAppResources<BiliApplication> appResources,
        ITabCreateMethodService tabCreateMethodService
    )
    {
        AppResources = appResources;
        TabCreateMethodService = tabCreateMethodService;
    }

    [ObservableProperty]
    RankVideo _Base;

    public IAppResources<BiliApplication> AppResources { get; }
    public ITabCreateMethodService TabCreateMethodService { get; }
    public IRootNavigationMethod RootNavigationMethod { get; }

    public void SetData(RankVideo value)
    {
        this.Base = value;
    }

    [RelayCommand]
    void GoAction()
    {
        TabCreateMethodService.GoNavigationPlayer(
            new VideoPlayerArgs()
            {
                Aid = Base.Aid,
                Bvid = Base.Bvid,
            }
        );
    }
}
