using Bilibili.Broadcast.Message.Main;
using System.Security.Cryptography;

namespace BiliNetWork;

public sealed class HttpExtensions : IHttpExtensions
{
    public HttpExtensions(ICurrent current, ITokenManager tokenManager)
    {
        Current = current;
        TokenManager = tokenManager;
    }

    public ICurrent Current { get; }
    public ITokenManager TokenManager { get; }

    public async Task<string> GetClientType(
        Dictionary<string, string> keyvalues,
        RequestType requestType,
        bool isaccess,
        bool issign,
        AccountToken logindata = null
    )
    {
        switch (requestType)
        {
            case RequestType.Android:
                keyvalues.Add("appkey", ApiKey.AndroidKey.Key);
                keyvalues.Add("mobi_app", "android");
                keyvalues.Add("build", gRpcConfig.Build.ToString());
                keyvalues.Add("device", "android");
                keyvalues.Add("channel", "bili");
                keyvalues.Add("c_locale", "zh_CN");
                keyvalues.Add("s_locale", "zh_CN");
                keyvalues.Add("platform", "android");
                keyvalues.Add("ts", Current.TimeSpanSeconds.ToString());
                break;
            case RequestType.Web:
                keyvalues.Add("appkey", ApiKey.WebKey.Key);
                keyvalues.Add("platform", "web");
                break;
            case RequestType.IOS:
                keyvalues.Add("appkey", ApiKey.IOSKey.Key);
                keyvalues.Add("build", gRpcConfig.Build.ToString());
                keyvalues.Add("mobi_app", "iphone");
                keyvalues.Add("channel", "bili");
                //这里的c_locale 可能可以更改数据源返回语言
                keyvalues.Add("c_locale", "zh_CN");
                keyvalues.Add("s_locale", "zh_CN");
                keyvalues.Add("device", "phone");
                keyvalues.Add("platform", "ios");
                keyvalues.Add("ts", Current.TimeSpanSeconds.ToString());
                break;
            case RequestType.Login:
                keyvalues.Add("appkey", ApiKey.LoginKey.Key);
                keyvalues.Add("ts", Current.TimeSpanSeconds.ToString());
                keyvalues.Add("device", "android");
                keyvalues.Add("platform", "android");
                keyvalues.Add("mobi_app", "android");
                break;
            case RequestType.Third:
                keyvalues.Add("appkey", ApiKey.IOSKey.Key);
                break;
            case RequestType.Custom:
                keyvalues.Add("appkey",ApiKey.AndroidKey.Key);
                keyvalues.Add("ts", Current.TimeSpanSeconds.ToString());
                break;
        }
        string quest = "";
        if (issign)
            quest = await SignQuery(keyvalues, requestType, isaccess, logindata);
        else
        {
            var questlist = keyvalues.Select(x => $"{x.Key}={x.Value}");
            quest = string.Join("&", questlist);
        }
        return quest;
    }

    internal async Task<string> SignQuery(
        Dictionary<string, string> parameters,
        RequestType requestType,
        bool isaccess,
        AccountToken logindata = null
    )
    {
        var token = await TokenManager.GetToken(Current.TokenName);
        if (isaccess == true)
        {
            if (logindata != null)
            {
                if (requestType == RequestType.Android)
                {
                    parameters.Add($"access_key", logindata.SECCDATA);
                }
                else
                {
                    parameters.Add($"access_key", logindata.AccessToken);
                }
            }
            else if (logindata == null && token != null)
            {
                if (requestType == RequestType.Android)
                {
                    parameters.Add($"access_key", token.SECCDATA);
                }
                else
                {
                    parameters.Add($"access_key", token.AccessToken);
                }
            }
        }
        var questlist = parameters.Select(x => $"{x.Key}={x.Value}").ToList();
        questlist.Sort();
        string apisecret = "";
        switch (requestType)
        {
            case RequestType.Android:
                apisecret = ApiKey.AndroidKey.Secret;
                break;
            case RequestType.Web:
                apisecret = ApiKey.WebKey.Secret;
                break;
            case RequestType.IOS:
                apisecret = ApiKey.IOSKey.Secret;
                break;
            case RequestType.Login:
                apisecret = ApiKey.LoginKey.Secret;
                break;
            case RequestType.Third:
                apisecret = ApiKey.IOSKey.Secret;
                break;
        }
        var quest = string.Join("&", questlist);
        var sign = quest + apisecret;
        var sign2 = ToMD5(sign).ToLower();
        return quest + $"&sign={sign2}";
    }

    private string ToMD5(string input)
    {
        //将字符串编码为字节序列
        byte[] bt = Encoding.UTF8.GetBytes(input);
        //创建默认实现的实例
        var md5 = MD5.Create();
        //计算指定字节数组的哈希值。
        var md5bt = md5.ComputeHash(bt);
        //将byte数组转换为字符串
        StringBuilder builder = new StringBuilder();
        foreach (var item in md5bt)
        {
            builder.Append(item.ToString("X2"));
        }
        string md5Str = builder.ToString();
        return builder.ToString();
    }
}
