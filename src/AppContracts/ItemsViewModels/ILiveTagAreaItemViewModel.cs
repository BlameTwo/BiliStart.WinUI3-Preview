using CommunityToolkit.Mvvm.Input;
using IAppContracts.Bases;
using Network.Models.Live;

namespace IAppContracts.ItemsViewModels;

public interface ILiveTagAreaItemViewModel : IItemControlVMBase<LiveTagAreaList>
{
    public LiveTagAreaList Base { get; set; }

    public IRelayCommand GoActionCommand { get; }
}
