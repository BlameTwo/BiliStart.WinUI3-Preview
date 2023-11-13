using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;

namespace BiliStart.WinUI3.UI.Controls;

partial class DanmakuControl
{
    /// <summary>
    /// 弹幕透明度
    /// </summary>
    public double DanmakuOpacity
    {
        get { return (double)GetValue(DanmakuOpacityProperty); }
        set { SetValue(DanmakuOpacityProperty, value); }
    }

    public static readonly DependencyProperty DanmakuOpacityProperty = DependencyProperty.Register(
        "DanmakuOpacity",
        typeof(double),
        typeof(DanmakuControl),
        new PropertyMetadata(1.0)
    );

    /// <summary>
    /// 弹幕缩放
    /// </summary>
    public double DanmakuZoom
    {
        get { return (double)GetValue(DanmakuZoomProperty); }
        set { SetValue(DanmakuZoomProperty, value); }
    }

    // Using a DependencyProperty as the backing store for DanmakuZoom.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty DanmakuZoomProperty = DependencyProperty.Register(
        "DanmakuZoom",
        typeof(double),
        typeof(DanmakuControl),
        new PropertyMetadata(1.0)
    );

    /// <summary>
    /// 弹幕显示区域
    /// </summary>
    public double DanmakuArea
    {
        get { return (double)GetValue(DanmakuAreaProperty); }
        set { SetValue(DanmakuAreaProperty, value); }
    }

    // Using a DependencyProperty as the backing store for DanmakuArea.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty DanmakuAreaProperty = DependencyProperty.Register(
        "DanmakuArea",
        typeof(double),
        typeof(DanmakuControl),
        new PropertyMetadata(1.0)
    );

    /// <summary>
    /// 弹幕字体
    /// </summary>
    public FontFamily DanmakuFont
    {
        get { return (FontFamily)GetValue(DanmakuFontProperty); }
        set { SetValue(DanmakuFontProperty, value); }
    }

    // Using a DependencyProperty as the backing store for DanmakuFont.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty DanmakuFontProperty = DependencyProperty.Register(
        "DanmakuFont",
        typeof(FontFamily),
        typeof(DanmakuControl),
        new PropertyMetadata(new FontFamily("微软雅黑"))
    );

    /// <summary>
    /// 弹幕移动速度（秒）
    /// </summary>
    public int DanmakuDuration
    {
        get { return (int)GetValue(DanmakuDurationProperty); }
        set { SetValue(DanmakuDurationProperty, value); }
    }

    // Using a DependencyProperty as the backing store for DanmakuDuration.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty DanmakuDurationProperty = DependencyProperty.Register(
        "DanmakuDuration",
        typeof(int),
        typeof(DanmakuControl),
        new PropertyMetadata(7)
    );

    public bool IsOpen
    {
        get { return (bool)GetValue(IsOpenProperty); }
        set { SetValue(IsOpenProperty, value); }
    }

    // Using a DependencyProperty as the backing store for IsOpen.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty IsOpenProperty = DependencyProperty.Register(
        "IsOpen",
        typeof(bool),
        typeof(DanmakuControl),
        new PropertyMetadata(
            true,
            (s, e) =>
            {
                var obj = s as DanmakuControl;
                if ((bool)e.NewValue == false)
                {
                    obj._Bottom.Children.Clear();
                    obj._top.Children.Clear();
                    obj._Scroll.Children.Clear();
                    obj.ScrollStory.Clear();
                    obj.topbottomStory.Clear();
                }
            }
        )
    );
}
