using Bilibili.App.Dynamic.V2;
using ViewConverter.Models.Dynamic;

namespace ViewConverter;

public class AccountDynamicConverter : IAccountDynamicConverter
{
    public UserAllModel FormatUserAllModel(DynAllReply dynAll)
    {
        UserAllModel model = new();
        model.DynamicUpList = FormatUpList(dynAll);
        model.HistoryOffset = dynAll.DynamicList.HistoryOffset;
        model.Businessid = dynAll.DynamicList.List.Last().Extend.BusinessId;
        model.HasMore = dynAll.DynamicList.HasMore;
        model.UpdateCount = dynAll.DynamicList.UpdateNum;
        model.DynamicItems = dynAll.DynamicList.List.ToList();
        return model;
    }

    private DynamicUpList FormatUpList(DynAllReply dynAll)
    {
        DynamicUpList model = new();
        if (dynAll.UpList == null) return model;
        model.Title = dynAll.UpList.Title;
        foreach (var item in dynAll.UpList.List)
        {
            model.Items.Add(
                new()
                {
                    Face = item.Face,
                    HASUpdate = item.HasUpdate,
                    IsRecall = item.IsRecall,
                    ItemCardType = item.UserItemType,
                    LiveState = item.LiveState,
                    Name = item.Name,
                    Uid = item.Uid,
                    Uri = item.Uri,
                }
            );
        }
        return model;
    }
}
