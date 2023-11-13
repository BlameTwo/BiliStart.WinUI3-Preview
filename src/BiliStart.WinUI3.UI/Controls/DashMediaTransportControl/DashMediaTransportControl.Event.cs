using BiliStart.WinUI3.UI.Controls.MediaPlayer;

namespace BiliStart.WinUI3.UI.Controls;

partial class DashMediaTransportControl
{
    private MaxScreenClickDelegate MaxScreenClickHandle;

    public event MaxScreenClickDelegate MaxScreenClick
    {
        add { MaxScreenClickHandle += value; }
        remove { MaxScreenClickHandle -= value; }
    }

    private TopScreenClickDelegate TopScreenClickHandle;

    public event TopScreenClickDelegate TopScreenClick
    {
        add { TopScreenClickHandle += value; }
        remove { TopScreenClickHandle -= value; }
    }

    /// <summary>
    /// 清晰度列表筛选
    /// </summary>
    public event QualityListChangedDelegate QualityChanged
    {
        add { QualityListChangedHandle += value; }
        remove { QualityListChangedHandle -= value; }
    }

    public event MediaTranControlLoadedDelegate OpenedChanged
    {
        add { MediaTranControlLoadedHandler += value; }
        remove { MediaTranControlLoadedHandler -= value; }
    }

    private QualityListChangedDelegate QualityListChangedHandle;

    private MediaTranControlLoadedDelegate MediaTranControlLoadedHandler;

    private ChangedStateDelegate ChangeStateHandle;

    public event ChangedStateDelegate ChangedState
    {
        add { ChangeStateHandle += value; }
        remove { ChangeStateHandle -= value; }
    }

    private PlayerProgressChangedDelegate PlayerProgressHandler;
    public event PlayerProgressChangedDelegate PlayerProgressChanged
    {
        add { PlayerProgressHandler += value; }
        remove { PlayerProgressHandler -= value; }
    }

    private DanmakuStateChangedDelegate DanmakuStateChangedHandler;

    public event DanmakuStateChangedDelegate DanmakuStateChanged
    {
        add => DanmakuStateChangedHandler += value;
        remove => DanmakuStateChangedHandler -= value;
    }
}
