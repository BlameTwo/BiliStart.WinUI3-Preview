using Network.Models;
using Network.Models.Accounts;

namespace INetwork;

/// <summary>
/// Http请求扩展
/// </summary>
public interface IHttpExtensions
{
    /// <summary>
    /// 直接获得全部的url参数以及加密后的sign参数
    /// </summary>
    /// <param name="keyvalues"></param>
    /// <param name="requestType"></param>
    /// <param name="isaccess"></param>
    /// <returns></returns>
    Task<string> GetClientType(
        Dictionary<string, string> keyvalues,
        RequestType requestType,
        bool isaccess,
        bool issign,
        AccountToken logindata = null
    );
}
