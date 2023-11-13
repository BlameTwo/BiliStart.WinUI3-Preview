using Network.Models;
using Network.Models.Live;

namespace INetwork.IProviders;

public interface ILiveProvider
{
    Task<ResultCode<LiveRoomInfo>> GetLiveDanmakuInfoAsync(
        int roomId,
        CancellationToken canceltoken = default
    );

    /// <summary>
    /// 创建直播间消息
    /// </summary>
    /// <param name="info">直播间Url基础信息</param>
    /// <param name="roomid">Roomid</param>
    /// <returns></returns>
    ILiveClient CreateClient(
        LiveRoomInfo info,
        int roomid,
        CancellationToken canceltoken = default
    );

    public Task<ResultCode<LiveFeedDataModel>> GetLiveFeedDataAsync(
        int page = 1,
        CancellationToken canceltoken = default
    );

    public Task<ResultCode<LiveTagDataModel>> GetLiveTagDataAsync(
        CancellationToken canceltoken = default
    );

    public Task<ResultCode<LiveTagItemDataModel>> GetLiveTagItemDataAsync(
        long parentid,
        long areaid,
        string sort_type,
        int page = 1,
        int pagesize = 30,
        CancellationToken canceltoken = default
    );
    public Task<ResultCode<LiveTagItemDataModel>> GetLiveTagItemDataAsync(
        long parentid,
        long areaid,
        int page = 1,
        int pagesize = 30,
        CancellationToken canceltoken = default
    );

    public Task<ResultCode<LiveRoomDetailDataModel>> GetLiveRoomInfoAsync(
        long roomId,
        CancellationToken canceltoken = default
    );

    public Task<ResultCode<LiveUrlDataModel>> GetLiveRoomUrlInfoAsync(
        long roomId,
        CancellationToken canceltoken = default
    );

    public Task<ResultCode<LiveUrlDataModel>> GetLiveRoomUrlInfoAsync(
        long roomId,
        long Quality,
        bool OnlyAudio,
        CancellationToken canceltoken = default
    );

    IBIliDocument BIliDocument { get; }
}
