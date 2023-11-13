using System.Security.Cryptography;

namespace BiliNetWork;

public class FileEncryptionProviderService : IFileEncryptionProviderService
{
    public async Task<string> DecFileAsync(string datFilepath)
    {
        return await Task.Run(() =>
        {
            byte[] keyStreamFromFile;
            byte[] encryptedDataFromFile;
            using (FileStream fs = File.OpenRead(datFilepath))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    int keyStreamLength = br.ReadInt32();
                    keyStreamFromFile = br.ReadBytes(keyStreamLength);
                    int dataLength = br.ReadInt32();
                    encryptedDataFromFile = br.ReadBytes(dataLength);
                }
            }

            // 使用异或运算对数据进行解密
            byte[] decryptedData = new byte[encryptedDataFromFile.Length];
            for (int i = 0; i < encryptedDataFromFile.Length; i++)
            {
                decryptedData[i] = (byte)(encryptedDataFromFile[i] ^ keyStreamFromFile[i]); // 异或运算
            }

            // 将解密后的数据转换为字符串
            string dataString = System.Text.Encoding.UTF8.GetString(decryptedData);
            return dataString;
        });
    }

    public async Task EncFileAsync(string Filepath, string savePath)
    {
        byte[] dataBytes = System.Text.Encoding.UTF8.GetBytes(
            await File.ReadAllTextAsync(Filepath)
        );
        byte[] keyStream = new byte[dataBytes.Length];
        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(keyStream);
        }
        byte[] encryptedData = new byte[dataBytes.Length];
        for (int i = 0; i < dataBytes.Length; i++)
        {
            encryptedData[i] = (byte)(dataBytes[i] ^ keyStream[i]);
        }
        if (File.Exists(savePath))
            File.Delete(savePath);
        using (FileStream fs = new FileStream(savePath, FileMode.Create))
        {
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                bw.Write(keyStream.Length);
                bw.Write(keyStream);
                bw.Write(encryptedData.Length);
                bw.Write(encryptedData);
            }
        }
    }
}
