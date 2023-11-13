using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Network.Models.Totals;

public class CheckMusicRankRegisterModel
{
    [JsonPropertyName("listen_fid")]
    public long ListenFid { get; set; }

    [JsonPropertyName("all_fid")]
    public long Fid { get; set; }

    [JsonPropertyName("fav_mid")]
    public long Mid { get; set; }

    [JsonPropertyName("cover_url")]
    public string Cover { get; set; }

    /// <summary>
    /// 是否订阅
    /// </summary>
    [JsonPropertyName("is_subscribe")]
    public bool IsRegister { get; set; }

    [JsonPropertyName("listen_count")]
    public int ListenCount { get; set; }
}

public class MusicRankDataIDModel
{
    [JsonPropertyName("list")]
    public List<YearData> YearData { get; set; }
}

public class YearData
{
    public string Year { get; set; }
    public List<MusicRankIDItem> MusicRankItem { get; set; }
}

public class MusicRankIDItem
{
    [JsonPropertyName("ID")]
    public int ID { get; set; }

    [JsonPropertyName("priod")]
    public int Priod { get; set; }

    [JsonPropertyName("publish_time")]
    public long Publish { get; set; }
}

public class MusicRankList
{
    [JsonPropertyName("list")]
    public List<MusicRankItem> List { get; set; }
}

public class MusicRankItem
{
    [JsonPropertyName("music_id")]
    public string Music_ID { get; set; }

    [JsonPropertyName("music_title")]
    public string Title { get; set; }

    [JsonPropertyName("singer")]
    public string Singer { get; set; }

    [JsonPropertyName("album")]
    public string Album { get; set; }

    [JsonPropertyName("mv_aid")]
    public long MVAid { get; set; }

    [JsonPropertyName("mv_bvid")]
    public string MVBvid { get; set; }

    [JsonPropertyName("mv_cover")]
    public string MVCover { get; set; }

    [JsonPropertyName("heat")]
    public int Heat { get; set; }

    [JsonPropertyName("rank")]
    public int RankNumber { get; set; }

    [JsonPropertyName("can_listen")]
    public bool CanListen { get; set; }

    [JsonPropertyName("recommendation")]
    public string Recommand { get; set; }

    [JsonPropertyName("creation_aid")]
    public long CreateAid { get; set; }

    [JsonPropertyName("creation_bvid")]
    public string CreateBvid { get; set; }

    [JsonPropertyName("creation_cover")]
    public string CreateCover { get; set; }

    [JsonPropertyName("creation_title")]
    public string CreateTitle { get; set; }

    [JsonPropertyName("creation_up")]
    public long CreateUpDateTime { get; set; }

    [JsonPropertyName("creation_nickname")]
    public string CreateNickName { get; set; }

    [JsonPropertyName("creation_duration")]
    public int CreateDuration { get; set; }

    [JsonPropertyName("creation_play")]
    public long CreatePlay { get; set; }

    [JsonPropertyName("creation_reason")]
    public string CreateReason { get; set; }

    [JsonPropertyName("achievements")]
    public List<string> Achievements { get; set; }
}
