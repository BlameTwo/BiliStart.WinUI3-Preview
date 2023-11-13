using BiliStart.WinUI3.UI.Controls.MediaPlayer;

namespace BiliStart.WinUI3.UI.Controls;

partial class DashMediaPlayerElement
{
    private TransportQualityListChangedDelegate TransportQualityListChangedHandler;

    public event TransportQualityListChangedDelegate TransportQualityListChanged
    {
        add { TransportQualityListChangedHandler += value; }
        remove { TransportQualityListChangedHandler -= value; }
    }

    private PlayerProgressChangedDelegate PlayerProgressHandler;

    public event PlayerProgressChangedDelegate PlayerProgressChanged
    {
        add { PlayerProgressHandler += value; }
        remove { PlayerProgressHandler -= value; }
    }

    private DanmakuSendDelegate DanmakuSendHandler;

    public event DanmakuSendDelegate DanmakuSend
    {
        add => DanmakuSendHandler += value;
        remove => DanmakuSendHandler -= value;
    }

    private PlayerOpenedDelegate PlayerOpenedHandler;

    public event PlayerOpenedDelegate PlayOpenedEvent
    {
        add { PlayerOpenedHandler += value; }
        remove { PlayerOpenedHandler -= value; }
    }

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

    private ChangedStateDelegate ChangeStateHandle;

    public event ChangedStateDelegate ChangedState
    {
        add { ChangeStateHandle += value; }
        remove { ChangeStateHandle -= value; }
    }

    private DanmakuStateChangedDelegate DanmakuStateChangedHandler;

    public event DanmakuStateChangedDelegate DanmakuStateChanged
    {
        add => DanmakuStateChangedHandler += value;
        remove => DanmakuStateChangedHandler -= value;
    }
}
