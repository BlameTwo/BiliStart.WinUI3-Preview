using CommunityToolkit.Mvvm.ComponentModel;

namespace ViewConverter.Models;

[INotifyPropertyChanged]
public partial class DownloadPages
{
    public DownloadPages(ViewPage page)
    {
        this.Page = page;
    }

    [ObservableProperty]
    bool? _IsDownload;

    [ObservableProperty]
    ViewPage _Page;
}

[INotifyPropertyChanged]
public partial class DownloadQuality
{
    public string Title { get; set; }

    public int QualityId { get; set; }
}
