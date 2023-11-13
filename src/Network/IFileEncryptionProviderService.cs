namespace INetwork;

/// <summary>
/// 加密解密文件模块
/// </summary>
public interface IFileEncryptionProviderService
{
    /// <summary>
    /// 加密文件
    /// </summary>
    /// <param name="datFilepath">需要加密的文件</param>
    /// <returns>返回加密后的文件路径</returns>
    public Task EncFileAsync(string Filepath, string savePath);

    /// <summary>
    /// 解密文件
    /// </summary>
    /// <returns>返回解密后的字符串值</returns>
    public Task<string> DecFileAsync(string datFilepath);
}
