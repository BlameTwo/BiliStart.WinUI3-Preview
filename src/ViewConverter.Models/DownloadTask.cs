using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace ViewConverter.Models;

//FFmpeg命令
//C:\path\to\ffmpeg.exe -i audio.m4s -i video.m4s -c:v copy -c:a aac -strict experimental -b:a 128k output.mp4


/// <summary>
/// 单Video下载
/// </summary>
[INotifyPropertyChanged]
public partial class DownloadTask
{
    [ObservableProperty]
    bool _IsCancel;

    [ObservableProperty]
    string _Url;

    [ObservableProperty]
    string _SavePath;

    [ObservableProperty]
    string _Status;

    [ObservableProperty]
    double _Progress;

    CancellationTokenSource _source = new();

    [ObservableProperty]
    long _FileLength;

    [RelayCommand]
    async Task StartAsync()
    {
        if (File.Exists(SavePath))
        {
            this.FileLength = new FileInfo(SavePath).Length;
        }
        await StartDownloadAsync(_source.Token);
    }

    public DownloadTask(string url, string savepath)
    {
        this.Url = url;
        this.SavePath = savepath;
    }

    async Task StartDownloadAsync(CancellationToken cancellationToken)
    {
        using (var httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.Add("referer", "https://www.bilibili.com");
            httpClient.DefaultRequestHeaders.Add(
                "User-Agent",
                "Mozilla/5.0 BiliDroid/1.12.0 (bbcallen@gmail.com)"
            );
            httpClient.DefaultRequestHeaders.Range = new System.Net.Http.Headers.RangeHeaderValue(
                FileLength,
                null
            );
            try
            {
                using (
                    var response = await httpClient.GetAsync(
                        Url,
                        HttpCompletionOption.ResponseHeadersRead,
                        cancellationToken
                    )
                )
                {
                    response.EnsureSuccessStatusCode();
                    long totalBytes = response.Content.Headers.ContentLength ?? -1;
                    long downloadedBytes = 0;
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    using (
                        var fileStream = new FileStream(SavePath, FileMode.Create, FileAccess.Write)
                    )
                    {
                        var buffer = new byte[8192];
                        int bytesRead;

                        while (
                            (
                                bytesRead = await stream.ReadAsync(
                                    buffer,
                                    0,
                                    buffer.Length,
                                    cancellationToken
                                )
                            ) > 0
                        )
                        {
                            if (IsCancel)
                            {
                                Status = "Download Canceled";
                                return;
                            }
                            await fileStream.WriteAsync(buffer, 0, bytesRead);
                            downloadedBytes += bytesRead;
                            Progress = (double)downloadedBytes / totalBytes * 100;
                            if (ProgressDownloadHandler != null)
                                this.ProgressDownloadHandler.Invoke(this, this.Progress);
                        }
                    }
                }

                // Simulate completion
                Status = "Download Completed";
                if (DownloadCompletedHandler != null)
                    this.DownloadCompletedHandler.Invoke(this, SavePath);
            }
            catch (OperationCanceledException)
            {
                Status = "Download Canceled";
            }
            catch (Exception ex)
            {
                Status = $"Error downloading: {ex.Message}";
            }
            finally { }
        }
    }
}

/// <summary>
/// 单Cid下载
/// </summary>
[INotifyPropertyChanged]
public partial class BiliDownloadItem
{
    [ObservableProperty]
    string _SavePath;

    [ObservableProperty]
    string _Title;

    [ObservableProperty]
    DownloadTask _AudioDownload;

    [ObservableProperty]
    DownloadTask _VideoDownload;

    [ObservableProperty]
    long _Duration;

    [ObservableProperty]
    string _State;

    [ObservableProperty]
    double _Progress;

    [RelayCommand]
    async Task Start()
    {
        await AudioDownload.StartCommand.ExecuteAsync(null);
        await VideoDownload.StartCommand.ExecuteAsync(null);
    }
}

/// <summary>
/// 单视频下载
/// </summary>
[INotifyPropertyChanged]
public partial class BiliDownload
{
    [ObservableProperty]
    string _Title;

    [ObservableProperty]
    string _Cover;

    [ObservableProperty]
    ObservableCollection<BiliDownloadItem> _Items;

    [ObservableProperty]
    string _Id;

    [ObservableProperty]
    string _State;

    [ObservableProperty]
    string _Shard;

    [ObservableProperty]
    Guid _Guid;

    [RelayCommand]
    async Task StartDownload()
    {
        foreach (var item in Items)
        {
            await item.StartCommand.ExecuteAsync(null);
        }
    }
}

/// <summary>
/// 在服务中的下载列表
/// </summary>
[INotifyPropertyChanged]
public partial class BiliDownloadModel
{
    [ObservableProperty]
    ObservableCollection<BiliDownload> _BiliDownloadItems;

    [ObservableProperty]
    int _State;
}
