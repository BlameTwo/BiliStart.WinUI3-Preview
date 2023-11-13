using Bilibili.App.Search.V2;
using Bilibili.Broadcast.Message.Main;
using Network.Models.Services;
using Network.Models.ThirdApi;
using Network.Models.Totals.HotHistory;
using System;
using ViewConverter.Models.ServiceData;

namespace BiliNetWork.Providers;

public sealed class BiliServiceProvider : IBiliServiceProvider
{
    public BiliServiceProvider(
        IRequestMessage requestMessage,
        IVideoViewModelConverter videoViewModelConverter,
        IHttpClientProvider httpClientProvider,
        ICurrent current,
        IBIliDocument bIliDocument,
        IBiliDataViewModelConverter biliDataViewModelConverter
    )
    {
        RequestMessage = requestMessage;
        VideoViewModelConverter = videoViewModelConverter;
        HttpClientProvider = httpClientProvider;
        Current = current;
        BIliDocument = bIliDocument;
        BiliDataViewModelConverter = biliDataViewModelConverter;
    }

    public IRequestMessage RequestMessage { get; }
    public IVideoViewModelConverter VideoViewModelConverter { get; }
    public IHttpClientProvider HttpClientProvider { get; }
    public ICurrent Current { get; }
    public IBIliDocument BIliDocument { get; }
    public IBiliDataViewModelConverter BiliDataViewModelConverter { get; }

    public async Task<ResultCode<CheckMusicRankRegisterModel>> GetRegisterMusicRankAsync(
        CancellationToken canceltoken = default
    )
    {
        Dictionary<string, string> map = new Dictionary<string, string>();
        map.Add("list_id", "82");
        var request = await RequestMessage.GetHttpRequestMessageAsync(
            Apis.CHECK_MUSIC_RANK_REGISTER,
            Network.Models.RequestType.Web,
            HttpMethod.Get,
            map,
            false,
            true,
            false
        );
        var result = await HttpClientProvider.SendAsync(request);
        return await BIliDocument.CheckDataCode<CheckMusicRankRegisterModel>(request, result);
    }

    public async Task<ResultCode<HotSearch>> GetSearchRankListAsync(
        CancellationToken canceltoken = default
    )
    {
        Dictionary<string, string> map = new();
        map.Add("csrf", await Current.GetCSRFAsync());
        var request = await RequestMessage.GetHttpRequestMessageAsync(
            Apis.BILIBILI_HOT_SEARCH_LIST,
            Network.Models.RequestType.Web,
            HttpMethod.Get,
            map,
            false,
            true,
            false
        );
        var result = await HttpClientProvider.SendAsync(request);
        return await BIliDocument.CheckDataCode<HotSearch>(request, result)!;
    }

    public async Task<bool> SetRegisterMusicRankAsync(
        bool state,
        CancellationToken canceltoken = default
    )
    {
        int value = state == true ? 1 : 2;
        Dictionary<string, string> map = new();
        map.Add("state", value.ToString());
        map.Add("list_id", "82");
        map.Add("csrf", await Current.GetCSRFAsync());
        var requestmsg = await RequestMessage.GetHttpRequestMessageAsync(
            Apis.MUSIC_RANK_REGISTER,
            Network.Models.RequestType.Web,
            HttpMethod.Post,
            map,
            isaccess: false,
            true,
            false
        );
        var result = await HttpClientProvider.SendAsync(requestmsg);
        var str = await result.Content.ReadAsStringAsync();
        return true;
    }

    public async Task<ResultCode<MusicRankDataIDModel>> GetMusicListIDAsync(
        CancellationToken canceltoken = default
    )
    {
        Dictionary<string, string> map = new();
        map.Add("list_type", "1");
        var requestmsg = await RequestMessage.GetHttpRequestMessageAsync(
            Apis.MUSCI_RANK_IDLIST,
            Network.Models.RequestType.Web,
            HttpMethod.Get,
            map,
            false,
            true,
            false
        );
        ;
        var result = await HttpClientProvider.SendAsync(requestmsg);
        var str = await result.Content.ReadAsStringAsync();
        var job = JsonObject.Parse(str);
        var data = new ResultCode<MusicRankDataIDModel>()
        {
            Code = job["code"].GetValue<int>(),
            Message = job["message"].GetValue<string>(),
            TTl = job["ttl"].GetValue<int>(),
            Data = new MusicRankDataIDModel() { YearData = new List<YearData>() }
        };
        var year = job["data"]["list"].AsObject();
        foreach (var item in year.AsEnumerable())
        {
            YearData yeardata = new() { MusicRankItem = new() };
            yeardata.Year = item.Key;
            foreach (var item2 in item.Value.AsArray())
            {
                yeardata.MusicRankItem.Add(item2.Deserialize<MusicRankIDItem>()!);
            }
            data.Data.YearData.Add(yeardata);
        }
        return data;
    }

