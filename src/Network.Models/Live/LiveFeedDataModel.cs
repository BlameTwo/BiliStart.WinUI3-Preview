using System.Text.Json.Serialization;

namespace Network.Models.Live;

public class AdTransparentContent
{
    [JsonPropertyName("request_id")]
    public string RequestId { get; set; }

    [JsonPropertyName("source_id")]
    public int SourceId { get; set; }

    [JsonPropertyName("resource_id")]
    public int ResourceId { get; set; }

    [JsonPropertyName("is_ad_loc")]
    public bool IsAdLoc { get; set; }

    [JsonPropertyName("server_type")]
    public int ServerType { get; set; }

    [JsonPropertyName("client_ip")]
    public string ClientIp { get; set; }

    [JsonPropertyName("index")]
    public int Index { get; set; }

    [JsonPropertyName("src_id")]
    public int SrcId { get; set; }
}

public class AreaEntranceV3
{
    [JsonPropertyName("module_info")]
    public ModuleInfo ModuleInfo { get; set; }

    [JsonPropertyName("extra_info")]
    public ExtraInfo ExtraInfo { get; set; }

    [JsonPropertyName("list")]
    public List<LiveList> List { get; set; }

    [JsonPropertyName("entrance_type")]
    public int EntranceType { get; set; }
}

public class LiveBannerV1
{
    [JsonPropertyName("module_info")]
    public ModuleInfo ModuleInfo { get; set; }

    [JsonPropertyName("list")]
    public List<LiveList> List { get; set; }
}

public class LiveCardData
{
    [JsonPropertyName("banner_v1")]
    public LiveBannerV1 LiveBannerV1 { get; set; }

    [JsonPropertyName("my_idol_v1")]
    public MyIdolV1 MyIdolV1 { get; set; }

    [JsonPropertyName("area_entrance_v3")]
    public AreaEntranceV3 AreaEntranceV3 { get; set; }

    [JsonPropertyName("small_card_v1")]
    public SmallCardV1 SmallCardV1 { get; set; }
}

public class LiveCardList
{
    [JsonPropertyName("card_type")]
    public string CardType { get; set; }

    [JsonPropertyName("card_data")]
    public LiveCardData LiveCardData { get; set; }
}

public class CoverLeftStyle
{
    [JsonPropertyName("text")]
    public string Text { get; set; }
}

public class CoverRightStyle
{
    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("img")]
    public string Img { get; set; }
}

public class LiveFeedDataModel
{
    [JsonPropertyName("card_list")]
    public List<LiveCardList> LiveCardList { get; set; }

    [JsonPropertyName("is_rollback")]
    public int IsRollback { get; set; }

    [JsonPropertyName("has_more")]
    public int HasMore { get; set; }

    [JsonPropertyName("trigger_time")]
    public int TriggerTime { get; set; }

    [JsonPropertyName("is_need_refresh")]
    public int IsNeedRefresh { get; set; }
}

public class ExtraInfo
{
    [JsonPropertyName("total_count")]
    public int TotalCount { get; set; }

    [JsonPropertyName("time_desc")]
    public string TimeDesc { get; set; }

    [JsonPropertyName("uname_desc")]
    public string UnameDesc { get; set; }

    [JsonPropertyName("tags_desc")]
    public string TagsDesc { get; set; }

    [JsonPropertyName("card_type")]
    public int CardType { get; set; }

    [JsonPropertyName("relation_page")]
    public int RelationPage { get; set; }

    [JsonPropertyName("show_type")]
    public int ShowType { get; set; }

    [JsonPropertyName("card_type_v2")]
    public int CardTypeV2 { get; set; }

    [JsonPropertyName("card_type_v3")]
    public int CardTypeV3 { get; set; }

    [JsonPropertyName("offline")]
    public List<object> Offline { get; set; }
}

public class LiveFeedback
{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("subtitle")]
    public string Subtitle { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("LiveReasons")]
    public List<LiveReason> LiveReasons { get; set; }
}

public class LiveFeedTag
{
    [JsonPropertyName("tag_text")]
    public string TagText { get; set; }
}

