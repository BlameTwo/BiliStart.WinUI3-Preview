using CommunityToolkit.Mvvm.Input;
using IAppContracts.Bases;
using Microsoft.UI.Xaml;
using Network.Models.Enum;
using System;
using ViewConverter.Models;

namespace IAppContracts.ItemsViewModels;

public interface IReplyMainItemViewModel : IItemControlVMBase<Tuple<RepliesItem, long, CommentType>>
{
    /// <summary>
    /// 主信息
    /// </summary>
    RepliesItem ItemModel { get; set; }

    /// <summary>
    /// 喜欢命令
    /// </summary>
    IRelayCommand LikeCommand { get; }

    CommentType CommentType { get; set; }

    Visibility IsComment { get; set; }

    long LikeCount { get; set; }

    bool IsLikeing { get; set; }

    /// <summary>
    /// 视频AId
    /// </summary>
    public long TargetAid { get; set; }

    IRelayCommand GoCommentCommand { get; }
}
