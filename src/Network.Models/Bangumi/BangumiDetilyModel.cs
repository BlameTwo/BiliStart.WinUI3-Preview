using System.Text.Json.Serialization;

namespace Network.Models.Bangumi;

public class BangumiDetilyModel
{
    [JsonPropertyName("actor")]
    public BangumiDetilyActor BangumiDetilyActor { get; set; }

    [JsonPropertyName("alias")]
    public string Alias { get; set; }

    [JsonPropertyName("areas")]
    public List<BangumiDetilyArea> BangumiDetilyArea { get; set; }

    [JsonPropertyName("badge")]
    public string Badge { get; set; }

    [JsonPropertyName("celebrity")]
    public List<BangumiDetilyCelebrity> Celebrity { get; set; }

    [JsonPropertyName("origin_name")]
    public string OriginName { get; set; }

    [JsonPropertyName("cover")]
    public string Cover { get; set; }

    [JsonPropertyName("dynamic_subtitle")]
    public string Dynamic_Title { get; set; }

    [JsonPropertyName("evaluate")]
    public string Desc { get; set; }

    [JsonPropertyName("link")]
    public string Link { get; set; }

    [JsonPropertyName("media_id")]
    public long MediaID { get; set; }

    [JsonPropertyName("mode")]
    public int Mode { get; set; }

    [JsonPropertyName("new_ep")]
    public BangumiDetilyNewEp BangumiDetilyNewEp { get; set; }

    [JsonPropertyName("publish")]
    public BangumiDetilyPublish Publish { get; set; }

    [JsonPropertyName("rating")]
    public BangumiDetilyRating Rating { get; set; }

    [JsonPropertyName("season_id")]
    public long SeasonID { get; set; }

    [JsonPropertyName("season_title")]
    public string SeasonTitle { get; set; }

    [JsonPropertyName("series")]
    public BangumiDetilySeries BangumiDetilySeries { get; set; }

    [JsonPropertyName("share_copy")]
    public string ShareTitle { get; set; }

    [JsonPropertyName("share_url")]
    public string ShareUrl { get; set; }

    [JsonPropertyName("staff")]
    public BangumiDetilyActor Staff { get; set; }

    [JsonPropertyName("stat")]
    public BangumiDetilyStat BangumiDetilyStat { get; set; }

    [JsonPropertyName("subtitle")]
    public string SubTitle { get; set; }

    [JsonPropertyName("Title")]
    public string Title { get; set; }

    [JsonPropertyName("type_desc")]
    public string TypeDesc { get; set; }

    [JsonPropertyName("type_name")]
    public string TypeName { get; set; }

    [JsonPropertyName("up_info")]
    public BangumiDetilyUpInfo UpInfo { get; set; }

    [JsonPropertyName("user_status")]
    public BangumiDetilyUserStatus UserStatus { get; set; }

    [JsonPropertyName("modules")]
    public List<BangumiDetilyModules> Modules { get; set; }
}

public class BangumiDetilyModules
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("style")]
    public string Style { get; set; }

    [JsonPropertyName("data")]
    public ModulesData Data { get; set; }
}

public class ModulesData
{
    [JsonPropertyName("attr")]
    public int Attr { get; set; }

    [JsonPropertyName("episode_id")]
    public int EpisodeId { get; set; }

    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("split_text")]
    public string SplitText { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("type")]
    public int Type { get; set; }

    [JsonPropertyName("type2")]
    public int Type2 { get; set; }

    [JsonPropertyName("episode_ids")]
    public List<object> EpisodeIds { get; set; }

    [JsonPropertyName("episodes")]
    public List<Data_Episodes> Episodes { get; set; }
}

public class Data_Episodes
{
    [JsonPropertyName("aid")]
    public long Aid { get; set; }

    [JsonPropertyName("badge")]
    public string Badge { get; set; }

    [JsonPropertyName("bvid")]
    public string Bvid { get; set; }

    [JsonPropertyName("cid")]
    public long Cid { get; set; }

    [JsonPropertyName("cover")]
    public string Cover { get; set; }

    [JsonPropertyName("duration")]
    public long Duartion { get; set; }

    [JsonPropertyName("ep_id")]
    public long Epid { get; set; }

    [JsonPropertyName("ep_index")]
    public int EpIndex { get; set; }

    [JsonPropertyName("from")]
    public string From { get; set; }

    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("pub_time")]
    public long PubTime { get; set; }

    [JsonPropertyName("stat")]
    public EpisodeStat Stat { get; set; }

    [JsonPropertyName("string")]
    public string SubTitle { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }
}

