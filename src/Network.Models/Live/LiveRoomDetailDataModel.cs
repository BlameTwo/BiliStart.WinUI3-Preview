using System.Text.Json.Serialization;

namespace Network.Models.Live;

// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
public class LiveInfoActivityBannerInfo
{
    [JsonPropertyName("top")]
    public List<object> Top { get; set; }

    [JsonPropertyName("bottom")]
    public List<object> Bottom { get; set; }

    [JsonPropertyName("inputBanner")]
    public List<object> InputBanner { get; set; }

    [JsonPropertyName("superBanner")]
    public object SuperBanner { get; set; }

    [JsonPropertyName("lol_activity")]
    public object LolActivity { get; set; }

    [JsonPropertyName("gift_banner")]
    public GiftBanner GiftBanner { get; set; }

    [JsonPropertyName("revenue_banner")]
    public RevenueBanner RevenueBanner { get; set; }

    [JsonPropertyName("pendant_banner")]
    public List<PendantBanner> PendantBanner { get; set; }

    [JsonPropertyName("proactive_banner")]
    public ProactiveBanner ProactiveBanner { get; set; }
}

public class LiveRoomInfoAdLivegameInfo
{
    [JsonPropertyName("request_id")]
    public string RequestId { get; set; }

    [JsonPropertyName("hide_component")]
    public int HideComponent { get; set; }

    [JsonPropertyName("is_ad")]
    public int IsAd { get; set; }
}

public class LiveRoomInfoAnchorInfo
{
    [JsonPropertyName("base_info")]
    public BaseInfo BaseInfo { get; set; }

    [JsonPropertyName("live_info")]
    public LiveInfo LiveInfo { get; set; }

    [JsonPropertyName("relation_info")]
    public RelationInfo RelationInfo { get; set; }

    [JsonPropertyName("medal_info")]
    public MedalInfo MedalInfo { get; set; }

    [JsonPropertyName("gift_info")]
    public GiftInfo GiftInfo { get; set; }
}

public class BaseInfo
{
    [JsonPropertyName("uname")]
    public string Uname { get; set; }

    [JsonPropertyName("face")]
    public string Face { get; set; }

    [JsonPropertyName("gender")]
    public string Gender { get; set; }

    [JsonPropertyName("official_info")]
    public OfficialInfo OfficialInfo { get; set; }

    [JsonPropertyName("is_nft")]
    public int IsNft { get; set; }

    [JsonPropertyName("nft_dmark")]
    public string NftDmark { get; set; }
}

public class BlockInfo
{
    [JsonPropertyName("block")]
    public bool Block { get; set; }
}

public class ChronosMode
{
    [JsonPropertyName("mobi_pool")]
    public string MobiPool { get; set; }

    [JsonPropertyName("mobi_module")]
    public string MobiModule { get; set; }

    [JsonPropertyName("mobi_module_file")]
    public string MobiModuleFile { get; set; }

    [JsonPropertyName("mobi_module_file_name")]
    public string MobiModuleFileName { get; set; }
}

public class ClickButton
{
    [JsonPropertyName("portrait_text")]
    public List<string> PortraitText { get; set; }

    [JsonPropertyName("landscape_text")]
    public List<string> LandscapeText { get; set; }
}

public class Custom
{
    [JsonPropertyName("icon")]
    public string Icon { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("note")]
    public string Note { get; set; }

    [JsonPropertyName("jump_url")]
    public string JumpUrl { get; set; }

    [JsonPropertyName("status")]
    public int Status { get; set; }

    [JsonPropertyName("sub_icon")]
    public string SubIcon { get; set; }
}

public class CustomStatusInfo
{
    [JsonPropertyName("status_list")]
    public List<object> StatusList { get; set; }
}

public class DanmuExtra
{
    [JsonPropertyName("screen_switch_off")]
    public bool ScreenSwitchOff { get; set; }

    [JsonPropertyName("chronos_kv")]
    public string ChronosKv { get; set; }
}

public class LiveRoomDetailDataModel
{
    [JsonPropertyName("room_info")]
    public RoomInfo RoomInfo { get; set; }

    [JsonPropertyName("anchor_info")]
    public LiveRoomInfoAnchorInfo LiveRoomInfoAnchorInfo { get; set; }

    [JsonPropertyName("tab_info")]
    public List<TabInfo> TabInfo { get; set; }

    [JsonPropertyName("pk_info")]
    public object PkInfo { get; set; }

    [JsonPropertyName("guard_info")]
    public GuardInfo GuardInfo { get; set; }

    [JsonPropertyName("guard_buy_info")]
    public GuardBuyInfo GuardBuyInfo { get; set; }

    [JsonPropertyName("rankdb_info")]
    public object RankdbInfo { get; set; }

    [JsonPropertyName("round_video_info")]
    public object RoundVideoInfo { get; set; }

    [JsonPropertyName("anchor_reward")]
    public object AnchorReward { get; set; }

    [JsonPropertyName("activity_banner_info")]
    public LiveInfoActivityBannerInfo LiveInfoActivityBannerInfo { get; set; }

    [JsonPropertyName("activity_score_info")]
    public object ActivityScoreInfo { get; set; }

    [JsonPropertyName("skin_info")]
    public SkinInfo SkinInfo { get; set; }

    [JsonPropertyName("activity_lol_match_info")]
    public object ActivityLolMatchInfo { get; set; }

    [JsonPropertyName("battle_info")]
    public object BattleInfo { get; set; }

    [JsonPropertyName("switch_info")]
    public SwitchInfo SwitchInfo { get; set; }

    [JsonPropertyName("studio_info")]
    public object StudioInfo { get; set; }

    [JsonPropertyName("voice_join")]
    public VoiceJoin VoiceJoin { get; set; }

    [JsonPropertyName("super_chat")]
    public SuperChat SuperChat { get; set; }

    [JsonPropertyName("room_config_info")]
    public RoomConfigInfo RoomConfigInfo { get; set; }

    [JsonPropertyName("gift_memory_info")]
    public GiftMemoryInfo GiftMemoryInfo { get; set; }

    [JsonPropertyName("new_switch_info")]
    public NewSwitchInfo NewSwitchInfo { get; set; }

    [JsonPropertyName("custom_status_info")]
    public CustomStatusInfo CustomStatusInfo { get; set; }

    [JsonPropertyName("topic_room_info")]
    public TopicRoomInfo TopicRoomInfo { get; set; }

