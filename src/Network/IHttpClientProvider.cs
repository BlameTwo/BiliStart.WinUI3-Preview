using Google.Protobuf;
using Network.Models;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace INetwork;

public interface IHttpClientProvider
{
    /// <summary>
    /// 转换为String
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public Task<string> SendToStringAsync(
        HttpRequestMessage message,
        CancellationToken token = default
    );

    /// <summary>
    /// 转换为Stream
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public Task<Stream> SendToStreamAsync(
        HttpRequestMessage message,
        CancellationToken token = default
    );

    /// <summary>
    /// 原本数据
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage message,
        CancellationToken token = default
    );

    /// <summary>
    /// 初始化客户端请求器
    /// </summary>
    public void InitClient();
}
