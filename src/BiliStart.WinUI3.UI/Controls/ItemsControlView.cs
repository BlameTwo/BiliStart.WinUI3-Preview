using BiliStart.WinUI3.UI.Controls.Base;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Animation;

namespace BiliStart.WinUI3.UI.Controls;

/// <summary>
/// 简单的一个能够使用ItemsPanel大的布局容器，主要应对瀑布流布局
/// </summary>
public sealed class ItemsControlView : ItemControlBase
{
    public DataTemplateSelector DataTemplateSelecter
    {
        get { return (DataTemplateSelector)GetValue(DataTemplateSelecterProperty); }
        set { SetValue(DataTemplateSelecterProperty, value); }
    }

    public static readonly DependencyProperty DataTemplateSelecterProperty =
        DependencyProperty.Register(
            "DataTemplateSelecter",
            typeof(DataTemplateSelector),
            typeof(ItemsControlView),
            new PropertyMetadata(null)
        );

    public TransitionCollection ThransitionCollection
    {
        get { return (TransitionCollection)GetValue(ThransitionCollectionProperty); }
        set { SetValue(ThransitionCollectionProperty, value); }
    }

    // Using a DependencyProperty as the backing store for ThransitionCollection.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty ThransitionCollectionProperty =
        DependencyProperty.Register(
            "ThransitionCollection",
            typeof(TransitionCollection),
            typeof(ItemsControlView),
            new PropertyMetadata(default)
        );

    public DataTemplate ItemTemplate
    {
        get { return (DataTemplate)GetValue(ItemTemplateProperty); }
        set { SetValue(ItemTemplateProperty, value); }
    }

    // Using a DependencyProperty as the backing store for ItemTemplate.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty ItemTemplateProperty = DependencyProperty.Register(
        "ItemTemplate",
        typeof(DataTemplate),
        typeof(ItemControlBase),
        new PropertyMetadata(null)
    );

    public ItemsPanelTemplate ItemsPanel
    {
        get { return (ItemsPanelTemplate)GetValue(ItemsPanelProperty); }
        set { SetValue(ItemsPanelProperty, value); }
    }

    public static readonly DependencyProperty ItemsPanelProperty = DependencyProperty.Register(
        "ItemsPanel",
        typeof(ItemsPanelTemplate),
        typeof(ItemsControlView),
        new PropertyMetadata(default)
    );

    public override void ChangedViewer()
    {
    }
}
