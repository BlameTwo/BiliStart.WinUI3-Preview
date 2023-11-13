using Bilibili.App.Interface.V1;
using Lib.Helper;
using ViewConverter.Models.AccountHistory;

namespace ViewConverter;

public class AccountHistoryConverter : IAccountHistoryConverter
{
    public AccountHistoryConverter(IAvToBvConverter avToBvConverter)
    {
        AvToBvConverter = avToBvConverter;
    }

    public IAvToBvConverter AvToBvConverter { get; }

    public AccountVideoHistoryModel ConverterModel(CursorV2Reply v2Reply)
    {
        AccountVideoHistoryModel model = new AccountVideoHistoryModel() { Videos = new() ,Lives = new()};
        foreach (var item in v2Reply.Items)
        {
            if (item.Business == "archive")
                model.Videos.Add(VideoItem(item));
            else if (item.Business == "live")
            {
                model.Lives.Add(LiveItem(item));
            }
        }
        ;
        model.Cursor = v2Reply.Cursor;
        return model;
    }

    internal AccountLiveHistoryItem LiveItem(CursorItem item)
    {
        return new()
        {
            Cover = item.CardLive.Cover,
            Dt = new() { Icon = item.Dt.Icon, Type = item.Dt.Type, },
            RoomId = item.Kid,
            Title = item.Title,
            ViewTime = TickSpanHelper.UnixConvertToDateTime(item.ViewAt),
            Tag = item.CardLive.Tag,
            UpMid = item.CardLive.Mid,
            UpName = item.CardLive.Name,
        };
    }

    internal AccountVideoHistoryItem VideoItem(CursorItem item)
    {
        return new()
        {
            Aid = AvToBvConverter.Dec(item.CardUgc.Bvid),
            Bvid = item.CardUgc.Bvid,
            Cid = item.CardUgc.Cid,
            Cover = item.CardUgc.Cover,
            Title = item.Title,
            Duration = item.CardUgc.Duration,
            Progress = item.CardUgc.Progress,
            ShareUrl = item.CardUgc.ShareSubtitle,
            UpMid = item.CardUgc.Mid,
            UpName = item.CardUgc.Name,
            View = item.CardUgc.View,
            ViewTime = TickSpanHelper.UnixConvertToDateTime(item.ViewAt),
            Type = 1
        };
    }
}
