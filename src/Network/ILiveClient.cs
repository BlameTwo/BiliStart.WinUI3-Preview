using Network.Models.Live;
using System.Net.WebSockets;
using System.Text.Json;

namespace INetwork;

public interface ILiveClient
{
    event LogOutputDelegate LogOutputEvent;
    event ServerCloseDelegate ServerCloseEvent;
    event ServerConnectionDelegate ServerConnectionEvent;
    event ServerMessageDelegate ServerMessageEvent;

    public Task CloseAsync(
        WebSocketCloseStatus closeStatus = WebSocketCloseStatus.NormalClosure,
        string? statusDescription = null
    );
    Task Connection();
    void ParseReceiveData(byte[] receiveByte);
    void ReceiveMessageData();
    void ReTry();
    Task SendDataAsync(string data, LiveAction operation, bool brotltCompress = false);
}

public delegate void ServerCloseDelegate(object source, string message);

public delegate void LogOutputDelegate(object source, string log);

public delegate void ServerMessageDelegate(object source, JsonElement message);

public delegate void ServerConnectionDelegate(object source, bool IsConnection);
