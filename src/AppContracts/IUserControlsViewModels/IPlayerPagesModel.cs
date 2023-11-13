using CommunityToolkit.Mvvm.ComponentModel;
using IAppContracts.Bases;
using System;
using System.Collections.ObjectModel;
using ViewConverter.Models;

namespace IAppContracts.IUserControlsViewModels;

public interface IPlayerPagesModel : IUserControlVMBase<Tuple<PlayerView>>
{
    PlayerView View { get; set; }

    ObservableCollection<ViewPage> PlayerPages { get; set; }


    long SpaceCid { get; set; }

}
