using Network.Models.ThirdApi;

namespace INetwork.IProviders;

/// <summary>
/// 非B站API
/// </summary>
public interface IThirdApiProvider
{
    /// <summary>
    /// 获取Bing Api
    /// </summary>
    /// <returns></returns>
    public Task<BingWallpaperModel> GetBingWallpaperAsync(CancellationToken canceltoken = default);

    /// <summary>
    /// 获取每日一言
    /// </summary>
    /// <returns></returns>
    public Task<EveryDayModel> GetEveryDayAsync(CancellationToken canceltoken = default);

    /// <summary>
    /// 每日一言的点赞数量
    /// </summary>
    /// <param name="uuid"></param>
    /// <returns></returns>
    public Task<EveryDayTotalModel> GetEveryDayTotalAsync(
        string uuid,
        CancellationToken canceltoken = default
    );


    /// <summary>
    /// 原神VITS合成
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public Task<Stream> GetVITSDataAsync(VitsRequest args);

    /// <summary>
    /// Yurikoto 壁纸API
    /// </summary>
    /// <param name="canceltoken"></param>
    /// <returns></returns>

    public Task<YurikotoWallpaperModel> GetYurikoWallpaper(CancellationToken canceltoken = default);
}
