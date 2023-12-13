using Bilibili.App.Dynamic.V2;
using Bilibili.App.Interface.V1;
using System.Reflection.Metadata.Ecma335;
using ViewConverter.Models.AccountHistory;
using ViewConverter.Models.Dynamic;

namespace BiliNetWork.Providers;

public sealed class AccountProvider : IAccountProvider
{
    public AccountProvider(
        IRequestMessage requestMessage,
        IHttpClientProvider httpClientProvider,
        IBIliDocument bIliDocument,
        IAccountHistoryConverter accountHistoryConverter,
        IAccountDynamicConverter accountDynamicConverter
    )
    {
        RequestMessage = requestMessage;
        HttpClientProvider = httpClientProvider;
        BIliDocument = bIliDocument;
        AccountHistoryConverter = accountHistoryConverter;
        AccountDynamicConverter = accountDynamicConverter;
    }

    public IRequestMessage RequestMessage { get; }
    public IHttpClientProvider HttpClientProvider { get; }
    public IBIliDocument BIliDocument { get; }
    public IAccountHistoryConverter AccountHistoryConverter { get; }
    public IAccountDynamicConverter AccountDynamicConverter { get; }

    public async Task<ResultCode<MyInfo>> GetAccountInfoAsync(
        CancellationToken canceltoken = default
    )
    {
        var result = await RequestMessage.GetHttpRequestMessageAsync(
            Apis.ACCOUNT_INFO_URL,
            RequestType.IOS,
            HttpMethod.Get,
            new(),
            true,
            false,
            true
        );
        var contentstr = await HttpClientProvider.SendAsync(result);
        return await BIliDocument.CheckDataCode<MyInfo>(result, contentstr);
    }

    public async Task<ResultCode<MyInfo>> GetTokenInfoAsync(
        AccountToken token,
        CancellationToken canceltoken = default
    )
    {
        var result = await RequestMessage.GetHttpRequestMessageAsync(
            Apis.ACCOUNT_INFO_URL,
            RequestType.IOS,
            HttpMethod.Get,
            new(),
            true,
            false,
            true,
            token
        );
        var contentstr = await HttpClientProvider.SendAsync(result);
        return await BIliDocument.CheckDataCode<MyInfo>(result, contentstr);
    }

    public async Task<AccountVideoHistoryModel> GetAccountHistoryAsync(
        Cursor cursor,
        string tabname = "archive",
        CancellationToken canceltoken = default
    ) =>
        AccountHistoryConverter.ConverterModel(await GetHistoryAsync(cursor, tabname, canceltoken));

    public async Task<CursorV2Reply> GetHistoryAsync(
        Cursor cursor,
        string Tabname,
        CancellationToken token = default
    )
    {
        if (cursor == null)
            cursor = new();
        CursorV2Req req = new CursorV2Req() { Cursor = cursor, Business = Tabname };
        var request = await RequestMessage.GetHttpRequestMessageAsync(Apis.HISTORY_CURSOR, req);
        var result = await HttpClientProvider.SendAsync(request);
        return await BIliDocument.ParseMessageAsync<CursorV2Reply>(result, CursorV2Reply.Parser);
    }

    public async Task<AccountVideoHistoryModel> GetAccountLiveHistoryAsync(
        Cursor cursor,
        CancellationToken token = default
    )
    {
        return AccountHistoryConverter.ConverterModel(await GetHistoryAsync(cursor, "live", token));
    }

    public async Task<ResultCode<MyData>> GetAccountTopNavigationAsync(
        CancellationToken canceltoken = default
    )
    {
        var result = await RequestMessage.GetHttpRequestMessageAsync(
            Apis.ACCOUNT_MY_DATA,
            RequestType.IOS,
            HttpMethod.Get,
            new(),
            true,
            false,
            true
        );
        var contentstr = await HttpClientProvider.SendAsync(result);
        return await BIliDocument.CheckDataCode<MyData>(result, contentstr);
    }

    public async Task<ResultCode<MySpace>> GetAccountSpaceAsync(
        long mid,
        CancellationToken canceltoken = default
    )
    {
        Dictionary<string, string> valuepairs = new();
        valuepairs.Add("vmid", mid.ToString());
        var result = await RequestMessage.GetHttpRequestMessageAsync(
            Apis.ACCOUNT_SPACE,
            RequestType.IOS,
            HttpMethod.Get,
            valuepairs,
            true,
            false,
            true
        );
        var content = await HttpClientProvider.SendAsync(result);
        return await BIliDocument.CheckDataCode<MySpace>(result, content);
    }

    public async Task<ResultCode<IpModel>> GetAccountIpAsync(
        CancellationToken canceltoken = default
    )
    {
        var result = await RequestMessage.GetHttpRequestMessageAsync(
            Apis.ACCOUNT_IP,
            RequestType.IOS,
            HttpMethod.Get,
            new(),
            true,
            false,
            true
        );
        var content = await HttpClientProvider.SendAsync(result);
        return await BIliDocument.CheckDataCode<IpModel>(result, content);
    }

    public async Task<UserAllModel> GetAccountAllDynamicAsync(
        string HistoryOffset = "",
        string BussinessId = "",
        CancellationToken cancellationToken = default
    )
    {
        DynAllReq req =
            new()
            {
                LocalTime = 8,
                PlayerArgs = new() { Qn = 112, Fnval = 464, },
                RefreshType = string.IsNullOrWhiteSpace(HistoryOffset)
                    ? Refresh.New
                    : Refresh.History,
                UpdateBaseline = BussinessId,
                Offset = HistoryOffset
            };
        var request = await RequestMessage.GetHttpRequestMessageAsync(Apis.DYNAMIC_ALL_TYPE, req);

        var content = await HttpClientProvider.SendAsync(request);
        var result = await BIliDocument.ParseMessageAsync<DynAllReply>(content, DynAllReply.Parser);
        if (result == null) return null;
        return AccountDynamicConverter.FormatUserAllModel(result);
    }

    public async Task GetAccountVideoDynamicAsync(CancellationToken cancellationToken = default)
    {
        DynVideoReq req =
            new()
            {
                LocalTime = 8,
                RefreshType = Refresh.New,
                PlayerArgs = new() { Qn = 112, Fnval = 464, },
            };
        var request = await RequestMessage.GetHttpRequestMessageAsync(Apis.DYNAMIC_VIDEO_TYPE, req);

        var content = await HttpClientProvider.SendAsync(request);
        var result = await BIliDocument.ParseMessageAsync<DynVideoReply>(
            content,
            DynVideoReply.Parser
        );
    }
}