    [JsonPropertyName("video_connection_info")]
    public object VideoConnectionInfo { get; set; }

    [JsonPropertyName("online_gold_rank_info")]
    public object OnlineGoldRankInfo { get; set; }

    [JsonPropertyName("online_gold_rank_info_v2")]
    public OnlineGoldRankInfoV2 OnlineGoldRankInfoV2 { get; set; }

    [JsonPropertyName("new_battle_info")]
    public object NewBattleInfo { get; set; }

    [JsonPropertyName("hot_rank_info")]
    public object HotRankInfo { get; set; }

    [JsonPropertyName("dm_speed_info")]
    public object DmSpeedInfo { get; set; }

    [JsonPropertyName("xtemplate_config")]
    public XtemplateConfig XtemplateConfig { get; set; }

    [JsonPropertyName("microphone_info")]
    public object MicrophoneInfo { get; set; }

    [JsonPropertyName("panel_info")]
    public object PanelInfo { get; set; }

    [JsonPropertyName("topic_info")]
    public TopicInfo TopicInfo { get; set; }

    [JsonPropertyName("new_panel_info")]
    public object NewPanelInfo { get; set; }

    [JsonPropertyName("shopping_info")]
    public ShoppingInfo ShoppingInfo { get; set; }

    [JsonPropertyName("multi_view_info")]
    public object MultiViewInfo { get; set; }

    [JsonPropertyName("new_tab_info")]
    public NewTabInfo NewTabInfo { get; set; }

    [JsonPropertyName("watched_show")]
    public WatchedShow WatchedShow { get; set; }

    [JsonPropertyName("show_reserve_status")]
    public bool ShowReserveStatus { get; set; }

    [JsonPropertyName("play_together_info")]
    public PlayTogetherInfo PlayTogetherInfo { get; set; }

    [JsonPropertyName("like_info")]
    public object LikeInfo { get; set; }

    [JsonPropertyName("double_click_info")]
    public DoubleClickInfo DoubleClickInfo { get; set; }

    [JsonPropertyName("function_card")]
    public FunctionCard FunctionCard { get; set; }

    [JsonPropertyName("like_info_v3")]
    public LikeInfoV3 LikeInfoV3 { get; set; }

    [JsonPropertyName("reserve_info")]
    public ReserveInfo ReserveInfo { get; set; }

    [JsonPropertyName("multi_voice")]
    public MultiVoice MultiVoice { get; set; }

    [JsonPropertyName("popular_rank_info")]
    public PopularRankInfo PopularRankInfo { get; set; }

    [JsonPropertyName("guide_status")]
    public GuideStatus GuideStatus { get; set; }

    [JsonPropertyName("new_area_rank_info")]
    public NewAreaRankInfo NewAreaRankInfo { get; set; }

    [JsonPropertyName("dm_vote")]
    public object DmVote { get; set; }

    [JsonPropertyName("gift_star")]
    public GiftStar GiftStar { get; set; }

    [JsonPropertyName("progress_for_widget")]
    public ProgressForWidget ProgressForWidget { get; set; }

    [JsonPropertyName("revenue_demotion")]
    public RevenueDemotion RevenueDemotion { get; set; }

    [JsonPropertyName("revenue_material_md5")]
    public RevenueMaterialMd5 RevenueMaterialMd5 { get; set; }

    [JsonPropertyName("ad_livegame_info")]
    public LiveRoomInfoAdLivegameInfo LiveRoomInfoAdLivegameInfo { get; set; }

    [JsonPropertyName("gaia")]
    public object Gaia { get; set; }

    [JsonPropertyName("block_info")]
    public BlockInfo BlockInfo { get; set; }

    [JsonPropertyName("danmu_extra")]
    public DanmuExtra DanmuExtra { get; set; }

    [JsonPropertyName("location")]
    public object Location { get; set; }

    [JsonPropertyName("room_rank_info")]
    public RoomRankInfo RoomRankInfo { get; set; }
}

public class DmBrushInfo
{
    [JsonPropertyName("landScape")]
    public LandScape LandScape { get; set; }

    [JsonPropertyName("verticalscreen")]
    public Verticalscreen Verticalscreen { get; set; }
}

public class DmEmoticonInfo
{
    [JsonPropertyName("is_open_emoticon")]
    public int IsOpenEmoticon { get; set; }

    [JsonPropertyName("is_shield_emoticon")]
    public int IsShieldEmoticon { get; set; }

    [JsonPropertyName("emoticon_ab_type")]
    public int EmoticonAbType { get; set; }

    [JsonPropertyName("hit_ab")]
    public int HitAb { get; set; }
}

public class DmMuKuType
{
    [JsonPropertyName("type")]
    public int Type { get; set; }
}

public class DmPoolInfo
{
    [JsonPropertyName("landScape")]
    public object LandScape { get; set; }

    [JsonPropertyName("verticalscreen")]
    public object Verticalscreen { get; set; }
}

public class DmSpeedInfo
{
    [JsonPropertyName("landScape")]
    public LandScape LandScape { get; set; }

    [JsonPropertyName("verticalscreen")]
    public Verticalscreen Verticalscreen { get; set; }
}

public class DmTagInfo
{
    [JsonPropertyName("dm_tag")]
    public int DmTag { get; set; }

    [JsonPropertyName("platform")]
    public List<object> Platform { get; set; }

    [JsonPropertyName("extra")]
    public string Extra { get; set; }

    [JsonPropertyName("dm_chronos_screen_type")]
    public int DmChronosScreenType { get; set; }

    [JsonPropertyName("dm_chronos_extra")]
    public string DmChronosExtra { get; set; }

    [JsonPropertyName("dm_mode")]
    public List<object> DmMode { get; set; }

    [JsonPropertyName("config_change")]
    public int ConfigChange { get; set; }

    [JsonPropertyName("dm_setting_switch")]
    public int DmSettingSwitch { get; set; }

    [JsonPropertyName("material_conf")]
    public object MaterialConf { get; set; }

    [JsonPropertyName("chronos_mode")]
    public ChronosMode ChronosMode { get; set; }
}

public class DmVoiceInfo
{
    [JsonPropertyName("anchor_switch_open")]
    public bool AnchorSwitchOpen { get; set; }

    [JsonPropertyName("is_banned")]
    public bool IsBanned { get; set; }

    [JsonPropertyName("code")]
    public int Code { get; set; }

    [JsonPropertyName("reason")]
    public string Reason { get; set; }
}

