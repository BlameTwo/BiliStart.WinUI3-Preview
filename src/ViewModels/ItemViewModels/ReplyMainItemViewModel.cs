using IAppContracts.ItemsViewModels;
using Network.Models.Enum;
using ViewConverter.Models.Messager;
using ViewModels.ItemViewModels.Bases;

namespace ViewModels.ItemViewModels;

public partial class ReplyMainItemViewModel : ReplyBase<RepliesItem>, IReplyMainItemViewModel
{
    public ReplyMainItemViewModel(IReplyProvider replyProvider, ITipShow tipShow)
        : base(replyProvider, tipShow) { }

    public long TargetAid { get; set; }

    [ObservableProperty]
    CommentType _CommentType;

    [RelayCommand]
    void Like()
    {
        Like(TargetAid);
    }

    [RelayCommand]
    void GoComment()
    {
        WeakReferenceMessenger.Default.Send(
            new PlayerCommonData(this.ItemModel, CommonOpenEnum.Open, this.CommentType)
        );
    }

    [ObservableProperty]
    Visibility _IsComment = Visibility.Visible;

    public void SetData(Tuple<RepliesItem, long, CommentType> value)
    {
        this.ItemModel = value.Item1;
        this.TargetAid = value.Item2;
        this.LikeCount = ItemModel.Like;
        this.CommentType = value.Item3;
    }

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
}
