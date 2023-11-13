using LanguageExt;

namespace BiliNetWork;

/// <summary>
/// 实现<see cref="ITokenManager"/>的一个类
/// </summary>
public sealed class TokenManager : ITokenManager
{

    public TokenManager(
        IBIliDocument bIliDocument,
        IFileEncryptionProviderService fileEncryptionProviderService
    )
    {
        if (!Directory.Exists(LocalSettingFolder))
            Directory.CreateDirectory(LocalSettingFolder);
        BIliDocument = bIliDocument;
        FileEncryptionProviderService = fileEncryptionProviderService;
    }

    public string LocalSettingFolder =>
        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        + "\\BiliStartDesktop\\Token";

    public IBIliDocument BIliDocument { get; }
    public IFileEncryptionProviderService FileEncryptionProviderService { get; }

    public async Task<AccountToken> GetToken(long Mid)
    {
        var tokens =  await Refersh();
        AccountToken token = new();
        if (tokens == null || tokens.Count == 0)
            return token;
        foreach (var item in tokens)
        {
            if (item.Key.Mid == Mid)
                token = item.Key;
        }
        return token!;
    }

    async Task<Dictionary<AccountToken, string>> Refersh()
    {
        Dictionary<AccountToken,string>? result = new();
        DirectoryInfo dirinfo = new DirectoryInfo(LocalSettingFolder);
        foreach (var item in dirinfo.GetFiles())
        {
            string str = null;
            if (item.Extension != ".dat")
                continue;
            str = await FileEncryptionProviderService.DecFileAsync(item.FullName);
            var obj = await BIliDocument.JsonDeserializeAsync<AccountToken>(str!);
            if (obj != null)
                result.Add(obj, item.FullName);
        }
        return result;
    }

    public async Task<IDictionary<AccountToken, string>> GetTokenList()
    {
        
        Dictionary<AccountToken, string> List = new Dictionary<AccountToken, string>();
        var tokens =  await Refersh();
        lock (tokens)
        {
            foreach (var item in tokens)
                List.Add(item.Key, item.Value);
            return List;
        }
    }

    public async Task<bool> SaveToken(AccountToken token)
    {
        string filename = Path.Combine(LocalSettingFolder, token.Mid + ".json");
        if (File.Exists(filename))
            File.Delete(filename);
        var str = await BIliDocument.JsonSerializeAsync(token);
        await File.CreateText(filename).DisposeAsync();
        await File.WriteAllTextAsync(filename, str);
        if (File.Exists(filename))
        {
            //此处加密文件并删除旧文件
            await FileEncryptionProviderService.EncFileAsync(
                filename,
                Path.Combine(LocalSettingFolder, token.Mid + ".dat")
            );
            File.Delete(filename);
            return true;
        }
        return false;
    }

    public async Task<bool> DelectToken(AccountToken token)
    {
        bool flage = false;
        var tokens = await Refersh();
        foreach (var item in tokens)
        {
            if (token.Mid == item.Key.Mid)
            {
                File.Delete(item.Value);
                flage = true;
            }
        }
        return flage;
    }
}
