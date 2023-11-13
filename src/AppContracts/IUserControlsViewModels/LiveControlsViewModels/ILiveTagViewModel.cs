using CommunityToolkit.Mvvm.Input;
using IAppContracts.Bases;
using IAppContracts.ItemsViewModels;
using Network.Models.Live;
using System.Collections.ObjectModel;

namespace IAppContracts.IUserControlsViewModels.LiveControlsViewModels;

public interface ILiveTagViewModel : IUserControlVMBase<LiveTagList>
{
    LiveTagList DataBase { get; set; }

    ObservableCollection<ILiveTagAreaItemViewModel> AreaItems { get; set; }
}
