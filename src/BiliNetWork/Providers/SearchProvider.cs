using Bilibili.App.Interface.V1;
using Bilibili.App.Search.V2;
using Bilibili.Broadcast.Message.Main;
using Bilibili.Polymer.App.Search.V1;

namespace BiliNetWork.Providers;

/*
 注解：搜索参数分为全部搜索和分类搜索，我都加了中间器去转换类
 */
public sealed class SearchProvider : ISearchProvider
{
    public SearchProvider(
        IHttpClientProvider httpClientProvider,
        IBIliDocument bIliDocument,
        IRequestMessage requestMessage,
        IVideoViewModelConverter videoViewModelConverter
    )
    {
        HttpClientProvider = httpClientProvider;
        BIliDocument = bIliDocument;
        RequestMessage = requestMessage;
        VideoViewModelConverter = videoViewModelConverter;
    }

    public IHttpClientProvider HttpClientProvider { get; }
    public IBIliDocument BIliDocument { get; }
    public IRequestMessage RequestMessage { get; }
    public IVideoViewModelConverter VideoViewModelConverter { get; }

    public async Task<SuggestionResult3Reply> GetSearchSuggestionAsync(
        string keyword,
        CancellationToken canceltoken = default
    )
    {
        SuggestionResult3Req req = new() { Keyword = keyword, Highlight = 0 };
        var request = await RequestMessage.GetHttpRequestMessageAsync(Apis.SEARCH_SUGGESTIONS, req);
        var response = await HttpClientProvider.SendAsync(request);
        return await BIliDocument.ParseMessageAsync<SuggestionResult3Reply>(
            response,
            SuggestionResult3Reply.Parser
        );
    }

    public async Task<SearchModel> GetSearchAllAsync(
        string keyword,
        int pagesize,
        string Next = "",
        SearchOrderByEnum order = SearchOrderByEnum.Default,
        CancellationToken canceltoken = default
    )
    { //排序2为新发布，3为弹幕多，1为播放多
        Bilibili.Polymer.App.Search.V1.SearchAllRequest req = new();

        req.Keyword = keyword;
        req.Order = (int)order;
        req.Pagination = new Bilibili.Pagination.Pagination() { PageSize = pagesize, Next = Next };
        req.IsOrgQuery = Convert.ToInt32(false);
        var request = await RequestMessage.GetHttpRequestMessageAsync(Apis.SEARCH_ALL, req);
        var response = await HttpClientProvider.SendAsync(request);
        return await VideoViewModelConverter.SearchAllConverter(
            await BIliDocument.ParseMessageAsync<SearchAllResponse>(
                response,
                SearchAllResponse.Parser
            ),
            null
        );
    }

    public async Task<SearchModel> GetSearchTypeAsync(
        string keyword,
        int type,
        int pagesize,
        string Next = "",
        CancellationToken canceltoken = default
    )
    {
        SearchByTypeRequest req =
            new()
            {
                Type = type,
                Keyword = keyword,
                PlayerArgs = new() { Qn = 112, Fnval = 464, },
                Pagination = new Bilibili.Pagination.Pagination()
                {
                    PageSize = pagesize,
                    Next = Next
                }
            };
        var request = await RequestMessage.GetHttpRequestMessageAsync(Apis.SEARCH_TYPE, req);
        var response = await HttpClientProvider.SendAsync(request);
        var result = await BIliDocument.ParseMessageAsync<SearchByTypeResponse>(
            response,
            SearchByTypeResponse.Parser
        );
        return await VideoViewModelConverter.SearchTypeConverter(result);
    }

}
