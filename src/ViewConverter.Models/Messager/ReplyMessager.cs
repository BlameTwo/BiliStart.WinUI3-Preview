using Network.Models.Enum;

namespace ViewConverter.Models.Messager
{
    /// <summary>
    /// 视频评论的点赞请求消息
    /// </summary>
    /// <param name="islike"></param>
    /// <param name="id">Rpid</param>
    public record PlayerReplyLikeRequestMessager(
        long oid,
        long rpid,
        bool islike,
        CommentType type
    );

    /// <summary>
    /// 视频评论的点赞返回消息
    /// </summary>
    /// <param name="result"></param>
    /// <param name="id">Rpid</param>
    public record PlayerReplyLikeReponseMessager(long id, long rpid);
}
