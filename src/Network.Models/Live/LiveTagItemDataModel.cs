using System.Text.Json.Serialization;

namespace Network.Models.Live;

// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
public class LiveItemBanner
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("pic")]
    public string Pic { get; set; }

    [JsonPropertyName("link")]
    public string Link { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("position")]
    public int Position { get; set; }

    [JsonPropertyName("sort_num")]
    public int SortNum { get; set; }

    [JsonPropertyName("session_id")]
    public string SessionId { get; set; }

    [JsonPropertyName("group_id")]
    public int GroupId { get; set; }

    [JsonPropertyName("is_ad")]
    public bool IsAd { get; set; }

    [JsonPropertyName("ad_transparent_content")]
    public object AdTransparentContent { get; set; }

    [JsonPropertyName("show_ad_icon")]
    public bool ShowAdIcon { get; set; }
}

public class CoverSize
{
    [JsonPropertyName("height")]
    public int Height { get; set; }

    [JsonPropertyName("width")]
    public int Width { get; set; }
}

public class LiveTagItemDataModel
{
    [JsonPropertyName("new_tags")]
    public List<LiveTagItemNewTag> NewTags { get; set; }

    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("list")]
    public List<LiveTagItemList> List { get; set; }

    [JsonPropertyName("banner")]
    public List<LiveItemBanner> LiveItemBanner { get; set; }

    [JsonPropertyName("activity_banner")]
    public List<object> ActivityBanner { get; set; }

    [JsonPropertyName("trigger_time")]
    public int TriggerTime { get; set; }

    [JsonPropertyName("is_need_refresh")]
    public int IsNeedRefresh { get; set; }

    [JsonPropertyName("card_type")]
    public string CardType { get; set; }

    [JsonPropertyName("extra")]
    public Extra Extra { get; set; }

    [JsonPropertyName("card_type_v2")]
    public int CardTypeV2 { get; set; }

    [JsonPropertyName("vajra")]
    public object Vajra { get; set; }
}

public class Extra
{
    [JsonPropertyName("is_app_index_v2")]
    public bool IsAppIndexV2 { get; set; }
}

public class LiveTagItemList
{
    [JsonPropertyName("roomid")]
    public int Roomid { get; set; }

    [JsonPropertyName("uid")]
    public object Uid { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("uname")]
    public string Uname { get; set; }

    [JsonPropertyName("online")]
    public int Online { get; set; }

    [JsonPropertyName("user_cover")]
    public string UserCover { get; set; }

    [JsonPropertyName("user_cover_flag")]
    public int UserCoverFlag { get; set; }

    [JsonPropertyName("system_cover")]
    public string SystemCover { get; set; }

    [JsonPropertyName("show_cover")]
    public string ShowCover { get; set; }

    [JsonPropertyName("link")]
    public string Link { get; set; }

    [JsonPropertyName("face")]
    public string Face { get; set; }

    [JsonPropertyName("parent_id")]
    public int ParentId { get; set; }

    [JsonPropertyName("parent_name")]
    public string ParentName { get; set; }

    [JsonPropertyName("area_id")]
    public int AreaId { get; set; }

    [JsonPropertyName("area_name")]
    public string AreaName { get; set; }

    [JsonPropertyName("cover")]
    public string Cover { get; set; }

    [JsonPropertyName("web_pendent")]
    public string WebPendent { get; set; }

    [JsonPropertyName("cover_size")]
    public CoverSize CoverSize { get; set; }

    [JsonPropertyName("play_url")]
    public string PlayUrl { get; set; }

    [JsonPropertyName("play_url_h265")]
    public string PlayUrlH265 { get; set; }

    [JsonPropertyName("play_url_card")]
    public string PlayUrlCard { get; set; }

    [JsonPropertyName("accept_quality")]
    public string AcceptQuality { get; set; }

    [JsonPropertyName("current_quality")]
    public int CurrentQuality { get; set; }

    [JsonPropertyName("accept_quality_v2")]
    public List<object> AcceptQualityV2 { get; set; }

    [JsonPropertyName("current_qn")]
    public int CurrentQn { get; set; }

    [JsonPropertyName("quality_description")]
    public List<QualityDescription> QualityDescription { get; set; }

    [JsonPropertyName("is_tv")]
    public int IsTv { get; set; }

    [JsonPropertyName("corner")]
    public string Corner { get; set; }

    [JsonPropertyName("pendent")]
    public string Pendent { get; set; }

    [JsonPropertyName("session_id")]
    public string SessionId { get; set; }

    [JsonPropertyName("group_id")]
    public int GroupId { get; set; }

    [JsonPropertyName("show_callback")]
    public string ShowCallback { get; set; }

    [JsonPropertyName("click_callback")]
    public string ClickCallback { get; set; }

    [JsonPropertyName("flag")]
    public int Flag { get; set; }

    [JsonPropertyName("pendent_ld")]
    public string PendentLd { get; set; }

    [JsonPropertyName("pendent_ru")]
    public string PendentRu { get; set; }

    [JsonPropertyName("pendent_ld_color")]
    public string PendentLdColor { get; set; }

    [JsonPropertyName("pendent_ru_color")]
    public string PendentRuColor { get; set; }

    [JsonPropertyName("pendent_ru_pic")]
    public string PendentRuPic { get; set; }

    [JsonPropertyName("pendent_list")]
    public List<LiveTagItemPendentList> LiveTagItemPendentList { get; set; }

    [JsonPropertyName("pk_id")]
    public int PkId { get; set; }

    [JsonPropertyName("jumpfrom_extend")]
    public int JumpfromExtend { get; set; }

    [JsonPropertyName("area_v2_parent_id")]
    public int AreaV2ParentId { get; set; }

    [JsonPropertyName("area_v2_parent_name")]
    public string AreaV2ParentName { get; set; }

    [JsonPropertyName("area_v2_id")]
    public int AreaV2Id { get; set; }

    [JsonPropertyName("area_v2_name")]
    public string AreaV2Name { get; set; }

    [JsonPropertyName("p2p_type")]
    public int P2pType { get; set; }

    [JsonPropertyName("broadcast_type")]
    public int BroadcastType { get; set; }

    [JsonPropertyName("is_full_screen_list")]
    public int IsFullScreenList { get; set; }

    [JsonPropertyName("watched_show")]
    public WatchedShow WatchedShow { get; set; }

    [JsonPropertyName("virtual_area_id")]
    public int VirtualAreaId { get; set; }

    [JsonPropertyName("full_screen_user_cover")]
    public string FullScreenUserCover { get; set; }

    [JsonPropertyName("virtual_parent_area_id")]
    public int VirtualParentAreaId { get; set; }
}

public class LiveTagItemNewTag
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("icon")]
    public string Icon { get; set; }

    [JsonPropertyName("sort_type")]
    public string SortType { get; set; }

    [JsonPropertyName("type")]
    public int Type { get; set; }

    [JsonPropertyName("sub")]
    public List<object> Sub { get; set; }

    [JsonPropertyName("hero_list")]
    public List<object> HeroList { get; set; }

    [JsonPropertyName("sort")]
    public int Sort { get; set; }
}

public class LiveTagItemPendentList
{
    [JsonPropertyName("content")]
    public string Content { get; set; }

    [JsonPropertyName("color")]
    public string Color { get; set; }

    [JsonPropertyName("pic")]
    public string Pic { get; set; }

    [JsonPropertyName("position")]
    public int Position { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("pendent_id")]
    public int PendentId { get; set; }
}

public class WatchedShow
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
