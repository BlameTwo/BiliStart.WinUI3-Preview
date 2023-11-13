using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using ViewConverter.Models.Messager;

namespace ViewConverter.Models;

/// <summary>
/// 排行视图
/// </summary>
[INotifyPropertyChanged]
public partial class RankVideo : VideoModelBase
{
    /// <summary>
    /// 综合评分
    /// </summary>
    public long Pts { get; set; }

    public long Favourite { get; set; }

    public string UpFace { get; set; }

    public int Danmaku { get; set; }
}

/// <summary>
/// 热门视频试图
/// </summary>
[INotifyPropertyChanged]
public partial class HotVideo : VideoModelBase
{
    /// <summary>
    /// 热门原因
    /// </summary>
    public string HotTitle { get; set; }
}

public class HotVideoModel
{
    public List<HotVideo> HotVideo { get; set; }

    public long Idx { get; set; }
}

/// <summary>
/// 视频卡片视图基础
/// </summary>
public class VideoModelBase
{
    /// <summary>
    /// 封面
    /// </summary>
    public string Cover { get; set; }

    public long Aid { get; set; }

    public string Bvid { get; set; }

    /// <summary>
    /// 视频标题
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// 简介
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// 观看总数
    /// </summary>
    public string LookCount { get; set; }

    /// <summary>
    /// Up名称
    /// </summary>
    public string UpName { get; set; }

    public long UpMid { get; set; }

    /// <summary>
    /// 视频时长
    /// </summary>
    public string TimeDuration { get; set; }

    public long Cid { get; set; }
}

[INotifyPropertyChanged]
public partial class HomeVideo : VideoModelBase
{
    public object SourceData { get; set; }

    public string Danmaku { get; set; }
}

[INotifyPropertyChanged]
public partial class MusicRankCard : VideoModelBase
{
    public long CreateTime { get; set; }

    public string MsuciID { get; set; }

    public long Duration { get; set; }

    public MusicBigCard TopCard { get; set; }

    public MusicSmallCard BootomCard { get; set; }
}

public class MusicSmallCard
{
    public string Title { get; set; }

    public string Cover { get; set; }

    public string UpName { get; set; }

    public long PlayCount { get; set; }

    public string Reason { get; set; }
}

public class MusicBigCard
{
    /// <summary>
    /// 专辑标题
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// 专辑收藏数量
    /// </summary>
    public long Heat { get; set; }

    public string RankString { get; set; }

    /// <summary>
    /// 专辑现在排名
    /// </summary>
    public int Rank { get; set; }

    public string Cover { get; set; }

    /// <summary>
    /// 专辑发布人
    /// </summary>
    public string Album { get; set; }

    public string Singer { get; set; }
}
