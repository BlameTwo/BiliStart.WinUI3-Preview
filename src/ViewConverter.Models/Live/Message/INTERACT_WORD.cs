using Network.Models.Enum;
using Network.Models.Live;
using System.Text.Json.Serialization;

namespace ViewConverter.Models.Live.Message;

/// <summary>
/// 进房消息
/// </summary>
public class INTERACT_WORD : ILiveMessageModel
{
    [JsonPropertyName("uid")]
    public long Uid { get; set; }

    [JsonPropertyName("uname")]
    public string Uname { get; set; }

    [JsonPropertyName("uname_color")]
    public string UnameColor { get; set; }

    [JsonPropertyName("identities")]
    public List<int> Identities { get; set; }

    [JsonPropertyName("msg_type")]
    public int MsgType { get; set; }

    [JsonPropertyName("roomid")]
    public int Roomid { get; set; }

    [JsonPropertyName("timestamp")]
    public int Timestamp { get; set; }

    [JsonPropertyName("score")]
    public long Score { get; set; }

    [JsonPropertyName("fans_medal")]
    public FansMedal FansMedal { get; set; }

    [JsonPropertyName("is_spread")]
    public int IsSpread { get; set; }

    [JsonPropertyName("spread_info")]
    public string SpreadInfo { get; set; }

    [JsonPropertyName("contribution")]
    public Contribution Contribution { get; set; }

    [JsonPropertyName("spread_desc")]
    public string SpreadDesc { get; set; }

    [JsonPropertyName("tail_icon")]
    public int TailIcon { get; set; }

    [JsonPropertyName("trigger_time")]
    public long TriggerTime { get; set; }

    [JsonPropertyName("privilege_type")]
    public int PrivilegeType { get; set; }

    [JsonPropertyName("core_user_type")]
    public int CoreUserType { get; set; }

    [JsonPropertyName("tail_text")]
    public string TailText { get; set; }

    [JsonPropertyName("contribution_v2")]
    public ContributionV2 ContributionV2 { get; set; }

    [JsonIgnore]
    public LiveMessageType MessageType => LiveMessageType.UserGoRoom;
}

public class Contribution
{
    [JsonPropertyName("grade")]
    public int Grade { get; set; }
}

public class ContributionV2
{
    [JsonPropertyName("grade")]
    public int Grade { get; set; }

    [JsonPropertyName("rank_type")]
    public string RankType { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; }
}

public class FansMedal
{
    [JsonPropertyName("target_id")]
    public long TargetId { get; set; }

    [JsonPropertyName("medal_level")]
    public int MedalLevel { get; set; }

    [JsonPropertyName("medal_name")]
    public string MedalName { get; set; }

    [JsonPropertyName("medal_color")]
    public int MedalColor { get; set; }

    [JsonPropertyName("medal_color_start")]
    public int MedalColorStart { get; set; }

    [JsonPropertyName("medal_color_end")]
    public int MedalColorEnd { get; set; }

    [JsonPropertyName("medal_color_border")]
    public int MedalColorBorder { get; set; }

    [JsonPropertyName("is_lighted")]
    public int IsLighted { get; set; }

    [JsonPropertyName("guard_level")]
    public int GuardLevel { get; set; }

    [JsonPropertyName("special")]
    public string Special { get; set; }

    [JsonPropertyName("icon_id")]
    public int IconId { get; set; }

    [JsonPropertyName("anchor_roomid")]
    public int AnchorRoomid { get; set; }

    [JsonPropertyName("score")]
    public int Score { get; set; }
}
