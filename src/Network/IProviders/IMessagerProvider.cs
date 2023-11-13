using Network.Models;
using Network.Models.Accounts;

namespace INetwork.IProviders;

/// <summary>
/// 用户消息
/// </summary>
public interface IMessagerProvider
{
    /// <summary>
    /// 获得简单消息
    /// </summary>
    /// <returns></returns>
    public Task<ResultCode<AccountMessage>> GetAccountMessageAsync(
        CancellationToken canceltoken = default
    );

    /// <summary>
    /// 获得消息主题
    /// </summary>
    /// <returns></returns>
    public Task<string> GetMessageDataAsync(CancellationToken canceltoken = default);
}
