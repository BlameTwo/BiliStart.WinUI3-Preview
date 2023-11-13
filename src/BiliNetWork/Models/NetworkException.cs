namespace BiliNetWork.Models;

/// <summary>
/// BiliStart网络异常
/// </summary>
public class NetworkException : Exception
{
    public NetworkException(
        NetworkExceptionType type,
        string message,
        HttpRequestMessage requestmessage = null,
        HttpResponseMessage httpResponseMessage = null
    )
    {
        Type = type;
        Requestmessage = requestmessage;
        this.Message = message;
        HttpResponseMessage = httpResponseMessage;
    }

    public override string Message { get; }

    public NetworkExceptionType Type { get; }
    public HttpRequestMessage Requestmessage { get; }
    public HttpResponseMessage HttpResponseMessage { get; }
}

public enum NetworkExceptionType
{
    /// <summary>
    /// Token不正确
    /// </summary>
    Token,

    /// <summary>
    /// 此接口需要登陆
    /// </summary>
    Login,

    /// <summary>
    /// 网络异常
    /// </summary>
    Network,

    /// <summary>
    /// 数据错误
    /// </summary>
    DataError
}
