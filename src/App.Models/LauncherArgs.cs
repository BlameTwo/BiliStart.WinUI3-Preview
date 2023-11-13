namespace App.Models;

public class LauncherArgs
{
    public static readonly string PluginArg = "--plugin";

    /// <summary>
    /// 默认启动方式，为空也是默认启动
    /// </summary>
    public static readonly string DefaultArg = "--application";
}

/// <summary>
/// 启动方式
/// </summary>
public enum LauncherMode
{
    Plugin,
    Default,
    InstallPlugin
}
