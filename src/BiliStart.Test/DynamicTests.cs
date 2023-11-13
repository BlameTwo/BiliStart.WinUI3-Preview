using ViewConverter.Models.Dynamic;

namespace BiliStart.Test;

/// <summary>
/// 用户动态测试
/// </summary>
[TestClass]
public class DynamicTests
{
    void SetupRegister()
    {
        TestService.Register();
    }

    CancellationTokenSource tokensouce = new();

    /// <summary>
    /// 测试动态
    /// </summary>
    [TestMethod]
    public async Task AccountAllDynamicTestAsync()
    {
        SetupRegister();
        var Account = (IAccountProvider)
            TestService.Host.Services.GetService(typeof(IAccountProvider))!;
        UserAllModel model = new();
        for (int i = 1; i < 6; i++)
        {
            //这里需要传入
            var result = await Account.GetAccountAllDynamicAsync(
                model.HistoryOffset,
                model.Businessid,
                tokensouce.Token
            );
            model = result;
        }
    }

    /// <summary>
    /// 测试视频动态
    /// </summary>
    /// <returns></returns>
    [TestMethod]
    public async Task AccountVideoDynamicTestAsync()
    {
        SetupRegister();
        var Account = (IAccountProvider)
            TestService.Host.Services.GetService(typeof(IAccountProvider))!;
        await Account.GetAccountVideoDynamicAsync(tokensouce.Token);
    }
}
