using CommunityToolkit.Mvvm.Input;
using IAppContracts.Bases;
using Network.Models.Totals.HotHistory;

namespace IAppContracts.ItemsViewModels;

public interface IHotHistoryItemViewModel: IItemControlVMBase<HotHistoryNavItem>
{
    HotHistoryNavItem Base { get; set; }

    IRelayCommand GoActionCommand { get; }
}
