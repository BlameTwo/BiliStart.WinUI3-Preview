using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AppContractService.Services;

public sealed class AppProtocolSetupService : IAppProtocolSetupService
{
    Uri _uri = null;

    public bool Check() => this._uri != null;

    public void Invoke()
    {
        if (_uri == null)
            return;

        var navmethod = AppService.GetService<ITabCreateMethodService>();
        var scheme = _uri.Scheme;
        var query = _uri.Query;
        var queryParameters = System.Web.HttpUtility.ParseQueryString(query);
        AppService
            .GetService<IWindowManager>()
            .TryDispatcherAction(() =>
            {
                if (_uri.Authority == "video")
                {
                    VideoPlayerArgs args = new();
                    var seval = _uri.Segments[1];
                    var cid = queryParameters["cid"];
                    if (cid != null)
                    {
                        args.SpaceCid = long.Parse(cid);
                    }
                    args.Aid = long.Parse(seval);
                    AppService.GetService<IWindowManager>().TryDispatcherAction(() =>
                    {
                        navmethod.GoNavigationPlayer(args);
                    });
                }
                else if (_uri.Authority == "search")
                {
                    foreach (var item in queryParameters.AllKeys)
                    {
                        if (item == "keyword")
                            navmethod.GoNavigationSearch(queryParameters[item]);
                    }
                }
                else if (_uri.Authority == "space")
                {

                }
                AppService.GetService<ILogger>().Information($"没有见过的Uri： {_uri.ToString()} ");
            });
    }

    public void Invoke(Uri uri)
    {
        this._uri = uri;
        Invoke();
    }

    public void SaveUri(Uri uri)
    {
        this._uri = uri;
    }
}
