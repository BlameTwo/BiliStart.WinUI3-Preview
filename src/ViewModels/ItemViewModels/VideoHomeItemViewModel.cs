using IAppContracts;
using IAppContracts.ItemsViewModels;

namespace ViewModels.ItemViewModels;

public partial class VideoHomeItemViewModel : ObservableObject, IVideoHomeItemViewModel
{
    public VideoHomeItemViewModel(
        IRootNavigationMethod rootNavigationMethod,
        IAppResources<BiliApplication> appResource, ITabCreateMethodService tabCreateMethodService
    )
    {
        RootNavigationMethod = rootNavigationMethod;
        AppResource = appResource;
        TabCreateMethodService = tabCreateMethodService;
    }

    [RelayCommand]
    void GoAction()
    {
        VideoPlayerArgs model = new VideoPlayerArgs()
        {
            Aid = Base.Aid,
            Bvid = Base.Bvid,
        };
        TabCreateMethodService.GoNavigationPlayer(model);
    }

    public void SetData(HomeVideo value)
    {
        this.Base = value;
    }

    [ObservableProperty]
    HomeVideo _Base;

    public IRootNavigationMethod RootNavigationMethod { get; }

    public IAppResources<BiliApplication> AppResource { get; }
    public ITabCreateMethodService TabCreateMethodService { get; }
}
