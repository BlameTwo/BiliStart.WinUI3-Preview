using IAppContracts.Bases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ViewConverter.Models;

namespace IAppContracts.IUserControlsViewModels;

public interface IPlayerRelatesViewModel : IUserControlVMBase<IEnumerable<PlayerRelatesVideo>>
{
    ObservableCollection<PlayerRelatesVideo> RelatesVideo { get; set; }

    public ITabCreateMethodService TabCreateMethodService { get; }

    void ClickChanged(PlayerRelatesVideo video);
}
