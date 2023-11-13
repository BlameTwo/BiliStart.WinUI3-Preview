using IAppContracts.ItemsViewModels;
using ViewConverter.Models.AccountHistory;

namespace ViewModels.ItemViewModels;

public sealed partial class AccountVideoHistoryItemViewModel
    : ObservableObject,
        IAccountVideoHistoryItemViewModel
{
    public AccountVideoHistoryItemViewModel(
        IAppResources<BiliApplication> appResources,
        ITabCreateMethodService tabCreateMethodService
    )
    {
        AppResources = appResources;
        TabCreateMethodService = tabCreateMethodService;
    }

    [ObservableProperty]
    AccountVideoHistoryItem _Base;

    public IAppResources<BiliApplication> AppResources { get; }
    public ITabCreateMethodService TabCreateMethodService { get; }

    public void SetData(AccountVideoHistoryItem value)
    {
        this.Base = value;
    }

    [RelayCommand]
    void GoAction()
    {
        switch (Base.Type)
        {
            case 1:
                TabCreateMethodService.GoNavigationPlayer(
                    new VideoPlayerArgs()
                    {
                        Aid = Base.Aid,
                        Bvid = Base.Bvid,
                    }
                );
                break;
        }
    }
}
