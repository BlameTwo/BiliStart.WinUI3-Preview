using IAppContracts.Factorys;
using IAppContracts.ItemsViewModels;
using ViewConverter.Models;

namespace AppContractService.Services.FactorysServices;

public class CommunityFactory : ICommunityFactory
{
    public IReplyMainItemViewModel CreateReplyMainItem(
        RepliesItem data,
        long view,
        CommentType type
    )
    {
        var result = AppService.GetService<IReplyMainItemViewModel>();
        result.SetData(new(data, view, type));
        return result;
    }

    public IReplyCommentItemViewModel CreateReplyCommentItem(RepliesItemBase data, CommentType type)
    {
        var result = AppService.GetService<IReplyCommentItemViewModel>();
        result.SetData(new(data, type));
        return result;
    }
}
