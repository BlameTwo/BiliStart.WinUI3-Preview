using Network.Models.Accounts;

namespace INetwork;

/// <summary>
/// Token管理(多账号
/// </summary>
public interface ITokenManager
{
    /// <summary>
    /// 获得本地所有账号的Token
    /// </summary>
    /// <returns></returns>
    public Task<IDictionary<AccountToken, string>> GetTokenList();

    public Task<bool> SaveToken(AccountToken token);

    public Task<bool> DelectToken(AccountToken token);

    public Task<AccountToken> GetToken(long Mid);
}
