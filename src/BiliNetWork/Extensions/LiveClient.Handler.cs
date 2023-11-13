namespace BiliNetWork.Extensions;

partial class LiveClient
{
    private LogOutputDelegate LogOutputHandler;

    public event LogOutputDelegate LogOutputEvent
    {
        add => LogOutputHandler += value;
        remove => LogOutputHandler -= value;
    }

    private ServerMessageDelegate ServerMessageHandler;

    public event ServerMessageDelegate ServerMessageEvent
    {
        add => ServerMessageHandler += value;
        remove => ServerMessageHandler -= value;
    }

    private ServerConnectionDelegate ServerConnectionHandler;

    public event ServerConnectionDelegate ServerConnectionEvent
    {
        add => ServerConnectionHandler += value;
        remove => ServerConnectionHandler -= value;
    }

    private ServerCloseDelegate ServerCloseHandler;

    public event ServerCloseDelegate ServerCloseEvent
    {
        add => ServerCloseHandler += value;
        remove => ServerCloseHandler -= value;
    }
}
