using Bilibili.Community.Service.Dm.V1;
using Bilibili.Main.Community.Reply.V1;
using Network.Models.ThirdApi;
using ViewConverter.Models;
using ViewConverter.Models.ServiceData;

namespace IViewConverter;

public interface IBiliDataViewModelConverter
{
    public Task<MainReplyList> ConverterToReply(MainListReply reply);

    public Task<CommentReplyList> ConverterCommentReply(DetailListReply reply);

    public IEnumerable<DanmakuSession> ConverterDanmaku(DmSegMobileReply reply);


    public Task<AppBrandSource> BrandConverterToImage(BiliBrandModel model);
}
