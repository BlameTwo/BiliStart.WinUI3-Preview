using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ViewConverter.Models;

namespace IAppContracts;

public interface IDownloadService
{
    public long Number { get; set; }

    public Task<bool> AddDownload(long av, List<ViewPage> cids, int quality);

    public ObservableCollection<BiliDownload> GetBiliDownloads();

    public BiliDownload GetDownloadItem(string guid);
}
