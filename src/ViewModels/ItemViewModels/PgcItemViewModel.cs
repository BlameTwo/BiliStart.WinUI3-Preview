using IAppContracts.ItemsViewModels;
using Network.Models.Bangumi;

namespace ViewModels.ItemViewModels;

public partial class PgcItemViewModel : ObservableObject, IPgcItemViewModel
{
    private ModelItems _base;

    public ModelItems Base
    {
        get { return _base; }
        set => SetProperty(ref _base, value);
    }

    [RelayCommand]
    void GoPGC() => TabCreateMethodService.GoNavigationPgcPlayer(Base.SeasonId);

    public PgcItemViewModel(
        IBangumiProvider bangumiProvider,
        ITabCreateMethodService tabCreateMethodService,
        IAppResources<BiliApplication> appResources
    )
    {
        BangumiProvider = bangumiProvider;
        TabCreateMethodService = tabCreateMethodService;
        AppResources = appResources;
    }

    public IRootNavigationMethod RootNavigationMethod { get; }
    public IBangumiProvider BangumiProvider { get; }
    public ITabCreateMethodService TabCreateMethodService { get; }
    public IAppResources<BiliApplication> AppResources { get; }
}
