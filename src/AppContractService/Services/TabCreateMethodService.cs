using Bilibili.App.Playerunite.V1;
using IAppContracts.TabViewContract;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace AppContractService.Services;

public class TabCreateMethodService : ITabCreateMethodService
{
    public TabCreateMethodService(
        ITabViewService tabViewService,
        ITabUserControlService tabUserControlService
    )
    {
        TabViewService = tabViewService;
        TabUserControlService = tabUserControlService;
    }

    public ITabViewService TabViewService { get; }
    public ITabUserControlService TabUserControlService { get; }

    public void GoAccountSpace(long mid)
    {
        string key = $"{typeof(ViewModels.AppTabViewModels.AccountSpaceViewModel).FullName}+{mid}";
        TabViewService.GoToView(
            new(
                typeof(ViewModels.AppTabViewModels.AccountSpaceViewModel).FullName,
                "Up主空间",
                true,
                "\uE1A6",
                key
            ),
            mid
        );
    }

    public void GoNavigationPlayer(VideoPlayerArgs player)
    {
        string key = $"{typeof(ViewModels.AppTabViewModels.PlayerViewModel).FullName}+{player.Aid}";

        TabViewService.GoToView(
            new(
                typeof(ViewModels.AppTabViewModels.PlayerViewModel).FullName,
                "视频播放",
                true,
                "\uE116",
                key
            ),
            player
        );
    }

    public void GoNavigationPgcPlayer(long SMID)
    {
        string key = $"{typeof(ViewModels.AppTabViewModels.PgcPlayerViewModel).FullName}+{SMID}";
        TabViewService.GoToView(
            new(
                typeof(ViewModels.AppTabViewModels.PgcPlayerViewModel).FullName,
                "流媒体播放",
                true,
                "\uF131",
                key
            ),
            SMID
        );
    }

    public void GoNavigationSearch(string keyword)
    {
        string key = $"{typeof(ViewModels.AppTabViewModels.SearchViewModel).FullName}+{keyword}";
        TabViewService.GoToView(
            new(
                typeof(ViewModels.AppTabViewModels.SearchViewModel).FullName,
                "搜索",
                true,
                "\uE11A",
                key
            ),
            keyword
        );
    }

    public void GoAccountHistory()
    {
        string key = $"{typeof(ViewModels.AppTabViewModels.AccountHistoryViewModel).FullName}";
        TabViewService.GoToView(
            new(
                typeof(ViewModels.AppTabViewModels.AccountHistoryViewModel).FullName,
                "历史记录",
                true,
                "\uEC92",
                key
            ),
            null
        );
    }

    public void GoLiveTagTab()
    {
        string key = $"{typeof(ViewModels.AppTabViewModels.LiveTagViewModel).FullName}";
        TabViewService.GoToView(new(key, "直播标签", true, "\uF6BA", key));
    }

    public void GoLivePlayer(long Roomid)
    {
        string key = $"{typeof(ViewModels.AppTabViewModels.LivePlayerViewModel).FullName}+{Roomid}";
        TabViewService.GoToView(
            new(
                typeof(ViewModels.AppTabViewModels.LivePlayerViewModel).FullName,
                Roomid.ToString() + "的房间",
                true,
                "\uF71E",
                key
            ),
            Roomid
        );
    }

    public void GoMyDynamic()
    {
        string key = $"{typeof(ViewModels.AppTabViewModels.AccountDynamicViewModel).FullName}";
        TabViewService.GoToView(new(key, "我的动态", true, "\uEC80", key));
    }
}
