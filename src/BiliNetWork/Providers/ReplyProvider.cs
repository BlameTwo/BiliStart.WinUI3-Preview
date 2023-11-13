using Bilibili.Main.Community.Reply.V1;
using Network.Models.Community;

namespace BiliNetWork.Providers;

public class ReplyProvider : IReplyProvider
{
    public ReplyProvider(
        IRequestMessage requestMessage,
        IHttpClientProvider httpClientProvider,
        ICurrent current,
        IBIliDocument bIliDocument,
        IBiliDataViewModelConverter biliDataViewModelConverter
    )
    {
        RequestMessage = requestMessage;
        HttpClientProvider = httpClientProvider;
        Current = current;
        BIliDocument = bIliDocument;
        BiliDataViewModelConverter = biliDataViewModelConverter;
    }

    public IRequestMessage RequestMessage { get; }
    public IHttpClientProvider HttpClientProvider { get; }
    public ICurrent Current { get; }
    public IBIliDocument BIliDocument { get; }
    public IBiliDataViewModelConverter BiliDataViewModelConverter { get; }

    public async Task<MainReplyList> GetReplyListAsync(
        long aid,
        long Next = 0,
        ReplyOrderEnum order = ReplyOrderEnum.Hot,
        CommentType type = CommentType.Video,
        CancellationToken canceltoken = default
    )
    {
        if (aid == 0)
            return default;
        var cursorReq = new Bilibili.Main.Community.Reply.V1.CursorReq();
        cursorReq.Mode =
            order == ReplyOrderEnum.Time
                ? Mode.MainListTime
                : order == ReplyOrderEnum.Hot
                    ? Mode.MainListHot
                    : Mode.Default;
        cursorReq.Next = Next;
        Bilibili.Main.Community.Reply.V1.MainListReq req =
            new()
            {
                Oid = aid,
                Cursor = cursorReq,
                Rpid = 0,
                Type = (int)type
            };
        var result = await HttpClientProvider.SendAsync(
            await RequestMessage.GetHttpRequestMessageAsync(Apis.REPLY_MAIN, req)
        );
        var reply = await BIliDocument.ParseMessageAsync(
            result,
            Bilibili.Main.Community.Reply.V1.MainListReply.Parser
        );
        return await BiliDataViewModelConverter.ConverterToReply(reply);
    }

    public async Task<CommentReplyList> GetReplyCommentAsync(
        RepliesItemBase _replies,
        long Next = 0,
        ReplyOrderEnum order = ReplyOrderEnum.Hot,
        CommentType type = CommentType.Video,
        CancellationToken canceltoken = default
    )
    {
        var cursorReq = new Bilibili.Main.Community.Reply.V1.CursorReq();
        cursorReq.Mode =
            order == ReplyOrderEnum.Time
                ? Mode.MainListTime
                : order == ReplyOrderEnum.Hot
                    ? Mode.MainListHot
                    : Mode.Default;
        cursorReq.Next = Next;
        Bilibili.Main.Community.Reply.V1.DetailListReq req =
            new()
            {
                Oid = _replies.Oid,
                Cursor = cursorReq,
                Root = _replies.Rpid,
                Scene = DetailListScene.Reply,
                Type = (int)type
            };
        var result = await HttpClientProvider.SendAsync(
            await RequestMessage.GetHttpRequestMessageAsync(Apis.REPLY_Detail, req)
        );
        var reply = await BIliDocument.ParseMessageAsync(
            result,
            Bilibili.Main.Community.Reply.V1.DetailListReply.Parser
        );
        return await BiliDataViewModelConverter.ConverterCommentReply(reply);
    }

    public async Task<ResultCode<LikeReplyResult>> LikeReplyAsync(
        bool islike,
        long oid,
        long rpid,
        CommentType type,
        CancellationToken canceltoken = default
    )
    {
        var values = new Dictionary<string, string>
        {
            { "oid", oid.ToString() },
            { "action", islike ? "1" : "0" },
            { "rpid", rpid.ToString() },
            { "type", ((int)type).ToString() },
        };
        var request = await RequestMessage.GetHttpRequestMessageAsync(
            Apis.LIKE_REPLY,
            RequestType.IOS,
            HttpMethod.Post,
            values,
            true,
            false,
            true
        );
        var response = await HttpClientProvider.SendAsync(request);
        var jsonobj = await BIliDocument.CheckDataCode<LikeReplyResult>(request, response);
        if (jsonobj.Code == 0)
            jsonobj.Data.IsFlage = true;
        return jsonobj;
    }
}
