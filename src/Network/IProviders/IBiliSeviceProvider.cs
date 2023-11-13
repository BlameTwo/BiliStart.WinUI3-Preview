using Bilibili.App.Search.V2;
using Bilibili.Broadcast.Message.Main;
using Network.Models;
using Network.Models.Enum;
using Network.Models.Services;
using Network.Models.ThirdApi;
using Network.Models.Totals;
using ViewConverter.Models;
using ViewConverter.Models.ServiceData;

namespace INetwork.IProviders;

public interface IBiliServiceProvider
{
    /// <summary>
    /// 订阅MusicRank
    /// </summary>
    /// <param name="flage">是否订阅</param>
    /// <returns></returns>
    Task<ResultCode<CheckMusicRankRegisterModel>> GetRegisterMusicRankAsync(
        CancellationToken canceltoken = default
    );

    /// <summary>
    /// 设置订阅MusicRank
    /// </summary>
    /// <param name="state"></param>
    /// <returns></returns>
    Task<bool> SetRegisterMusicRankAsync(bool state, CancellationToken canceltoken = default);

    Task<ResultCode<MusicRankDataIDModel>> GetMusicListIDAsync(
        CancellationToken canceltoken = default
    );

    Task<List<MusicRankCard>> GetMusicItemsAsync(
        MusicRankIDItem data,
        CancellationToken canceltoken = default
    );

    #region AI搜索
    public Task<SubmitChatTaskReply> CreateChat(string ask, ChatSourceEnum type);

    public Task<ChatResult> AskChat(string ask, ChatSourceEnum type, string ssid);
    #endregion

    #region 热搜榜单
    /// <summary>
    /// 获得热搜
    /// </summary>
    /// <returns></returns>
    Task<ResultCode<HotSearch>> GetSearchRankListAsync(CancellationToken canceltoken = default);
    #endregion

    public Task<ResultCode<LotteryResultMode>> GetLotteryResultAsync(string busid, string bustype);


    public Task<AppBrandSource> GetAppBrandListAsync();
}
