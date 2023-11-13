using ViewConverter.Models.VideoModel;

namespace ViewConverter;

/// <summary>
/// 用来转换视频子类到最基本的
/// </summary>
public sealed class VideoViewModelConverter : IVideoViewModelConverter
{
    public async Task<List<HotVideo>> HotConverterToVideo(List<Card> cards)
    {
        return await Task.Run(() =>
        {
            List<HotVideo> videoList = new List<HotVideo>();
            foreach (var item in cards)
            {
                videoList.Add(
                    new()
                    {
                        Title = item.SmallCoverV5.Base.Title,
                        UpName = item.SmallCoverV5.Base.ThreePointV4.SharePlane.Author,
                        UpMid = item.SmallCoverV5.Base.ThreePointV4.SharePlane.AuthorId,
                        LookCount = item.SmallCoverV5.Base.ThreePointV4.SharePlane.PlayNumber,
                        Description = item.SmallCoverV5.Base.ThreePointV4.SharePlane.ShareSubtitle,
                        TimeDuration = item.SmallCoverV5.CoverRightText1,
                        Aid = item.SmallCoverV5.Base.ThreePointV4.SharePlane.Aid,
                        Bvid = item.SmallCoverV5.Base.ThreePointV4.SharePlane.Bvid,
                        HotTitle = item.SmallCoverV5.RcmdReasonStyle?.Text ?? string.Empty,
                        Cover = item.SmallCoverV5.Base.Cover
                    }
                );
            }
            return videoList;
        });
    }

    public async Task<HomeVideoBase> HomeConverterToVideo(List<VideoItem> videoItems)
    {
        return await Task.Run(() =>
        {
            HomeVideoBase valresult = new();
            foreach (var item in videoItems)
            {
                if (item.Card_Goto == "banner")
                {
                    valresult.Idx = item.idx;
                    valresult.Hash = item.BannerHash;
                    foreach (var banner in item.BannerItem)
                    {
                        valresult.BannerItems.Add(banner);
                    }
                }
                else if (item.Card_Goto == "av" && item.PlayArg != null)
                {
                    HomeVideo video = new();
                    video.Title = item.Title;
                    video.SourceData = item;
                    video.UpName = item.UpArg.Name;
                    video.UpMid = item.UpArg.Mid;
                    video.Aid = Convert.ToInt64(item.Param);
                    video.Cover = item.Cover;
                    video.Description = item.Desc;
                    video.LookCount = item.DanmakuTest;
                    video.Danmaku = item.DanmakuTest;
                    video.Cid = item.PlayArg.cid;
                    TimeSpan ts = TimeSpan.FromSeconds(item.PlayArg.Duration);
                    video.TimeDuration = $"{ts.Hours}:{ts.Minutes}:{ts.Seconds}";
                    valresult.Items.Add(video);
                }
            }
            return valresult;
        });
    }

    public async Task<List<RankVideo>> RankConverterToVideo(List<Bilibili.App.Show.V1.Item> items)
    {
        return await Task.Run(() =>
        {
            var videoList = new List<RankVideo>();
            foreach (var item in items)
            {
                var val = new RankVideo()
                {
                    Aid = int.Parse(item.Param),
                    Title = item.Title,
                    Cover = item.Cover,
                    Pts = item.Pts,
                    LookCount = item.Play.ToString(),
                    Favourite = item.Favourite,
                    UpName = item.Name,
                    UpFace = item.Face,
                    UpMid = item.Mid,
                    Danmaku = item.Danmaku
                };
                TimeSpan time = TimeSpan.FromSeconds(item.Duration);
                val.TimeDuration = $"{time.Hours}:{time.Minutes}:{time.Seconds}";
                videoList.Add(val);
                ;
            }
            return videoList;
        });
    }

    string lul = @"<em class=""keyword"">(.*?)</em>";

    public async Task<SearchModel> SearchAllConverter(
        Bilibili.Polymer.App.Search.V1.SearchAllResponse value,
        string selectstr
    )
    {
        return await Task.Run(() =>
        {
            List<SearchModelItem> items = new();
            foreach (var val in value.Item)
            {
                SearchModelItem sml = FormatSearchItem(val);
                if (sml != null)
                {
                    sml.Source = val;
                    items.Add(sml);
                }
            }
            SearchModel model =
                new()
                {
                    PageSize = value.Item.Count,
                    Next = value.Pagination.Next,
                    NavHeader = value.Nav.ToList(),
                    Item = items,
                    Trickid = value.Trackid
                }; //这里把房间号切换为直播
            if (value.Pagination.Next == "")
                model.IsEnd = true;
            else
                model.Next = value.Pagination.Next;
            foreach (var item in model.NavHeader)
            {
                if (item.Name == "直播")
                    item.Type = 5;
            }
            if (value.Pagination.Next == null)
                model.IsEnd = true;
            return model;
        });
    }

