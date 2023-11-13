using Bilibili.App.View.V1;
using Bilibili.Polymer.App.Search.V1;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ViewConverter.Models;

public class SearchModel
{
    /// <summary>
    /// 游标
    /// </summary>
    public string Next { get; set; }

    /// <summary>
    /// 标识数据是否到尾部
    /// </summary>
    public bool IsEnd { get; set; } = false;

    public string Trickid { get; set; }

    /// <summary>
    /// 第一次搜索默认综合导航会有这个参数
    /// </summary>
    public List<Nav> NavHeader { get; set; }

    /// <summary>
    /// 总个数
    /// </summary>
    public int PageSize { get; set; }

    public List<SearchModelItem> Item { get; set; }
}

public class SearchModelItem
{
    public Item Source { get; set; }

    public string Title { get; set; }

    public string Cover { get; set; }

    public SearchMovieItem MovieItem { get; set; }

    public string Type { get; set; }

    public SearchVideoItem VideoItem { get; set; }

    public SearchVideoUser User { get; set; }

    public SearchArticleItem Article { get; set; }

    public string Trackid { get; set; }

    public string Param { get; set; }
}

public class SearchVideoItem
{
    public string Type = "视频";
    public long Av { get; set; }

    public string Bvid { get; set; }

    public string UpName { get; set; }

    public string DurationString { get; set; }

    public long UpMid { get; set; }

    public string PublishTimeString { get; set; }

    public long Cid { get; set; }

    public string ShareTitle { get; set; }

    public long PlayerCount { get; set; }

    public long DanmakuCount { get; set; }
}

public class SearchArticleItem
{
    /// <summary>
    /// 观看数量，和<see cref="View"/>数据一致
    /// </summary>
    public long Play { get; set; }

    /// <summary>
    /// 观看数量
    /// </summary>
    public long View { get; set; }

    public string Desc { get; set; }

    /// <summary>
    /// 喜欢
    /// </summary>
    public long Like { get; set; }

    /// <summary>
    /// 回复
    /// </summary>
    public long Reply { get; set; }

    public string UpName { get; set; }

    public List<string> Images { get; set; }

    public long UpMid { get; set; }
}

public class SearchMovieItem
{
    /// <summary>
    /// 声优表
    /// </summary>
    public string Cv { get; set; }

    /// <summary>
    /// 评分
    /// </summary>
    public double Rating { get; set; }

    /// <summary>
    /// 电影专属的ssid
    /// </summary>
    public long SSID { get; set; }

    /// <summary>
    /// 发布时间
    /// </summary>
    public long PublishTime { get; set; }

    /// <summary>
    /// 2为动画电影
    /// </summary>
    public int MediaType { get; set; }

    /// <summary>
    /// 电影来源国家
    /// </summary>
    public string MoviaSource { get; set; }

    /// <summary>
    /// 电影分类
    /// </summary>
    public string MovieType { get; set; }

    /// <summary>
    /// 分集
    /// </summary>
    public List<EpisodeNew> Episodes { get; set; }
}

public class SearchLiveItem { }

public class SearchVideoUser
{
    public long Favs { get; set; }

    public string SubTitle { get; set; }

    public string Mid { get; set; }

    public bool Isup { get; set; }

    public long VideoCount { get; set; }

    public long LiveRoomId { get; set; }

    public string Sign { get; set; }
}

public class SearchDefaultWorld
{
    public string KeyWorld { get; set; }

    public string ShowWorld { get; set; }

    public string Paramter { get; set; }
}