public class LiveList
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("link")]
    public string Link { get; set; }

    [JsonPropertyName("pic")]
    public string Pic { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("content")]
    public string Content { get; set; }

    [JsonPropertyName("session_id")]
    public string SessionId { get; set; }

    [JsonPropertyName("group_id")]
    public int GroupId { get; set; }

    [JsonPropertyName("is_ad")]
    public bool IsAd { get; set; }

    [JsonPropertyName("ad_transparent_content")]
    public AdTransparentContent AdTransparentContent { get; set; }

    [JsonPropertyName("show_ad_icon")]
    public bool ShowAdIcon { get; set; }

    [JsonPropertyName("roomid")]
    public int Roomid { get; set; }

    [JsonPropertyName("uid")]
    public long Uid { get; set; }

    [JsonPropertyName("uname")]
    public string Uname { get; set; }

    [JsonPropertyName("face")]
    public string Face { get; set; }

    [JsonPropertyName("cover")]
    public string Cover { get; set; }

    [JsonPropertyName("area")]
    public int Area { get; set; }

    [JsonPropertyName("live_time")]
    public int LiveTime { get; set; }

    [JsonPropertyName("area_name")]
    public string AreaName { get; set; }

    [JsonPropertyName("area_v2_id")]
    public int AreaV2Id { get; set; }

    [JsonPropertyName("area_v2_name")]
    public string AreaV2Name { get; set; }

    [JsonPropertyName("area_v2_parent_name")]
    public string AreaV2ParentName { get; set; }

    [JsonPropertyName("area_v2_parent_id")]
    public int AreaV2ParentId { get; set; }

    [JsonPropertyName("live_tag_name")]
    public string LiveTagName { get; set; }

    [JsonPropertyName("online")]
    public int Online { get; set; }

    [JsonPropertyName("play_url")]
    public string PlayUrl { get; set; }

    [JsonPropertyName("play_url_h265")]
    public string PlayUrlH265 { get; set; }

    [JsonPropertyName("accept_quality")]
    public List<int> AcceptQuality { get; set; }

    [JsonPropertyName("current_quality")]
    public int CurrentQuality { get; set; }

    [JsonPropertyName("pk_id")]
    public int PkId { get; set; }

    [JsonPropertyName("special_attention")]
    public int SpecialAttention { get; set; }

    [JsonPropertyName("broadcast_type")]
    public int BroadcastType { get; set; }

    [JsonPropertyName("pendent_ru")]
    public string PendentRu { get; set; }

    [JsonPropertyName("pendent_ru_color")]
    public string PendentRuColor { get; set; }

    [JsonPropertyName("pendent_ru_pic")]
    public string PendentRuPic { get; set; }

    [JsonPropertyName("official_verify")]
    public int OfficialVerify { get; set; }

    [JsonPropertyName("current_qn")]
    public int CurrentQn { get; set; }

    [JsonPropertyName("quality_description")]
    public List<QualityDescription> QualityDescription { get; set; }

    [JsonPropertyName("play_url_card")]
    public string PlayUrlCard { get; set; }

    [JsonPropertyName("flag")]
    public int Flag { get; set; }

    [JsonPropertyName("pendent_list")]
    public List<PendentList> PendentList { get; set; }

    [JsonPropertyName("p2p_type")]
    public int P2pType { get; set; }

    [JsonPropertyName("watched_show")]
    public LiveWatchedShow LiveWatchedShow { get; set; }

    [JsonPropertyName("is_nft")]
    public int IsNft { get; set; }

    [JsonPropertyName("nft_dmark")]
    public string NftDmark { get; set; }

    [JsonPropertyName("status_text")]
    public string StatusText { get; set; }

    [JsonPropertyName("tag_type")]
    public int TagType { get; set; }
}

public class ModuleInfo
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("link")]
    public string Link { get; set; }

    [JsonPropertyName("pic")]
    public string Pic { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("type")]
    public int Type { get; set; }

    [JsonPropertyName("sort")]
    public int Sort { get; set; }

    [JsonPropertyName("count")]
    public int Count { get; set; }
}

public class MyIdolV1
{
    [JsonPropertyName("module_info")]
    public ModuleInfo ModuleInfo { get; set; }

    [JsonPropertyName("extra_info")]
    public ExtraInfo ExtraInfo { get; set; }

    [JsonPropertyName("list")]
    public List<LiveList> List { get; set; }
}

public class PendentList
{
    [JsonPropertyName("content")]
    public string Content { get; set; }

    [JsonPropertyName("position")]
    public int Position { get; set; }

    [JsonPropertyName("color")]
    public string Color { get; set; }

    [JsonPropertyName("pic")]
    public string Pic { get; set; }

    [JsonPropertyName("pendent_id")]
    public int PendentId { get; set; }
}

public class QualityDescription
{
    [JsonPropertyName("qn")]
    public int Qn { get; set; }

    [JsonPropertyName("desc")]
    public string Desc { get; set; }
}

public class LiveReason
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("id_type")]
    public string IdType { get; set; }
}

