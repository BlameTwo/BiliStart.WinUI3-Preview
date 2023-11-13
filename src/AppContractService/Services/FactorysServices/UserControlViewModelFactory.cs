using IAppContracts.Factorys;
using IAppContracts.IUserControlsViewModels;
using IAppContracts.IUserControlsViewModels.LiveControlsViewModels;
using Network.Models.Live;
using ViewConverter.Models;

namespace AppContractService.Services.FactorysServices;

public class UserControlViewModelFactory : IUserControlViewModelFactory
{
    public IPlayerReplysCommonsViewModel CreateCommons(CommentReplyList data, CommentType type)
    {
        var relates = AppService.GetService<IPlayerReplysCommonsViewModel>();
        relates.SetData(new(data, type));
        return relates;
    }

    public IPlayerRelatesViewModel CreatePlayerRelates(PlayerView view)
    {
        var relates = AppService.GetService<IPlayerRelatesViewModel>();
        relates.SetData(view.Relates);
        return relates;
    }

    public IPlayerReplysViewModel CreatePlayerReplays(
        MainReplyList data,
        long view,
        ReplyOrderEnum OrderBy,
        CommentType type
    )
    {
        var relates = AppService.GetService<IPlayerReplysViewModel>();
        relates.SetData(new(data, view, OrderBy, type));
        return relates;
    }

    public IPlayerPagesModel CreatePlayerPages(PlayerView view, long space = 0)
    {
        var relates = AppService.GetService<IPlayerPagesModel>();
        relates.SetData(new(view));
        relates.SpaceCid = space;
        return relates;
    }

    public IBiliStartNotifyViewModel CreateNotifyIconViewModel(object data)
    {
        var relates = AppService.GetService<IBiliStartNotifyViewModel>();
        relates.SetData(data);
        return relates;
    }

    public ITokenItemViewModel CreateTokenItemViewModel(AccountToken token, string path)
    {
        var relates = AppService.GetService<ITokenItemViewModel>();
        relates.SetData(new(token, path));
       
        return relates;
    }

    public ILiveTagViewModel CreateLiveTagViewModel(LiveTagList model)
    {
        var relates = AppService.GetService<ILiveTagViewModel>();
        relates.SetData(model);
        return relates;
    }


    public IBIliChatViewModel CreateBiliChatViewModel()
    {

        var relates = AppService.GetService<IBIliChatViewModel>();
        relates.SetData(null);
        return relates;
    }

    public async Task<ILiveTagItemViewModel> CreateLiveTagItemViewModel(LiveTagAreaList liveTagAreaList)
    {
        ILiveTagItemViewModel relates = AppService.GetService<ILiveTagItemViewModel>();
        await relates.RefershDataAsync(liveTagAreaList);
        return relates;
    }

    public ILauncherLoginViewModel CreateLauncherLoginViewModel()
        => AppService.GetService<ILauncherLoginViewModel>();
}
