using Bilibili.App.Show.Gateway.V1;
using CommunityToolkit.Mvvm.Input;
using IAppContracts.Bases;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Network.Models.Enum;
using System;
using System.Threading.Tasks;
using ViewConverter.Models;

namespace IAppContracts.ItemsViewModels;

public interface IReplyCommentItemViewModel
    : IItemControlVMBase<Tuple<RepliesItemBase, CommentType>>
{
    RepliesItemBase ItemModel { get; set; }

    /// <summary>
    /// 喜欢命令
    /// </summary>
    IRelayCommand LikeCommand { get; }

    CommentType CommentType { get; set; }

    long LikeCount { get; set; }

    Visibility IsComment { get; set; }

    bool IsLikeing { get; set; }
}
