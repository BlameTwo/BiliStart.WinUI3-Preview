using CommunityToolkit.Mvvm.Input;
using IAppContracts.Bases;
using ViewConverter.Models;

namespace IAppContracts.ItemsViewModels;

public interface IVideoHomeItemViewModel : IItemControlVMBase<HomeVideo>
{
    HomeVideo Base { get; set; }

    IRelayCommand GoActionCommand { get; }

    IAppResources<BiliApplication> AppResource { get; }
}
