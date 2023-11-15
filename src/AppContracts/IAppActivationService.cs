using App.Models;
using App.Models.Enum;
using IAppExtension.Contract;
using Microsoft.Windows.AppLifecycle;
using System.Threading.Tasks;

namespace IAppContracts;

/// <summary>
/// 应用程序启动类
/// </summary>
/// <typeparam name="T">继承于BiliApplication</typeparam>
public interface IAppActivationService<T>
    where T : BiliApplication, IAppService
{
    /// <summary>
    /// 主题服务
    /// </summary>
    IThemeService<T> ThemeService { get; }

    /// <summary>
    /// 启动方法
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    Task ActivationAsync(T app, SetupEnum type);

    /// <summary>
    /// 处理启动参数
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    void ActivationProtocolSetup(AppActivationArguments args);

    SetupEnum GetSetupType();
}
