using System.Text.Json.Serialization;

namespace Network.Models.Totals.HotHistory;

public class Attentions
{
    [JsonPropertyName("uids")]
    public List<object> Uids { get; set; }
}

public class AttrBit
{
    [JsonPropertyName("not_night")]
    public bool NotNight { get; set; }
}

public class Bases
{
    [JsonPropertyName("participation")]
    public Participation Participation { get; set; }

    [JsonPropertyName("head")]
    public Head Head { get; set; }
}

public class HotHsitoryNavCard
{
    [JsonPropertyName("goto")]
    public string Goto { get; set; }

    [JsonPropertyName("param")]
    public string Param { get; set; }

    [JsonPropertyName("item_id")]
    public int ItemId { get; set; }

    [JsonPropertyName("ukey")]
    public string Ukey { get; set; }

    [JsonPropertyName("item")]
    public List<HotHistoryNavItem> Item { get; set; }

    [JsonPropertyName("url_ext")]
    public HotHistoryCardUrlExt UrlExt { get; set; }
}

public class HotHistoryCardUrlExt
{
    [JsonPropertyName("sort_type")]
    public int SortType { get; set; }

    [JsonPropertyName("conf_module_id")]
    public long ConfModule { get; set; }

    [JsonPropertyName("goto")]
    public string GoTo { get; set; }
}

public class Color
{
    [JsonPropertyName("bg_color")]
    public string BgColor { get; set; }

    [JsonPropertyName("select_font_color")]
    public string HotHistoryNavSelectFontColor { get; set; }

    [JsonPropertyName("nt_select_font_color")]
    public string NtHotHistoryNavSelectFontColor { get; set; }
}

public class HotHistoryNavigationModel
{
    [JsonPropertyName("page_id")]
    public int PageId { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("foreign_id")]
    public int ForeignId { get; set; }

    [JsonPropertyName("foreign_type")]
    public int ForeignType { get; set; }

    [JsonPropertyName("share_title")]
    public string ShareTitle { get; set; }

    [JsonPropertyName("share_image")]
    public string ShareImage { get; set; }

    [JsonPropertyName("share_url")]
    public string ShareUrl { get; set; }

    [JsonPropertyName("share_caption")]
    public string ShareCaption { get; set; }

    [JsonPropertyName("share_type")]
    public int ShareType { get; set; }

    [JsonPropertyName("page_url")]
    public string PageUrl { get; set; }

    [JsonPropertyName("dynamic_info")]
    public DynamicInfo DynamicInfo { get; set; }

    [JsonPropertyName("cards")]
    public List<HotHsitoryNavCard> Cards { get; set; }

    [JsonPropertyName("attentions")]
    public Attentions Attentions { get; set; }

    [JsonPropertyName("offset")]
    public int Offset { get; set; }

    [JsonPropertyName("has_more")]
    public int HasMore { get; set; }

    [JsonPropertyName("version_msg")]
    public string VersionMsg { get; set; }

    [JsonPropertyName("bases")]
    public Bases Bases { get; set; }

    [JsonPropertyName("color")]
    public Color Color { get; set; }

    [JsonPropertyName("attr_bit")]
    public AttrBit AttrBit { get; set; }

    [JsonPropertyName("up_space")]
    public UpSpace UpSpace { get; set; }
}

public class DynamicInfo
{
    [JsonPropertyName("is_followed")]
    public bool IsFollowed { get; set; }

    [JsonPropertyName("display_subscribe_btn")]
    public bool DisplaySubscribeBtn { get; set; }

    [JsonPropertyName("display_view_num")]
    public bool DisplayViewNum { get; set; }
}

public class Head
{
    [JsonPropertyName("content")]
    public string Content { get; set; }

    [JsonPropertyName("head_uri")]
    public string HeadUri { get; set; }

    [JsonPropertyName("color")]
    public Color Color { get; set; }

    [JsonPropertyName("user_info")]
    public UserInfo UserInfo { get; set; }

    [JsonPropertyName("opt_image")]
    public string OptImage { get; set; }

    [JsonPropertyName("opt_image_2")]
    public string OptImage2 { get; set; }
}

public class ImagesUnion
{
    [JsonPropertyName("un_select")]
    public UnHotHistoryNavSelect UnHotHistoryNavSelect { get; set; }

    [JsonPropertyName("select")]
    public HotHistoryNavSelect HotHistoryNavSelect { get; set; }
}

public class HotHistoryNavItem
{
    [JsonPropertyName("goto")]
    public string Goto { get; set; }

    [JsonPropertyName("param")]
    public string Param { get; set; }

    [JsonPropertyName("item_id")]
    public long ItemId { get; set; }

    [JsonPropertyName("width")]
    public int Width { get; set; }

    [JsonPropertyName("length")]
    public int Length { get; set; }

    [JsonPropertyName("image")]
    public string Image { get; set; }

    [JsonPropertyName("item")]
    public List<HotHistoryNavItem> Items { get; set; }

    [JsonPropertyName("color")]
    public Color Color { get; set; }

    [JsonPropertyName("setting")]
    public Setting Setting { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("images_union")]
    public ImagesUnion ImagesUnion { get; set; }

    [JsonPropertyName("uri")]
    public string Uri { get; set; }

    [JsonPropertyName("content")]
    public string Content { get; set; }

    [JsonPropertyName("repost")]
    public HotHistoryItemRepost Repost { get; set; }

    [JsonPropertyName("icon")]
    public HotHistoryItemIcon Icon { get; set; }

