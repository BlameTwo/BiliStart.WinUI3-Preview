using CommunityToolkit.WinUI.Controls;
using System.Collections;
using System.Collections.Generic;

namespace IAppContracts.SegmentedContract;

public interface ISegmentedNavigationView
{
    /// <summary>
    /// 注册容器
    /// </summary>
    /// <param name="control"></param>
    void RegisterView(Segmented control);

    void UnRegisterView();

    /// <summary>
    /// 获得当前导航控件的Item
    /// </summary>
    /// <returns></returns>
    IList<object> GetItems();


    public void NavigationPage(int index);

}
