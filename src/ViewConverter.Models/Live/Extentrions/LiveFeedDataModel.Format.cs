using Network.Models.Live;

namespace ViewConverter.Models.Live.Extentrions;

/// <summary>
/// 对直播数据的一个转换
/// </summary>
public static class LiveFeedDataModelFormat
{
    /// <summary>
    /// 分离出我的关注列表
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public static LiveCardList FormatMyLike(this LiveFeedDataModel model)
    {
        //my_idol_v1
        var result = model.LiveCardList.Where((val) => val.CardType == "my_idol_v1").First();
        if (result == null)
            return default;
        return result;
    }

    public static List<LiveCardList> FormatList(this LiveFeedDataModel model) =>
        model.LiveCardList.Where((val) => val.CardType == "small_card_v1").ToList();

    public static LiveCardList FormatHotTag(this LiveFeedDataModel model)
    {
        var list = model.LiveCardList.Where((val) => val.CardType == "area_entrance_v3");
        if (list == null || list.Count() == 0)
            return default;
        var result = list.First();
        if (result == null)
            return default;
        return result;
    }
}