    SearchModelItem FormatSearchItem(Bilibili.Polymer.App.Search.V1.Item val)
    {
        SearchModelItem sml = null;
        if (
            val.Goto == "av"
            || val.Goto == "movie"
            || val.Goto == "bangumi"
            || val.Goto == "article"
            || val.Goto == "author"
        )
        {
            sml = new();
            sml.Param = val.Param;
            sml.Trackid = val.Trackid;
        }
        else
            return null;
        if (val.Goto == "av")
        {
            sml = new SearchModelItem() { Cover = val.Av.Cover, };
            sml.Type = "视频";
            sml.VideoItem = new()
            {
                Av = long.Parse(val.Param),
                PlayerCount = val.Av.Play,
                DanmakuCount = val.Av.Danmaku,
                DurationString = val.Av.Duration,
                UpMid = val.Av.Mid,
                UpName = val.Av.Author,
                PublishTimeString = val.Av.ShowCardDesc2
            };
            if (val.Av.Share.Type == "video")
            {
                sml.VideoItem.Bvid = val.Av.Share.Video.Bvid;
                sml.VideoItem.Cid = val.Av.Share.Video.Cid;
                sml.VideoItem.ShareTitle = val.Av.Share.Video.ShareSubtitle;
            }
            string output = Regex.Replace(val.Av.Title, lul, "$1");
            sml.Title = output;
        }
        else if (val.Goto == "movie" || val.Goto == "bangumi")
        {
            sml = new SearchModelItem() { Cover = val.Bangumi.Cover, };
            if (val.Goto == "movie")
                sml.Type = "影视";
            else
                sml.Type = "番剧";
            string movie = Regex.Replace(val.Bangumi.Title, lul, "$1");
            sml.MovieItem = new()
            {
                Cv = val.Bangumi.Cv,
                Episodes = val.Bangumi.EpisodesNew.Take(2).ToList(),
                Rating = val.Bangumi.Rating,
                MediaType = val.Bangumi.MediaType,
                MoviaSource = val.Bangumi.Area,
                MovieType = val.Bangumi.StylesV2,
                PublishTime = val.Bangumi.Ptime,
                SSID = val.Bangumi.SeasonId
            };
            sml.Title = movie;
        }
        else if (val.Goto == "article")
        {
            sml = new SearchModelItem() { Cover = val.Article.ImageUrls[0], Article = new() };
            sml.Article.UpName = val.Article.Name;
            sml.Article.UpMid = val.Article.Mid;
            sml.Article.Reply = val.Article.Reply;
            sml.Article.Desc = val.Article.Desc;
            sml.Article.View = val.Article.View;
            sml.Article.Like = val.Article.Like;
            sml.Article.Play = val.Article.Play;
            string article = Regex.Replace(val.Article.Title, lul, "$1");
            sml.Title = article;
        }
        else if (val.Goto == "live")
        {
            //sml = new SearchModelItem()
            //{
            //    Cover = val.Live.Cover
            //};
            //string live = Regex.Replace(val.Live.Title, lul, "$1");
            //sml.Title = live;
        }
        else if (val.Goto == "author")
        {
            sml = new SearchModelItem() { Cover = val.Author.Cover, };
            string user = Regex.Replace(val.Author.Title, lul, "$1");
            sml.Title = user;
            sml.User = new()
            {
                Mid = val.Param,
                Sign = val.Author.Sign,
                Favs = val.Author.Fans,
                SubTitle = val.Author.OfficialVerify.Desc,
                Isup = val.Author.IsUp,
                LiveRoomId = val.Author.Roomid,
                VideoCount = val.Author.Archives,
            };
        }
        return sml;
    }

    public async Task<SearchModel> SearchTypeConverter(
        Bilibili.Polymer.App.Search.V1.SearchByTypeResponse value
    )
    {
        return await Task.Run(() =>
        {
            SearchModel sml = new();
            if (value.Pagination.Next == "")
                sml.IsEnd = true;
            else
                sml.Next = value.Pagination.Next;
            sml.Trickid = value.Trackid;
            sml.NavHeader = null;
            List<SearchModelItem> items = new();
            foreach (var item in value.Items)
            {
                SearchModelItem sm = FormatSearchItem(item);
                if (sm != null)
                {
                    sm.Source = item;
                    items.Add(sm);
                }
            }
            sml.Item = items;
            return sml;
        });
    }

    public Task<List<MusicRankCard>> MusicRankToVideo(List<MusicRankItem> items)
    {
        return Task.Run(() =>
        {
            List<MusicRankCard> cards = new();
            foreach (var item in items)
            {
                MusicRankCard card =
                    new()
                    {
                        Aid = item.CreateAid,
                        Bvid = item.CreateBvid,
                        MsuciID = item.Music_ID,
                        Duration = item.CreateDuration,
                        CreateTime = item.CreateUpDateTime
                    };
                string rankstr = "";
                item.Achievements.ForEach(
                    (val) =>
                    {
                        rankstr += val;
                        rankstr += " ";
                    }
                );
                MusicBigCard bigcard =
                    new()
                    {
                        Title = item.Title,
                        Album = item.Album,
                        Singer = item.Singer,
                        Cover = item.MVCover,
                        Heat = item.Heat,
                        Rank = item.RankNumber,
                        RankString = rankstr,
                    };
                card.TopCard = bigcard;
                MusicSmallCard smallcard =
                    new()
                    {
                        Title = item.CreateTitle,
                        Cover = item.CreateCover,
                        PlayCount = item.CreatePlay,
                        UpName = item.CreateNickName,
                        Reason = item.CreateReason,
                    };
                card.BootomCard = smallcard;
                cards.Add(card);
            }
            return cards;
        });
    }
}
