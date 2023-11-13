using App.Models;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;

namespace IAppContracts;

public interface INavigationService
{
    /// <summary>
    /// 导航
    /// </summary>
    /// <param name="typeEnum">导航对象</param>
    /// <param name="pagekey"></param>
    /// <param name="parameter"></param>
    /// <param name="clearnavigation"></param>
    /// <returns></returns>
    bool NavigationTo(string pagekey, object? parameter = null, bool clearnavigation = false);

    /// <summary>
    /// 对一个导航对象进行回退操作
    /// </summary>
    /// <param name="typeEnum"></param>
    /// <returns></returns>
    void GoBack();

    /// <summary>
    /// 对一个导航对象进行一个前进操作
    /// </summary>
    /// <param name="typeEnum"></param>
    /// <returns></returns>
    void GoForward();

    /// <summary>
    /// 根导航事件
    /// </summary>
    event NavigatedEventHandler NavigatedEvent;

    /// <summary>
    /// App导航是否支持回退
    /// </summary>
    bool? CanBack { get; }

    /// <summary>
    /// 综合Frame
    /// </summary>
    Frame? BaseFrame { get; set; }
}
