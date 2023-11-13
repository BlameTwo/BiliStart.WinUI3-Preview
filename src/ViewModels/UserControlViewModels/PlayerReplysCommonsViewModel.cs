using CommunityToolkit.Mvvm.Messaging;
using Google.Protobuf.WellKnownTypes;
using IAppContracts.Factorys;
using IAppContracts.ItemsViewModels;
using IAppContracts.IUserControlsViewModels;
using Network.Models.Enum;
using ViewConverter.Models.Messager;

namespace ViewModels.UserControlViewModels;

public partial class PlayerReplysCommonsViewModel
    : ObservableRecipient,
        IPlayerReplysCommonsViewModel
{
    public PlayerReplysCommonsViewModel(
        IRootNavigationMethod rootNavigationMethod,
        IReplyProvider replyProvider,
        ICommunityFactory communityFactory,
        ITipShow tipShow
    )
    {
        RootNavigationMethod = rootNavigationMethod;
        this.BackGoMainCommand = new(() => back());
        this.AddDataCommand = new AsyncRelayCommand(() => AddData());

        ReplyProvider = replyProvider;
        CommunityFactory = communityFactory;
        TipShow = tipShow;
    }

    private async Task AddData()
    {
        var result = await ReplyProvider.GetReplyCommentAsync(
            this.CommentReplyList.Main,
            _next,
            Network.Models.Enum.ReplyOrderEnum.Hot,
            this.CommentType
        );
        foreach (var item in result.Main.Replies)
        {
            var itemresult = CommunityFactory.CreateReplyCommentItem(item, this.CommentType);
            this.RepliesList.Add(itemresult);
        }
    }

    private void back()
    {
        WeakReferenceMessenger.Default.Send<PlayerGoBackMain>(new PlayerGoBackMain(true));
    }

    private long _next = 0;

    public void SetData(Tuple<CommentReplyList, CommentType> value)
    {
        this.LikeCount = value.Item1.Main.Like;
        this.IsLike = value.Item1.Main.ReplyControl.IsLike;
        this.CommentType = value.Item2;
        this.CommentReplyList = value.Item1;
        this.RepliesList = new();
        this._next = value.Item1.Next;
        foreach (var item in value.Item1.Main.Replies)
        {
            var result = CommunityFactory.CreateReplyCommentItem(item, this.CommentType);
            this.RepliesList.Add(result);
        }
    }

    [ObservableProperty]
    RepliesItem _Base;

    [ObservableProperty]
    CommentReplyList _CommentReplyList;

    [ObservableProperty]
    ObservableCollection<IReplyCommentItemViewModel> _RepliesList;

    [ObservableProperty]
    CommentType _CommentType;

    [ObservableProperty]
    bool _IsLikeing = true;

    [ObservableProperty]
    bool _IsLike;

    [ObservableProperty]
    long _LikeCount;
    public IRootNavigationMethod RootNavigationMethod { get; }

    [RelayCommand]
    public async Task Like()
    {
        this.IsLikeing = false;
        var _islike = !IsLike;
        var result = await ReplyProvider.LikeReplyAsync(
            _islike,
            this.CommentReplyList.Main.Oid,
            CommentReplyList.Main.Rpid,
            this.CommentType
        );
        if (result.Data.IsFlage)
        {
            TipShow.ShowMessage("操作成功", Symbol.Accept);
            if (_islike)
                this.LikeCount++;
            else
                this.LikeCount--;
        }
        this.IsLike = _islike;
        this.IsLikeing = true;
    }

    public IReplyProvider ReplyProvider { get; }
    public ICommunityFactory CommunityFactory { get; }
    public ITipShow TipShow { get; }
    public RelayCommand BackGoMainCommand { get; }

    public IAsyncRelayCommand AddDataCommand { get; }
}
