namespace App.Models.MediaPlayerArgs;

/*
 VideoPlayerArgs类是帮助对视频播放的一个统合配置
 */

public class VideoPlayerArgs
{
    /// <summary>
    /// 视频Aid，必须
    /// </summary>
    public long? Aid { get; set; }

    /// <summary>
    /// 视频Bvid，可选
    /// </summary>
    public string Bvid { get; set; }

    /// <summary>
    /// 视频跳转Cid,等级比任何预制配置都高
    /// </summary>
    public long? SpaceCid { get; set; } = null;

    /// <summary>
    /// 上次观看进度，可选
    /// </summary>
    public double LastLookProgress { get;set; }

    /// <summary>
    /// 跳转进度，优先级比<see cref="LastLookProgress"/>高，可选
    /// </summary>
    public double SpaceProgress { get; set; }

    /// <summary>
    /// 默认清晰度，可选
    /// </summary>
    public int DefaultQualityIndex { get; set; }


}
