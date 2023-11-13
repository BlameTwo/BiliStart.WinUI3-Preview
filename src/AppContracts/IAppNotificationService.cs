using Network.Models.Accounts;
using System.Threading.Tasks;

namespace IAppContracts;

public interface IAppNotificationService
{
    public Task SendLoginToken(AccountToken token);
}
