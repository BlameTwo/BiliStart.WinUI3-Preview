using IAppContracts.ItemsViewModels;
using ViewConverter.Models.AccountHistory;

namespace ViewModels.ItemViewModels;

public partial class AccountHistoryLiveItemViewModel
    : ObservableObject,
        IAccountHistoryLiveItemViewModel
{
    public AccountHistoryLiveItemViewModel(ITabCreateMethodService tabCreateMethodService,IAppResources<BiliApplication> appResources)
    {
        TabCreateMethodService = tabCreateMethodService;
        AppResources = appResources;
    }

    public AccountLiveHistoryItem Base { get; set; }
    public IAppResources<BiliApplication> AppResources { get; }
    public ITabCreateMethodService TabCreateMethodService { get; }

    [RelayCommand]
    void GoAction()
    {
        TabCreateMethodService.GoLivePlayer(this.Base.RoomId);
    }

    public void SetData(AccountLiveHistoryItem value)
    {
        this.Base = value;
    }
}
