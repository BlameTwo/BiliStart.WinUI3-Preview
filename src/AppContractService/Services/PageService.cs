/*
 2023.7.9
此类主要辅助NavigationService服务进行导航，其中包含V和所有的VM的Type类型。


通过Key反射获取Vm对象。
 */


using ViewModels;
using Views.AccountHistoryPages;

namespace AppContractService.Services;

public sealed class PageService : IPageService, IAppService
{
    public PageService()
    {
        Register<ShellPage, ShellViewModel>();
        Register<RootPage, RootViewModel>();
        Register<HomePage, HomeViewModel>();
        Register<SettingPage, SettingViewModel>();

        Register<PgcPage, PgcViewModel>();

        Register<LivePage, LiveViewModel>();

        #region 综合页面
        Register<TotalPage, TotalViewModel>();
        Register<RankPage, RankViewModel>();
        Register<HotPage, HotViewModel>();
        Register<MusicRankPage, MusicRankViewModel>();
        Register<SearchRankPage, SearchRankViewModel>();
        Register<HotHistoryPage, HotHistoryViewModel>();
        #endregion


        #region 更多页面
        Register<DownloadPage, DownloadViewModel>();
        #endregion

        Register<LauncherPage, LauncherViewModel>();

        #region 流媒体页面
        Register<MoviePage, ViewModels.PageViewModels.MovieViewModel>();
        #endregion

        Register<ViewTestPage, ViewTestViewModel>();

        Register<AboutPage, AboutViewModel>();



        #region 历史记录分页面
        Register<VideoHistoryPage, AccountHistoryVideoViewModel>();
        Register<LiveHistoryPage, LiveHistoryViewModel>();
        #endregion
    }

    private readonly Dictionary<string, Type> _keypages = new();

    public string ServiceID { get; set; } = nameof(PageService);

    /// <summary>
    /// 获得Page
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public Type GetPage(string key)
    {
        Type pagetype;
        lock (_keypages)
        {
            if (!_keypages.TryGetValue(key, out pagetype))
            {
                return null;
            }
        }
        return pagetype;
    }

    public void Register<V, VM>()
        where V : Page
    {
        lock (_keypages) //加锁
        {
            var key = typeof(VM).FullName;
            if (_keypages.ContainsKey(key))
            {
                throw new ArgumentException($"内容已增加{key}");
            }
            var type = typeof(V);
            if (_keypages.Any(x => x.Value == type))
            {
                throw new ArgumentException($"内容已存在{key}");
            }
            _keypages.Add(key, type);
        }
    }

    public void RegisterPlugin(Type view, string key)
    {
        lock (_keypages) //加锁
        {
            if (_keypages.ContainsKey(key) || _keypages.Any(x => x.Value == view))
            {
                return;
            }
            _keypages.Add(key, view);
        }
    }

    /// <summary>
    /// 获得VM
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public object GetPageVM(string key)
    {
        object obj = null;
        //通过程序集进行反射获取Type
        var list = AppDomain.CurrentDomain.GetAssemblies();
        foreach (var item in list)
        {
            if (item.FullName.StartsWith("ViewModels"))
            {
                var type = item.GetType(key);
                if (type == null)
                    continue;
                obj = AppService.GetService(type);
            }
        }
        return obj;
    }
}
