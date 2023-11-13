using IAppContracts.ItemsViewModels;
using Network.Models.Enum;
using ViewConverter.Models;

namespace IAppContracts.Factorys;

/// <summary>
/// 社区信息转换成为ViewModel
/// </summary>
public interface ICommunityFactory
{
    public IReplyMainItemViewModel CreateReplyMainItem(
        RepliesItem data,
        long view,
        CommentType type
    );

    public IReplyCommentItemViewModel CreateReplyCommentItem(
        RepliesItemBase data,
        CommentType type
    );
}
