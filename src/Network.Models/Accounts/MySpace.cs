using System.Text.Json.Serialization;

namespace Network.Models.Accounts;

public class MySpace
{
    [JsonPropertyName("setting")]
    public Space_Setting Setting { get; set; }

    [JsonPropertyName("card")]
    public Space_Card Card { get; set; }

    [JsonPropertyName("images")]
    public Space_Images Images { get; set; }
}

public class Space_Card
{
    [JsonPropertyName("mid")]
    public string MID { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("approve")]
    public bool AppProve { get; set; }

    [JsonPropertyName("sex")]
    public string SexString { get; set; }

    [JsonPropertyName("rank")]
    public string Rank { get; set; }

    [JsonPropertyName("face")]
    public string Face { get; set; }

    [JsonPropertyName("DisplayRank")]
    public string DIsplayRank { get; set; }

    [JsonPropertyName("regtime")]
    public int Retime { get; set; }

    [JsonPropertyName("spacesta")]
    public int Spacesta { get; set; }

    [JsonPropertyName("birthday")]
    public string Birthday { get; set; }

    [JsonPropertyName("place")]
    public string Place { get; set; }

    [JsonPropertyName("description")]
    public string Discription { get; set; }

    [JsonPropertyName("article")]
    public int Article { get; set; }

    [JsonPropertyName("attentions")]
    public object Attentions { get; set; }

    /// <summary>
    /// 粉丝
    /// </summary>
    [JsonPropertyName("fans")]
    public int Fans { get; set; }

    [JsonPropertyName("friend")]
    public int Friend { get; set; }

    [JsonPropertyName("attention")]
    public int Attention { get; set; }

    [JsonPropertyName("sign")]
    public string Sign { get; set; }

    [JsonPropertyName("level_info")]
    public Level_Exp LevelInfo { get; set; }

    [JsonPropertyName("official_verify")]
    public Official Official { get; set; }

    [JsonPropertyName("vip")]
    public Vip Vip { get; set; }

    [JsonPropertyName("likes")]
    public Space_Likes Likes { get; set; }

    [JsonPropertyName("achieve")]
    public Space_Achieve TopImage { get; set; }
}

public class Space_Images
{
    [JsonPropertyName("imgUrl")]
    public string TopImage { get; set; }

    [JsonPropertyName("night_imgurl")]
    public string NightImage { get; set; }

    [JsonPropertyName("show_reset")]
    public bool ShowReset { get; set; }

    [JsonPropertyName("goods_available")]
    public bool Goods { get; set; }
}

public class Space_Achieve
{
    [JsonPropertyName("is_default")]
    public bool Default { get; set; }

    [JsonPropertyName("image")]
    public string Image { get; set; }

    [JsonPropertyName("achieve_url")]
    public string AchieveUrl { get; set; }
}

public class Space_Likes
{
    [JsonPropertyName("like_num")]
    public int LikeCount { get; set; }

    [JsonPropertyName("skr_tip")]
    public string SkrTip { get; set; }
}

public class Space_Setting
{
    [JsonPropertyName("channel")]
    public int Channel { get; set; }

    [JsonPropertyName("fav_video")]
    public int Fav_VIdeo { get; set; }

    [JsonPropertyName("conis_video")]
    public int Fav_Voucher { get; set; }

    [JsonPropertyName("likes_video")]
    public int Like_Video { get; set; }

    [JsonPropertyName("bangumi")]
    public int Bangumi { get; set; }

    [JsonPropertyName("played_game")]
    public int PlayerGame { get; set; }

    [JsonPropertyName("groups")]
    public int Groups { get; set; }

    [JsonPropertyName("comic")]
    public int Comic { get; set; }

    [JsonPropertyName("bbq")]
    public int BBQ { get; set; }

    [JsonPropertyName("dress_up")]
    public int DressUp { get; set; }

    [JsonPropertyName("disable_following")]
    public int DisableFollowing { get; set; }

    [JsonPropertyName("live_playback")]
    public int Live_PlayBack { get; set; }
}
