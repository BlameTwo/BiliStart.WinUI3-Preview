using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IAppContracts.Bases;
using ViewConverter.Models;

namespace IAppContracts.ItemsViewModels;

public partial interface IVideoHotItemViewModel : IItemControlVMBase<HotVideo>
{
    IRelayCommand GoVideoCommand { get; }
    HotVideo Base { get; set; }

    IAppResources<BiliApplication> AppResources { get; }
}