public class DoubleClickInfo
{
    [JsonPropertyName("emoticon")]
    public Emoticon Emoticon { get; set; }

    [JsonPropertyName("combo_animations")]
    public List<string> ComboAnimations { get; set; }
}

public class Emoticon
{
    [JsonPropertyName("emoji")]
    public string Emoji { get; set; }

    [JsonPropertyName("descript")]
    public string Descript { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("is_dynamic")]
    public int IsDynamic { get; set; }

    [JsonPropertyName("in_player_area")]
    public int InPlayerArea { get; set; }

    [JsonPropertyName("width")]
    public int Width { get; set; }

    [JsonPropertyName("height")]
    public int Height { get; set; }

    [JsonPropertyName("identity")]
    public int Identity { get; set; }

    [JsonPropertyName("unlock_need_gift")]
    public int UnlockNeedGift { get; set; }

    [JsonPropertyName("perm")]
    public int Perm { get; set; }

    [JsonPropertyName("unlock_need_level")]
    public int UnlockNeedLevel { get; set; }

    [JsonPropertyName("emoticon_value_type")]
    public int EmoticonValueType { get; set; }

    [JsonPropertyName("bulge_display")]
    public int BulgeDisplay { get; set; }

    [JsonPropertyName("unlock_show_text")]
    public string UnlockShowText { get; set; }

    [JsonPropertyName("unlock_show_color")]
    public string UnlockShowColor { get; set; }

    [JsonPropertyName("emoticon_unique")]
    public string EmoticonUnique { get; set; }
}

public class Exp
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("value")]
    public string Value { get; set; }
}

public class FollowCard
{
    [JsonPropertyName("card_text")]
    public string CardText { get; set; }

    [JsonPropertyName("show_time")]
    public int ShowTime { get; set; }

    [JsonPropertyName("card_type")]
    public int CardType { get; set; }

    [JsonPropertyName("rest_time")]
    public int RestTime { get; set; }

    [JsonPropertyName("delay_time")]
    public int DelayTime { get; set; }

    [JsonPropertyName("feed")]
    public int Feed { get; set; }

    [JsonPropertyName("attract_comment")]
    public int AttractComment { get; set; }

    [JsonPropertyName("share_room")]
    public int ShareRoom { get; set; }

    [JsonPropertyName("join_prophet")]
    public int JoinProphet { get; set; }

    [JsonPropertyName("send_dm")]
    public int SendDm { get; set; }

    [JsonPropertyName("at_least_time")]
    public int AtLeastTime { get; set; }

    [JsonPropertyName("click_like")]
    public int ClickLike { get; set; }
}

public class Frame
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("position")]
    public int Position { get; set; }

    [JsonPropertyName("value")]
    public string Value { get; set; }

    [JsonPropertyName("desc")]
    public string Desc { get; set; }
}

public class FunctionCard
{
    [JsonPropertyName("match_card")]
    public object MatchCard { get; set; }

    [JsonPropertyName("follow_card")]
    public FollowCard FollowCard { get; set; }

    [JsonPropertyName("forecast_card")]
    public object ForecastCard { get; set; }
}

public class GiftBanner
{
    [JsonPropertyName("img")]
    public List<object> Img { get; set; }

    [JsonPropertyName("interval")]
    public int Interval { get; set; }
}

public class GiftInfo
{
    [JsonPropertyName("price")]
    public int Price { get; set; }

    [JsonPropertyName("price_update_time")]
    public int PriceUpdateTime { get; set; }
}

public class GiftMemoryInfo
{
    [JsonPropertyName("list")]
    public object List { get; set; }
}

public class GiftStar
{
    [JsonPropertyName("display_widget_ab_group")]
    public int DisplayWidgetAbGroup { get; set; }
}

public class GiftStarProcess
{
    [JsonPropertyName("task_info")]
    public TaskInfo TaskInfo { get; set; }

    [JsonPropertyName("preload_timestamp")]
    public int PreloadTimestamp { get; set; }

    [JsonPropertyName("preload")]
    public bool Preload { get; set; }

    [JsonPropertyName("preload_task_info")]
    public object PreloadTaskInfo { get; set; }

    [JsonPropertyName("widget_bg")]
    public string WidgetBg { get; set; }

    [JsonPropertyName("jump_schema")]
    public string JumpSchema { get; set; }

    [JsonPropertyName("ab_group")]
    public int AbGroup { get; set; }
}

public class GuardBuyInfo
{
    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("duration")]
    public int Duration { get; set; }

    [JsonPropertyName("list")]
    public List<object> List { get; set; }
}

public class GuardInfo
{
    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("achievement_level")]
    public int AchievementLevel { get; set; }

    [JsonPropertyName("anchor_guard_achieve_level")]
    public int AnchorGuardAchieveLevel { get; set; }
}

public class GuideStatus
{
    [JsonPropertyName("guide_info")]
    public object GuideInfo { get; set; }
}

public class IconInfo
{
    [JsonPropertyName("show_red_dot")]
    public bool ShowRedDot { get; set; }

    [JsonPropertyName("bubble_uuid")]
    public int BubbleUuid { get; set; }

    [JsonPropertyName("bubble_last_time")]
    public int BubbleLastTime { get; set; }

    [JsonPropertyName("bubble_text")]
    public string BubbleText { get; set; }

    [JsonPropertyName("num")]
    public int Num { get; set; }

    [JsonPropertyName("num_ack_by_click")]
    public bool NumAckByClick { get; set; }
}

public class InteractionList
{
    [JsonPropertyName("biz_id")]
    public int BizId { get; set; }

    [JsonPropertyName("icon")]
    public string Icon { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("note")]
    public string Note { get; set; }

    [JsonPropertyName("weight")]
    public int Weight { get; set; }

    [JsonPropertyName("status_type")]
    public int StatusType { get; set; }

    [JsonPropertyName("notification")]
    public object Notification { get; set; }

    [JsonPropertyName("custom")]
    public object Custom { get; set; }

    [JsonPropertyName("jump_url")]
    public string JumpUrl { get; set; }

    [JsonPropertyName("type_id")]
    public int TypeId { get; set; }

    [JsonPropertyName("tab")]
    public object Tab { get; set; }

    [JsonPropertyName("dynamic_icon")]
    public string DynamicIcon { get; set; }

    [JsonPropertyName("sub_icon")]
    public string SubIcon { get; set; }

    [JsonPropertyName("panel_icon")]
    public string PanelIcon { get; set; }

