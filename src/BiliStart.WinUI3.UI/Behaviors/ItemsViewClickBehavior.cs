using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Xaml.Interactivity;
using System.Diagnostics;

namespace BiliStart.WinUI3.UI.Behaviors;

/// <summary>
/// 解耦 DataTemplate与VM之间的 Event 调用矛盾
/// </summary>
public class ItemsViewClickBehavior:Behavior<ItemsView>
{
    protected override void OnAttached()
    {
        if (this.AssociatedObject.SelectionMode != ItemsViewSelectionMode.None  && !this.AssociatedObject.IsItemInvokedEnabled)
        {
#if DEBUG
            Debug.WriteLine("ItemsView属性不正确，此转换器仅支持对选择模式为None和打开ItemClick的ItemsView使用");
#endif
            return;
        }
#if DEBUG
        Debug.WriteLine("ItemsViewClickBehavior 行为 加载完毕");
#endif
        this.AssociatedObject.ItemInvoked += AssociatedObject_ItemInvoked;
    }

    protected override void OnDetaching()
    {
#if DEBUG
        Debug.WriteLine("ItemsViewClickBehavior 行为 卸载完毕");
#endif
    }

    private void AssociatedObject_ItemInvoked(ItemsView sender, ItemsViewItemInvokedEventArgs args)
    {
        if (args.InvokedItem == null)
            return;
        this.ItemClickCommand.Execute(args.InvokedItem);
    }

    public IRelayCommand<object> ItemClickCommand
    {
        get { return (IRelayCommand<object>)GetValue(ItemClickCommandProperty); }
        set { SetValue(ItemClickCommandProperty, value); }
    }

    public static readonly DependencyProperty ItemClickCommandProperty =
        DependencyProperty.Register("ItemClickCommand", typeof(IRelayCommand<object>), typeof(ItemsViewClickBehavior), new PropertyMetadata(null));

}
