using CommunityToolkit.Mvvm.Input;
using IAppContracts.Bases;
using ViewConverter.Models.AccountHistory;

namespace IAppContracts.ItemsViewModels;

public interface IAccountHistoryLiveItemViewModel: IItemControlVMBase<AccountLiveHistoryItem>
{
    public AccountLiveHistoryItem Base { get; set; }

    public IAppResources<BiliApplication> AppResources { get; }

    public IRelayCommand GoActionCommand { get; }
}
