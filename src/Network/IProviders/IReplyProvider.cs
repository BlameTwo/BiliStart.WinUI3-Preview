using Network.Models.Community;
using Network.Models;
using Network.Models.Enum;
using ViewConverter.Models;

namespace INetwork.IProviders;

public interface IReplyProvider
{
    Task<MainReplyList> GetReplyListAsync(
        long aid,
        long Next = 0,
        ReplyOrderEnum order = ReplyOrderEnum.Hot,
        CommentType type = CommentType.Video,
        CancellationToken canceltoken = default
    );

    Task<CommentReplyList> GetReplyCommentAsync(
        RepliesItemBase _replies,
        long Next = 0,
        ReplyOrderEnum order = ReplyOrderEnum.Hot,
        CommentType type = CommentType.Video,
        CancellationToken canceltoken = default
    );

    Task<ResultCode<LikeReplyResult>> LikeReplyAsync(
        bool islike,
        long oid,
        long rpid,
        CommentType type,
        CancellationToken canceltoken = default
    );
}
