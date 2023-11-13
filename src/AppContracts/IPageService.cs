using IAppExtension.Contract;
using System;

namespace IAppContracts;

public interface IPageService : IAppService
{
    Type GetPage(string key);

    object GetPageVM(string key);

    public void RegisterPlugin(Type view, string key);
}
