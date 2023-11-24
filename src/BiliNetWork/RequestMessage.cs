using Bilibili.Main.Community.Reply.V1;

namespace BiliNetWork;

public sealed class RequestMessage : IRequestMessage, IAppService
{
    public RequestMessage(
        ICurrent current,
        IHttpExtensions httpExtensions,
        ITokenManager tokenManager
    )
    {
        Current = current;
        HttpExtensions = httpExtensions;
        TokenManager = tokenManager;
    }

    public string ServiceID { get; set; } = nameof(RequestMessage);

    public ICurrent Current { get; }
    public IHttpExtensions HttpExtensions { get; }
    public ITokenManager TokenManager { get; }
    public int MaxCache { get; set; } = 25;

    public readonly List<Tuple<HttpRequestMessage, HttpResponseMessage>> _historyHistory = new();

    public async Task<HttpRequestMessage> GetAccessTokenAsync(
        TokenThird tokenThird,
        CancellationToken canceltoken = default
    )
    {
        HttpRequestMessage message = new(HttpMethod.Get, tokenThird.Data.ConfirmUrl);
        message.Headers.Add("Cookie", await Current.GetAccessCookieAsync());
        if (canceltoken.IsCancellationRequested == true)
            return default;
        return message;
    }

    public List<Tuple<HttpRequestMessage, HttpResponseMessage>> GetHistoryRequest()
    {
        return _historyHistory;
    }

    public async Task<HttpRequestMessage> GetHttpRequestMessageAsync(
        string url,
        IMessage grpcmessage,
        CancellationToken canceltoken = default
    )
    {
        var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
        var token = (await TokenManager.GetToken(Current.TokenName)).AccessToken;
        if (canceltoken.IsCancellationRequested == true)
            return default;
        requestMessage.Version = HttpVersion.Version20;
        var grpcConfig = new gRpcConfig(token);
        var userAgent =
            $"bili-universal/{Apis.Build} "
            + $"os/ios model/{gRpcConfig.Model} mobi_app/iphone "
            + $"osVer/{gRpcConfig.OSVersion} "
            + $"network/{gRpcConfig.NetworkType} "
            + $"grpc-objc/1.32.0 grpc-c/12.0.0 (ios; cronet_http)";
        if (!string.IsNullOrWhiteSpace(token))
        {
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue(
                "identify_v1",
                token
            );
            ;
        }
        requestMessage.Headers.Add(GrpcHeaders.UserAgent, userAgent);
        requestMessage.Headers.Add(GrpcHeaders.AppKey, gRpcConfig.MobileApp);
        requestMessage.Headers.Add(GrpcHeaders.BiliDevice, grpcConfig.GetDeviceBin());
        requestMessage.Headers.Add(GrpcHeaders.BiliFawkes, grpcConfig.GetFawkesreqBin());
        requestMessage.Headers.Add(GrpcHeaders.BiliLocale, grpcConfig.GetLocaleBin());
        requestMessage.Headers.Add(GrpcHeaders.BiliMeta, grpcConfig.GetMetadataBin());
        requestMessage.Headers.Add(GrpcHeaders.BiliNetwork, grpcConfig.GetNetworkBin());
        requestMessage.Headers.Add(GrpcHeaders.BiliRestriction, grpcConfig.GetRestrictionBin());
        requestMessage.Headers.Add(
            GrpcHeaders.GRPCAcceptEncodingKey,
            GrpcHeaders.GRPCAcceptEncodingValue
        );
        requestMessage.Headers.Add(GrpcHeaders.GRPCTimeOutKey, GrpcHeaders.GRPCTimeOutValue);
        requestMessage.Headers.Add(GrpcHeaders.Envoriment, gRpcConfig.Envorienment);
        requestMessage.Headers.Add(
            GrpcHeaders.TransferEncodingKey,
            GrpcHeaders.TransferEncodingValue
        );
        requestMessage.Headers.Add(GrpcHeaders.TEKey, GrpcHeaders.TEValue);
        var messageBytes = grpcmessage.ToByteArray();
        requestMessage.Version = HttpVersion.Version20;
        var stateBytes = new byte[] { 0, 0, 0, 0, (byte)messageBytes.Length };
        var bodyBytes = new byte[5 + messageBytes.Length];
        stateBytes.CopyTo(bodyBytes, 0);
        messageBytes.CopyTo(bodyBytes, 5);
        var byteArrayContent = new ByteArrayContent(bodyBytes);
        byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(
            GrpcHeaders.GRPCContentType
        );
        byteArrayContent.Headers.ContentLength = bodyBytes.Length;
        requestMessage.Content = byteArrayContent;
        return requestMessage;
    }

