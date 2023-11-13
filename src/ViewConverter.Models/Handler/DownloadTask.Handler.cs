namespace ViewConverter.Models;

/// <summary>
/// 下载更改
/// </summary>
/// <param name="sender"></param>
/// <param name="progress"></param>
public delegate void ProgressDownloadChangedDelegate(object sender, double progress);

/// <summary>
/// 下载完毕
/// </summary>
/// <param name="sender"></param>
/// <param name="filepath"></param>
public delegate void DownloadCompletedDelegate(object sender, string filepath);

partial class DownloadTask
{
    internal ProgressDownloadChangedDelegate ProgressDownloadHandler;

    public event ProgressDownloadChangedDelegate ProgressDownloadChanged
    {
        add { ProgressDownloadHandler += value; }
        remove { ProgressDownloadHandler -= value; }
    }

    internal DownloadCompletedDelegate DownloadCompletedHandler;

    public event DownloadCompletedDelegate DownloadCompleted
    {
        add { DownloadCompletedHandler += value; }
        remove { DownloadCompletedHandler -= value; }
    }
}
