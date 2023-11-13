using Windows.ApplicationModel.Resources.Core;

namespace AppViews;

/// <summary>
/// 应用资源读取类
/// </summary>
public static class BiliResourceLoader
{
    /// <summary>
    /// 总Resources
    /// </summary>
    internal static ResourceMap ViewPageMap { get; private set; } = null;

    /// <summary>
    /// ViewResources
    /// </summary>
    internal static ResourceMap View { get; private set; } = null;

    private static string ViewPage = "ViewPage";

    private static string Settings = "Settings";

    private static string Dialog = "Dialog";

    static BiliResourceLoader()
    {
        ViewPageMap = ResourceManager.Current.MainResourceMap;
        View = ViewPageMap.GetSubtree("Views");
    }

    public static string ReadResourceString(string key, string name)
    {
        var result = View.GetValue($"{key}/{name}");
        if (result == null || result.ValueAsString == null)
            return "NULL";
        return result.ValueAsString;
    }

    public static string ReadViewResourceString(string name)
    {
        return ReadResourceString(ViewPage, name);
    }

    public static string ReadDialogResourceString(string name)
    {
        return ReadResourceString(Dialog, name);
    }

    public static string ReadSettingResourceString(string name)
    {
        return ReadResourceString(Settings, name);
    }
}
