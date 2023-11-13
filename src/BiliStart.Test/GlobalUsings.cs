global using Microsoft.VisualStudio.TestTools.UnitTesting;
global using BiliNetWork;
global using INetwork.IProviders;
global using App.Models.MediaPlayerArgs;
global using INetwork;
global using BiliNetWork.Providers;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using IViewConverter;
global using ViewConverter;
namespace BiliStart.Test;

/*
 本测试单元仅测试Api数据接口相关
 
 */

public static class TestService
{
    public static void Register()
    {
        Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder().RegisterNetwork().Build();
        ((IHttpClientProvider)TestService.Host.Services.GetService(typeof(IHttpClientProvider))!).InitClient();
        //这里的TokenName本来就为保存到数据，若想调试本测试单元，请首先登陆后修改属性值再测试。
        ((ICurrent)TestService.Host.Services.GetService(typeof(ICurrent))!).TokenName = 108534711;

    }

    public static IHost Host = null;

    public static IHostBuilder RegisterNetwork(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices(
            (contenxt, service) =>
            {
                //请求头组装
                service.AddSingleton<IRequestMessage, RequestMessage>();
                //Http验证拓展
                service.AddSingleton<IHttpExtensions, HttpExtensions>();
                //登录控制器
                service.AddSingleton<ILoginProvider, LoginProvider>();
                //搜索服务控制器
                service.AddTransient<ISearchProvider, SearchProvider>();
                //普通视频控制器
                service.AddSingleton<IVideoProvider, VideoProvider>();
                //账户控制器
                service.AddSingleton<IAccountProvider, AccountProvider>();
                //账户消息控制器
                service.AddSingleton<IMessagerProvider, MessagerProvider>();
                //流媒体控制器
                service.AddSingleton<IBangumiProvider, BangumiProvider>();
                //Http控制器
                service.AddSingleton<IHttpClientProvider, HttpClientProvider>();
                //分区控制器
                service.AddSingleton<ITidProvider, TidProvider>();
                //弹幕控制器
                service.AddSingleton<IDanmakuProvider, DanmakuProvider>();
                //B站的订阅服务控制器
                service.AddSingleton<IBiliServiceProvider, BiliServiceProvider>();
                //号码转换控制器
                service.AddSingleton<IAvToBvConverter, AvToBvConverter>();
                //回复控制器
                service.AddSingleton<IReplyProvider, ReplyProvider>();
                //二次Token获取接口
                service.AddSingleton<IAccountTokenSet, AccountTokenSet>();
                //Token管理
                service.AddSingleton<ITokenManager, TokenManager>();
                //B站数据序列化转换
                service.AddSingleton<IBIliDocument, BIliDocument>();
                //非BiliBili的API
                service.AddSingleton<IThirdApiProvider, ThirdApiProvider>();
                //直播相关控制器
                service.AddSingleton<ILiveProvider, LiveProvider>();
                
                service.AddSingleton<ICurrent,Current>();

                service.AddSingleton<IFileEncryptionProviderService, FileEncryptionProviderService>();

                service.AddSingleton<IVideoViewModelConverter, VideoViewModelConverter>();
                service.AddSingleton<IPlayerViewModelConverter, PlayerViewModelConverter>();
                service.AddSingleton<IBiliDataViewModelConverter, BiliDataViewModelConverter>();
                service.AddSingleton<IAccountHistoryConverter, AccountHistoryConverter>();
                service.AddSingleton<IAccountDynamicConverter, AccountDynamicConverter>();
            }
        );
        return hostBuilder;
    }
}
