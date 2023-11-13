using Microsoft.VisualStudio.TestTools.UnitTesting;
using Windows.Storage.Streams;

namespace BiliStart.Test;

[TestClass]
public class GenshinVitsTests
{
    void SetupRegister()
    {
        TestService.Register();
    }

    [TestMethod]
    public async Task VitsTest()
    {
        SetupRegister();
        IThirdApiProvider thirdApiProvider = TestService.Host.Services.GetService<IThirdApiProvider>()!;
        var stream = await thirdApiProvider.GetVITSDataAsync(new Network.Models.ThirdApi.VitsRequest("你好","可可利亚"));
        
    }
}
