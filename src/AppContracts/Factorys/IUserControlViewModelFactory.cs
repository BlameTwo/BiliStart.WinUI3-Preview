using IAppContracts.ItemsViewModels;
using IAppContracts.IUserControlsViewModels;
using IAppContracts.IUserControlsViewModels.LiveControlsViewModels;
using Network.Models.Accounts;
using Network.Models.Enum;
using Network.Models.Live;
using System.Threading.Tasks;
using ViewConverter.Models;

namespace IAppContracts.Factorys;

/// <summary>
/// 综合性创建工厂
/// </summary>
public interface IUserControlViewModelFactory
{
    public IPlayerRelatesViewModel CreatePlayerRelates(PlayerView view);

    public IPlayerReplysViewModel CreatePlayerReplays(
        MainReplyList data,
        long view,
        ReplyOrderEnum OrderBy,
        CommentType type
    );

    public IPlayerReplysCommonsViewModel CreateCommons(CommentReplyList data, CommentType type);

    public IPlayerPagesModel CreatePlayerPages(PlayerView view,long space=0);

    public IBiliStartNotifyViewModel CreateNotifyIconViewModel(object data);

    public ITokenItemViewModel CreateTokenItemViewModel(AccountToken token, string path);

    public ILiveTagViewModel CreateLiveTagViewModel(LiveTagList model);

    public IBIliChatViewModel CreateBiliChatViewModel();

    public ILauncherLoginViewModel CreateLauncherLoginViewModel();
    public Task<ILiveTagItemViewModel> CreateLiveTagItemViewModel(LiveTagAreaList liveTagAreaList);
}
