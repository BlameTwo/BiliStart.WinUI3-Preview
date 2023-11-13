using Bilibili.Community.Service.Dm.V1;
using Network.Models.ThirdApi;
using ViewConverter.Models;
using ViewConverter.Models.ServiceData;

namespace ViewConverter;

public class BiliDataViewModelConverter : IBiliDataViewModelConverter
{
    public async Task<CommentReplyList> ConverterCommentReply(DetailListReply reply)
    {
        return await Task.Run(() =>
        {
            var result = new CommentReplyList()
            {
                Next = reply.Cursor.Next,
                IsBegin = reply.Cursor.IsBegin,
                Type = reply.Cursor.Mode,
                Main = GetCommentReplyMain(reply),
            };
            return result;
        });
    }

    public async Task<MainReplyList> ConverterToReply(MainListReply reply)
    {
        return await Task.Run(() =>
        {
            MainReplyList main = new();
            main.Replies = GetRepliesList(reply.Replies.ToList());
            main.Next = reply.Cursor.Next;
            main.Prev = reply.Cursor.Prev;
            main.TipText = reply.SubjectControl.ChildText;
            main.Count = reply.SubjectControl.Count;
            main.Title = reply.SubjectControl.Title;
            return main;
        });
    }

    public async Task<AppBrandSource> BrandConverterToImage(BiliBrandModel model)
    {
        return await Task.Run(() =>
        {
            AppBrandSource source = new() { AllWallpaper = new() };
            foreach (var item in model.Tabs)
            {
                source.TabCount++;
                foreach (var section in item.Sections)
                {
                    source.AllWallpaper.AddRange(section.List);
                }
            }
            source.Count = source.AllWallpaper.Count;
            return source;
        });
    }

    private RepliesItem GetCommentReplyMain(DetailListReply reply)
    {
        RepliesItem main =
            new()
            {
                UpMid = reply.Root.Mid,
                Oid = reply.Root.Oid,
                Rpid = reply.Root.Id,
                Replies = GetRepliesItemList(reply.Root.Replies.ToList()),
                Count = reply.Root.Count,
                Like = reply.Root.Like,
                PublishTime = reply.Root.Ctime,
                ReplyContent = GetReplyContent(reply.Root.Content),
                ReplyControl = GetReplyControl(reply.Root.ReplyControl),
                ReplyUp = GetReplyUp(reply.Root.Member),
                Type = reply.Root.Type,
            };
        return main;
    }

    internal List<RepliesItem> GetRepliesList(List<ReplyInfo> reply)
    {
        List<RepliesItem> repliesitem = new();
        foreach (var item in reply)
        {
            RepliesItem value =
                new()
                {
                    Like = item.Like,
                    Oid = item.Oid,
                    Count = item.Count,
                    Rpid = item.Id,
                    PublishTime = item.Ctime,
                    UpMid = item.Mid,
                    Type = item.Type,
                };
            value.ReplyContent = GetReplyContent(item.Content);
            value.ReplyUp = GetReplyUp(item.Member);
            value.ReplyControl = GetReplyControl(item.ReplyControl);
            if (item.Replies != null)
            {
                value.Replies = new();
                foreach (var replie in item.Replies)
                {
                    value.Replies.Add(
                        new()
                        {
                            Count = replie.Count,
                            Like = replie.Like,
                            Rpid = replie.Id,
                            Oid = replie.Oid,
                            PublishTime = replie.Ctime,
                            ReplyContent = GetReplyContent(replie.Content),
                            ReplyUp = GetReplyUp(replie.Member),
                            UpMid = replie.Mid,
                            Type = replie.Type
                        }
                    );
                }
            }
            repliesitem.Add(value);
        }
        return repliesitem;
    }

