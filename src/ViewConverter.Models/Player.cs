using Bilibili.App.View.V1;

namespace ViewConverter.Models;

public class PlayerView
{
    public PlayerView(
        PlayerSession playerSession,
        List<Bilibili.App.View.V1.Tag> tags,
        List<DescV2> viewDescs,
        string bvid,
        long aid,
        long cid,
        PlayerUserStat playerUserStat,
        PlayerSessionUp PlayerUp,
        string Share,
        List<PlayerRelatesVideo> relates,
        List<ViewPage> playerpage
    )
    {
        PlayerSession = playerSession;
        Tags = tags;
        ViewDescs = viewDescs;
        Bvid = bvid;
        Aid = aid;
        FirstCid = cid;
        PlayerUserStat = playerUserStat;
        this.Playerup = PlayerUp;
        this.ShareLink = Share;
        Relates = relates;
        this.PlayerPages = playerpage;
    }

    public PlayerSessionUp Playerup { get; set; }

    public PlayerSession PlayerSession { get; set; }

    public List<ViewPage> PlayerPages { get; set; }

    public PlayerUserStat PlayerUserStat { get; set; }

    public string Bvid { get; set; }

    public long Aid { get; set; }

    public long FirstCid { get; set; }

    public List<Bilibili.App.View.V1.Tag> Tags { get; set; }

    public List<DescV2> ViewDescs { get; set; }

    public string ShareLink { get; set; }

    public List<PlayerRelatesVideo> Relates { get; set; }
}

/// <summary>
/// 推荐视频
/// </summary>
public class PlayerRelatesVideo
{
    public string Aid { get; set; }

    public string Bvid { get; set; }

    public string Title { get; set; }

    public string Cover { get; set; }

    public PlayerUp Up { get; set; }

    public long View { get; set; }

    public long Reply { get; set; }

    public long Fav { get; set; }

    public long Coin { get; set; }

    public long ShareCount { get; set; }

    public long Like { get; set; }

    public long Duration { get; set; }

    public string Cid { get; set; }
    public string TrackId { get; set; }
}

public class PlayerUp
{
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }

    public long Mid { get; set; }

    public string Cover { get; set; }
}

public class PlayerSessionUp : PlayerUp
{
    public bool IsLike { get; set; }
}

public class PlayerUserStat
{
    public bool IsLike { get; set; }

    public bool IsFav { get; set; }

    public bool IsCoin { get; set; }

    public ViewHistory History { get; set; }
}

public class ViewHistory
{
    public long Cid { get; set; }

    public long Progress { get; set; }
}

public class ViewPage
{
    public long Cid { get; set; }

    public long Duration { get; set; }

    public string Title { get; set; }
    public string Desc { get; set; }

    public long Height { get; set; }

    public long Width { get; set; }
}

public class PlayerSession
{
    /// <summary>
    /// 标题
    /// </summary>
    public string Title { get; set; }

    public string Cover { get; set; }

    /// <summary>
    /// 视频简介
    /// </summary>
    public string Desc { get; set; }

    /// <summary>
    /// 观看次数
    /// </summary>
    public long ViewCount { get; set; }

    /// <summary>
    /// 投币次数
    /// </summary>
    public long ViewCoins { get; set; }

    /// <summary>
    /// 收藏人数
    /// </summary>
    public long ViewFavorites { get; set; }

    /// <summary>
    /// 点赞数量
    /// </summary>
    public long ViewLike { get; set; }

    /// <summary>
    /// 发布时间
    /// </summary>
    public long ViewPublish { get; set; }

    /// <summary>
    /// 弹幕数量
    /// </summary>
    public long ViewDanmaku { get; set; }
}
