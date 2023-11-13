namespace ViewModels.ContentPopupViewModels;

public partial class ImagePopupViewModels:ObservableRecipient
{
    public ImagePopupViewModels(IWindowManager windowManager)
    {
        WindowManager = windowManager;
    }

    public IWindowManager WindowManager { get; }
}