    [JsonPropertyName("match_entrance")]
    public int MatchEntrance { get; set; }

    [JsonPropertyName("icon_info")]
    public IconInfo IconInfo { get; set; }

    [JsonPropertyName("common_type")]
    public int CommonType { get; set; }

    [JsonPropertyName("extra")]
    public object Extra { get; set; }
}

public class LiveRoomDetailyItem
{
    [JsonPropertyName("conf_id")]
    public int ConfId { get; set; }

    [JsonPropertyName("rank_name")]
    public string RankName { get; set; }

    [JsonPropertyName("uid")]
    public long Uid { get; set; }

    [JsonPropertyName("rank")]
    public int Rank { get; set; }

    [JsonPropertyName("icon_url_blue")]
    public string IconUrlBlue { get; set; }

    [JsonPropertyName("icon_url_pink")]
    public string IconUrlPink { get; set; }

    [JsonPropertyName("icon_url_grey")]
    public string IconUrlGrey { get; set; }

    [JsonPropertyName("jump_url_link")]
    public string JumpUrlLink { get; set; }

    [JsonPropertyName("jump_url_pc")]
    public string JumpUrlPc { get; set; }

    [JsonPropertyName("jump_url_pink")]
    public string JumpUrlPink { get; set; }

    [JsonPropertyName("jump_url_web")]
    public string JumpUrlWeb { get; set; }
}

public class LiveRoomDetailyItem2
{
    [JsonPropertyName("uid")]
    public long Uid { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("face")]
    public string Face { get; set; }

    [JsonPropertyName("rank")]
    public int Rank { get; set; }

    [JsonPropertyName("score")]
    public int Score { get; set; }

    [JsonPropertyName("medal_info")]
    public object MedalInfo { get; set; }

    [JsonPropertyName("guard_level")]
    public int GuardLevel { get; set; }

    [JsonPropertyName("wealth_level")]
    public int WealthLevel { get; set; }
}

public class LandScape
{
    [JsonPropertyName("valley")]
    public Valley Valley { get; set; }

    [JsonPropertyName("peak")]
    public Peak Peak { get; set; }

    [JsonPropertyName("proportion")]
    public int Proportion { get; set; }

    [JsonPropertyName("interval")]
    public int Interval { get; set; }

    [JsonPropertyName("min_time")]
    public int MinTime { get; set; }

    [JsonPropertyName("brush_count")]
    public int BrushCount { get; set; }

    [JsonPropertyName("slice_count")]
    public int SliceCount { get; set; }

    [JsonPropertyName("storage_time")]
    public int StorageTime { get; set; }

    [JsonPropertyName("is_hide_anti_brush")]
    public int IsHideAntiBrush { get; set; }
}

public class LikeInfoV3
{
    [JsonPropertyName("total_likes")]
    public int TotalLikes { get; set; }

    [JsonPropertyName("click_block")]
    public bool ClickBlock { get; set; }

    [JsonPropertyName("count_block")]
    public bool CountBlock { get; set; }

    [JsonPropertyName("guild_emo_text")]
    public string GuildEmoText { get; set; }

    [JsonPropertyName("guild_dm_text")]
    public string GuildDmText { get; set; }

    [JsonPropertyName("like_dm_text")]
    public string LikeDmText { get; set; }

    [JsonPropertyName("hand_icons")]
    public List<string> HandIcons { get; set; }

    [JsonPropertyName("dm_icons")]
    public List<string> DmIcons { get; set; }

    [JsonPropertyName("eggshells_icon")]
    public string EggshellsIcon { get; set; }

    [JsonPropertyName("count_show_time")]
    public int CountShowTime { get; set; }

    [JsonPropertyName("process_icon")]
    public string ProcessIcon { get; set; }

    [JsonPropertyName("process_color")]
    public string ProcessColor { get; set; }

    [JsonPropertyName("report_click_limit")]
    public int ReportClickLimit { get; set; }

    [JsonPropertyName("report_time_min")]
    public int ReportTimeMin { get; set; }

    [JsonPropertyName("report_time_max")]
    public int ReportTimeMax { get; set; }
}

public class LiveRoomDetailList
{
    [JsonPropertyName("uid")]
    public long Uid { get; set; }

    [JsonPropertyName("face")]
    public string Face { get; set; }

    [JsonPropertyName("uname")]
    public string Uname { get; set; }

    [JsonPropertyName("score")]
    public string Score { get; set; }

    [JsonPropertyName("rank")]
    public int Rank { get; set; }

    [JsonPropertyName("guard_level")]
    public int GuardLevel { get; set; }

    [JsonPropertyName("wealth_level")]
    public int WealthLevel { get; set; }
}

public class LiveInfo
{
    [JsonPropertyName("level")]
    public int Level { get; set; }

    [JsonPropertyName("level_color")]
    public int LevelColor { get; set; }
}

public class MedalInfo
{
    [JsonPropertyName("medal_name")]
    public string MedalName { get; set; }

    [JsonPropertyName("medal_id")]
    public int MedalId { get; set; }

    [JsonPropertyName("fansclub")]
    public int Fansclub { get; set; }
}

public class MultiVoice
{
    [JsonPropertyName("switch_status")]
    public int SwitchStatus { get; set; }

    [JsonPropertyName("members")]
    public List<object> Members { get; set; }

    [JsonPropertyName("mv_role")]
    public int MvRole { get; set; }

    [JsonPropertyName("seat_type")]
    public int SeatType { get; set; }

    [JsonPropertyName("invoking_time")]
    public int InvokingTime { get; set; }

    [JsonPropertyName("version")]
    public int Version { get; set; }

    [JsonPropertyName("pk")]
    public object Pk { get; set; }

    [JsonPropertyName("biz_session_id")]
    public string BizSessionId { get; set; }

    [JsonPropertyName("mode_details")]
    public object ModeDetails { get; set; }

    [JsonPropertyName("hat_list")]
    public object HatList { get; set; }
}

public class NewAreaRankInfo
{
    [JsonPropertyName("items")]
    public List<LiveRoomDetailyItem> Items { get; set; }

    [JsonPropertyName("rotation_cycle_time_web")]
    public int RotationCycleTimeWeb { get; set; }
}

public class NewSwitchInfo
{
    [JsonPropertyName("room-socket")]
    public int RoomSocket { get; set; }

    [JsonPropertyName("room-prop-send")]
    public int RoomPropSend { get; set; }

