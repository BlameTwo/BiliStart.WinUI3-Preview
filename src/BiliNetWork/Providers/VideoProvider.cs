using Bilibili.App.Dynamic.V2;
using Network.Models.Totals.HotHistory;
using ViewConverter.Models.VideoModel;

namespace BiliNetWork.Providers;

public sealed class VideoProvider : IVideoProvider
{
    public ICurrent Current { get; }
    public IRequestMessage RequestMessage { get; }
    public IHttpClientProvider HttpClientProvider { get; }
    public IVideoViewModelConverter VideoViewModelConverter { get; }
    public IPlayerViewModelConverter PlayerViewModelConverter { get; }
    public ITokenManager TokenManager { get; }
    public IBIliDocument BIliDocument { get; }
    public int RankMaxPs { get; set; } = 30;

    public VideoProvider(
        ICurrent current,
        IRequestMessage requestMessage,
        IHttpClientProvider httpClientProvider,
        IVideoViewModelConverter videoViewModelConverter,
        IPlayerViewModelConverter playerViewModelConverter,
        ITokenManager tokenManager,
        IBIliDocument bIliDocument
    )
    {
        Current = current;
        RequestMessage = requestMessage;
        HttpClientProvider = httpClientProvider;
        VideoViewModelConverter = videoViewModelConverter;
        PlayerViewModelConverter = playerViewModelConverter;
        TokenManager = tokenManager;
        BIliDocument = bIliDocument;
    }

    public async Task<HomeVideoBase> GetHomeVideoAsync(
        bool isRefersh,
        string idx = null,
        string hash = null,
        CancellationToken canceltoken = default
    )
    {
        if (isRefersh)
        {
            idx = "0";
            hash = "0";
        }
        var dict = new Dictionary<string, string>() { { "idx", idx }, { "banner_hash", hash } };
        var request = await RequestMessage.GetHttpRequestMessageAsync(
            Apis.BILIBILI_FIND_HOME_VIDEO,
            RequestType.Android,
            HttpMethod.Get,
            dict,
            true,
            true,
            true
        );
        var reponse = await HttpClientProvider.SendAsync(request);
        var data = await BIliDocument.CheckDataCode<HomeVideoModel>(request, reponse)!;
        var resultlist = data.Data.Items.Where(
            (v) => v.Card_Goto == "av" || v.Card_Goto == "banner"
        );
        return await VideoViewModelConverter.HomeConverterToVideo(resultlist.ToList());
    }

    public async Task<List<RankVideo>> GetRankListAsync(
        int pn,
        int tid,
        CancellationToken canceltoken = default
    )
    {
        Bilibili.App.Show.V1.RankRegionResultReq req =
            new()
            {
                Rid = tid,
                Ps = RankMaxPs,
                Pn = pn
            };
        var request = await RequestMessage.GetHttpRequestMessageAsync(Apis.VIDEO_RANK, req);
        var reponse = await HttpClientProvider.SendAsync(request);
        var result = await BIliDocument.ParseMessageAsync<Bilibili.App.Show.V1.RankListReply>(
            reponse,
            RankListReply.Parser
        );
        return await VideoViewModelConverter.RankConverterToVideo(result.Items.ToList());
    }

    public async Task<HotVideoModel> GetHotListAsync(
        long idx = 0,
        CancellationToken canceltoken = default
    )
    {
        HotVideoModel model = new();
        var popularReq = new PopularResultReq()
        {
            Idx = idx,
            LoginEvent = 2,
            Qn = 112,
            Fnval = 464,
            Fourk = 1,
            Spmid = "creation.hot-tab.0.0",
            PlayerArgs = new Bilibili.App.Archive.Middleware.V1.PlayerArgs
            {
                Qn = 112,
                Fnval = 464,
            },
        };
        var request = await RequestMessage.GetHttpRequestMessageAsync(Apis.VIDEO_HOT, popularReq);
        var reponse = await HttpClientProvider.SendAsync(request);
        var result = await BIliDocument.ParseMessageAsync<Bilibili.App.Show.V1.PopularReply>(
            reponse,
            PopularReply.Parser
        );
        var resultitem = result.Items
            .Where((val => val.ItemCase == Bilibili.App.Card.V1.Card.ItemOneofCase.SmallCoverV5))
            .Where((val) => val.SmallCoverV5 != null)
            .Where((val) => val.SmallCoverV5.Base.CardGoto == "av")
            .ToList();
        model.Idx = result.Items.Last().SmallCoverV5.Base.Idx;
        var result2 = await VideoViewModelConverter.HotConverterToVideo(resultitem);
        model.HotVideo = result2;
        return model;
    }

