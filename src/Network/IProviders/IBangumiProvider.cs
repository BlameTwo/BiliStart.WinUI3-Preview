using Network.Models;
using Network.Models.Bangumi;

namespace INetwork.IProviders;

public interface IBangumiProvider
{
    /// <summary>
    /// 获得流媒体详情
    /// </summary>
    /// <param name="seasonId">SID</param>
    /// <returns></returns>
    public Task<ResultCode<BangumiDetilyModel>> GetBangumiViewInfoAsync(
        string seasonId,
        CancellationToken canceltoken = default
    );

    /// <summary>
    /// 电影列表
    /// </summary>
    /// <param name="cursor">游标</param>
    /// <returns></returns>
    public Task<ResultData<BangumiModel>> GetMoviePageInfoAsync(
        BangumiCursor cursor = null,
        CancellationToken canceltoken = default
    );

    /// <summary>
    /// 纪录片列表
    /// </summary>
    /// <param name="cursor">游标</param>
    /// <returns></returns>
    public Task<ResultData<BangumiModel>> GetDocumentaryPageInfoAsync(
        BangumiCursor cursor = null,
        CancellationToken canceltoken = default
    );

    /// <summary>
    /// 电视剧列表
    /// </summary>
    /// <param name="cursor">游标</param>
    /// <returns></returns>
    public Task<ResultData<BangumiModel>> GetDTVPageInfoAsync(
        BangumiCursor cursor = null,
        CancellationToken canceltoken = default
    );

    /// <summary>
    /// 综艺列表
    /// </summary>
    /// <param name="cursor">游标</param>
    /// <returns></returns>
    public Task<ResultData<BangumiModel>> GetVarietyPageInfoAsync(
        BangumiCursor cursor = null,
        CancellationToken canceltoken = default
    );

    /// <summary>
    /// 获得播放信息和地址
    /// </summary>
    /// <param name="aid"></param>
    /// <param name="Epid"></param>
    /// <param name="Cid"></param>
    /// <returns></returns>
    public Task<ResultData<PgcDashInfo>> GetBangumiUrlInfoAsync(
        long aid,
        long Epid,
        long Cid,
        CancellationToken canceltoken = default
    );
}