    [JsonPropertyName("text")]
    public HotHistoryText Text { get; set; }

    [JsonPropertyName("positions")]
    public HotHistoryItemPositions Positions { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }
}

public class HotHistoryItemPositions
{
    [JsonPropertyName("position1")]
    public string Position1 { get; set; }

    [JsonPropertyName("position2")]
    public string Position2 { get; set; }

    [JsonPropertyName("position3")]
    public string Position3 { get; set; }

    [JsonPropertyName("position4")]
    public string Position4 { get; set; }

    [JsonPropertyName("position5")]
    public string Position5 { get; set; }
}

public class HotHistoryText
{
    [JsonPropertyName("top_content")]
    public string TopContent { get; set; }
}

public class HotHistoryItemIcon
{
    [JsonPropertyName("top_icon")]
    public string Icon { get; set; }
}

public class HotHistoryItemRepost
{
    [JsonPropertyName("biz_type")]
    public string BizType { get; set; }
}

public class HotHistoryNavLabel
{
    [JsonPropertyName("path")]
    public string Path { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("label_theme")]
    public string HotHistoryNavLabelTheme { get; set; }

    [JsonPropertyName("text_color")]
    public string TextColor { get; set; }

    [JsonPropertyName("bg_style")]
    public int BgStyle { get; set; }

    [JsonPropertyName("bg_color")]
    public string BgColor { get; set; }

    [JsonPropertyName("border_color")]
    public string BorderColor { get; set; }

    [JsonPropertyName("use_img_label")]
    public bool UseImgHotHistoryNavLabel { get; set; }

    [JsonPropertyName("img_label_uri_hans")]
    public string ImgHotHistoryNavLabelUriHans { get; set; }

    [JsonPropertyName("img_label_uri_hant")]
    public string ImgHotHistoryNavLabelUriHant { get; set; }

    [JsonPropertyName("img_label_uri_hans_static")]
    public string ImgHotHistoryNavLabelUriHansStatic { get; set; }

    [JsonPropertyName("img_label_uri_hant_static")]
    public string ImgHotHistoryNavLabelUriHantStatic { get; set; }
}

public class OfficialInfo
{
    [JsonPropertyName("role")]
    public int Role { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("desc")]
    public string Desc { get; set; }

    [JsonPropertyName("type")]
    public int Type { get; set; }
}

public class Participation
{
    [JsonPropertyName("param")]
    public string Param { get; set; }

    [JsonPropertyName("item_id")]
    public int ItemId { get; set; }

    [JsonPropertyName("image")]
    public string Image { get; set; }

    [JsonPropertyName("un_image")]
    public string UnImage { get; set; }

    [JsonPropertyName("item")]
    public List<HotHistoryNavItem> Item { get; set; }
}

public class HotHistoryNavSelect
{
    [JsonPropertyName("image")]
    public string Image { get; set; }

    [JsonPropertyName("width")]
    public int Width { get; set; }

    [JsonPropertyName("height")]
    public int Height { get; set; }
}

public class Setting
{
    [JsonPropertyName("display_title")]
    public bool DisplayTitle { get; set; }

    [JsonPropertyName("display_op")]
    public bool DisplayOp { get; set; }

    [JsonPropertyName("display_num")]
    public bool DisplayNum { get; set; }

    [JsonPropertyName("display_node_num")]
    public bool DisplayNodeNum { get; set; }

    [JsonPropertyName("display_desc")]
    public bool DisplayDesc { get; set; }

    [JsonPropertyName("tab_style")]
    public int TabStyle { get; set; }
}

public class UnHotHistoryNavSelect
{
    [JsonPropertyName("image")]
    public string Image { get; set; }

    [JsonPropertyName("width")]
    public int Width { get; set; }

    [JsonPropertyName("height")]
    public int Height { get; set; }
}

public class UpSpace
{
    [JsonPropertyName("space_page_url")]
    public string SpacePageUrl { get; set; }

    [JsonPropertyName("exclusive_page_url")]
    public string ExclusivePageUrl { get; set; }
}

public class UserInfo
{
    [JsonPropertyName("mid")]
    public int Mid { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("face")]
    public string Face { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("official_info")]
    public OfficialInfo OfficialInfo { get; set; }

    [JsonPropertyName("vip")]
    public Vip Vip { get; set; }
}

public class Vip
{
    [JsonPropertyName("type")]
    public int Type { get; set; }

    [JsonPropertyName("status")]
    public int Status { get; set; }

    [JsonPropertyName("due_date")]
    public int DueDate { get; set; }

    [JsonPropertyName("vip_pay_type")]
    public int VipPayType { get; set; }

    [JsonPropertyName("theme_type")]
    public int ThemeType { get; set; }

    [JsonPropertyName("label")]
    public HotHistoryNavLabel HotHistoryNavLabel { get; set; }

    [JsonPropertyName("avatar_subscript")]
    public int AvatarSubscript { get; set; }

    [JsonPropertyName("nickname_color")]
    public string NicknameColor { get; set; }

    [JsonPropertyName("role")]
    public int Role { get; set; }

    [JsonPropertyName("avatar_subscript_url")]
    public string AvatarSubscriptUrl { get; set; }

    [JsonPropertyName("tv_vip_status")]
    public int TvVipStatus { get; set; }

    [JsonPropertyName("tv_vip_pay_type")]
    public int TvVipPayType { get; set; }

    [JsonPropertyName("tv_due_date")]
    public int TvDueDate { get; set; }
}
