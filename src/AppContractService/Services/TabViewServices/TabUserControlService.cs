using App.Models.AppTabView;
using AppContractService;
using IAppContracts.TabViewContract;
using ViewModels.AppTabViewModels;
using Views.TabViews;

namespace AppServices;

public class TabUserControlService : ITabUserControlService
{
    public TabUserControlService()
    {
        tabitemsvalue = new();
        this.Register<MainControlView, ViewModels.AppTabViewModels.MainViewModel>();
        this.Register<AccountSpaceControlView, ViewModels.AppTabViewModels.AccountSpaceViewModel>();
        this.Register<Views.TabViews.PlayerControlView, ViewModels.AppTabViewModels.PlayerViewModel>();
        this.Register<Views.TabViews.PgcPlayerControlView, ViewModels.AppTabViewModels.PgcPlayerViewModel>();
        this.Register<Views.TabViews.SearchControlView,ViewModels.AppTabViewModels.SearchViewModel>();
        this.Register<Views.TabViews.AccountHistoryControlView, ViewModels.AppTabViewModels.AccountHistoryViewModel>();
        this.Register<Views.TabViews.LiveTagControlView,ViewModels.AppTabViewModels.LiveTagViewModel>();
        this.Register<Views.TabViews.LivePlayerControlView,ViewModels.AppTabViewModels.LivePlayerViewModel>();
        this.Register<Views.TabViews.AccountDynamicControlView,ViewModels.AppTabViewModels.AccountDynamicViewModel>();
    }

    public void Register<V, ViewModel>()
        where V : TabViewItemControl<ViewModel>
        where ViewModel:class
    {
        lock (tabitemsvalue)
        {
            if (tabitemsvalue.ContainsKey(typeof(ViewModel).FullName))
            {
                return;
            }
            tabitemsvalue.Add(typeof(ViewModel).FullName, new(typeof(V), typeof(ViewModel)));
        }
    }

    public object AddViewControl(string key,object paramter=null)
    {
        Tuple<Type, Type> value = null;
        if (!tabitemsvalue.TryGetValue(key, out value))
            return null;
        var pageview = AppService.GetService(value.Item1);
        var pageviewmodel = AppService.GetService(value.Item2);
        if (pageview is ITabModel)
        {
            (pageview as ITabModel).RegisterViewModel(pageviewmodel);
            (pageview as ITabModel).GoParamter(paramter);
        }
        return pageview;
    }

    Dictionary<string, Tuple<Type, Type>> tabitemsvalue = null;
}
