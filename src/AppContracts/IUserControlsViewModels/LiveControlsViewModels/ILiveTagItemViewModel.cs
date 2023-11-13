using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IAppContracts.ItemsViewModels;
using Network.Models.Live;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace IAppContracts.IUserControlsViewModels.LiveControlsViewModels;

public interface ILiveTagItemViewModel
{
    Task RefershDataAsync(LiveTagAreaList value);

    LiveTagAreaList DataBase { get; set; }

    ObservableCollection<LiveTagItemNewTag> Tags { get; set; }


    ObservableCollection<ILiveTagAreaIndexViewModel> TagItemLists { get; set; }

    LiveTagItemNewTag SelectTag { get; set; }

    IRelayCommand BackCommand { get;  }


    void GoLivePlayer(LiveTagItemList model);

    IAsyncRelayCommand AddDataCommand { get;  }

    IAsyncRelayCommand<LiveTagItemNewTag> SelectTagChangedCommand { get; }

}
