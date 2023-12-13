using Bilibili.Main.Community.Reply.V1;
using System.Net.NetworkInformation;
using System;

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
        var token = (await TokenManager.GetToken(Current.TokenName));
        if (canceltoken.IsCancellationRequested == true)
            return default;
        requestMessage.Version = HttpVersion.Version20;
        var grpcConfig = new gRpcConfig(token.AccessToken);
        var userAgent =
            $"bili-universal/62800300 "
            + $"os/ios model/{gRpcConfig.Model} mobi_app/iphone "
            + $"osVer/{gRpcConfig.OSVersion} "
            + $"network/{gRpcConfig.NetworkType} "
            + $"grpc-objc/1.32.0 grpc-c/12.0.0 (ios; cronet_http)";
        if (!string.IsNullOrWhiteSpace(token.AccessToken))
        {
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue(
                "identify_v1",
                token.AccessToken
            );
            ;
        }
        var buvid = GetBuvid();
        requestMessage.Headers.Add(GrpcHeaders.UserAgent, userAgent);
        requestMessage.Headers.Add(GrpcHeaders.AppKey, gRpcConfig.MobileApp);
        requestMessage.Headers.Add("buvid", buvid);
        requestMessage.Headers.Add(GrpcHeaders.BiliDevice, grpcConfig.GetDeviceBin(buvid));
        requestMessage.Headers.Add(GrpcHeaders.BiliFawkes, grpcConfig.GetFawkesreqBin());
        requestMessage.Headers.Add(GrpcHeaders.BiliLocale, grpcConfig.GetLocaleBin());
        requestMessage.Headers.Add(GrpcHeaders.GRPCTimeOutKey, GrpcHeaders.GRPCTimeOutValue);
        requestMessage.Headers.Add(GrpcHeaders.Envoriment, GrpcHeaders.Envorienment);
        requestMessage.Headers.Add(GrpcHeaders.BiliMeta, grpcConfig.GetMetadataBin(buvid));
        requestMessage.Headers.Add(GrpcHeaders.BiliNetwork, grpcConfig.GetNetworkBin());
        requestMessage.Headers.Add(GrpcHeaders.BiliRestriction, grpcConfig.GetRestrictionBin());
        requestMessage.Headers.Add(
            GrpcHeaders.GRPCAcceptEncodingKey,
            GrpcHeaders.GRPCAcceptEncodingValue
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

    private string GetBuvid()
    {
        var macAddress = NetworkInterface
            .GetAllNetworkInterfaces()
            .Where(
                nic =>
                    nic.OperationalStatus == OperationalStatus.Up
                    && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback
            )
            .Select(nic => nic.GetPhysicalAddress().ToString())
            .FirstOrDefault();
        var buvidObj = new Buvid(macAddress);
        return buvidObj.Generate();
    }

    private string GenRandomString(int length)
    {
        var random = new Random();
        const string charset = "0123456789abcdefghijklmnopqrstuvwxyz";
        var randomString = new StringBuilder(length);
        for (var i = 0; i < length; i++)
        {
            _ = randomString.Append(charset[random.Next(charset.Length)]);
        }

        return randomString.ToString();
    }

    public string GetTraceId()
    {
        var random_id = GenRandomString(32);
        var random_trace_id = new StringBuilder(40);
        _ = random_trace_id.Append(random_id[..24]);
        var b_arr = new sbyte[3];
        var ts = DateTimeOffset.Now.ToUnixTimeSeconds();
        for (var i = 2; i >= 0; i--)
        {
            ts >>= 8;
            b_arr[i] = ((ts / 128) % 2) == 0 ? (sbyte)(ts % 256) : (sbyte)((ts % 256) - 256);
        }
        for (var i = 0; i < 3; i++)
        {
            _ = random_trace_id.Append(b_arr[i].ToString("x2"));
        }
        _ = random_trace_id.Append(random_id.Substring(30, 2));
        var random_trace_id_final = new StringBuilder(64);
        _ = random_trace_id_final.Append(random_trace_id);
        _ = random_trace_id_final.Append(":");
        _ = random_trace_id_final.Append(random_trace_id.ToString(16, 16));
        _ = random_trace_id_final.Append(":0:0");
        return random_trace_id_final.ToString();
    }

    public string GetAuroraEid(long uid)
    {
        if (uid == 0)
        {
            return string.Empty;
        }

        var resultByte = new List<byte>(64);
        var midByte = Encoding.UTF8.GetBytes(uid.ToString());
        for (var i = 0; i < midByte.Length; i++)
        {
            resultByte.Add((byte)(midByte[i] ^ Encoding.UTF8.GetBytes("ad1va46a7lza")[i % 12]));
        }
        return Convert.ToBase64String(resultByte.ToArray()).TrimEnd('=');
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

    public async Task<HttpRequestMessage> GetHttpRequestMesageAsync(
        RequestArgs args,
        CancellationToken token = default
    )
    {
        HttpRequestMessage message = new();
        if (args.RequestType == RequestType.Android)
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
