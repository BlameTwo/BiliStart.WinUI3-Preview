using Bilibili.App.Interface.V1;
using Network.Models.Bangumi;
using System.Reflection.Metadata.Ecma335;

namespace BiliNetWork.Providers;

public sealed class BangumiProvider : IBangumiProvider
{
    public BangumiProvider(
        IHttpClientProvider httpClientProvider,
        IRequestMessage requestMessage,
        IBIliDocument bIliDocument,
        ICurrent current,
        ITokenManager tokenManager
    )
    {
        HttpClientProvider = httpClientProvider;
        RequestMessage = requestMessage;
        BIliDocument = bIliDocument;
        Current = current;
        TokenManager = tokenManager;
    }

    public IHttpClientProvider HttpClientProvider { get; }
    public IRequestMessage RequestMessage { get; }
    public IBIliDocument BIliDocument { get; }
    public ICurrent Current { get; }
    public ITokenManager TokenManager { get; }

    public async Task<ResultData<BangumiModel>> GetMoviePageInfoAsync(
        BangumiCursor cursor = null,
        CancellationToken canceltoken = default
    ) => await GetPageInfoAsync(BangumiParamter.Movie, cursor, canceltoken);

    public async Task<ResultData<BangumiModel>> GetDocumentaryPageInfoAsync(
        BangumiCursor cursor = null,
        CancellationToken canceltoken = default
    ) => await GetPageInfoAsync(BangumiParamter.MoviePlayer, cursor, canceltoken);

    public async Task<ResultData<BangumiModel>> GetDTVPageInfoAsync(
        BangumiCursor cursor = null,
        CancellationToken canceltoken = default
    ) => await GetPageInfoAsync(BangumiParamter.TvPlayer, cursor, canceltoken);

    public async Task<ResultData<BangumiModel>> GetVarietyPageInfoAsync(
        BangumiCursor cursor = null,
        CancellationToken canceltoken = default
    ) => await GetPageInfoAsync(BangumiParamter.Variety, cursor, canceltoken);

    async Task<ResultData<BangumiModel>> GetPageInfoAsync(
        string type,
        BangumiCursor cursor,
        CancellationToken canceltoken = default
    )
    {
        Dictionary<string, string> valueparamters = new Dictionary<string, string>()
        {
            { "fnval", "976" },
            { "fnver", "0" },
            { "fourk", "1" },
            { "name", type },
            { "qn", "112" }
        };
        if (cursor != null)
            valueparamters.Add("cursor", JsonSerializer.Serialize(cursor));
        var req = await RequestMessage.GetHttpRequestMessageAsync(
            Apis.PGC_PAGE,
            RequestType.IOS,
            HttpMethod.Get,
            valueparamters,
            true,
            false,
            true
        );
        var result = await HttpClientProvider.SendAsync(req);
        return await BIliDocument.CheckDataResult<BangumiModel>(req, result);
    }

    public async Task<ResultCode<BangumiDetilyModel>> GetBangumiViewInfoAsync(
        string seasonId,
        CancellationToken canceltoken = default
    )
    {
        ////https://app.bilibili.com/bilibili.pgc.gateway.player.v2.PlayURL/PlayView
        //Bilibili.Pgc.Gateway.Player.V2.PlayViewReq req = new()
        //{

        //};
        Dictionary<string, string> valueparamters = new Dictionary<string, string>()
        {
            { "season_id", seasonId },
        };
        var req = await RequestMessage.GetHttpRequestMessageAsync(
            Apis.PGC_VIEW,
            RequestType.IOS,
            HttpMethod.Get,
            valueparamters,
            true,
            false,
            true
        );
        var result = await HttpClientProvider.SendToStringAsync(req);
        return await BIliDocument.JsonDeserializeAsync<ResultCode<BangumiDetilyModel>>(result);
    }

    public async Task<ResultData<PgcDashInfo>> GetBangumiUrlInfoAsync(
        long aid,
        long Epid,
        long Cid,
        CancellationToken canceltoken = default
    )
    {
        Dictionary<string, string> valueparamter =
            new()
            {
                { "avid", aid.ToString() },
                { "cid", Cid.ToString() },
                { "ep_id", Epid.ToString() },
                { "qn", "80" },
                { "fourk", "1" },
                { "fnver", "0" },
                { "fnval", "4048" },
                { "module", "bangumi" },
                { "mid", (await TokenManager.GetToken(Current.TokenName)).Mid.ToString() }
            };
        var request = await RequestMessage.GetHttpRequestMessageAsync(
            Apis.PGC_PLAYURL,
            RequestType.Web,
            HttpMethod.Get,
            valueparamter,
            true,
            false,
            true
        );
        var content = await HttpClientProvider.SendAsync(request);
        return await BIliDocument.CheckDataResult<PgcDashInfo>(request, content);
    }
}
