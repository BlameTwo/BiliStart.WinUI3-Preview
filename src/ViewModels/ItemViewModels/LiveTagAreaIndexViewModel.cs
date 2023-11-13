using IAppContracts.ItemsViewModels;
using Network.Models.Live;

namespace ViewModels.ItemViewModels;

public partial class LiveTagAreaIndexViewModel : ObservableObject, ILiveTagAreaIndexViewModel
{
    public LiveTagAreaIndexViewModel(
        IAppResources<BiliApplication> appResources,
        IRootNavigationMethod rootNavigationMethod,ITabCreateMethodService tabCreateMethodService
    )
    {
        AppResources = appResources;
        RootNavigationMethod = rootNavigationMethod;
        TabCreateMethodService = tabCreateMethodService;
    }

    [RelayCommand]
    void GoAction()
    {
        TabCreateMethodService.GoLivePlayer(Base.Roomid);
    }

    public void SetData(LiveTagItemList value)
    {
        this.Base = value;
    }

    [ObservableProperty]
    LiveTagItemList _Base;

    public IAppResources<BiliApplication> AppResources { get; }
    public IRootNavigationMethod RootNavigationMethod { get; }
    public ITabCreateMethodService TabCreateMethodService { get; }
}
