using Network.Models;

namespace INetwork.IProviders;

/// <summary>
///  分区控制器
/// </summary>
public interface ITidProvider
{
    public Task<ResultCode<List<TidData>>> GetTidIconListAsync(
        CancellationToken canceltoken = default
    );

    public List<TidData> FormatRank(List<TidData> data);

    public List<TidData> FormatPage(List<TidData> data);
}
