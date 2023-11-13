namespace BiliNetWork.Providers;

public sealed class TidProvider : ITidProvider
{
    public TidProvider(
        IRequestMessage requestMessage,
        IHttpClientProvider httpClientProvider,
        IBIliDocument bIliDocument
    )
    {
        RequestMessage = requestMessage;
        HttpClientProvider = httpClientProvider;
        BIliDocument = bIliDocument;
    }

    public IRequestMessage RequestMessage { get; }
    public IHttpClientProvider HttpClientProvider { get; }
    public IBIliDocument BIliDocument { get; }

    public async Task<ResultCode<List<TidData>>> GetTidIconListAsync(
        CancellationToken canceltoken = default
    )
    {
        var request = await RequestMessage.GetHttpRequestMessageAsync(
            Apis.TID_ICON,
            RequestType.IOS,
            HttpMethod.Get,
            new(),
            true,
            false,
            true
        );
        var reponse = await HttpClientProvider.SendAsync(request);
        return await BIliDocument.CheckDataCode<List<TidData>>(request, reponse)!;
    }

    /// <summary>
    /// 转换排行榜显示Tid
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public List<TidData> FormatRank(List<TidData> data)
    {
        var lists = new List<TidData>();
        foreach (var item in data)
        {
            bool rankflage = false;
            foreach (var config in item.Configs)
            {
                if (config.Region_Type == "rank" && !string.IsNullOrWhiteSpace(item.Logo))
                    rankflage = true;
            }
            if (rankflage)
                lists.Add(item);
        }
        return lists;
    }

    /// <summary>
    /// 转换分区ID的
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public List<TidData> FormatPage(List<TidData> data)
    {
        var lists = new List<TidData>();
        return lists;
    }
}
