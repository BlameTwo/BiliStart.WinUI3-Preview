using App.Models;
using Microsoft.UI.Input;
using Microsoft.UI.Xaml;
using Microsoft.Xaml.Interactivity;
using System.Diagnostics;
using System.Windows.Input;

namespace BiliStart.WinUI3.UI.Behaviors;

/// <summary>
/// 绑定当前UI页面的鼠标输入 行为器
/// </summary>
public class MouseParseBindingBehavior : Behavior<FrameworkElement>
{
    protected override void OnAttached()
    {
#if DEBUG
        Debug.WriteLine($"加载行为{typeof(MouseParseBindingBehavior)}");
#endif
        this.AssociatedObject.PointerPressed += AssociatedObject_PointerPressed;
    }

    private void AssociatedObject_PointerPressed(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
    {
        //获得当前对象的鼠标输入（首先是鼠标在对象之上
        PointerPoint point = e.GetCurrentPoint(this.AssociatedObject);
        if (CheckBinding(point))
        {
            MouseCommand.Execute(point);
        }
    }

    /// <summary>
    /// 检查是否能够触发
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    private bool CheckBinding(PointerPoint point)
    {
        if (MouseType == MouseEnum.XButton1 && point.Properties.IsXButton1Pressed)
            return true;
        else if (MouseType == MouseEnum.XButton2 && point.Properties.IsXButton2Pressed)
            return true;
        else if (MouseType == MouseEnum.LeftButton && point.Properties.IsLeftButtonPressed)
            return true;
        else if (MouseType == MouseEnum.RightButton && point.Properties.IsRightButtonPressed)
            return true;
        return false;
    }

    protected override void OnDetaching()
    {
#if DEBUG
        Debug.WriteLine($"移除行为{typeof(MouseParseBindingBehavior)}");
#endif
        this.AssociatedObject.PointerPressed -= AssociatedObject_PointerPressed;
    }



    public MouseEnum MouseType
    {
        get { return (MouseEnum)GetValue(MouseTypeProperty); }
        set { SetValue(MouseTypeProperty, value); }
    }

    public static readonly DependencyProperty MouseTypeProperty =
        DependencyProperty.Register("MouseType", typeof(MouseEnum), typeof(MouseParseBindingBehavior), new PropertyMetadata(null));



    public ICommand MouseCommand
    {
        get { return (ICommand)GetValue(MouseCommandProperty); }
        set { SetValue(MouseCommandProperty, value); }
    }

    public static readonly DependencyProperty MouseCommandProperty =
        DependencyProperty.Register("MouseCommand", typeof(ICommand), typeof(MouseParseBindingBehavior), new PropertyMetadata(null));



    public object MouseCommandParameter
    {
        get { return (object)GetValue(MouseCommandParameterProperty); }
        set { SetValue(MouseCommandParameterProperty, value); }
    }

    public static readonly DependencyProperty MouseCommandParameterProperty =
        DependencyProperty.Register("MouseCommandParameter", typeof(object), typeof(MouseParseBindingBehavior), new PropertyMetadata(default));


}
