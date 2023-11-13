using CommunityToolkit.Mvvm.Input;
using IAppContracts.Bases;
using Network.Models.Live;

namespace IAppContracts.ItemsViewModels;

public interface ILiveTagAreaIndexViewModel : IItemControlVMBase<LiveTagItemList>
{
    public LiveTagItemList Base { get; set; }

    public IAppResources<BiliApplication> AppResources { get; }

    public IRelayCommand GoActionCommand { get; }
}
