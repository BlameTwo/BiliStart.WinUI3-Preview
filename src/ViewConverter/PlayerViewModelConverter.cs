namespace ViewConverter;

public sealed class PlayerViewModelConverter : IPlayerViewModelConverter
{
    public IAvToBvConverter AvToBvConverter { get; }

    public PlayerViewModelConverter(IAvToBvConverter avToBvConverter)
    {
        AvToBvConverter = avToBvConverter;
    }

    public async Task<PlayerView> GetPlayerViewToModel(ViewReply view)
    {
        return await Task.Run(() =>
        {
            var Session = GetPlayerSession(view);
            var state = GetPlayerStat(view);
            var pages = GetPlayerPages(view);
            return new PlayerView(
                Session,
                view.Tag.ToList(),
                view.DescV2.ToList(),
                view.Bvid,
                view.Arc.Aid,
                view.Arc.FirstCid,
                state,
                GetPlayerUp(view),
                view.ShortLink,
                GetRelatesVideos(view),
                pages
            );
        });
    }

    public List<Models.ViewPage> GetPlayerPages(ViewReply view)
    {
        var list = new List<Models.ViewPage>();
        foreach (var item in view.Pages)
        {
            list.Add(
                new()
                {
                    Cid = item.Page.Cid,
                    Desc = item.Page.Desc,
                    Duration = item.Page.Duration,
                    Title = item.Page.Part,
                    Height = item.Page.Dimension.Height,
                    Width = item.Page.Dimension.Width,
                }
            );
        }
        return list;
    }

    internal PlayerSession GetPlayerSession(ViewReply view)
    {
        return new()
        {
            Title = view.Arc.Title,
            ViewCoins = view.Arc.Stat.Coin,
            ViewCount = view.Arc.Stat.View,
            ViewDanmaku = view.Arc.Stat.Danmaku,
            ViewFavorites = view.Arc.Stat.Fav,
            ViewLike = view.Arc.Stat.Like,
            ViewPublish = view.Arc.Pubdate,
            Desc = view.Arc.Desc,
            Cover = view.Arc.Pic
        };
    }

    internal PlayerUserStat GetPlayerStat(ViewReply view)
    {
        var result = new PlayerUserStat()
        {
            IsCoin = Convert.ToBoolean(view.ReqUser.Coin),
            IsLike = Convert.ToBoolean(view.ReqUser.Like),
            IsFav = Convert.ToBoolean(view.ReqUser.Favorite),
        };
        if (view.History != null)
        {
            result.History = new ViewHistory()
            {
                Cid = view.History.Cid,
                Progress = view.History.Progress,
            };
        }
        return result;
    }

    internal List<PlayerRelatesVideo> GetRelatesVideos(ViewReply view)
    {
        List<PlayerRelatesVideo> values = new();
        foreach (var item in view.Relates)
        {
            if (item.Goto != "av")
                continue;
            values.Add(
                new PlayerRelatesVideo()
                {
                    Bvid = AvToBvConverter.Enc(item.Aid),
                    Aid = item.Aid.ToString(),
                    Cid = item.Cid.ToString(),
                    Coin = item.Stat.Coin,
                    Cover = item.Pic,
                    Duration = item.Duration,
                    Fav = item.Stat.Fav,
                    Reply = item.Stat.Reply,
                    Like = item.Stat.Like,
                    ShareCount = item.Stat.Share,
                    Title = item.Title,
                    Up = new PlayerUp()
                    {
                        Cover = item.Author.Face,
                        Mid = item.Author.Mid,
                        Name = item.Author.Name,
                    },
                    TrackId = item.Trackid,
                    View = item.Stat.View
                }
            );
            ;
        }
        return values;
    }

    internal PlayerSessionUp GetPlayerUp(ViewReply view)
    {
        return new PlayerSessionUp()
        {
            Name = view.Arc.Author.Name,
            Mid = view.Arc.Author.Mid,
            Cover = view.Arc.Author.Face,
            IsLike = Convert.ToBoolean(view.ReqUser.Attention)
        };
    }
}
