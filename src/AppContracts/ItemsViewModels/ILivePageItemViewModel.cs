using CommunityToolkit.Mvvm.Input;
using IAppContracts.Bases;
using Network.Models.Live;

namespace IAppContracts.ItemsViewModels;

public interface ILivePageItemViewModel : IItemControlVMBase<LiveCardList>
{
    public IAppResources<BiliApplication> AppResources { get; }
    public LiveCardList Base { get; set; }

    public IRelayCommand GoActionCommand { get; }
}
