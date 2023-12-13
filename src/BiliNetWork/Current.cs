/*
 2023.7.9
此服务中包含临时的请求头配置信息，以及基本的登录信息判断
 */

namespace BiliNetWork;

public sealed class Current : ICurrent
{
    public Current(ITokenManager tokenManager)
    {
        LocalID = Guid.NewGuid().ToString("N");
        Build = "7430300";
        TokenManager = tokenManager;
        TokenName = 0;
    }

    public string LocalID { get; set; }
    public string Build { get; set; }
    public long TimeSpanSeconds
    {
        get { return DateTimeOffset.Now.ToLocalTime().ToUnixTimeSeconds(); }
    }

    public long TimeSpanMilliSeconds
    {
        get { return DateTimeOffset.Now.ToLocalTime().ToUnixTimeMilliseconds(); }
    }

    public ITokenManager TokenManager { get; }

    private long _tokenName;
    public long TokenName
    {
        get { return _tokenName; }
        set { _tokenName = value; }
    }

    public async Task<string> GetAccessCookieAsync()
    {
        var result = await TokenManager.GetToken(TokenName);
        if (result.CookieString != null)
            return result.CookieString;
        return null;
    }

    async Task<bool> islogin()
    {
        var token = await TokenManager.GetToken(TokenName);
        if (token == null)
            return false;
        if (token.LastTokenSaveTime == null)
            return false;
        string offsetstr = token.LastTokenSaveTime.ToString();
        var lastoffset = DateTimeOffset.Parse(offsetstr);
        bool istt = (DateTimeOffset.Now - lastoffset).TotalSeconds < token.Expires_in;
        if (token.AccessToken != null && token.SECCDATA != null && istt)
        {
            return true;
        }
        return false;
    }

    async Task<bool> ICurrent.IsLoginAsync()
    {
        return await islogin();
    }

    public async Task<string> GetCSRFAsync()
    {
        var token = await TokenManager.GetToken(TokenName);
        string csrf = null;
        foreach (var item in token.cookies.Cookies)
        {
            if (item.Name == "bili_jct")
            {
                csrf = item.Value;
                break;
            }
        }
        return csrf;
    }

    public string GetAppVersion()
    {
        return "0.0.5";
    }

    public string GetAppPublishWay()
    {
        return "preview";
    }
}