public class SmallCardV1
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("cover")]
    public string Cover { get; set; }

    [JsonPropertyName("link")]
    public string Link { get; set; }

    [JsonPropertyName("area_id")]
    public int AreaId { get; set; }

    [JsonPropertyName("area_name")]
    public string AreaName { get; set; }

    [JsonPropertyName("parent_area_id")]
    public int ParentAreaId { get; set; }

    [JsonPropertyName("parent_area_name")]
    public string ParentAreaName { get; set; }

    [JsonPropertyName("uid")]
    public long Uid { get; set; }

    [JsonPropertyName("online")]
    public long Online { get; set; }

    [JsonPropertyName("pendent_list")]
    public List<PendentList> PendentList { get; set; }

    [JsonPropertyName("cover_left_style")]
    public CoverLeftStyle CoverLeftStyle { get; set; }

    [JsonPropertyName("cover_right_style")]
    public CoverRightStyle CoverRightStyle { get; set; }

    [JsonPropertyName("subtitle_style")]
    public LiveSubtitleStyle LiveSubtitleStyle { get; set; }

    [JsonPropertyName("session_id")]
    public string SessionId { get; set; }

    [JsonPropertyName("group_id")]
    public int GroupId { get; set; }

    [JsonPropertyName("jumpfrom_extend")]
    public int JumpfromExtend { get; set; }

    [JsonPropertyName("show_callback")]
    public string ShowCallback { get; set; }

    [JsonPropertyName("click_callback")]
    public string ClickCallback { get; set; }

    [JsonPropertyName("LiveFeedback_img")]
    public string LiveFeedbackImg { get; set; }

    [JsonPropertyName("LiveFeedback_night_img")]
    public string LiveFeedbackNightImg { get; set; }

    [JsonPropertyName("LiveFeedback")]
    public List<LiveFeedback> LiveFeedback { get; set; }

    [JsonPropertyName("flag")]
    public int Flag { get; set; }

    [JsonPropertyName("broadcast_type")]
    public int BroadcastType { get; set; }

    [JsonPropertyName("accept_quality")]
    public List<int> AcceptQuality { get; set; }

    [JsonPropertyName("current_qn")]
    public int CurrentQn { get; set; }

    [JsonPropertyName("current_quality")]
    public int CurrentQuality { get; set; }

    [JsonPropertyName("play_url")]
    public string PlayUrl { get; set; }

    [JsonPropertyName("play_url_h265")]
    public string PlayUrlH265 { get; set; }

    [JsonPropertyName("quality_description")]
    public List<QualityDescription> QualityDescription { get; set; }

    [JsonPropertyName("play_url_card")]
    public string PlayUrlCard { get; set; }

    [JsonPropertyName("p2p_type")]
    public int P2pType { get; set; }

    [JsonPropertyName("pk_id")]
    public int PkId { get; set; }

    [JsonPropertyName("index")]
    public int Index { get; set; }

    [JsonPropertyName("is_hide_LiveFeedback")]
    public int IsHideLiveFeedback { get; set; }

    [JsonPropertyName("is_full_screen_list")]
    public int IsFullScreenList { get; set; }

    [JsonPropertyName("rec_tag_style")]
    public object RecTagStyle { get; set; }

    [JsonPropertyName("watched_show")]
    public LiveWatchedShow LiveWatchedShow { get; set; }

    [JsonPropertyName("is_ad")]
    public bool IsAd { get; set; }

    [JsonPropertyName("ad_transparent_content")]
    public object AdTransparentContent { get; set; }

    [JsonPropertyName("show_ad_icon")]
    public bool ShowAdIcon { get; set; }

    [JsonPropertyName("uname")]
    public string Uname { get; set; }

    [JsonPropertyName("feed_style")]
    public int FeedStyle { get; set; }

    [JsonPropertyName("feed_tag")]
    public LiveFeedTag LiveFeedTag { get; set; }

    [JsonPropertyName("face")]
    public string Face { get; set; }

    [JsonPropertyName("official_verify")]
    public int OfficialVerify { get; set; }
}

public class LiveSubtitleStyle
{
    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("text_color")]
    public string TextColor { get; set; }

    [JsonPropertyName("text_night_color")]
    public string TextNightColor { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }
}

public class LiveWatchedShow
{
    [JsonPropertyName("switch")]
    public bool Switch { get; set; }

    [JsonPropertyName("num")]
    public int Num { get; set; }

    [JsonPropertyName("text_small")]
    public string TextSmall { get; set; }

    [JsonPropertyName("text_large")]
    public string TextLarge { get; set; }

    [JsonPropertyName("icon")]
    public string Icon { get; set; }

    [JsonPropertyName("icon_location")]
    public int IconLocation { get; set; }

    [JsonPropertyName("icon_web")]
    public string IconWeb { get; set; }
}
