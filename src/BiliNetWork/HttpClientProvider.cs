namespace BiliNetWork;

public sealed class HttpClientProvider : IHttpClientProvider
{
    private HttpClient _client;

    public IRequestMessage RequestMessage { get; }

    ~HttpClientProvider()
    {
        _client.Dispose();
    }

    public HttpClientProvider(IRequestMessage requestMessage)
    {
        RequestMessage = requestMessage;
    }

    public void InitClient()
    {

        if (_client != null)
        {
            _client.Dispose();
            _client = null;
        }
        _client = GetClient(true);
    }

    HttpClient GetClient(bool ifGrpc)
    {
        ServicePointManager.SecurityProtocol =
            SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        var handler = new HttpClientHandler
        {
            AllowAutoRedirect = true,
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.None,
            UseCookies = true,

        };
        var client = new HttpClient(handler);
        client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue
        {
            NoCache = false,
            NoStore = false
        };
        if( ifGrpc )
            client.DefaultRequestHeaders.Connection.Add("Keep-Alive");
        client.DefaultRequestHeaders.Add(
            "accept",
            "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9"
        );
        return client;
    }

    public async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage message,
        CancellationToken token = default
    )
    {
        try
        {
            var reponse =  await _client.SendAsync(message, token);
            this.RequestMessage.AddRequest(message, reponse);
            return reponse;
        }
        catch (Exception)
        {
            this.InitClient();
            return null;
        }
    }

    public async Task<Stream> SendToStreamAsync(
        HttpRequestMessage message,
        CancellationToken token = default
    )
    {
        var resultresponse = await SendAsync(message, token);
        resultresponse.EnsureSuccessStatusCode();
        return await resultresponse.Content.ReadAsStreamAsync(token);
    }

    public async Task<string> SendToStringAsync(
        HttpRequestMessage message,
        CancellationToken token = default
    )
    {
        var resultresponse = await SendAsync(message, token);
        resultresponse.EnsureSuccessStatusCode();
        return await resultresponse.Content.ReadAsStringAsync(token);
    }
}
