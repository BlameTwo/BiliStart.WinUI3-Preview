namespace INetwork;

/// <summary>
/// BiliNetwork的配置信息
/// </summary>
public interface ICurrent
{
    /// <summary>
    /// 登录设备UID
    /// </summary>
    public string LocalID { get; set; }

    /// <summary>
    /// 请求最长时间
    /// </summary>
    public long TimeSpanSeconds { get; }

    public long TimeSpanMilliSeconds { get; }

    public long TokenName { get; set; }

    /// <summary>
    /// 客户端请求BUILD版本号代码
    /// </summary>
    public string Build { get; set; }

    /// <summary>
    /// 获得是否登录或登录token有效
    /// </summary>
    /// <returns></returns>
    public Task<bool> IsLoginAsync();

    /// <summary>
    /// 获得CSRF跨域校验值
    /// </summary>
    /// <returns></returns>
    public Task<string> GetCSRFAsync();

    /// <summary>
    /// 获得用户的Cookie
    /// </summary>
    /// <returns></returns>
    public Task<string> GetAccessCookieAsync();

    /// <summary>
    /// 获取当前应用版本
    /// </summary>
    /// <returns></returns>
    public string GetAppVersion();

    /// <summary>
    /// 获得当前应用发布渠道
    /// </summary>
    /// <returns></returns>
    public string GetAppPublishWay();
}
