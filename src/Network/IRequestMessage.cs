using Google.Protobuf;
using Network.Models;
using Network.Models.Accounts;

namespace INetwork;

/// <summary>
/// 组装请求接口
/// </summary>
public interface IRequestMessage
{
    /// <summary>
    /// 综合性的请求接口
    /// </summary>
    /// <param name="url">url</param>
    /// <param name="clienttype">客户机类型</param>
    /// <param name="method">请求方式</param>
    /// <param name="valuePairs">参数列表</param>
    /// <param name="isaccess">是否需要token</param>
    /// <param name="iscookie">是否需要cookie</param>
    /// <param name="issign">是否需要签名</param>
    /// <param name="logindata">单次请求Token</param>
    /// <returns></returns>
    public Task<HttpRequestMessage> GetHttpRequestMessageAsync(
        string url,
        RequestType clienttype,
        HttpMethod method,
        Dictionary<string, string> valuePairs,
        bool isaccess,
        bool iscookie,
        bool issign,
        AccountToken logindata = null,
        CancellationToken token = default
    );

    public Task<HttpRequestMessage> GetHttpRequestMesageAsync(RequestArgs args,CancellationToken token = default);

    /// <summary>
    /// 获得Grpc请求方式
    /// </summary>
    /// <param name="url"></param>
    /// <param name="grpcmessage"></param>
    /// <returns></returns>
    public Task<HttpRequestMessage> GetHttpRequestMessageAsync(
        string url,
        IMessage grpcmessage,
        CancellationToken canceltoken = default
    );

    public HttpRequestMessage GetHttpRequestMessageAsync(
        string url,
        HttpMethod method,
        Dictionary<string, string> values
    );

    public Task<HttpRequestMessage> GetThirdRequestAsync(CancellationToken canceltoken = default);

    public Task<HttpRequestMessage> GetAccessTokenAsync(
        TokenThird tokenThird,
        CancellationToken canceltoken = default
    );

    public int MaxCache { get; set; }

    public List<Tuple<HttpRequestMessage, HttpResponseMessage>> GetHistoryRequest();

    public void AddRequest(HttpRequestMessage request, HttpResponseMessage httpResponseMessage);
}
