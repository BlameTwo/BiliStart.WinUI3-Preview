namespace App.Models;

/// <summary>
/// 应用导航参数
/// </summary>
/// <typeparam name="T"></typeparam>
public class AppNavigationPageArgs
{
    public object ViewModel { get; set; }

    public object Paramter { get; set; }

    /// <summary>
    /// 在导航视图的控件上的参数
    /// </summary>
    public object ViewParamter { get; set; }
}
