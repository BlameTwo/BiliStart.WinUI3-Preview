using App.Models;
using Network.Models.Live;
using System.Threading.Tasks;

namespace IAppContracts;

public interface IRootNavigationMethod
{
    IWindowManager WindowManager { get; }

    public INavigationService RootNavigationService { get; }






    public void BackMain();
}
