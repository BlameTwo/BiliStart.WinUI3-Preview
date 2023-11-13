/*
 2023.7.9
AppSerivce的主要作用为注册容器，并发放对象（T,Type）。
 */



namespace AppContractService;

public static partial class AppService
{
    /// <summary>
    /// 运行方式，0为Debug，1为Release（无用
    /// </summary>
    static int RunMode = 0;
    public static IHost Host { get; set; }

    public static void InitService<T>(T app)
        where T : BiliApplication
    {
        Host = Microsoft.Extensions.Hosting.Host
            .CreateDefaultBuilder()
            .RegisterPage()
            .RegisterAppNavigation()
            .RegisterNetwork()
            .RegisterDialog()
            .RegisterExtensions()
            .RegisterItemVM()
            .RegisterLog()
            .RegisterPopup()
            .Build();
    }

    public static T GetService<T>()
    {
        if (Host.Services.GetRequiredService(typeof(T)) is not T service)
        {
            throw new ArgumentException($"{typeof(T)} 不存在于注册主机内。");
        }
        return service;
    }

    public static T GetKeyService<T>(string key)
    {
        if(Host.Services.GetRequiredKeyedService(typeof(T), key) is not T service)
        {
            throw new ArgumentException($"{typeof(T)} 不存在于注册主机内。");
        }
        return service;
    }

    public static object GetService(Type type)
    {
        if (Host.Services.GetRequiredService(type) == null)
        {
            throw new System.Exception($"注册项目缺少{type}");
        }
        return Host.Services.GetRequiredService(type)!;
    }
}