    [JsonPropertyName("room-sailing")]
    public int RoomSailing { get; set; }

    [JsonPropertyName("room-info-popularity")]
    public int RoomInfoPopularity { get; set; }

    [JsonPropertyName("room-danmaku-editor")]
    public int RoomDanmakuEditor { get; set; }

    [JsonPropertyName("room-effect")]
    public int RoomEffect { get; set; }

    [JsonPropertyName("room-fans_medal")]
    public int RoomFansMedal { get; set; }

    [JsonPropertyName("room-report")]
    public int RoomReport { get; set; }

    [JsonPropertyName("room-feedback")]
    public int RoomFeedback { get; set; }

    [JsonPropertyName("room-player-watermark")]
    public int RoomPlayerWatermark { get; set; }

    [JsonPropertyName("room-recommend-live_off")]
    public int RoomRecommendLiveOff { get; set; }

    [JsonPropertyName("room-activity")]
    public int RoomActivity { get; set; }

    [JsonPropertyName("room-super-chat")]
    public int RoomSuperChat { get; set; }

    [JsonPropertyName("room-interactive-panel")]
    public int RoomInteractivePanel { get; set; }

    [JsonPropertyName("room-player-recommend")]
    public int RoomPlayerRecommend { get; set; }

    [JsonPropertyName("sync-title-to-name")]
    public int SyncTitleToName { get; set; }

    [JsonPropertyName("room-hot-rank")]
    public int RoomHotRank { get; set; }

    [JsonPropertyName("guard-buy-notice")]
    public int GuardBuyNotice { get; set; }

    [JsonPropertyName("gift-batter-bar")]
    public int GiftBatterBar { get; set; }

    [JsonPropertyName("super-chat-effect")]
    public int SuperChatEffect { get; set; }

    [JsonPropertyName("flowing-free-gift-bar")]
    public int FlowingFreeGiftBar { get; set; }

    [JsonPropertyName("gift-gif-zoom")]
    public int GiftGifZoom { get; set; }

    [JsonPropertyName("fans-medal-progress")]
    public int FansMedalProgress { get; set; }

    [JsonPropertyName("gift-bay-screen")]
    public int GiftBayScreen { get; set; }

    [JsonPropertyName("room-enter")]
    public int RoomEnter { get; set; }

    [JsonPropertyName("fans-club")]
    public int FansClub { get; set; }

    [JsonPropertyName("anchor-card")]
    public int AnchorCard { get; set; }

    [JsonPropertyName("room-gift-panel-assets")]
    public int RoomGiftPanelAssets { get; set; }

    [JsonPropertyName("room-popular-rank")]
    public int RoomPopularRank { get; set; }

    [JsonPropertyName("mic_user_gift")]
    public int MicUserGift { get; set; }

    [JsonPropertyName("new-room-area-rank")]
    public int NewRoomAreaRank { get; set; }

    [JsonPropertyName("wealth_medal")]
    public int WealthMedal { get; set; }

    [JsonPropertyName("bubble")]
    public int Bubble { get; set; }

    [JsonPropertyName("title")]
    public int Title { get; set; }

    [JsonPropertyName("h-all")]
    public int HAll { get; set; }

    [JsonPropertyName("h-send-pay-gift")]
    public int HSendPayGift { get; set; }

    [JsonPropertyName("h-send-free-gift")]
    public int HSendFreeGift { get; set; }

    [JsonPropertyName("h-room-enter")]
    public int HRoomEnter { get; set; }

    [JsonPropertyName("h-subscribe-action")]
    public int HSubscribeAction { get; set; }

    [JsonPropertyName("h-share-action")]
    public int HShareAction { get; set; }

    [JsonPropertyName("h-other-action")]
    public int HOtherAction { get; set; }

    [JsonPropertyName("v-all")]
    public int VAll { get; set; }

    [JsonPropertyName("v-send-pay-gift")]
    public int VSendPayGift { get; set; }

    [JsonPropertyName("v-send-free-gift")]
    public int VSendFreeGift { get; set; }

    [JsonPropertyName("v-room-enter")]
    public int VRoomEnter { get; set; }

    [JsonPropertyName("v-subscribe-action")]
    public int VSubscribeAction { get; set; }

    [JsonPropertyName("v-share-action")]
    public int VShareAction { get; set; }

    [JsonPropertyName("v-other-action")]
    public int VOtherAction { get; set; }

    [JsonPropertyName("v-gift-batter-bar")]
    public int VGiftBatterBar { get; set; }

    [JsonPropertyName("room_rank_rearrange")]
    public int RoomRankRearrange { get; set; }
}

public class NewTabInfo
{
    [JsonPropertyName("setting_list")]
    public List<SettingList> SettingList { get; set; }

    [JsonPropertyName("interaction_list")]
    public List<InteractionList> InteractionList { get; set; }

    [JsonPropertyName("is_fixed")]
    public int IsFixed { get; set; }

    [JsonPropertyName("outer_list")]
    public List<OuterList> OuterList { get; set; }

    [JsonPropertyName("is_match")]
    public int IsMatch { get; set; }

    [JsonPropertyName("match_cristina")]
    public string MatchCristina { get; set; }

    [JsonPropertyName("match_icon")]
    public string MatchIcon { get; set; }

    [JsonPropertyName("match_experiment")]
    public int MatchExperiment { get; set; }

    [JsonPropertyName("panel_data")]
    public object PanelData { get; set; }

    [JsonPropertyName("match_bg_image")]
    public string MatchBgImage { get; set; }

    [JsonPropertyName("entrance_guide_blacklist")]
    public int EntranceGuideBlacklist { get; set; }

    [JsonPropertyName("exps")]
    public List<Exp> Exps { get; set; }
}

public class OfficialInfo
{
    [JsonPropertyName("role")]
    public int Role { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("desc")]
    public string Desc { get; set; }
}

public class OnlineGoldRankInfoV2
{
    [JsonPropertyName("list")]
    public List<LiveRoomDetailList> List { get; set; }

    [JsonPropertyName("count")]
    public int Count { get; set; }
}

public class OuterList
{
    [JsonPropertyName("biz_id")]
    public int BizId { get; set; }

    [JsonPropertyName("icon")]
    public string Icon { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("note")]
    public string Note { get; set; }

    [JsonPropertyName("weight")]
    public int Weight { get; set; }

    [JsonPropertyName("status_type")]
    public int StatusType { get; set; }

