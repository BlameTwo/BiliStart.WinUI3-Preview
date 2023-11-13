using Network.Models;
using Network.Models.Accounts;

namespace INetwork.IProviders;

public interface ILoginProvider
{
    public Task<ResultCode<AccountLoginData>> RefQRAsync(CancellationToken canceltoken = default);

    public Task<LoginTrueString> PollAutoQRAsync(
        string Qrkey,
        CancellationToken canceltoken = default
    );
}
