using System.Text.Json.Serialization;

namespace Network.Models.Accounts;

public class AccountLoginData
{
    /// <summary>
    /// 二维码Url
    /// </summary>
    [JsonPropertyName("url")]
    public string PicUrl { get; set; }

    /// <summary>
    /// 校验码
    /// </summary>

    [JsonPropertyName("auth_code")]
    public string QRKey { get; set; }
}

public class LoginTrueString
{
    /// <summary>
    /// 携带的json字符串
    /// </summary>
    public string Body { get; set; }

    /// <summary>
    /// 检查状态
    /// </summary>
    public Checkenum Check { get; set; }

    /// <summary>
    /// 返回的Cookie信息
    /// </summary>
    public string Cookie { get; set; }
}

/// <summary>
/// 检查状态
/// </summary>
public enum Checkenum
{
    /// <summary>
    /// 超时
    /// </summary>
    OnTime,

    /// <summary>
    /// 登录成功
    /// </summary>
    Yes,

    /// <summary>
    /// 未扫码
    /// </summary>
    No,

    /// <summary>
    /// 扫了码未确定
    /// </summary>
    YesOrNo
}

/// <summary>
/// 登录cookie
/// </summary>
public class AccountToken : ICloneable
{
    /// <summary>
    /// 是否是新用户？
    /// </summary>
    [JsonPropertyName("is_new")]
    public bool IsNewAccount { get; set; }

    /// <summary>
    /// Token保存时间
    /// </summary>
    [JsonPropertyName("LastTokenSaveTime")]
    public string LastTokenSaveTime { get; set; }

    /// <summary>
    /// 你滴账号
    /// </summary>
    [JsonPropertyName("mid")]
    public long Mid { get; set; } = 0;

    /// <summary>
    /// 你滴访问权限
    /// </summary>
    [JsonPropertyName("access_token")]
    public string SECCDATA { get; set; } = "";

    /// <summary>
    /// 用来刷新Token的字符串
    /// </summary>
    [JsonPropertyName("refresh_token")]
    public string RefToken { get; set; }

    /// <summary>
    /// 有效时间
    /// </summary>
    [JsonPropertyName("expires_in")]
    public long Expires_in { get; set; }

    [JsonPropertyName("token_info")]
    public AccountToken Info { get; set; }

    [JsonPropertyName("cookie_info")]
    public AccountTokenCookies cookies { get; set; }

    public string CookieString
    {
        get
        {
            if (cookies == null)
                return null;
            string str = "";
            foreach (var item in cookies.Cookies)
            {
                str += $"{item.Name}={item.Value};";
            }
            return str;
        }
    }

    [JsonPropertyName("sso")]
    public string[] SSO { get; set; }

    [JsonPropertyName("hint")]
    public string Hint { get; set; }

    [JsonPropertyName("AccessToken")]
    public string AccessToken { get; set; } = null;

    public object Clone()
    {
        return this;
    }
}

public class AccountTokenCookies
{
    /// <summary>
    /// Cookie列表
    /// </summary>
    [JsonPropertyName("cookies")]
    public List<Cookie> Cookies { get; set; }

    /// <summary>
    /// 可跨的域
    /// </summary>

    [JsonPropertyName("domains")]
    public string[] Domains { get; set; }
}

public class Cookie
{
    /// <summary>
    /// Cookie名称
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// Cookie值
    /// </summary>

    [JsonPropertyName("value")]
    public string Value { get; set; }

    /// <summary>
    /// 暂时不明白
    /// </summary>

    [JsonPropertyName("http_only")]
    public int Http_Only { get; set; }

    /// <summary>
    /// 剩余时间？
    /// </summary>

    [JsonPropertyName("expires")]
    public long Expires { get; set; }

    [JsonPropertyName("secure")]
    public int Secure { get; set; }
}
