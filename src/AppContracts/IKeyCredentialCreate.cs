using System.Threading.Tasks;

namespace IAppContracts;

public interface IKeyCredentialCreate
{
    /// <summary>
    /// 验证用户
    /// </summary>
    /// <returns></returns>
    Task<bool> UserPinVefify();
}