    public async Task<HttpRequestMessage> GetHttpRequestMessageAsync(
        string url,
        RequestType clienttype,
        HttpMethod method,
        Dictionary<string, string> valuePairs,
        bool isaccess,
        bool iscookie,
        bool issign,
        AccountToken logindata = null,
        CancellationToken token = default
    )
    {
        if (token.IsCancellationRequested == true)
            return null;
        HttpRequestMessage message = new();
        if (clienttype == RequestType.Android)
        { //这里增加一个UA来法昂之鉴权失败，与Grpc的请求UA基本一致，不过有些不同。
            message.Headers.Add(
                "User-Agent",
                $"Mozilla/5.0 BiliDroid/7.43.0 (bbcallen@gmail.com) os/android model/ALA-AN70 mobi_app/android build/{Apis.Build} channel/bili innerVer/7430300 osVer/12 network/2"
            );
        }
        var cookie = await Current.GetAccessCookieAsync();
        if (token.IsCancellationRequested == true)
            return null;
        if (iscookie && cookie != null)
            message.Headers.Add("Cookie", cookie);
        if (method == HttpMethod.Get)
        {
            var quest = await HttpExtensions.GetClientType(
                valuePairs,
                clienttype,
                isaccess,
                issign,
                logindata
            );
            url += $"?{quest}";
            message.RequestUri = new Uri(url);
        }
        else if (method == HttpMethod.Post)
        {
            var quest = await HttpExtensions.GetClientType(
                valuePairs,
                clienttype,
                isaccess,
                issign,
                logindata
            );
            message.Content = new StringContent(
                quest,
                Encoding.UTF8,
                "application/x-www-form-urlencoded"
            );
            message.RequestUri = new(url);
        }
        if (token.IsCancellationRequested == true)
            return null;
        message.Method = method;
        return message;
    }

    public HttpRequestMessage GetHttpRequestMessageAsync(
        string url,
        HttpMethod method,
        Dictionary<string, string> values
    )
    {
        string quest = url;
        HttpRequestMessage request = new();
        request.Method = method;
        if (values.Count != 0)
        {
            var questlist = values.Select(x => $"{x.Key}={x.Value}");
            quest += "?" + string.Join("&", questlist);
            request.RequestUri = new Uri(quest);
        }
        return request;
    }

    public async Task<HttpRequestMessage> GetThirdRequestAsync(
        CancellationToken canceltoken = default
    )
    {
        HttpRequestMessage requestmessage = new();
        requestmessage.Method = HttpMethod.Get;
        requestmessage.Headers.Add("Cookie", await Current.GetAccessCookieAsync());
        if (canceltoken.IsCancellationRequested == true)
            return default;
        requestmessage.RequestUri = new(Apis.BILIBILI_TV_Third);
        return requestmessage;
    }

    public void AddRequest(HttpRequestMessage request, HttpResponseMessage httpResponseMessage)
    {
        this._historyHistory.Add(new(request, httpResponseMessage));
    }

    public async Task<HttpRequestMessage> GetHttpRequestMesageAsync(RequestArgs args, CancellationToken token = default)
    {
         HttpRequestMessage message = new();
        if(args.RequestType == RequestType.Android)
        {
            message.Headers.Add(
                "User-Agent",
                $"Mozilla/5.0 BiliDroid/7.43.0 (bbcallen@gmail.com) os/android model/ALA-AN70 mobi_app/android build/{Apis.Build} channel/bili innerVer/7430300 osVer/12 network/2"
            );
        }
        if (args.IsCookie)
        {
            var cookie = await Current.GetAccessCookieAsync();
            if (token.IsCancellationRequested == true)
                return null;
            message.Headers.Add("Cookie", cookie);
        }
        var quest = await HttpExtensions.GetClientType(
                args.Arguments,
                args.RequestType,
                args.IsLogin,
                args.IsLogin
            );
        var url = args.Host;
        if (args.HttpMethod == HttpMethod.Get)
        {
            url += $"?{quest}";
        }
        else if (args.HttpMethod == HttpMethod.Post)
        {
            message.Content = new StringContent(
                quest,
                Encoding.UTF8,
                "application/x-www-form-urlencoded"
            );
        }
        message.RequestUri = new Uri(url);
        message.Method = args.HttpMethod;
        return message;
    }
}
