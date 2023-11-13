using Microsoft.UI.Xaml.Controls;

namespace IAppContracts.ItemsViewModels;

/// <summary>
/// 可以动态调整Item样式的基类
/// </summary>
public interface IDynamicItemOrientation
{
    /// <summary>
    /// 根据布局方式更换样式
    /// </summary>
    void ChangedOrientation(Orientation orientation);
}
