namespace Network.Models.Enum;

public enum SearchTypeEnum
{
    /// <summary>
    /// 动画
    /// </summary>
    Animation = 7,

    /// <summary>
    /// 直播
    /// </summary>
    Live = 4,

    /// <summary>
    /// 用户
    /// </summary>
    User = 2,

    /// <summary>
    /// 影视
    /// </summary>
    Movie = 8,

    /// <summary>
    /// 专栏
    /// </summary>
    Article = 6
}

/// <summary>
/// 搜索排序
/// </summary>
public enum SearchOrderByEnum
{
    NewPublish = 2,
    Danmaku = 3,
    Player = 1,
    Default = 4
}

public class SearchOrderBy
{
    public SearchOrderByEnum Type { get; set; }

    public string Name { get; set; }

    public static List<SearchOrderBy> Defatul()
    {
        return new List<SearchOrderBy>()
        {
            new SearchOrderBy() { Name = "默认排序", Type = SearchOrderByEnum.Default },
            new SearchOrderBy() { Name = "新发布", Type = SearchOrderByEnum.NewPublish },
            new SearchOrderBy() { Name = "弹幕多", Type = SearchOrderByEnum.Danmaku },
            new SearchOrderBy() { Name = "播放多", Type = SearchOrderByEnum.Player }
        };
    }
}
