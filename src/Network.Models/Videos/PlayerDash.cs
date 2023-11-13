using Network.Models.Bases;
using System.Text.Json.Serialization;

namespace Network.Models.Videos;

public class VideoInfo
{
    [JsonPropertyName("from")]
    public string from { get; set; }

    [JsonPropertyName("result")]
    public string result { get; set; }

    [JsonPropertyName("message")]
    public string message { get; set; }

    [JsonPropertyName("format")]
    public string Format { get; set; }

    /// <summary>
    /// 视频长度
    /// </summary>
    [JsonPropertyName("timelength")]
    public long TimeLength { get; set; }

    [JsonPropertyName("accept_format")]
    public string VideoFormat { get; set; }

    /// <summary>
    /// 视频清晰度列表
    /// </summary>
    [JsonPropertyName("accept_description")]
    public List<string> Description { get; set; }

    /// <summary>
    /// 视频流编码ID
    /// </summary>
    [JsonPropertyName("video_codecid")]
    public int VideoCodeCid { get; set; }

    [JsonPropertyName("dash")]
    public Dash Dash { get; set; }

    [JsonPropertyName("last_play_time")]
    public long LastPlay { get; set; }

    [JsonPropertyName("last_play_cid")]
    public long LastCid { get; set; }

    [JsonPropertyName("accept_quality")]
    public List<int> Quality { get; set; }

    [JsonPropertyName("support_formats")]
    public List<Support_Formats> Support_Formats { get; set; }
}

public class Dash
{
    [JsonPropertyName("duration")]
    public int Duration { get; set; }

    [JsonPropertyName("minBufferTime")]
    public double MinBufferTime { get; set; }

    [JsonPropertyName("min_buffer_time")]
    public double Min_buffer_time { get; set; }

    [JsonPropertyName("video")]
    public List<DashVideo> DashVideos { get; set; }

    [JsonPropertyName("audio")]
    public List<DashVideo> DashAudio { get; set; }

    [JsonPropertyName("dolby")]
    public DashDolby Dolby { get; set; }

    [JsonPropertyName("flac")]
    public DashFlac HasFlac { get; set; }
}

public class DashDolby
{
    [JsonPropertyName("type")]
    public int Type { get; set; }

    [JsonPropertyName("audio")]
    public List<DashVideo> Audio { get; set; }
}

/// <summary>
/// 无损音乐
/// </summary>
public class DashFlac
{
    [JsonPropertyName("display")]
    public bool HisFlayDisplay { get; set; }

    [JsonPropertyName("audio")]
    public DashVideo Audio { get; set; }
}

public class DashVideo
{
    [JsonPropertyName("id")]
    public int ID { get; set; }

    [JsonPropertyName("baseUrl")]
    public string BaseUrl { get; set; }

    [JsonPropertyName("base_url")]
    public string Base_Url { get; set; }

    [JsonPropertyName("backupUrl")]
    public List<string> BackupUrl { get; set; }

    [JsonPropertyName("backup_url")]
    public List<string> Backup_Url { get; set; }

    /// <summary>
    /// 视频流格式
    /// </summary>
    [JsonPropertyName("mimeType")]
    public string VideoType { get; set; }

    /// <summary>
    /// 视频流编码器
    /// </summary>
    [JsonPropertyName("codecs")]
    public string Codecs { get; set; }

    [JsonPropertyName("height")]
    public int Height { get; set; }

    [JsonPropertyName("width")]
    public int Width { get; set; }

    [JsonPropertyName("frameRate")]
    public string FPS { get; set; }

    [JsonPropertyName("SegmentBase")]
    public SegmentBase SegmentBase { get; set; }

    [JsonPropertyName("bandwidth")]
    public int BandWidth { get; set; }

    [JsonPropertyName("codecid")]
    public int CodeCid { get; set; }
}

public class SegmentBase
{
    [JsonPropertyName("Initialization")]
    public string Initialization { get; set; }

    [JsonPropertyName("indexRange")]
    public string indexRange { get; set; }
}

public class Support_Formats
{
    [JsonPropertyName("quality")]
    public int Quality { get; set; }

    [JsonPropertyName("format")]
    public string Format { get; set; }

    [JsonPropertyName("new_description")]
    public string New_description { get; set; }

    [JsonPropertyName("display_desc")]
    public string Display_Desc { get; set; }

    [JsonPropertyName("superscript")]
    public string SuperScript { get; set; }

    [JsonPropertyName("codecs")]
    public List<string> Codec { get; set; }
}
