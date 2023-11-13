using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewConverter.Models.Dynamic;

namespace BiliStart.Test;

[TestClass]
public class BiliServiceTests
{
    void SetupRegister()
    {
        TestService.Register();
    }

    CancellationTokenSource tokensouce = new();

    /// <summary>
    /// 测试互动抽奖
    /// </summary>
    /// <returns></returns>
    [TestMethod]
    public async Task LotteryTest()
    {
        SetupRegister(); 
        var service = (IBiliServiceProvider)
            TestService.Host.Services.GetService(typeof(IBiliServiceProvider))!;
        string busid = "849321566515757077";
        string bustype = "1";

        var result = await service.GetLotteryResultAsync(busid, bustype);
    }

    [TestMethod("测试开屏壁纸获取")]
    public async Task BrandTest()
    {
        SetupRegister();
        var service = (IBiliServiceProvider)
            TestService.Host.Services.GetService(typeof(IBiliServiceProvider))!;
        var result =  await service.GetAppBrandListAsync();
    }
}
