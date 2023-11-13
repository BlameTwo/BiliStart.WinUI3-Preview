namespace Views.Models;

public class BiliStartNotifyControl : ContentVM<IBiliStartNotifyViewModel>
{
    public override void ViewModelChanged()
    {
        this.ViewModel.WindowManager.WindowHideChanged += WindowManager_WindowHideChanged;
    }

    private void WindowManager_WindowHideChanged(Window _window, bool isShow)
    {
        this.ViewModel._isshow = isShow;
    }
}
