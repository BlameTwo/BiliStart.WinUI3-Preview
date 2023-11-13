using CommunityToolkit.Mvvm.Input;
using IAppContracts.Bases;
using IAppContracts.ItemsViewModels;
using Network.Models.Enum;
using System;
using System.Collections.ObjectModel;
using ViewConverter.Models;

namespace IAppContracts.IUserControlsViewModels;

public interface IPlayerReplysViewModel
    : IUserControlVMBase<Tuple<MainReplyList, long, ReplyOrderEnum, CommentType>>
{
    MainReplyList ReplyData { get; set; }

    ObservableCollection<IReplyMainItemViewModel> ReplyItems { get; set; }

    long Aid { get; set; }

    IAsyncRelayCommand AddDataCommand { get; }

    CommentType CommentType { get; set; }

    ObservableCollection<string> OrderList { get; set; }

    string OrderSelecter { get; set; }
}