    public async Task<PlayerView> GetVideoViewAsync(
        VideoTypeEnum type,
        string id,
        CancellationToken canceltoken = default
    )
    {
        var req = new Bilibili.App.View.V1.ViewReq();
        if (type == VideoTypeEnum.Av)
            req.Aid = int.Parse(id);
        else
            req.Bvid = id;
        var appReq = await RequestMessage.GetHttpRequestMessageAsync(Apis.VIDEO_PLAYVIEW, req);
        var appRes = await HttpClientProvider.SendAsync(appReq);
        var reply = await BIliDocument.ParseMessageAsync(appRes, ViewReply.Parser);
        return await PlayerViewModelConverter.GetPlayerViewToModel(reply);
    }

    public async Task<ResultCode<Network.Models.Videos.VideoInfo>> GetVideoDashSourceAsync(
        VideoTypeEnum typeEnum,
        long cid,
        string id,
        int dashEnum = 0,
        FnvalEnum fnvalEnum = FnvalEnum.FLV,
        CancellationToken canceltoken = default
    )
    {
        string idname = typeEnum == VideoTypeEnum.Av ? "avid" : "bvid";
        Dictionary<string, string> keyvalues = new();
        keyvalues.Add(idname, id);
        keyvalues.Add("mid", (await this.TokenManager.GetToken(Current.TokenName)).Mid.ToString());
        keyvalues.Add("cid", cid.ToString());
        keyvalues.Add("fnver", "0");
        keyvalues.Add("fourk", "1");
        keyvalues.Add("fnval", "4048");
        keyvalues.Add("qn", "64");
        keyvalues.Add("otype", "json");

        var questmessage = await RequestMessage.GetHttpRequestMessageAsync(
            Apis.VIDEO_PLAYRUL,
            RequestType.IOS,
            HttpMethod.Get,
            keyvalues,
            true,
            false,
            true
        );
        var resultcontent = await HttpClientProvider.SendAsync(questmessage);

        return await BIliDocument.CheckDataCode<Network.Models.Videos.VideoInfo>(
            questmessage,
            resultcontent
        )!;
    }

    public async Task<ResultCode<HotHistoryNavigationModel>> GetHotHistoryNavigationAsync(
        CancellationToken canceltoken = default
    )
    {
        var dict = new Dictionary<string, string>();

        dict.Add("page_id", "170452");
        dict.Add("from_spmid", "dynamic.activity.0.0");
        dict.Add("player_net", "1");
        dict.Add("qn", "32");
        dict.Add("tab_id", "0");
        dict.Add("tab_module_id", "0");
        var request = await RequestMessage.GetHttpRequestMessageAsync(
            Apis.HOT_HISTORY_NAV,
            RequestType.IOS,
            HttpMethod.Get,
            dict,
            true,
            false,
            true
        );
        var reponse = await HttpClientProvider.SendAsync(request);
        return await BIliDocument.CheckDataCode<HotHistoryNavigationModel>(request, reponse);
    }

    public async Task<ResultCode<HotHistoryNavigationModel>> GetHotHistoryModelAsync(
        string pageid,
        CancellationToken canceltoken = default
    )
    {
        var dict = new Dictionary<string, string>()
        {
            { "fourk", "0" },
            { "fnver", "0" },
            { "fnval", "272" },
            { "page_id", pageid },
            { "qn", "32" },
            { "disable_rcmd", "0" },
            { "https_url_req", "0" },
            { "memory", "4636" }
        };
        var request = await RequestMessage.GetHttpRequestMessageAsync(
            Apis.HOT_HISTORY_Model,
            RequestType.Android,
            HttpMethod.Get,
            dict,
            true,
            false,
            true
        );
        var reponse = await HttpClientProvider.SendAsync(request);
        return await BIliDocument.CheckDataCode<HotHistoryNavigationModel>(request, reponse);
    }

    public async Task<ResultCode<HotHistoryItems>> GetHotHistoryItemAsync(
        string pageid,
        HotHistoryNavigationModel model,
        CancellationToken canceltoken = default
    )
    {
        var dict = new Dictionary<string, string>()
        {
            { "from_spmid", "dynamic.activity.0.0" },
            { "fourk", "0" },
            { "fnver", "0" },
            { "fnval", "272" },
            { "goto", model.Cards.Last().UrlExt.GoTo },
            { "conf_module_id", model.Cards.Last().UrlExt.ConfModule.ToString() },
            { "qn", "32" },
            { "disable_rcmd", "0" },
            { "primary_page_id", pageid },
            { "player_net", "1" },
            { "sort_type", model.Cards.Last().UrlExt.SortType.ToString() },
            { "force_host", "0" },
            { "offset", "0" }
        };
        var request = await RequestMessage.GetHttpRequestMessageAsync(
            Apis.HOT_HISTORY_LISTITEM,
            RequestType.Android,
            HttpMethod.Get,
            dict,
            true,
            false,
            true
        );
        var reponse = await HttpClientProvider.SendAsync(request);
        var result = await reponse.Content.ReadAsStringAsync();
        return await BIliDocument.CheckDataCode<HotHistoryItems>(request, reponse);
    }
}
