using Network.Models.Live;
using Network.Models.Live.Using;
using System.Net.WebSockets;
using System.Xml.Linq;

namespace BiliNetWork.Extensions;

public partial class LiveClient : ILiveClient
{
    public int roomId;
    public Uri chatServer;
    public CancellationTokenSource stopCancellationTokenSource;
    public CancellationToken stopCancellationToken;
    private LiveRoomInfo _info;
    public ClientWebSocket client;
    public LiveRoomState _state = LiveRoomState.Default;
    private readonly int _roomId;
    private readonly int _uid;
    private int reTryCount = 0;

    public LiveClient(LiveRoomInfo info, int roomId, int uid)
    {
        _state = LiveRoomState.Default;
        this._info = info;
        this._roomId = roomId;
        this._uid = uid;
        Init(info);
    }

    private void Init(LiveRoomInfo info)
    {
        stopCancellationTokenSource = new CancellationTokenSource();
        stopCancellationToken = stopCancellationTokenSource.Token;
        this._info = info;
        chatServer = info.HostList.First().ServerWss;
        client = new();

        client.Options.SetRequestHeader("Accept-Encoding", "br");
        client.Options.SetRequestHeader(
            "Accept-Language",
            "zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6"
        );
        client.Options.SetRequestHeader("Cache-Control", "no-cache");
        client.Options.SetRequestHeader("Host", $"{chatServer.Host}:{chatServer.Port}");
        client.Options.SetRequestHeader("Origin", "https://live.bilibili.com");
        client.Options.SetRequestHeader("Pragma", "no-cache");
        client.Options.SetRequestHeader(
            "User-Agent",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/109.0.0.0 Safari/537.36 Edg/109.0.1518.61"
        );
    }

    /// <summary>
    /// 连接弹幕WebSocket服务器并认证、心跳
    /// </summary>
    public async Task Connection()
    {
        if (stopCancellationToken.IsCancellationRequested == true)
            return;
        await client.ConnectAsync(chatServer, stopCancellationToken);
        var auto = new LiveAuthenticationModel(_uid, _roomId, _info.Token);
        await SendDataAsync(JsonSerializer.Serialize(auto), LiveAction.AUTH);
        ReceiveMessageData();
    }

    /// <summary>
    /// 接收回复
    /// </summary>
    public async void ReceiveMessageData()
    {
        List<byte> data = new();
        byte[] buffer = new byte[1024 * 1024 * 4];
        WebSocketReceiveResult result;

        while (true)
        {
            try
            {
                result = await client.ReceiveAsync(
                    new ArraySegment<byte>(buffer),
                    stopCancellationToken
                );
            }
            catch (TaskCanceledException)
            {
                break;
            }
            catch (WebSocketException ex)
            {
                ReTry();
                return;
            }
            data.AddRange(buffer.Take(result.Count));
            if (result.EndOfMessage)
            {
                ParseReceiveData(data.ToArray());
                data = new();
            }
            else
            {
                return;
            }
        }
    }

    /// <summary>
    /// 处理回复信息
    /// </summary>
    /// <param name="receiveByte"></param>
    public async void ParseReceiveData(byte[] receiveByte)
    {
        await Task.Run(() =>
        {
            foreach (JsonElement element in MessageManager.UnPack(receiveByte))
            {
                if (element.TryGetProperty("code", out var code))
                {
                    CheckLiveCode(code);
                }
                else
                {
                    if (this.ServerMessageHandler == null)
                        return;
                    this.ServerMessageHandler.Invoke(this, element);
                }
            }
        });
    }

    private void CheckLiveCode(JsonElement code)
    {
        if (
            code.GetInt32() == 0
            && (this._state == LiveRoomState.Default || this._state == LiveRoomState.Opening)
        )
        {
            this._state = LiveRoomState.Opened;
            if (this.ServerConnectionHandler == null)
                return;
            ServerConnectionHandler.Invoke(this, true);
            Heart();
        }
        else if (code.GetInt32() == 0 && _state == LiveRoomState.Opened)
        {
            //心跳包回复发送
        }
    }

    private async void Heart()
    {
        while (true)
        {
            if (_state != LiveRoomState.Opened)
                break;
            await SendDataAsync("", LiveAction.HEARTBEAT);
            await Task.Delay(30000);
        }
    }

    public async Task SendDataAsync(string data, LiveAction operation, bool brotltCompress = false)
    {
        if (client.State == WebSocketState.Open && !stopCancellationToken.IsCancellationRequested)
        {
            await client.SendAsync(
                MessageManager.Pack(data, operation, brotltCompress),
                WebSocketMessageType.Binary,
                true,
                stopCancellationToken
            );
        }
    }

    public async void ReTry()
    {
        if (this._state == LiveRoomState.Closed)
            return;
        if (reTryCount < 5)
        {
            reTryCount++;
            Console.WriteLine($"服务器连接失败，重试第{reTryCount}次");
            stopCancellationTokenSource.Cancel();
            stopCancellationTokenSource.Dispose();
            stopCancellationTokenSource = new();
            stopCancellationToken = stopCancellationTokenSource.Token;
            client = new ClientWebSocket();
            client.Options.SetRequestHeader("Accept-Encoding", "br");
            client.Options.SetRequestHeader(
                "Accept-Language",
                "zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6"
            );
            client.Options.SetRequestHeader("Cache-Control", "no-cache");
            client.Options.SetRequestHeader("Host", $"{chatServer.Host}:{chatServer.Port}");
            client.Options.SetRequestHeader("Origin", "https://live.bilibili.com");
            client.Options.SetRequestHeader("Pragma", "no-cache");
            client.Options.SetRequestHeader(
                "User-Agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/109.0.0.0 Safari/537.36 Edg/109.0.1518.61"
            );
            await Connection();
        }
        else
        {
            await CloseAsync();
        }
    }

    public async Task CloseAsync(
        WebSocketCloseStatus closeStatus = WebSocketCloseStatus.NormalClosure,
        string? statusDescription = null
    )
    {
        if (client.State == WebSocketState.Open)
        {
            Console.WriteLine("Close");
            this._state = LiveRoomState.Closed;
            await client.CloseAsync(closeStatus, statusDescription, CancellationToken.None);
            stopCancellationTokenSource.Cancel();
            client.Dispose();
            if (this.ServerCloseHandler == null)
                return;
            this.ServerCloseHandler.Invoke(this, "正常关闭或超时关闭");
        }
    }
}
