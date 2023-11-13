namespace Network.Models.Live;

public enum LiveAction
{
    HANDSHAKE = 0,
    HANDSHAKE_REPLY = 1,
    HEARTBEAT = 2,
    HEARTBEAT_REPLY = 3,
    SEND_MSG = 4,
    SEND_MSG_REPLY = 5,
    DISCONNECT_REPLY = 6,
    AUTH = 7,
    AUTH_REPLY = 8,
    RAW = 9,
    PROTO_READY = 10,
    PROTO_FINISH = 11,
    CHANGE_ROOM = 12,
    CHANGE_ROOM_REPLY = 13,
    REGISTER = 14,
    REGISTER_REPLY = 15,
    UNREGISTER = 16,
    UNREGISTER_REPLY = 17
}

public enum ProtoVer
{
    NORMAL = 0,
    HEARTBEAT = 1,
    DEFLATE = 2,
    BROTLI = 3
}

public enum LiveRoomState
{
    /// <summary>
    /// 连接中
    /// </summary>
    Connecting = 0,

    /// <summary>
    /// 错误
    /// </summary>
    Error = 1,

    /// <summary>
    /// 关闭中
    /// </summary>
    Closeing = 2,

    /// <summary>
    /// 已经关闭
    /// </summary>
    Closed = 3,

    /// <summary>
    /// 打开中
    /// </summary>
    Opening = 4,

    /// <summary>
    /// 打开完毕
    /// </summary>
    Opened = 5,

    /// <summary>
    /// 默认None
    /// </summary>
    Default = 6
}
