using App.Models.Popups;
using System.Collections.Generic;

namespace IAppContracts;

public interface IPopupManagerService
{
    public void ShowImagePopup(List<ImagePopupArgs> args);
}
