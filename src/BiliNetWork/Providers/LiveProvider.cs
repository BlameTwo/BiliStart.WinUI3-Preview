using Bilibili.App.Dynamic.V2;
using BiliNetWork.Extensions;
using Google.Protobuf.WellKnownTypes;
using Network.Models.Live;

namespace BiliNetWork.Providers;

public class LiveProvider : ILiveProvider
{
    public LiveProvider(
        IRequestMessage requestMessage,
        IHttpClientProvider httpClientProvider,
        IBIliDocument bIliDocument,
        ICurrent current
    )
    {
        RequestMessage = requestMessage;
        HttpClientProvider = httpClientProvider;
        BIliDocument = bIliDocument;
        Current = current;
    }

    public IRequestMessage RequestMessage { get; }
    public IHttpClientProvider HttpClientProvider { get; }
    public IBIliDocument BIliDocument { get; }
    public ICurrent Current { get; }

    public async Task<ResultCode<LiveRoomInfo>> GetLiveDanmakuInfoAsync(
        int roomId,
        CancellationToken canceltoken = default
    )
    {
        Dictionary<string, string> values = new() { { "id", roomId.ToString() }, { "type", "0" } };
        var request = await RequestMessage.GetHttpRequestMessageAsync(
            Apis.LIVE_ROOM_INFO,
            RequestType.Web,
            HttpMethod.Get,
            values,
            false,
            true,
            false
        );
        var reponse = await HttpClientProvider.SendAsync(request);
        return await BIliDocument.CheckDataCode<LiveRoomInfo>(request, reponse);
    }

    public async Task<ResultCode<LiveFeedDataModel>> GetLiveFeedDataAsync(
        int page = 1,
        CancellationToken canceltoken = default
    )
    {
        Dictionary<string, string> values =
            new()
            {
                { "login_event", "0" },
                { "page", page.ToString() },
                { "scale", "xhdpi" }
            };
        var request = await RequestMessage.GetHttpRequestMessageAsync(
            Apis.LIVE_PAGE_FEED,
            RequestType.Android,
            HttpMethod.Get,
            values,
            true,
            false,
            true
        );
        var reponse = await HttpClientProvider.SendAsync(request);
        return await BIliDocument.CheckDataCode<LiveFeedDataModel>(request, reponse);
    }

    public ILiveClient CreateClient(
        LiveRoomInfo info,
        int roomid,
        CancellationToken canceltoken = default
    )
    {
        ILiveClient client = new LiveClient(info, roomid, Convert.ToInt32(Current.TokenName));
        return client;
    }

    public async Task<ResultCode<LiveTagDataModel>> GetLiveTagDataAsync(
        CancellationToken canceltoken = default
    )
    {
        var request = await RequestMessage.GetHttpRequestMessageAsync(
            Apis.LIVE_TAG_DATA,
            RequestType.Android,
            HttpMethod.Get,
            new(),
            true,
            false,
            true
        );
        var reponse = await HttpClientProvider.SendAsync(request);
        return await BIliDocument.CheckDataCode<LiveTagDataModel>(request, reponse);
    }

    public async Task<ResultCode<LiveTagItemDataModel>> GetLiveTagItemDataAsync(
        long parentid,
        long areaid,
        string sort_type,
        int page = 1,
        int pagesize = 30,
        CancellationToken canceltoken = default
    )
    {
        Dictionary<string, string> values =
            new()
            {
                { "area_id", areaid.ToString() },
                { "parent_area_id", parentid.ToString() },
                { "page", page.ToString() },
                { "page_size", pagesize.ToString() },
                { "sort_type", sort_type },
            };
        return await this.getLiveTagitem(values, canceltoken);
    }

