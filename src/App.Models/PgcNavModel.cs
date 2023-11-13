namespace App.Models;

public static class PgcNavModel
{
    /// <summary>
    /// 番剧
    /// </summary>
    public static string JpAnimation { get; } = nameof(JpAnimation);

    /// <summary>
    /// 国创
    /// </summary>
    public static string ChinaAnimation { get; } = nameof(ChinaAnimation);

    /// <summary>
    /// 电影
    /// </summary>
    public static string Movie { get; } = nameof(Movie);

    /// <summary>
    /// 综艺
    /// </summary>
    public static string MoviePlayer { get; } = nameof(MoviePlayer);

    /// <summary>
    /// 电视剧
    /// </summary>
    public static string TVPlayer { get; } = nameof(TVPlayer);

    /// <summary>
    /// 纪录片
    /// </summary>
    public static string MovieREC { get; } = nameof(MovieREC);
}
