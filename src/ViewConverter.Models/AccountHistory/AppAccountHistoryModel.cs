using Bilibili.App.Interface.V1;

namespace ViewConverter.Models.AccountHistory;

public class AccountVideoHistoryModel
{
    public Cursor Cursor { get; set; }

    public List<AccountVideoHistoryItem> Videos { get; set; }

    public List<AccountLiveHistoryItem> Lives { get; set; }
}

/// <summary>
/// 视频历史记录
/// </summary>
public class AccountVideoHistoryItem: AccountVideoHistoryItemBase
{
    public long Aid { get; set; }
    public string Bvid { get; set; }

    public long Cid { get; set; }

    public string Title { get; set; }

    public long Duration { get; set; }

    public string ShareUrl { get; set; }

    public long View { get; set; }

    public string Cover { get; set; }

    public long Progress { get; set; }


    public string UpName { get; set; }

    public long UpMid { get; set; }

    /// <summary>
    /// 1视频，2直播，3专栏
    /// </summary>
    public int Type { get; set; }
}

/// <summary>
/// 基类
/// </summary>
public class AccountVideoHistoryItemBase
{
    /// <summary>
    /// 观看时间
    /// </summary>
    public DateTime ViewTime { get; set; }

    public HistoryDt Dt { get; set; }
}

/// <summary>
/// 观看设备
/// </summary>
public class HistoryDt
{
    public Bilibili.App.Interface.V1.DT Type { get; set; }

    public string Icon { get; set; }
}

public class AccountLiveHistoryItem: AccountVideoHistoryItemBase
{
    public long RoomId { get; set; }
    public string Title { get; set; }

    public long UpMid { get; set; }
    
    public string UpName { get; set; }

    public string Tag { get; set; }

    public string Cover { get; set; }
}