    async Task<ResultCode<LiveTagItemDataModel>> getLiveTagitem(
        Dictionary<string, string> values,
        CancellationToken canceltoken = default
    )
    {
        var request = await RequestMessage.GetHttpRequestMessageAsync(
            Apis.LIVE_TAG_DATA_ITEM,
            RequestType.Android,
            HttpMethod.Get,
            values,
            true,
            false,
            true
        );
        var reponse = await HttpClientProvider.SendAsync(request);
        var str = await reponse.Content.ReadAsStringAsync();
        return await BIliDocument.CheckDataCode<LiveTagItemDataModel>(request, reponse);
    }

    public async Task<ResultCode<LiveTagItemDataModel>> GetLiveTagItemDataAsync(
        long parentid,
        long areaid,
        int page = 1,
        int pagesize = 30,
        CancellationToken canceltoken = default
    )
    {
        Dictionary<string, string> values =
            new()
            {
                { "area_id", areaid.ToString() },
                { "parent_area_id", parentid.ToString() },
                { "page", page.ToString() },
                { "page_size", pagesize.ToString() },
            };
        return await this.getLiveTagitem(values);
    }

    public async Task<ResultCode<LiveRoomDetailDataModel>> GetLiveRoomInfoAsync(
        long roomId,
        CancellationToken canceltoken = default
    )
    {
        Dictionary<string, string> values = new() { { "room_id", roomId.ToString() } };
        var request = await RequestMessage.GetHttpRequestMessageAsync(
            Apis.LIVE_ROOM_GetByINFO,
            RequestType.Android,
            HttpMethod.Get,
            values,
            true,
            false,
            true
        );
        var reponse = await HttpClientProvider.SendAsync(request);
        return await BIliDocument.CheckDataCode<LiveRoomDetailDataModel>(request, reponse);
    }

    public async Task<ResultCode<LiveUrlDataModel>> GetLiveRoomUrlInfoAsync(
        long roomId,
        long Quality,
        bool OnlyAudio,
        CancellationToken canceltoken = default
    )
    {
        Dictionary<string, string> values =
            new()
            {
                { "room_id", roomId.ToString() },
                { "device_name", "ALA-AN70" },
                { "qn", Quality.ToString() },
                { "no_playurl", "0" },
                { "only_audio", OnlyAudio ? "1" : "0" },
                { "only_video", "0" },
                { "mask", "0" },
                { "need_hdr", "0" },
                { "protocol", Uri.EscapeDataString("0,1") },
                { "codec", Uri.EscapeDataString("0,1") },
                { "dolby", "1" },
                { "format", Uri.EscapeDataString("0,2") },
            };
        return await this.GetLiveRoomUrlAsync(values);
    }

    public async Task<ResultCode<LiveUrlDataModel>> GetLiveRoomUrlInfoAsync(
        long roomId,
        CancellationToken canceltoken = default
    )
    {
        Dictionary<string, string> values =
            new()
            {
                { "room_id", roomId.ToString() },
                { "device_name", "ALA-AN70" },
                { "qn", "10000" },
                { "no_playurl", "0" },
                { "only_audio", "0" },
                { "only_video", "0" },
                { "mask", "0" },
                { "need_hdr", "0" },
                { "protocol", Uri.EscapeDataString("0,1") },
                { "codec", Uri.EscapeDataString("0,1") },
                { "dolby", "1" },
                { "format", Uri.EscapeDataString("0,2") },
            };
        return await this.GetLiveRoomUrlAsync(values);
    }

    async Task<ResultCode<LiveUrlDataModel>> GetLiveRoomUrlAsync(
        Dictionary<string, string> values,
        CancellationToken canceltoken = default
    )
    {
        var request = await RequestMessage.GetHttpRequestMessageAsync(
            Apis.LIVE_ROOM_GETPLAYINFO,
            RequestType.Android,
            HttpMethod.Get,
            values,
            true,
            false,
            true
        );
        var reponse = await HttpClientProvider.SendAsync(request);
        return await BIliDocument.CheckDataCode<LiveUrlDataModel>(request, reponse);
    }
}