    [JsonPropertyName("notification")]
    public object Notification { get; set; }

    [JsonPropertyName("custom")]
    public List<Custom> Custom { get; set; }

    [JsonPropertyName("jump_url")]
    public string JumpUrl { get; set; }

    [JsonPropertyName("type_id")]
    public int TypeId { get; set; }

    [JsonPropertyName("tab")]
    public object Tab { get; set; }

    [JsonPropertyName("dynamic_icon")]
    public string DynamicIcon { get; set; }

    [JsonPropertyName("sub_icon")]
    public string SubIcon { get; set; }

    [JsonPropertyName("panel_icon")]
    public string PanelIcon { get; set; }

    [JsonPropertyName("match_entrance")]
    public int MatchEntrance { get; set; }

    [JsonPropertyName("icon_info")]
    public object IconInfo { get; set; }

    [JsonPropertyName("common_type")]
    public int CommonType { get; set; }

    [JsonPropertyName("extra")]
    public object Extra { get; set; }
}

public class Peak
{
    [JsonPropertyName("consumetime")]
    public int Consumetime { get; set; }

    [JsonPropertyName("consumecount")]
    public int Consumecount { get; set; }

    [JsonPropertyName("animationtime")]
    public int Animationtime { get; set; }
}

public class PendantBanner
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("cover")]
    public string Cover { get; set; }

    [JsonPropertyName("tip_text")]
    public string TipText { get; set; }

    [JsonPropertyName("tip_text_color")]
    public string TipTextColor { get; set; }

    [JsonPropertyName("tip_bottom_color")]
    public string TipBottomColor { get; set; }

    [JsonPropertyName("jump_url")]
    public string JumpUrl { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("weight")]
    public int Weight { get; set; }

    [JsonPropertyName("stay_time")]
    public int StayTime { get; set; }

    [JsonPropertyName("type")]
    public int Type { get; set; }
}

public class Pendants
{
    [JsonPropertyName("frame")]
    public Frame Frame { get; set; }

    [JsonPropertyName("badge")]
    public object Badge { get; set; }
}

public class PlayTogetherInfo
{
    [JsonPropertyName("status")]
    public int Status { get; set; }
}

public class PopularRankInfo
{
    [JsonPropertyName("rank")]
    public int Rank { get; set; }

    [JsonPropertyName("countdown")]
    public int Countdown { get; set; }

    [JsonPropertyName("timestamp")]
    public int Timestamp { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("on_rank_name")]
    public string OnRankName { get; set; }

    [JsonPropertyName("rank_name")]
    public string RankName { get; set; }
}

public class PostPanel
{
    [JsonPropertyName("click_button")]
    public ClickButton ClickButton { get; set; }

    [JsonPropertyName("post_status")]
    public int PostStatus { get; set; }
}

public class ProactiveBanner
{
    [JsonPropertyName("fliping_interval")]
    public int FlipingInterval { get; set; }

    [JsonPropertyName("list")]
    public List<object> List { get; set; }
}

public class ProcessList
{
    [JsonPropertyName("gift_id")]
    public int GiftId { get; set; }

    [JsonPropertyName("gift_img")]
    public string GiftImg { get; set; }

    [JsonPropertyName("gift_name")]
    public string GiftName { get; set; }

    [JsonPropertyName("completed_num")]
    public int CompletedNum { get; set; }

    [JsonPropertyName("target_num")]
    public int TargetNum { get; set; }
}

public class ProgressForWidget
{
    [JsonPropertyName("gift_star_process")]
    public GiftStarProcess GiftStarProcess { get; set; }

    [JsonPropertyName("wish_process")]
    public object WishProcess { get; set; }
}

public class RelationInfo
{
    [JsonPropertyName("attention")]
    public int Attention { get; set; }
}

public class ReserveInfo
{
    [JsonPropertyName("button_color")]
    public int ButtonColor { get; set; }

    [JsonPropertyName("show_reserve_status")]
    public bool ShowReserveStatus { get; set; }
}

public class RevenueBanner
{
    [JsonPropertyName("fliping_interval")]
    public int FlipingInterval { get; set; }

    [JsonPropertyName("list")]
    public List<object> List { get; set; }
}

public class RevenueDemotion
{
    [JsonPropertyName("global_gift_config_demotion")]
    public bool GlobalGiftConfigDemotion { get; set; }

    [JsonPropertyName("gift_break_up_request_min")]
    public int GiftBreakUpRequestMin { get; set; }

    [JsonPropertyName("gift_break_up_request_max")]
    public int GiftBreakUpRequestMax { get; set; }
}

public class RevenueMaterialMd5
{
    [JsonPropertyName("wealth")]
    public string Wealth { get; set; }
}

public class RoomConfigInfo
{
    [JsonPropertyName("dm_text")]
    public string DmText { get; set; }

    [JsonPropertyName("post_panel")]
    public PostPanel PostPanel { get; set; }
}

public class RoomInfo
{
    [JsonPropertyName("uid")]
    public long Uid { get; set; }

    [JsonPropertyName("room_id")]
    public int RoomId { get; set; }

    [JsonPropertyName("short_id")]
    public int ShortId { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("cover")]
    public string Cover { get; set; }

    [JsonPropertyName("tags")]
    public string Tags { get; set; }

    [JsonPropertyName("background")]
    public string Background { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("online")]
    public int Online { get; set; }

    [JsonPropertyName("live_status")]
    public int LiveStatus { get; set; }

    [JsonPropertyName("live_start_time")]
    public int LiveStartTime { get; set; }

    [JsonPropertyName("live_screen_type")]
    public int LiveScreenType { get; set; }

    [JsonPropertyName("lock_status")]
    public int LockStatus { get; set; }

    [JsonPropertyName("lock_time")]
    public int LockTime { get; set; }

    [JsonPropertyName("hidden_status")]
    public int HiddenStatus { get; set; }

    [JsonPropertyName("hidden_time")]
    public int HiddenTime { get; set; }

    [JsonPropertyName("area_id")]
    public int AreaId { get; set; }

    [JsonPropertyName("area_name")]
    public string AreaName { get; set; }

    [JsonPropertyName("parent_area_id")]
    public int ParentAreaId { get; set; }

    [JsonPropertyName("parent_area_name")]
    public string ParentAreaName { get; set; }

    [JsonPropertyName("keyframe")]
    public string Keyframe { get; set; }

    [JsonPropertyName("special_type")]
    public int SpecialType { get; set; }

