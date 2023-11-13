using CommunityToolkit.Mvvm.Input;
using IAppContracts.Bases;
using ViewConverter.Models;

namespace IAppContracts.ItemsViewModels;

public interface ISearchItemViewModel : IItemControlVMBase<SearchModelItem>
{
    IRelayCommand GoActionCommand { get; }

    SearchModelItem Base { get; set; }
}
