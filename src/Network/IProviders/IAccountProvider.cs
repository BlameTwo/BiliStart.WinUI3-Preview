using Bilibili.App.Interface.V1;
using Network.Models;
using Network.Models.Accounts;
using ViewConverter.Models.AccountHistory;
using ViewConverter.Models.Dynamic;

namespace INetwork.IProviders;

public interface IAccountProvider
{
    public Task<AccountVideoHistoryModel> GetAccountHistoryAsync(
        Cursor cursor,
        string tabname = "archive",
        CancellationToken canceltoken = default
    );

    /// <summary>
    /// 获得登录信息
    /// </summary>
    /// <returns></returns>
    public Task<ResultCode<MyInfo>> GetAccountInfoAsync(CancellationToken canceltoken = default);

    /// <summary>
    /// 获得顶部导航的信息
    /// </summary>
    /// <returns></returns>
    public Task<ResultCode<MyData>> GetAccountTopNavigationAsync(
        CancellationToken canceltoken = default
    );

    /// <summary>
    /// 获得单次登录信息
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    public Task<ResultCode<MyInfo>> GetTokenInfoAsync(
        AccountToken token,
        CancellationToken canceltoken = default
    );

    /// <summary>
    /// 获得用户空间信息
    /// </summary>
    /// <returns></returns>
    public Task<ResultCode<MySpace>> GetAccountSpaceAsync(
        long mid,
        CancellationToken canceltoken = default
    );

    /// <summary>
    /// 获得当前登录IP
    /// </summary>
    /// <returns></returns>
    public Task<ResultCode<IpModel>> GetAccountIpAsync(CancellationToken canceltoken = default);

    /// <summary>
    /// 全部视频动态
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<UserAllModel> GetAccountAllDynamicAsync(
        string HistoryOffset = "",
        string BussinessId = "",
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// 视频类型视频动态
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task GetAccountVideoDynamicAsync(CancellationToken cancellationToken = default);

    public Task<AccountVideoHistoryModel> GetAccountLiveHistoryAsync(
        Cursor cursor,
        CancellationToken token = default
    );
}
