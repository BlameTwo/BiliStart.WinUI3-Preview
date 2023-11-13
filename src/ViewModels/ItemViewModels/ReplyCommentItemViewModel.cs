using IAppContracts.ItemsViewModels;
using Network.Models.Enum;
using ViewModels.ItemViewModels.Bases;

namespace ViewModels.ItemViewModels;

public partial class ReplyCommentItemViewModel
    : ReplyBase<RepliesItemBase>,
        IReplyCommentItemViewModel
{
    public ReplyCommentItemViewModel(IReplyProvider replyProvider, ITipShow tipShow)
        : base(replyProvider, tipShow) { }

    [RelayCommand]
    void Like()
    {
        Like(this.ItemModel.Oid);
    }

    [ObservableProperty]
    Visibility _IsComment = Visibility.Collapsed;

    [ObservableProperty]
    CommentType _CommentType;

    public override async void Like(long Targetid)
    {
        IsLikeing = false;
        //反向操作
        bool islike = !this.ItemModel.ReplyControl.IsLike;
        var result = await ReplyProvider.LikeReplyAsync(
            islike,
            Targetid,
            ItemModel.Rpid,
            this.CommentType
        );
        //数据通知
        if (islike && result.Data.IsFlage)
            this.LikeCount++;
        else
            this.LikeCount--;
        TipShow.ShowMessage("操作成功", Symbol.Next);
        this.ItemModel.ReplyControl.IsLike = islike;
        IsLikeing = true;
    }

    public void SetData(Tuple<RepliesItemBase, CommentType> value)
    {
        this.ItemModel = value.Item1;
        this.CommentType = value.Item2;
    }
}
