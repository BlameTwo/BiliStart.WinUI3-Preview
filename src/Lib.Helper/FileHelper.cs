using System.IO;
using System.Threading.Tasks;

namespace Lib.Helper;

public static class FileHelper
{
    /// <summary>
    /// 将stream流保存到本地
    /// </summary>
    /// <param name="stream">流</param>
    /// <param name="FilePath">文件路径</param>
    /// <param name="isDelete">文件存在时是否删除</param>
    /// <returns></returns>
    public static async Task<bool> StreamSaveToFile(this Stream stream,string FilePath,bool isDelete=true)
    {
        using (var fileStream = File.Create(FilePath))
        {
            stream.Seek(0, SeekOrigin.Begin);
            await stream.CopyToAsync(fileStream);
            return true;
        }
    }

}