public class EpisodeStat
{
    [JsonPropertyName("coin")]
    public double Coin { get; set; }

    [JsonPropertyName("danmakus")]
    public long Danmakus { get; set; }

    [JsonPropertyName("likes")]
    public long Likes { get; set; }

    [JsonPropertyName("play")]
    public long Play { get; set; }

    [JsonPropertyName("reply")]
    public long Reply { get; set; }

    [JsonPropertyName("vt")]
    public long Vt { get; set; }
}

public class BangumiDetilyUserStatus
{
    [JsonPropertyName("follow")]
    public int Follow { get; set; }

    [JsonPropertyName("follow_bubble")]
    public int FollowBubble { get; set; }

    [JsonPropertyName("follow_status")]
    public int FollowStatus { get; set; }

    [JsonPropertyName("pay")]
    public int Pay { get; set; }

    [JsonPropertyName("pay_for")]
    public int PayFor { get; set; }

    [JsonPropertyName("progress")]
    public BangumiDetilyUserStatusProgress Progress { get; set; }
}

public class BangumiDetilyUserStatusProgress
{
    [JsonPropertyName("last_ep_id")]
    public long LastEpid { get; set; }

    [JsonPropertyName("last_ep_index")]
    public string LastEpIndex { get; set; }

    [JsonPropertyName("last_time")]
    public int LastTime { get; set; }
}

public class BangumiDetilyUpInfo
{
    [JsonPropertyName("avatar")]
    public string Avatar { get; set; }

    [JsonPropertyName("follower")]
    public long Follower { get; set; }

    [JsonPropertyName("is_follow")]
    public int IsFollow { get; set; }

    [JsonPropertyName("mid")]
    public long Mid { get; set; }

    [JsonPropertyName("uname")]
    public string UPname { get; set; }

    [JsonPropertyName("verify_type")]
    public int VerifyType { get; set; }

    [JsonPropertyName("vip_status")]
    public int VipStatus { get; set; }

    [JsonPropertyName("vip_type")]
    public int VipType { get; set; }
}

public class BangumiDetilyStat
{
    [JsonPropertyName("coins")]
    public double Coins { get; set; }

    [JsonPropertyName("danmakus")]
    public long Danmakus { get; set; }

    [JsonPropertyName("favorite")]
    public long Favorite { get; set; }

    [JsonPropertyName("favorites")]
    public long Favorites { get; set; }

    [JsonPropertyName("followers")]
    public string Followers { get; set; }

    [JsonPropertyName("likes")]
    public long Likes { get; set; }

    [JsonPropertyName("play")]
    public string PlayString { get; set; }

    [JsonPropertyName("reply")]
    public long Reply { get; set; }

    [JsonPropertyName("share")]
    public long Share { get; set; }

    [JsonPropertyName("views")]
    public long Views { get; set; }

    [JsonPropertyName("vt")]
    public int Vt { get; set; }
}

public class BangumiDetilySeries
{
    [JsonPropertyName("series_id")]
    public int Id { get; set; }

    [JsonPropertyName("series_title")]
    public string SeriesTitle { get; set; }
}

public class BangumiDetilyRating
{
    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("score")]
    public double Score { get; set; }
}

public class BangumiDetilyPublish
{
    [JsonPropertyName("is_finish")]
    public int Is_finish { get; set; }

    [JsonPropertyName("pub_time")]
    public string Pub_time { get; set; }

    [JsonPropertyName("pub_time_show")]
    public string Pub_time_show { get; set; }

    [JsonPropertyName("release_date_show")]
    public string Release_date_show { get; set; }

    [JsonPropertyName("time_length_show")]
    public string DurationLength { get; set; }
}

public class BangumiDetilyNewEp
{
    [JsonPropertyName("desc")]
    public string Desc { get; set; }

    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("is_new")]
    public int Is_new { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }
}

public class BangumiDetilyCelebrity
{
    [JsonPropertyName("avatar")]
    public string Cover { get; set; }

    [JsonPropertyName("character_avatar")]
    public string Character_avatar { get; set; }

    [JsonPropertyName("desc")]
    public string Desc { get; set; }

    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("short_desc")]
    public string Short_desc { get; set; }
}

public class BangumiDetilyArea
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }
}

public class BangumiDetilyActor
{
    [JsonPropertyName("info")]
    public string Info { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }
}