    [JsonPropertyName("up_session")]
    public string UpSession { get; set; }

    [JsonPropertyName("pk_status")]
    public int PkStatus { get; set; }

    [JsonPropertyName("pendants")]
    public Pendants Pendants { get; set; }

    [JsonPropertyName("on_voice_join")]
    public int OnVoiceJoin { get; set; }

    [JsonPropertyName("tv_screen_on")]
    public int TvScreenOn { get; set; }

    [JsonPropertyName("room_type")]
    public RoomType RoomType { get; set; }

    [JsonPropertyName("sub_session_key")]
    public string SubSessionKey { get; set; }

    [JsonPropertyName("live_model")]
    public int LiveModel { get; set; }

    [JsonPropertyName("live_platform")]
    public string LivePlatform { get; set; }

    [JsonPropertyName("voice_background")]
    public string VoiceBackground { get; set; }

    [JsonPropertyName("app_background")]
    public string AppBackground { get; set; }

    [JsonPropertyName("anchor_content")]
    public string AnchorContent { get; set; }

    [JsonPropertyName("content_is_open")]
    public bool ContentIsOpen { get; set; }

    [JsonPropertyName("tv_screen_float_on")]
    public int TvScreenFloatOn { get; set; }

    [JsonPropertyName("room_news")]
    public RoomNews RoomNews { get; set; }

    [JsonPropertyName("official_room_info")]
    public object OfficialRoomInfo { get; set; }

    [JsonPropertyName("official_room_id")]
    public int OfficialRoomId { get; set; }
}

public class RoomNews
{
    [JsonPropertyName("news_content")]
    public string NewsContent { get; set; }

    [JsonPropertyName("news_type")]
    public int NewsType { get; set; }

    [JsonPropertyName("news_page")]
    public string NewsPage { get; set; }

    [JsonPropertyName("content_is_open")]
    public bool ContentIsOpen { get; set; }

    [JsonPropertyName("icon")]
    public string Icon { get; set; }
}

public class RoomRankInfo
{
    [JsonPropertyName("anchor_rank_entry")]
    public object AnchorRankEntry { get; set; }

    [JsonPropertyName("user_rank_entry")]
    public UserRankEntry UserRankEntry { get; set; }

    [JsonPropertyName("user_rank_tab_list")]
    public UserRankTabList UserRankTabList { get; set; }
}

public class RoomType
{
    [JsonPropertyName("3-21")]
    public int _321 { get; set; }

    [JsonPropertyName("3-50")]
    public int _350 { get; set; }
}

public class SettingList
{
    [JsonPropertyName("biz_id")]
    public int BizId { get; set; }

    [JsonPropertyName("icon")]
    public string Icon { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("note")]
    public string Note { get; set; }

    [JsonPropertyName("weight")]
    public double Weight { get; set; }

    [JsonPropertyName("status_type")]
    public int StatusType { get; set; }

    [JsonPropertyName("notification")]
    public object Notification { get; set; }

    [JsonPropertyName("custom")]
    public object Custom { get; set; }

    [JsonPropertyName("jump_url")]
    public string JumpUrl { get; set; }

    [JsonPropertyName("type_id")]
    public int TypeId { get; set; }

    [JsonPropertyName("tab")]
    public object Tab { get; set; }

    [JsonPropertyName("dynamic_icon")]
    public string DynamicIcon { get; set; }

    [JsonPropertyName("sub_icon")]
    public string SubIcon { get; set; }

    [JsonPropertyName("panel_icon")]
    public string PanelIcon { get; set; }

    [JsonPropertyName("match_entrance")]
    public int MatchEntrance { get; set; }

    [JsonPropertyName("icon_info")]
    public object IconInfo { get; set; }

    [JsonPropertyName("common_type")]
    public int CommonType { get; set; }

    [JsonPropertyName("extra")]
    public object Extra { get; set; }
}

public class ShoppingInfo
{
    [JsonPropertyName("is_show")]
    public int IsShow { get; set; }
}

public class SkinInfo
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("skin_config")]
    public string SkinConfig { get; set; }

    [JsonPropertyName("start_time")]
    public int StartTime { get; set; }

    [JsonPropertyName("end_time")]
    public int EndTime { get; set; }

    [JsonPropertyName("current_time")]
    public int CurrentTime { get; set; }

    [JsonPropertyName("only_local")]
    public bool OnlyLocal { get; set; }
}

public class SubTab
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("desc")]
    public string Desc { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("status")]
    public int Status { get; set; }

    [JsonPropertyName("order")]
    public int Order { get; set; }

    [JsonPropertyName("documents")]
    public string Documents { get; set; }

    [JsonPropertyName("rank_name")]
    public string RankName { get; set; }

    [JsonPropertyName("default_sub_tab")]
    public string DefaultSubTab { get; set; }

    [JsonPropertyName("grand_tab")]
    public List<object> GrandTab { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("default")]
    public int Default { get; set; }

    [JsonPropertyName("comment")]
    public string Comment { get; set; }

    [JsonPropertyName("desc_url")]
    public string DescUrl { get; set; }

    [JsonPropertyName("switch")]
    public List<Switch> Switch { get; set; }

    [JsonPropertyName("sub_tab")]
    public object SubTabData { get; set; }
}

public class SuperChat
{
    [JsonPropertyName("status")]
    public int Status { get; set; }

    [JsonPropertyName("jump_url")]
    public string JumpUrl { get; set; }

    [JsonPropertyName("icon")]
    public string Icon { get; set; }

    [JsonPropertyName("ranked_mark")]
    public int RankedMark { get; set; }

    [JsonPropertyName("message_list")]
    public List<object> MessageList { get; set; }
}

public class Switch
{
    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("switch")]
    public string SwitchData { get; set; }

    [JsonPropertyName("ui_type")]
    public UiType UiType { get; set; }

    [JsonPropertyName("comment")]
    public string Comment { get; set; }
}

public class SwitchInfo
{
    [JsonPropertyName("close_guard")]
    public bool CloseGuard { get; set; }

    [JsonPropertyName("close_gift")]
    public bool CloseGift { get; set; }

    [JsonPropertyName("close_online")]
    public bool CloseOnline { get; set; }
}

public class Tab
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("status")]
    public int Status { get; set; }

    [JsonPropertyName("default")]
    public int Default { get; set; }

    [JsonPropertyName("comment")]
    public string Comment { get; set; }

    [JsonPropertyName("desc_url")]
    public string DescUrl { get; set; }

    [JsonPropertyName("switch")]
    public object Switch { get; set; }

    [JsonPropertyName("sub_tab")]
    public List<SubTab> SubTab { get; set; }
}

