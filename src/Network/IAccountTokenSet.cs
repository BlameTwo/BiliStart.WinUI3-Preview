using Network.Models;

namespace INetwork;

/// <summary>
/// 验证token
/// </summary>
public interface IAccountTokenSet
{
    public Task<TokenThird> GotoThird();

    public Task<string> GetAccessKeyToken(TokenThird third);
}
