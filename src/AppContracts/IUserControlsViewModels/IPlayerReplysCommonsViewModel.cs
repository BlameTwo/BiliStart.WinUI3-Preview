using CommunityToolkit.Mvvm.Input;
using IAppContracts.Bases;
using IAppContracts.ItemsViewModels;
using Network.Models.Enum;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ViewConverter.Models;

namespace IAppContracts.IUserControlsViewModels;

public interface IPlayerReplysCommonsViewModel
    : IUserControlVMBase<Tuple<CommentReplyList, CommentType>>
{
    RepliesItem Base { get; set; }

    bool IsLikeing { get; set; }

    long LikeCount { get; set; }

    bool IsLike { get; set; }

    ObservableCollection<IReplyCommentItemViewModel> RepliesList { get; set; }

    RelayCommand BackGoMainCommand { get; }

    IAsyncRelayCommand AddDataCommand { get; }

    CommentType CommentType { get; set; }

    IAsyncRelayCommand LikeCommand { get; }

    CommentReplyList CommentReplyList { get; set; }
}
