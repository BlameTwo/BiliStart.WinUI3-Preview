using IAppContracts.Factorys;
using IAppContracts.ItemsViewModels;
using IAppContracts.IUserControlsViewModels;
using Network.Models.Enum;

namespace ViewModels.UserControlViewModels
{
    public partial class PlayerReplysViewModel : UserControlViewModelBase, IPlayerReplysViewModel
    {
        public PlayerReplysViewModel(
            IRootNavigationMethod rootNavigationMethod,
            IReplyProvider replyProvider,
            ICommunityFactory communityFactory
        )
        {
            RootNavigationMethod = rootNavigationMethod;
            this.ReplyProvider = replyProvider;
            CommunityFactory = communityFactory;
            OrderList = new() { "最热排序", "最新排序" };
            this.AddDataCommand = new AsyncRelayCommand(adddata);
            this.OrderSelecter = OrderList[0];
        }

        private MainReplyList _replymain;

        public MainReplyList ReplyData
        {
            get { return _replymain; }
            set => SetProperty(ref _replymain, value);
        }

        private ObservableCollection<IReplyMainItemViewModel> replyitem;

        public ObservableCollection<IReplyMainItemViewModel> ReplyItems
        {
            get { return replyitem; }
            set => SetProperty(ref replyitem, value);
        }

        private string orderselecter;

        public string OrderSelecter
        {
            get { return orderselecter; }
            set
            {
                SetProperty(ref orderselecter, value);
                refersh(value);
            }
        }

        [ObservableProperty]
        CommentType _CommentType;

        private ObservableCollection<string> orderlist;

        public ObservableCollection<string> OrderList
        {
            get { return orderlist; }
            set { SetProperty(ref orderlist, value); }
        }

        #region 私有变量
        long _next;

        ReplyOrderEnum _replyorderby;
        #endregion

        private async void refersh(string orderby)
        {
            if (this.Aid == 0)
                return;
            if (ReplyItems == null)
                ReplyItems = new();
            else
                ReplyItems.Clear();
            _next = 0;
            ReplyOrderEnum orderenum = ReplyOrderEnum.Hot;
            if (orderby == "最新排序")
                orderenum = ReplyOrderEnum.Time;
            var result = await this.ReplyProvider.GetReplyListAsync(
                this.Aid,
                _next,
                orderenum,
                CommentType.Video
            );
            this.ReplyData = result;
            this._next = ReplyData.Next;
            foreach (var item in result.Replies)
            {
                this.ReplyItems.Add(
                    CommunityFactory.CreateReplyMainItem(item, Aid, this.CommentType)
                );
            }
        }

        private async Task adddata()
        {
            var result = await ReplyProvider.GetReplyListAsync(this.Aid, _next, _replyorderby);
            this._next = result.Next;
            foreach (var item in result.Replies)
            {
                this.ReplyItems.Add(
                    CommunityFactory.CreateReplyMainItem(item, Aid, this.CommentType)
                );
            }
        }

        public void SetData(Tuple<MainReplyList, long, ReplyOrderEnum, CommentType> value)
        {
            this.CommentType = value.Item4;
            this.ReplyItems = new();
            Aid = value.Item2;
            this.ReplyData = value.Item1;
            this._replyorderby = value.Item3;
            foreach (var item in value.Item1.Replies)
            {
                this.ReplyItems.Add(
                    CommunityFactory.CreateReplyMainItem(item, Aid, this.CommentType)
                );
            }
            this._next = value.Item1.Next;
        }

        public IReplyProvider ReplyProvider { get; }
        public ICommunityFactory CommunityFactory { get; }
        public long Aid { get; set; }
        public IRootNavigationMethod RootNavigationMethod { get; }

        public IAsyncRelayCommand AddDataCommand { get; }
    }
}
