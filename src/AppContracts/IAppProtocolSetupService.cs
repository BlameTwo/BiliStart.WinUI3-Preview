using System;

namespace IAppContracts;

/// <summary>
/// 一个后置保存Uri协议启动的解耦服务
/// </summary>
public interface IAppProtocolSetupService
{
    /// <summary>
    /// 保存Uri
    /// </summary>
    /// <param name="uri"></param>
    public void SaveUri(Uri uri);

    /// <summary>
    /// 后置执行
    /// </summary>
    public void Invoke();

    /// <summary>
    /// 检查Uri是否合法
    /// </summary>
    /// <returns></returns>
    public bool Check();

    /// <summary>
    /// 传入Uri执行
    /// </summary>
    /// <param name="uri"></param>
    public void Invoke(Uri uri);
}