public class TabInfo
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("desc")]
    public string Desc { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("status")]
    public int Status { get; set; }

    [JsonPropertyName("order")]
    public int Order { get; set; }

    [JsonPropertyName("documents")]
    public string Documents { get; set; }

    [JsonPropertyName("default")]
    public int Default { get; set; }

    [JsonPropertyName("default_sub_tab")]
    public string DefaultSubTab { get; set; }

    [JsonPropertyName("sub_tab")]
    public List<SubTab> SubTab { get; set; }

    [JsonPropertyName("roomid")]
    public int Roomid { get; set; }

    [JsonPropertyName("comment_type_id")]
    public int CommentTypeId { get; set; }

    [JsonPropertyName("comment_business_id")]
    public int CommentBusinessId { get; set; }
}

public class TaskInfo
{
    [JsonPropertyName("start_date")]
    public int StartDate { get; set; }

    [JsonPropertyName("process_list")]
    public List<ProcessList> ProcessList { get; set; }

    [JsonPropertyName("finished")]
    public bool Finished { get; set; }

    [JsonPropertyName("ddl_timestamp")]
    public int DdlTimestamp { get; set; }

    [JsonPropertyName("version")]
    public long Version { get; set; }

    [JsonPropertyName("reward_gift")]
    public int RewardGift { get; set; }

    [JsonPropertyName("reward_gift_img")]
    public string RewardGiftImg { get; set; }

    [JsonPropertyName("reward_gift_name")]
    public string RewardGiftName { get; set; }
}

public class TopicInfo
{
    [JsonPropertyName("topic_id")]
    public int TopicId { get; set; }

    [JsonPropertyName("topic_name")]
    public string TopicName { get; set; }
}

public class TopicRoomInfo
{
    [JsonPropertyName("interactive_h5_url")]
    public string InteractiveH5Url { get; set; }

    [JsonPropertyName("watermark")]
    public int Watermark { get; set; }
}

public class UiType
{
    [JsonPropertyName("op_button_text")]
    public int OpButtonText { get; set; }

    [JsonPropertyName("rank_prefix")]
    public int RankPrefix { get; set; }

    [JsonPropertyName("refresh_entry")]
    public int RefreshEntry { get; set; }

    [JsonPropertyName("show_score")]
    public int ShowScore { get; set; }
}

public class UserContributionRankEntry
{
    [JsonPropertyName("item")]
    public List<LiveRoomDetailyItem> LiveRoomDetailyItem { get; set; }

    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("show_max")]
    public int ShowMax { get; set; }
}

public class UserRankEntry
{
    [JsonPropertyName("user_contribution_rank_entry")]
    public UserContributionRankEntry UserContributionRankEntry { get; set; }
}

public class UserRankTabList
{
    [JsonPropertyName("tab")]
    public List<Tab> Tab { get; set; }
}

public class Valley
{
    [JsonPropertyName("consumetime")]
    public int Consumetime { get; set; }

    [JsonPropertyName("consumecount")]
    public int Consumecount { get; set; }

    [JsonPropertyName("animationtime")]
    public int Animationtime { get; set; }
}

public class Verticalscreen
{
    [JsonPropertyName("valley")]
    public Valley Valley { get; set; }

    [JsonPropertyName("peak")]
    public Peak Peak { get; set; }

    [JsonPropertyName("proportion")]
    public int Proportion { get; set; }

    [JsonPropertyName("interval")]
    public int Interval { get; set; }

    [JsonPropertyName("min_time")]
    public int MinTime { get; set; }

    [JsonPropertyName("brush_count")]
    public int BrushCount { get; set; }

    [JsonPropertyName("slice_count")]
    public int SliceCount { get; set; }

    [JsonPropertyName("storage_time")]
    public int StorageTime { get; set; }

    [JsonPropertyName("is_hide_anti_brush")]
    public int IsHideAntiBrush { get; set; }
}

public class VocieJoinColumns
{
    [JsonPropertyName("icon_close")]
    public string IconClose { get; set; }

    [JsonPropertyName("icon_open")]
    public string IconOpen { get; set; }

    [JsonPropertyName("icon_wait")]
    public string IconWait { get; set; }

    [JsonPropertyName("icon_starting")]
    public string IconStarting { get; set; }
}

public class VoiceJoin
{
    [JsonPropertyName("voice_join_open")]
    public int VoiceJoinOpen { get; set; }

    [JsonPropertyName("voice_join_status")]
    public VoiceJoinStatus VoiceJoinStatus { get; set; }

    [JsonPropertyName("vocie_join_columns")]
    public VocieJoinColumns VocieJoinColumns { get; set; }
}

public class VoiceJoinStatus
{
    [JsonPropertyName("room_status")]
    public int RoomStatus { get; set; }

    [JsonPropertyName("status")]
    public int Status { get; set; }

    [JsonPropertyName("uid")]
    public long Uid { get; set; }

    [JsonPropertyName("user_name")]
    public string UserName { get; set; }

    [JsonPropertyName("head_pic")]
    public string HeadPic { get; set; }

    [JsonPropertyName("guard")]
    public int Guard { get; set; }

    [JsonPropertyName("room_id")]
    public int RoomId { get; set; }

    [JsonPropertyName("start_at")]
    public int StartAt { get; set; }

    [JsonPropertyName("current_time")]
    public int CurrentTime { get; set; }
}

public class XtemplateConfig
{
    [JsonPropertyName("dm_speed_info")]
    public DmSpeedInfo DmSpeedInfo { get; set; }

    [JsonPropertyName("dm_brush_info")]
    public DmBrushInfo DmBrushInfo { get; set; }

    [JsonPropertyName("dm_pool_info")]
    public DmPoolInfo DmPoolInfo { get; set; }

    [JsonPropertyName("dm_voice_info")]
    public DmVoiceInfo DmVoiceInfo { get; set; }

    [JsonPropertyName("dm_emoticon_info")]
    public DmEmoticonInfo DmEmoticonInfo { get; set; }

    [JsonPropertyName("dm_tag_info")]
    public DmTagInfo DmTagInfo { get; set; }

    [JsonPropertyName("dm_mu_ku_type")]
    public DmMuKuType DmMuKuType { get; set; }
}
