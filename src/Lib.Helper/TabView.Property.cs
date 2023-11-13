using CommunityToolkit.WinUI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using System;

namespace Lib.Helper;

public class TabView
{

    #region 头部进度条
    public static Visibility GetTabProgressRingAction(DependencyObject obj)
    {
        return (Visibility)obj.GetValue(TabProgressRingActionProperty);
    }

    public static void SetTabProgressRingAction(DependencyObject obj, Visibility value)
    {
        obj.SetValue(TabProgressRingActionProperty, value);
    }

    public static readonly DependencyProperty TabProgressRingActionProperty =
        DependencyProperty.RegisterAttached(
            "TabProgressRingAction",
            typeof(Visibility),
            typeof(TabView),
            new PropertyMetadata(Visibility.Visible, OnProgressRingVisibility)
        );

    private static void OnProgressRingVisibility(
        DependencyObject d,
        DependencyPropertyChangedEventArgs e
    )
    {
        if (d is TabViewItem)
        {
            var result = ElementChildHelper.FindChildByName(d, "PARA_ProgressRing");
            if (result is ProgressRing ring)
            {
                ring.Visibility = (Visibility)e.NewValue;
            };
        }
    }
    #endregion
}
