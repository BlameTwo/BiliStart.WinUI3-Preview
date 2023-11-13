using Windows.Security.Credentials;

namespace AppContractService.Services;

internal class KeyCredentialCreate : IKeyCredentialCreate
{
    public async Task<bool> UserPinVefify()
    {
        bool supported = await KeyCredentialManager.IsSupportedAsync();
        var vefify = await KeyCredentialManager.RequestCreateAsync(
            "BiliStartVefify",
            KeyCredentialCreationOption.ReplaceExisting
        );

        if (vefify.Status == KeyCredentialStatus.Success)
            return true;
        else
            return false;
    }
}
