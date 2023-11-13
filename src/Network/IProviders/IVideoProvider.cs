using Bilibili.App.Show.V1;
using Network.Models;
using Network.Models.Accounts;
using Network.Models.Enum;
using Network.Models.Totals.HotHistory;
using Network.Models.Videos;
using System.Text;
using ViewConverter.Models;
using ViewConverter.Models.VideoModel;

namespace INetwork.IProviders;

public interface IVideoProvider
{
    /// <summary>
    /// 获得首页推荐
    /// </summary>
    /// <returns></returns>
    public Task<HomeVideoBase> GetHomeVideoAsync(
        bool isRefersh,
        string idx = null,
        string hash = null,
        CancellationToken canceltoken = default
    );
    public int RankMaxPs { get; set; }

    /// <summary>
    /// 获得全区排行榜
    /// </summary>
    /// <returns></returns>
    public Task<List<RankVideo>> GetRankListAsync(
        int pn,
        int tid,
        CancellationToken canceltoken = default
    );

    public Task<HotVideoModel> GetHotListAsync(
        long idx = 0,
        CancellationToken canceltoken = default
    );

    /// <summary>
    /// 获得视频的播放源
    /// </summary>
    /// <returns></returns>
    public Task<ResultCode<Network.Models.Videos.VideoInfo>> GetVideoDashSourceAsync(
        VideoTypeEnum typeEnum,
        long cid,
        string id,
        int dashEnum = 0,
        FnvalEnum fnvalEnum = FnvalEnum.FLV,
        CancellationToken canceltoken = default
    );

    public Task<PlayerView> GetVideoViewAsync(
        VideoTypeEnum type,
        string id,
        CancellationToken canceltoken = default
    );

    public Task<ResultCode<HotHistoryNavigationModel>> GetHotHistoryNavigationAsync(
        CancellationToken canceltoken = default
    );

    public Task<ResultCode<HotHistoryNavigationModel>> GetHotHistoryModelAsync(
        string pageid,
        CancellationToken canceltoken = default
    );

    public Task<ResultCode<HotHistoryItems>> GetHotHistoryItemAsync(
        string pageid,
        HotHistoryNavigationModel model,
        CancellationToken canceltoken = default
    );
}
