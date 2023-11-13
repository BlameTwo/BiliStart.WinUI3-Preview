using CommunityToolkit.Mvvm.Input;
using IAppContracts.Bases;
using ViewConverter.Models.AccountHistory;

namespace IAppContracts.ItemsViewModels;

public interface IAccountVideoHistoryItemViewModel: IItemControlVMBase<AccountVideoHistoryItem>
{
    public AccountVideoHistoryItem Base { get; set; }

    public IAppResources<BiliApplication> AppResources { get; }

    public IRelayCommand GoActionCommand { get; }
}
