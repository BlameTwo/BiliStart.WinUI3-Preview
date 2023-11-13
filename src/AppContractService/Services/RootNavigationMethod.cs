using Google.Protobuf.WellKnownTypes;
using Lib.Helper;
using Network.Models.Live;

namespace AppContractService.Services;

public class RootNavigationMethod : IRootNavigationMethod, IAppService
{
    public RootNavigationMethod(
        IWindowManager windowManager,
        [FromKeyedServices(NavHostingConfig.RootNav)] INavigationService navigationService,
        ICurrent current,
        ITokenManager tokenManager
    )
    {
        this.WindowManager = windowManager;
        RootNavigationService = navigationService;
        Current = current;
        TokenManager = tokenManager;
    }


    public string ServiceID { get; set; } = nameof(PageService);
    public IWindowManager WindowManager { get; }
    public INavigationService RootNavigationService { get; }
    public ICurrent Current { get; }
    public ITokenManager TokenManager { get; }






    bool NavigationBuild<T>(string keyvalue, T value)
    {
        var paramter = BuildModel<T>(value);
        var result =  RootNavigationService.NavigationTo(keyvalue, paramter);
        if(result)
            NavRootCount++;
        return result;
    }

    bool NavigationBuild(string keyvalue)
    {
        var paramter = BuildModel();
        var result = RootNavigationService.NavigationTo(keyvalue, paramter);
        if (result)
            NavRootCount++;
        return result;
    }


    /// <summary>
    /// 构建带参
    /// </summary>
    /// <typeparam name="Paramter"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    RootNavigationModel<Paramter> BuildModel<Paramter>(Paramter value) =>
        new RootNavigationModel<Paramter>()
        {
            Data = value,
            AWindow = WindowManager.GetAppWindow(),
            Window = WindowManager.GetWindow()
        };

    /// <summary>
    /// 构建无参
    /// </summary>
    /// <returns></returns>
    RootNavigationModel BuildModel() =>
        new RootNavigationModel()
        {
            AWindow = WindowManager.GetAppWindow(),
            Window = WindowManager.GetWindow()
        };

    /// <summary>
    /// Root从导航到Main后的导航次数
    /// </summary>
    int NavRootCount { get; set; } = 0;

    /// <summary>
    /// 回到首页
    /// </summary>
    public void BackMain()
    {
        //这里加一个is转换返回Main
        if(this.RootNavigationService is RootNavigationService navigation)
        {
            navigation.BackMain();
        }
    }
}
