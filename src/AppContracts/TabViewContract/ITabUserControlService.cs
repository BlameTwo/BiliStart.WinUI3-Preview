using App.Models.AppTabView;

namespace IAppContracts.TabViewContract;

public interface ITabUserControlService
{
    public void Register<V, ViewModel>()
        where V : TabViewItemControl<ViewModel>
        where ViewModel : class;

    public object AddViewControl(string key, object paramter=null);
}
