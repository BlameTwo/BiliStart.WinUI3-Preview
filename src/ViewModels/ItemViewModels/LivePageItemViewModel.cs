using IAppContracts.ItemsViewModels;
using Network.Models.Live;

namespace ViewModels.ItemViewModels;

public partial class LivePageItemViewModel : ObservableObject, ILivePageItemViewModel
{
    public LivePageItemViewModel(
        IRootNavigationMethod rootNavigationMethod,
        IAppResources<BiliApplication> appResources,
        ITabCreateMethodService tabCreateMethodService
    )
    {
        RootNavigationMethod = rootNavigationMethod;
        AppResources = appResources;
        TabCreateMethodService = tabCreateMethodService;
    }

    [RelayCommand]
    void GoAction()
    {
        TabCreateMethodService.GoLivePlayer(this.Base.LiveCardData.SmallCardV1.Id);
    }

    public void SetData(LiveCardList value)
    {
        this.Base = value;
    }

    [ObservableProperty]
    LiveCardList _Base;

    public IRootNavigationMethod RootNavigationMethod { get; }

    public IAppResources<BiliApplication> AppResources { get; }
    public ITabCreateMethodService TabCreateMethodService { get; }
}
