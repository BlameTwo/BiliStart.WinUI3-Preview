using System.Collections.ObjectModel;
using ViewConverter.Models;

namespace AppContractService.Services;

public class DownloadService : IDownloadService, IAppService
{
    public long Number { get; set; }

    public DownloadService(IVideoProvider provider)
    {
        VideoProvider = provider;
    }

    public IVideoProvider VideoProvider { get; }

    public string ServiceID { get; set; } = nameof(DownloadService);

    private BiliDownloadModel _downloadmodel = new() { BiliDownloadItems = new() };

    public async Task<bool> AddDownload(long av, List<ViewPage> cids, int quality)
    {
        var view = await VideoProvider.GetVideoViewAsync(VideoTypeEnum.Av, av.ToString());
        FilePath.VideoDownloadPath.CheckFolder();
        string videofolder = FilePath.VideoDownloadPath + $"\\{av}";
        videofolder.CheckFolder();
        BiliDownload download =
            new()
            {
                Id = av.ToString(),
                Title = view.PlayerSession.Title,
                Shard = view.ShareLink,
                Items = new(),
                Cover = view.PlayerSession.Cover,
                Guid = Guid.NewGuid()
            };
        foreach (var item in cids)
        {
            #region 创建文件夹
            videofolder.CheckFolder();
            string cidpath = videofolder + $"\\{item.Cid}";
            cidpath.CheckFolder();
            #endregion
            #region 获取下载源
            var urldownload = await VideoProvider.GetVideoDashSourceAsync(
                VideoTypeEnum.Av,
                item.Cid,
                av.ToString()
            );
            BiliDownloadItem downloaditem =
                new()
                {
                    Duration = item.Duration,
                    Title = item.Title,
                    SavePath = cidpath
                };
            downloaditem.AudioDownload = new(
                urldownload.Data.Dash.DashAudio[0].BaseUrl,
                cidpath + "\\audio.m4s"
            );
            foreach (var videodash in urldownload.Data.Dash.DashVideos)
            {
                if (videodash.ID == quality)
                {
                    downloaditem.VideoDownload = new(videodash.BaseUrl, cidpath + "\\video.m4s");
                }
            }
            download.Items.Add(downloaditem);
            #endregion
        }
        _downloadmodel.BiliDownloadItems.Add(download);
        return true;
    }

    public ObservableCollection<BiliDownload> GetBiliDownloads() =>
        _downloadmodel.BiliDownloadItems;

    public BiliDownload GetDownloadItem(string guid)
    {
        foreach (var item in _downloadmodel.BiliDownloadItems)
        {
            if (guid == item.Guid.ToString())
            {
                return item;
            }
        }
        return null;
    }
}
