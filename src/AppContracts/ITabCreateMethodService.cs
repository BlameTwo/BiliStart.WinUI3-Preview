using App.Models;
using App.Models.MediaPlayerArgs;


namespace IAppContracts;

/// <summary>
/// 0.0.5 新增API
/// </summary>
public interface ITabCreateMethodService
{
    public void GoAccountSpace(long mid);

    public void GoNavigationPlayer(VideoPlayerArgs player);

    public void GoNavigationPgcPlayer(long SMID);

    public void GoNavigationSearch(string keyword);

    public void GoAccountHistory();

    public void GoLiveTagTab();


    public void GoLivePlayer(long Roomid);


    public void GoMyDynamic();
}
