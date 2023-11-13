using App.Models;
using App.Models.AppTabView;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Reflection.PortableExecutable;

namespace IAppContracts.TabViewContract;

public interface ITabViewService
{
    public void RegisterView(TabView view);

    /// <summary>
    /// 导航到某个视图
    /// </summary>
    /// <param name="key">钥匙</param>
    /// <param name="paramter">参数</param>
    public void GoToView(TabViewArgs key, object paramter = null);
    public void AddItemView(TabViewItem tabViewItem);

    /// <summary>
    /// 更新标题
    /// </summary>
    /// <param name="key"></param>
    /// <param name="newHeader"></param>
    /// <returns></returns>
    public bool UpDateTitle(string key,string newHeader);

    /// <summary>
    /// 更新状态
    /// </summary>
    /// <param name="key"></param>
    /// <param name="visibility"></param>
    public void UpDateProgressRing(string key, Visibility visibility);

    /// <summary>
    /// 更新Icon图标
    /// </summary>
    /// <param name="key"></param>
    /// <param name="source"></param>
    public void UpDateIcon(string key, IconSource source);
}
