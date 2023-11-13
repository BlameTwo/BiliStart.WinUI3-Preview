using Bilibili.App.Interface.V1;
using Network.Models.Enum;
using ViewConverter.Models;

namespace INetwork.IProviders;

public interface ISearchProvider
{
    /// <summary>
    /// 搜索建议
    /// </summary>
    /// <param name="keyword">关键字</param>
    /// <returns></returns>
    Task<SuggestionResult3Reply> GetSearchSuggestionAsync(
        string keyword,
        CancellationToken canceltoken = default
    );

    Task<SearchModel> GetSearchAllAsync(
        string keyword,
        int pagesize,
        string Next = "",
        SearchOrderByEnum order = SearchOrderByEnum.Default,
        CancellationToken canceltoken = default
    );

    Task<SearchModel> GetSearchTypeAsync(
        string keyword,
        int type,
        int pagesize,
        string Next = "",
        CancellationToken canceltoken = default
    );
}
