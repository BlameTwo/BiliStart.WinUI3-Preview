using CommunityToolkit.Mvvm.ComponentModel;
using Network.Models.Videos;

namespace ViewConverter.Models.VideoModel;

[INotifyPropertyChanged]
public partial class HomeVideoBase : VideoModelBase
{
    /// <summary>
    /// 当前推荐页面的游标
    /// </summary>
    public long Idx { get; set; }

    /// <summary>
    /// 当前推荐页面的hash值
    /// </summary>
    public string Hash { get; set; }

    public List<HomeVideo> Items { get; set; } = new();

    public List<HomeBannerItem> BannerItems { get; set; } = new();
}
