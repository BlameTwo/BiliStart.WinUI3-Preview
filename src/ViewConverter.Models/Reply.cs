using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Network.Models.Enum;
using ViewConverter.Models.Messager;

namespace ViewConverter.Models;

public partial class MainReplyList
{
    /// <summary>
    /// 下一页游标
    /// </summary>
    public long Next { get; set; }

    public string Title { get; set; }

    /// <summary>
    /// 是否为开始
    /// </summary>
    public bool IsBegin { get; set; }

    public long Prev { get; set; }

    /// <summary>
    /// 提示文本
    /// </summary>
    public string TipText { get; set; }

    /// <summary>
    /// 总数
    /// </summary>
    public long Count { get; set; }

    /// <summary>
    /// 评论
    /// </summary>
    public List<RepliesItem> Replies { get; set; }
}

public class RepliesItem : RepliesItemBase
{
    public List<RepliesItemBase> Replies { get; set; }
}

public partial class RepliesItemBase
{
    public long Rpid { get; set; }

    public long Oid { get; set; }

    public long Type { get; set; }

    public long UpMid { get; set; }

    public long PublishTime { get; set; }

    public long Like { get; set; }

    public long Count { get; set; }

    public ReplyContent ReplyContent { get; set; }

    public CommentType CommandType { get; set; }

    public ReplyUp ReplyUp { get; set; }

    public ReplyControl ReplyControl { get; set; }
}

public class ReplyUp
{
    public long Mid { get; set; }

    public string Name { get; set; }

    public string SexString { get; set; }

    public string Face { get; set; }

    public long VipType { get; set; }

    public long OffcialType { get; set; }
}

/// <summary>
/// 评论内容
/// </summary>
public class ReplyContent
{
    /// <summary>
    /// 评论附带图片
    /// </summary>
    public List<ReplyEmoteItem> EmoteItems { get; set; }

    public List<ReplyUrlItem> UrlItems { get; set; }

    /// <summary>
    /// @到的用户
    /// </summary>
    public List<Tuple<string, ReplyUp>> AltUp { get; set; }

    public string Message { get; set; }
}

/// <summary>
/// 回复中的超链接
/// </summary>
public class ReplyUrlItem
{
    public string Text { get; set; }

    public string IconSource { get; set; }

    public string Keyword { get; set; }
}

public class ReplyEmoteItem
{
    public string Name { get; set; }
    public long Size { get; set; }

    public string Url { get; set; }
}

public class ReplyControl
{
    public bool IsUpLike { get; set; }

    public bool IsUpReply { get; set; }

    public bool IsLike { get; set; }
}

public class CommentReplyList
{
    public long Next { get; set; }

    public bool IsBegin { get; set; }

    public Bilibili.Main.Community.Reply.V1.Mode Type { get; set; }

    public RepliesItem Main { get; set; }
}
