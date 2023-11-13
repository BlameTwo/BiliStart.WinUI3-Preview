using App.Models.Popups;
using Views.ContentPopups;

namespace AppContractService.Services;

public class PopupManagerService : IPopupManagerService
{
    public PopupManagerService(IWindowManager windowManager)
    {
        WindowManager = windowManager;
    }

    public IWindowManager WindowManager { get; }

    public void ShowImagePopup(List<ImagePopupArgs> args)
    {
        var popup = AppService.GetService<ImagePopup>();
        popup.SetUri(args);
        WindowManager.ShowContentPopup(popup);
    }
}
