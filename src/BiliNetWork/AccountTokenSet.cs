using LanguageExt;
namespace BiliNetWork;

public sealed class AccountTokenSet : IAccountTokenSet
{
    HttpClient httpclient = new();

    public AccountTokenSet(
        ICurrent current,
        IHttpClientProvider httpClientProvider,
        IRequestMessage requestMessage
    )
    {
        Current = current;
        HttpClientProvider = httpClientProvider;
        RequestMessage = requestMessage;
    }

    public ICurrent Current { get; }
    public IHttpClientProvider HttpClientProvider { get; }
    public IRequestMessage RequestMessage { get; }

    public async Task<string> GetAccessKeyToken(TokenThird t)
    {
        var request = await RequestMessage.GetAccessTokenAsync(t);
        var reponse = await httpclient.SendAsync(request);
        var success = reponse.Headers.TryGetValues("location", out var location);
        if (!success)
        {
            return default;
        }
        var local = location!.FirstOrDefault();
        Uri uri = new(local!);
        var queries = HttpUtility.ParseQueryString(uri.Query);
        var accessKey = queries.Get("access_key");
        return accessKey;
    }

    public async Task<TokenThird> GotoThird()
    {
        var request = await RequestMessage.GetThirdRequestAsync();
        var reponse = await httpclient.SendAsync(request);
        var str = await reponse.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<TokenThird>(str)!;
    }
}
