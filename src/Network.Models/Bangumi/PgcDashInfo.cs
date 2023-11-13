using Network.Models.Bases;
using Network.Models.Videos;
using System.Text.Json.Serialization;

namespace Network.Models.Bangumi;

public class PgcDashInfo
{
    [JsonPropertyName("accept_format")]
    public string Accept { get; set; }

    [JsonPropertyName("code")]
    public int Code { get; set; }

    [JsonPropertyName("seek_param")]
    public string SeekParam { get; set; }

    [JsonPropertyName("is_preview")]
    public int IsPreview { get; set; }

    [JsonPropertyName("fnval")]
    public int Fnval { get; set; }

    [JsonPropertyName("video_project")]
    public bool VideoProject { get; set; }

    [JsonPropertyName("fnver")]
    public int Fnver { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("bp")]
    public int Bp { get; set; }

    [JsonPropertyName("result")]
    public string Result { get; set; }

    [JsonPropertyName("seek_type")]
    public string SeekType { get; set; }

    [JsonPropertyName("vip_type")]
    public int VipType { get; set; }

    [JsonPropertyName("from")]
    public string From { get; set; }

    [JsonPropertyName("video_codecid")]
    public int VideoCodeCid { get; set; }

    [JsonPropertyName("record_info")]
    public RecordInfo RecordInfo { get; set; }

    [JsonPropertyName("format")]
    public string Format { get; set; }

    [JsonPropertyName("support_formats")]
    public List<PgcSupport_formats> PgcSupport_Formats { get; set; }

    [JsonPropertyName("accept_quality")]
    public List<int> AcceptQuality { get; set; }

    [JsonPropertyName("quality")]
    public int Quality { get; set; }

    [JsonPropertyName("timelength")]
    public long Timelength { get; set; }

    [JsonPropertyName("dash")]
    public Dash Dash { get; set; }
}

public class PgcSupport_formats
{
    [JsonPropertyName("need_login")]
    public bool NeedLogin { get; set; }

    [JsonPropertyName("need_vip")]
    public bool NeedVip { get; set; }

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

public class RecordInfo
{
    [JsonPropertyName("record_icon")]
    public string RecordIcon { get; set; }

    [JsonPropertyName("record")]
    public string Record { get; set; }
}