    internal List<RepliesItemBase> GetRepliesItemList(List<ReplyInfo> reply)
    {
        List<RepliesItemBase> repliesitem = new();
        foreach (var item in reply)
        {
            RepliesItem value =
                new()
                {
                    Like = item.Like,
                    Oid = item.Oid,
                    Count = item.Count,
                    Rpid = item.Id,
                    PublishTime = item.Ctime,
                    UpMid = item.Mid,
                    Type = item.Type
                };
            value.ReplyContent = GetReplyContent(item.Content);
            value.ReplyUp = GetReplyUp(item.Member);
            value.ReplyControl = GetReplyControl(item.ReplyControl);
            if (item.Replies != null)
            {
                value.Replies = new();
                foreach (var replie in item.Replies)
                {
                    value.Replies.Add(
                        new()
                        {
                            Count = replie.Count,
                            Like = replie.Like,
                            Rpid = replie.Id,
                            Oid = replie.Oid,
                            PublishTime = replie.Ctime,
                            ReplyContent = GetReplyContent(replie.Content),
                            ReplyUp = GetReplyUp(replie.Member),
                            UpMid = replie.Mid,
                            Type = replie.Type
                        }
                    );
                }
            }
            repliesitem.Add(value);
        }
        return repliesitem;
    }

    internal ReplyContent GetReplyContent(Bilibili.Main.Community.Reply.V1.Content content)
    {
        ReplyContent replycontent = new() { UrlItems = new(), AltUp = new() };
        if (content.Emote != null)
        {
            replycontent.EmoteItems = new();
            foreach (var emote in content.Emote)
            {
                replycontent.EmoteItems.Add(
                    new()
                    {
                        Size = emote.Value.Size,
                        Name = emote.Key,
                        Url = emote.Value.Url,
                    }
                );
            }
        }
        if (content.Url != null)
        {
            foreach (var url in content.Url)
            {
                ReplyUrlItem replyUrlItem =
                    new()
                    {
                        IconSource = url.Value.PrefixIcon,
                        Text = url.Key,
                        Keyword = url.Key,
                    };
                replycontent.UrlItems.Add(replyUrlItem);
            }
        }
        if (content.Menber != null)
        {
            foreach (var item in content.Menber)
            {
                replycontent.AltUp.Add(new(item.Key, GetReplyUp(item.Value)));
            }
        }
        replycontent.Message = content.Message;
        return replycontent;
    }

    internal Models.ReplyControl GetReplyControl(
        Bilibili.Main.Community.Reply.V1.ReplyControl control
    )
    {
        return new()
        {
            IsUpLike = control.UpLike,
            IsUpReply = control.UpReply,
            IsLike =
                control.Action == 0
                    ? false
                    : control.Action == 1
                        ? true
                        : false
        };
    }

    internal ReplyUp GetReplyUp(Bilibili.Main.Community.Reply.V1.Member up)
    {
        return new()
        {
            Face = up.Face,
            Name = up.Name,
            Mid = up.Mid,
            OffcialType = up.OfficialVerifyType,
            VipType = up.VipType,
            SexString = up.Sex,
        };
    }

    /// <summary>
    /// 非异步的转换弹幕，已经对弹幕进行基础的时间排序
    /// </summary>
    /// <param name="reply"></param>
    /// <returns></returns>
    public IEnumerable<DanmakuSession> ConverterDanmaku(DmSegMobileReply reply)
    {
        List<DanmakuSession> list = new List<DanmakuSession>();
        foreach (var item in reply.Elems)
        {
            list.Add(GetDanmakuSession(item));
        }
        list.Sort(new TimeSpanComparer());
        return list;
    }

    public class TimeSpanComparer : IComparer<DanmakuSession>
    {
        public int Compare(DanmakuSession x, DanmakuSession y)
        {
            return x.Progress.CompareTo(y.Progress);
        }
    }

    private DanmakuSession GetDanmakuSession(DanmakuElem elem)
    {
        return new DanmakuSession()
        {
            Color = FormatColor(elem.Color),
            FontSize = elem.Fontsize,
            Id = elem.IdStr,
            MidHash = elem.MidHash,
            Progress = new TimeSpan(0, 0, 0, 0, elem.Progress),
            Publish = elem.Ctime,
            Text = elem.Content,
            Weight = elem.Weight,
            Mode =
                elem.Mode == 4
                    ? DanmakuType.Bottom
                    : elem.Mode == 5
                        ? DanmakuType.Top
                        : elem.Mode == 1
                            ? DanmakuType.Scrool
                            : DanmakuType.None
        };
    }

    DanmakuColor FormatColor(long color)
    {
        byte red = (byte)((color >> 16) & 0xFF);
        byte green = (byte)((color >> 8) & 0xFF);
        byte blue = (byte)(color & 0xFF);
        return new(red, green, blue);
    }


    
}
