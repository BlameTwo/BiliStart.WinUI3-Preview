/*
 2023.7.9
此类主要管理应用的简单消息弹出。
 */

namespace AppContractService.Services;

public sealed class TipShow : ITipShow
{
    private Panel _owner;

    public Panel Owner
    {
        get { return _owner; }
        set { _owner = value; }
    }

    public void ShowMessage(string message, Symbol icon)
    {
        PopupDialog popup = new(message, Owner, icon);
        popup.ShowPopup();
    }
}
