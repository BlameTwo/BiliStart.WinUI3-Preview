using System.Text.Json.Serialization;

namespace Network.Models.Videos;

public class VideoItem
{
    [JsonPropertyName("card_type")]
    public string Card_Type { get; set; }

    [JsonPropertyName("card_goto")]
    public string Card_Goto { get; set; }

    [JsonPropertyName("goto")]
    public string Goto { get; set; }

    [JsonPropertyName("param")]
    public string Param { get; set; }

    [JsonPropertyName("cover")]
    public string Cover { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("uri")]
    public string Uri { get; set; }

    [JsonPropertyName("three_point")]
    public Three_Point Three_Point { get; set; }

    [JsonPropertyName("args")]
    public UpArgs UpArg { get; set; }

    [JsonPropertyName("player_args")]
    public PlayerArgs PlayArg { get; set; }

    [JsonPropertyName("idx")]
    public int idx { get; set; }

    [JsonPropertyName("hash")]
    public string BannerHash { get; set; }

    [JsonPropertyName("banner_item")]
    public List<HomeBannerItem> BannerItem { get; set; }

    /// <summary>
    /// 播放数量（字符串）
    /// </summary>
    [JsonPropertyName("cover_left_text_2")]
    public string DanmakuTest { get; set; }

    /// <summary>
    /// 历史弹幕数量
    /// </summary>
    [JsonPropertyName("cover_left_text_3")]
    public string Danmaku { get; set; }

    [JsonPropertyName("desc")]
    public string Desc { get; set; }

    [JsonPropertyName("cover_left_text_1")]
    public string PlayerCount { get; set; }

    [JsonPropertyName("three_point_v2")]
    public List<Three_Point_V2> Three_Point_V2 { get; set; }

    [JsonPropertyName("mask")]
    public Mask Mask { get; set; }
}

public class HomeBannerItem
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("resource_id")]
    public long ResourceId { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("index")]
    public int Index { get; set; }

    [JsonPropertyName("static_banner")]
    public BannerStatic Static { get; set; }
}

public class BannerStatic
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("image")]
    public string Image { get; set; }

    [JsonPropertyName("hash")]
    public string Hash { get; set; }

    [JsonPropertyName("uri")]
    public string Uri { get; set; }

    [JsonPropertyName("request_id")]
    public string RequestId { get; set; }

    [JsonPropertyName("src_id")]
    public int SrcId { get; set; }

    [JsonPropertyName("is_ad_loc")]
    public bool IsAdLoc { get; set; }

    [JsonPropertyName("client_ip")]
    public string ClientIp { get; set; }

    [JsonPropertyName("server_type")]
    public int ServerType { get; set; }

    [JsonPropertyName("resource_id")]
    public int ResourceId { get; set; }

    [JsonPropertyName("index")]
    public int Index { get; set; }

    [JsonPropertyName("cm_mark")]
    public int CmMark { get; set; }
}

public class PlayerArgs
{
    [JsonPropertyName("aid")]
    public long Aid { get; set; }

    [JsonPropertyName("cid")]
    public long cid { get; set; }

    [JsonPropertyName("type")]
    public string VideoType { get; set; }

    [JsonPropertyName("duration")]
    public long Duration { get; set; }
}

public class Three_Point_V2
{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("icon")]
    public string Icon { get; set; }

    [JsonPropertyName("reasons")]
    public List<Dis_resource> Reasons { get; set; }
}

public class Mask
{
    [JsonPropertyName("avatar")]
    public UP Avatar { get; set; }

    [JsonPropertyName("button")]
    public MaskButton MaskButton { get; set; }
}

public class MaskButton
{
    [JsonPropertyName("text")]
    public string LikeState { get; set; }

    [JsonPropertyName("param")]
    public string commandparam { get; set; }

    [JsonPropertyName("event")]
    public string Event { get; set; }

    [JsonPropertyName("event_V2")]
    public string Event_V2 { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }
}

public class UP
{
    [JsonPropertyName("cover")]
    public string cover { get; set; }

    [JsonPropertyName("text")]
    public string Name { get; set; }

    [JsonPropertyName("uri")]
    public string Uri { get; set; }

    [JsonPropertyName("event")]
    public string Event { get; set; }

    [JsonPropertyName("event_V2")]
    public string Event_V2 { get; set; }

    [JsonPropertyName("up_id")]
    public long up_id { get; set; }
}

public class UpArgs
{
    [JsonPropertyName("up_id")]
    public long Mid { get; set; }

    [JsonPropertyName("up_name")]
    public string Name { get; set; }

    [JsonPropertyName("rname")]
    public string RName { get; set; }

    [JsonPropertyName("rid")]
    public int Rid { get; set; }

    [JsonPropertyName("tid")]
    public int Tid { get; set; }

    [JsonPropertyName("aid")]
    public int Aid { get; set; }
}

public class Dis_resource
{
    [JsonPropertyName("id")]
    public int id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("toast")]
    public string Toast { get; set; }
}

public class Three_Point
{
    [JsonPropertyName("dislike_reasons")]
    public List<Dis_resource> dis_Resources { get; set; }

    [JsonPropertyName("feedbacks")]
    public List<Dis_resource> FeedBacks { get; set; }

    [JsonPropertyName("watch_later")]
    public int Watch_Later { get; set; }
}
