namespace ViewConverter.Models.Messager;

public class DownloadMessager
{
    /// <summary>
    /// 刷新下载列表
    /// </summary>
    /// <param name="isrefersh"></param>
    /// <param name="isadd"></param>
    public record RefershDownloadList(bool isrefersh, bool isadd);
}