    public async Task<List<MusicRankCard>> GetMusicItemsAsync(
        MusicRankIDItem data,
        CancellationToken canceltoken = default
    )
    {
        Dictionary<string, string> map = new();
        map.Add("list_id", data.ID.ToString());
        map.Add("csrf", await Current.GetCSRFAsync());
        var requestmsg = await RequestMessage.GetHttpRequestMessageAsync(
            Apis.MUSIC_RANKMUSICITEM,
            Network.Models.RequestType.Web,
            HttpMethod.Get,
            map,
            false,
            true,
            false
        );
        ;
        var result = await HttpClientProvider.SendAsync(requestmsg);
        var obj = await BIliDocument.CheckDataCode<MusicRankList>(requestmsg, result)!;
        return await VideoViewModelConverter.MusicRankToVideo(obj.Data.List);
    }

    public async Task<SubmitChatTaskReply> CreateChat(string ask, ChatSourceEnum type)
    {
        SubmitChatTaskReq chat =
            new()
            {
                FromSource =
                    type == ChatSourceEnum.AppHistorySearch
                        ? "apphistory_search"
                        : type == ChatSourceEnum.AppSuggestSearch
                            ? "appsuggest_search"
                            : "app_search",
                Query = ask
            };
        var request = await RequestMessage.GetHttpRequestMessageAsync(Apis.CHAT_SUBTITLE, chat);
        var response = await HttpClientProvider.SendAsync(request);
        var result = await BIliDocument.ParseMessageAsync<SubmitChatTaskReply>(
            response,
            SubmitChatTaskReply.Parser
        );
        return result;
    }

    public async Task<ChatResult> AskChat(string ask, ChatSourceEnum type, string ssid)
    {
        Bilibili.App.Search.V2.GetChatResultReq chat =
            new()
            {
                FromSource =
                    type == ChatSourceEnum.AppHistorySearch
                        ? "apphistory_search"
                        : type == ChatSourceEnum.AppSuggestSearch
                            ? "appsuggest_search"
                            : "app_search",
                Query = ask,
                SessionId = ssid
            };
        var request = await RequestMessage.GetHttpRequestMessageAsync(Apis.CHAT_RESULT, chat);
        var response = await HttpClientProvider.SendAsync(request);
        return await BIliDocument.ParseMessageAsync<ChatResult>(response, ChatResult.Parser);
    }

    public async Task<ResultCode<LotteryResultMode>> GetLotteryResultAsync(
        string busid,
        string bustype
    )
    {
        var dictvalue = new Dictionary<string, string>()
        {
            { "business_id", busid },
            { "business_type", bustype }
        };

        var request = await RequestMessage.GetHttpRequestMessageAsync(
            Apis.BILI_LOTTERY_RESULT,
            RequestType.Web,
            HttpMethod.Get,
            dictvalue,
            false,
            true,
            false
        );
        var response = await HttpClientProvider.SendAsync(request);
        return await BIliDocument.CheckDataCode<LotteryResultMode>(request, response);
    }

    /// <summary>
    /// 获得开屏壁纸
    /// </summary>
    /// <returns></returns>
    public async Task<AppBrandSource> GetAppBrandListAsync()
    {
        var keyvalues = new Dictionary<string, string>()
        {
            { "screen_height", "900" },
            { "screen_width", "1600" }
        };
        var request = await RequestMessage.GetHttpRequestMessageAsync(
            Apis.APP_SPLASH,
            RequestType.Android,
            HttpMethod.Get,
            keyvalues,
            true,
            false,
            true
        );
        var response = await HttpClientProvider.SendAsync(request);
        var wallpaper = await response.Content.ReadAsStringAsync();
        return await BiliDataViewModelConverter.BrandConverterToImage(
            (await BIliDocument.CheckDataCode<BiliBrandModel>(request, response)).Data
        );
    }
}
