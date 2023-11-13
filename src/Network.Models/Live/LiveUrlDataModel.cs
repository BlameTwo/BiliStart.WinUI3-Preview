using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.Json.Serialization;

namespace Network.Models.Live;

public class LiveCodec
{
    [JsonPropertyName("codec_name")]
    public string CodecName { get; set; }

    [JsonPropertyName("current_qn")]
    public int CurrentQn { get; set; }

    [JsonPropertyName("accept_qn")]
    public List<int> AcceptQn { get; set; }

    [JsonPropertyName("base_url")]
    public string BaseUrl { get; set; }

    [JsonPropertyName("url_info")]
    public List<UrlInfo> UrlInfo { get; set; }

    [JsonPropertyName("hdr_qn")]
    public object HdrQn { get; set; }

    [JsonPropertyName("dolby_type")]
    public int DolbyType { get; set; }

    [JsonPropertyName("attr_name")]
    public string AttrName { get; set; }
}

public class LiveUrlDataModel
{
    [JsonPropertyName("room_id")]
    public int RoomId { get; set; }

    [JsonPropertyName("short_id")]
    public int ShortId { get; set; }

    [JsonPropertyName("uid")]
    public long Uid { get; set; }

    [JsonPropertyName("is_portrait")]
    public bool IsPortrait { get; set; }

    [JsonPropertyName("live_status")]
    public int LiveStatus { get; set; }

    [JsonPropertyName("live_time")]
    public int LiveTime { get; set; }

    [JsonPropertyName("all_special_types")]
    public List<object> AllSpecialTypes { get; set; }

    [JsonPropertyName("playurl_info")]
    public LivePlayurlInfo LivePlayurlInfo { get; set; }

    [JsonPropertyName("official_type")]
    public int OfficialType { get; set; }

    [JsonPropertyName("official_room_id")]
    public int OfficialRoomId { get; set; }
}

public class Format
{
    [JsonPropertyName("format_name")]
    public string FormatName { get; set; }

    [JsonPropertyName("codec")]
    public List<LiveCodec> Codec { get; set; }
}

public class GQnDesc
{
    [JsonPropertyName("qn")]
    public int Qn { get; set; }

    [JsonPropertyName("desc")]
    public string Desc { get; set; }

    [JsonPropertyName("hdr_desc")]
    public string HdrDesc { get; set; }

    [JsonPropertyName("attr_desc")]
    public object AttrDesc { get; set; }
}

public class P2pData
{
    [JsonPropertyName("p2p")]
    public bool P2p { get; set; }

    [JsonPropertyName("p2p_type")]
    public int P2pType { get; set; }

    [JsonPropertyName("m_p2p")]
    public bool MP2p { get; set; }

    [JsonPropertyName("m_servers")]
    public object MServers { get; set; }
}

public class LivePlayurl
{
    [JsonPropertyName("cid")]
    public int Cid { get; set; }

    [JsonPropertyName("g_qn_desc")]
    public List<GQnDesc> GQnDesc { get; set; }

    [JsonPropertyName("stream")]
    public List<LiveStream> LiveStream { get; set; }

    [JsonPropertyName("p2p_data")]
    public P2pData P2pData { get; set; }

    [JsonPropertyName("dolby_qn")]
    public object DolbyQn { get; set; }
}

public class LivePlayurlInfo
{
    [JsonPropertyName("conf_json")]
    public string ConfJson { get; set; }

    [JsonPropertyName("playurl")]
    public LivePlayurl Playurl { get; set; }
}

public class LiveStream
{
    [JsonPropertyName("protocol_name")]
    public string ProtocolName { get; set; }

    [JsonPropertyName("format")]
    public List<Format> Format { get; set; }
}

public class UrlInfo
{
    [JsonPropertyName("host")]
    public string Host { get; set; }

    [JsonPropertyName("extra")]
    public string Extra { get; set; }

    [JsonPropertyName("stream_ttl")]
    public int StreamTtl { get; set; }
}
