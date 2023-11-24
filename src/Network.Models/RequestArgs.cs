namespace Network.Models;

/// <summary>
/// 模块化请求，组装文档用
/// </summary>
public class RequestArgs
{
    /// <summary>
    /// 参数列表
    /// </summary>
    public Dictionary<string,string> Arguments { get; set; }

    /// <summary>
    /// 主机地址
    /// </summary>
    public string Host { get; set; }

    public bool IsCookie { get; set; }

    /// <summary>
    /// 是否需要登录
    /// </summary>
    public bool IsLogin { get; set; }

    public string Name { get; set; }

    public RequestType RequestType { get; set; }
    public HttpMethod HttpMethod { get; set; }
}