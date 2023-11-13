namespace Network.Models;

/// <summary>
/// Bilibili的API Key
/// </summary>
/// <param name="Key"></param>
/// <param name="Secret"></param>
public record class ApiKey(string Key, string Secret)
{
    public static string Version = "3.0.0";

    /// <summary>
    /// TVKey
    /// </summary>
    public static ApiKey AndroidTVKey { get; } =
        new ApiKey("4409e2ce8ffd12b8", "59b43e04ad6965f34319062b478f83dd");

    /// <summary>
    /// 安卓Key
    /// </summary>
    public static ApiKey AndroidKey { get; } =
        new ApiKey("1d8b6e7d45233436", "560c52ccd288fed045859ed18bffd973");

    /// <summary>
    /// 登录Key，TV端
    /// </summary>
    public static ApiKey LoginKey { get; } =
        new ApiKey("783bbb7264451d82", "2653583c8873dea268ab9386918b1d65");

    /// <summary>
    /// Uwp Key（可能是）
    /// </summary>
    public static ApiKey UWPKey { get; } =
        new ApiKey("7d089525d3611b1c", "acd495b248ec528c2eed1e862d393126");

    /// <summary>
    /// IOS Key
    /// </summary>
    public static ApiKey IOSKey { get; } =
        new ApiKey("27eb53fc9058f8c3", "c2ed53a74eeefe3cf99fbd01d8c9c375");

    /// <summary>
    /// Web Key
    /// </summary>
    public static ApiKey WebKey { get; } =
        new ApiKey("84956560bc028eb7", "94aba54af9065f71de72f5508f1cd42e");
}
