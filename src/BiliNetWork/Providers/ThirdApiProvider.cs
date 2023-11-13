using Network.Models.ThirdApi;
using System;

namespace BiliNetWork.Providers;

public sealed partial class ThirdApiProvider : IThirdApiProvider
{
    public ThirdApiProvider(
        IHttpClientProvider httpClientProvider,
        IRequestMessage requestMessage,
        IBIliDocument bIliDocument
    )
    {
        HttpClientProvider = httpClientProvider;
        RequestMessage = requestMessage;
        BIliDocument = bIliDocument;
    }

    public IHttpClientProvider HttpClientProvider { get; }
    public IRequestMessage RequestMessage { get; }
    public IBIliDocument BIliDocument { get; }

    public async Task<BingWallpaperModel> GetBingWallpaperAsync(
        CancellationToken canceltoken = default
    )
    {
        Dictionary<string, string> dict =
            new()
            {
                { "format", "js" },
                { "idx", "0" },
                { "n", "1" },
                { "mkt", "zh-CN" }
            };
        var request = RequestMessage.GetHttpRequestMessageAsync(
            ThirdApis.BingWallpaper,
            HttpMethod.Get,
            dict
        );
        var reponse = await HttpClientProvider.SendToStringAsync(request);
        return await BIliDocument.JsonDeserializeAsync<BingWallpaperModel>(reponse);
    }

    public async Task<EveryDayModel> GetEveryDayAsync(CancellationToken canceltoken = default)
    {
        Dictionary<string, string> dict = new() { { "encode", "json" }, { "charset", "utf-8" } };
        var request = RequestMessage.GetHttpRequestMessageAsync(
            ThirdApis.EveryDay,
            HttpMethod.Get,
            dict
        );
        var reponse = await HttpClientProvider.SendToStringAsync(request);
        return await BIliDocument.JsonDeserializeAsync<EveryDayModel>(reponse);
    }

    public async Task<EveryDayTotalModel> GetEveryDayTotalAsync(
        string uuid,
        CancellationToken canceltoken = default
    )
    {
        Dictionary<string, string> dict = new() { { "sentence_uuid", uuid } };
        var request = RequestMessage.GetHttpRequestMessageAsync(
            ThirdApis.EveryDayTotal,
            HttpMethod.Get,
            dict
        );
        var reponse = await HttpClientProvider.SendToStringAsync(request);
        return await BIliDocument.JsonDeserializeAsync<EveryDayTotalModel>(reponse);
    }

    public async Task<Stream> GetVITSDataAsync(VitsRequest args)
    {
        Dictionary<string, string> victvalues = new()
        {
            {"format",args.Format },
            {"length",args.Length.ToString() },//语速，1.0-1.9
            {"noise",args.Noise.ToString() },//感情，0.3-1.4
            {"noisew",args.Noisew.ToString() },//音素长度，0.1-1.2
            {"sdp_ratio",args.SDPRatio.ToString() },//SDP/DP混合，0.1-0.7
            {"speaker",args.Speaker.ToString() },
            {"text",args.Text }
        };
        Dictionary<string, string> dict = new() { { "encode", "json" } };
        var request = RequestMessage.GetHttpRequestMessageAsync(
            ThirdApis.GenshinVoiceData,
            HttpMethod.Get,
            victvalues
        );
        var reponse = await HttpClientProvider.SendToStreamAsync(request);
        return reponse;
    }

    

    public async Task<YurikotoWallpaperModel> GetYurikoWallpaper(
        CancellationToken canceltoken = default
    )
    {
        Dictionary<string, string> dict = new() { { "encode", "json" } };
        var request = RequestMessage.GetHttpRequestMessageAsync(
            ThirdApis.YurikotoWallpaper,
            HttpMethod.Get,
            dict
        );
        var reponse = await HttpClientProvider.SendToStringAsync(request);
        return await BIliDocument.JsonDeserializeAsync<YurikotoWallpaperModel>(reponse);
    }
}
