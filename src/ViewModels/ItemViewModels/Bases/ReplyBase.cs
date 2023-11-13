namespace ViewModels.ItemViewModels.Bases;

/// <summary>
/// 回复基类
/// </summary>
/// <typeparam name="T">回复的Item类型</typeparam>
public abstract partial class ReplyBase<T> : ObservableObject
{
    [ObservableProperty]
    T _ItemModel;

    [ObservableProperty]
    bool _IsLikeing = true;

    [ObservableProperty]
    long _LikeCount;

    public ReplyBase(IReplyProvider replyProvider, ITipShow tipShow)
    {
        ReplyProvider = replyProvider;
        TipShow = tipShow;
    }

    public abstract void Like(long Targetid);

    public IReplyProvider ReplyProvider { get; }
    public ITipShow TipShow { get; }
}
