using ViewConverter.Models;

namespace INetwork.IProviders;

public interface IDanmakuProvider
{
    public Task<IEnumerable<DanmakuSession>> GetVideoDanmakuAsync(
        long aid,
        long cid,
        int segmentIndex,
        CancellationToken canceltoken = default
    );

    public Task<string> SendDanmaku(
        string content,
        long aid,
        long cid,
        int type,
        long progress,
        int color,
        DanmakuType danmakuType,
        CancellationToken canceltoken = default
    );
}
