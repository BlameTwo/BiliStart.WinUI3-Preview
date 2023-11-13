using BiliStart.WinUI3.UI.Controls.Base;
using IAppContracts.ItemsViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections;
using System.Diagnostics;

namespace BiliStart.WinUI3.UI.Controls;

/// <summary>
/// 弹性布局列表控件，不包含选中事件和选中项目
/// </summary>
[TemplatePart(Name = "PART_ItemsRepeater", Type = typeof(ItemsRepeater))]
public partial class AdaptiveView : ItemControlBase
{
    public AdaptiveView()
    {
        this.DefaultStyleKey = typeof(AdaptiveView);
    }

    private ItemsRepeater _repeater = null;

    internal ItemsRepeater ItemsPresenter
    {
        get => _repeater;
        set
        {
            _repeater = value;
            this.ChangedItemsRepeater();
        }
    }

    #region 依赖属性


    public object Header
    {
        get { return (object)GetValue(HeaderProperty); }
        set { SetValue(HeaderProperty, value); }
    }

    public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
        "Header",
        typeof(object),
        typeof(AdaptiveView),
        new PropertyMetadata(default)
    );

    public ItemCollectionTransitionProvider ItemTransitionProvider
    {
        get { return (ItemCollectionTransitionProvider)GetValue(ItemTransitionProviderProperty); }
        set { SetValue(ItemTransitionProviderProperty, value); }
    }

    public static readonly DependencyProperty ItemTransitionProviderProperty =
        DependencyProperty.Register(
            "ItemTransitionProvider",
            typeof(ItemCollectionTransitionProvider),
            typeof(AdaptiveView),
            new PropertyMetadata(null)
        );


    public DataTemplate ItemTemplate
    {
        get { return (DataTemplate)GetValue(ItemTemplateProperty); }
        set { SetValue(ItemTemplateProperty, value); }
    }

    public static readonly DependencyProperty ItemTemplateProperty = DependencyProperty.Register(
        "ItemTemplate",
        typeof(DataTemplate),
        typeof(AdaptiveView),
        new PropertyMetadata(null)
    );

    public UniformGridLayout UniformGridLayout
    {
        get { return (UniformGridLayout)GetValue(UniformGridLayoutProperty); }
        set { SetValue(UniformGridLayoutProperty, value); }
    }

    // Using a DependencyProperty as the backing store for UniformGridLayout.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty UniformGridLayoutProperty =
        DependencyProperty.Register(
            "UniformGridLayout",
            typeof(UniformGridLayout),
            typeof(AdaptiveView),
            new PropertyMetadata(null)
        );

    public StackLayout StackLayout
    {
        get { return (StackLayout)GetValue(StackLayoutProperty); }
        set { SetValue(StackLayoutProperty, value); }
    }

    // Using a DependencyProperty as the backing store for StackLayout.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty StackLayoutProperty = DependencyProperty.Register(
        "StackLayout",
        typeof(StackLayout),
        typeof(AdaptiveView),
        new PropertyMetadata(null)
    );

    /// <summary>
    /// 最小宽度的水平阈值
    /// </summary>
    public double MinItemVerticalValue
    {
        get { return (double)GetValue(MinItemVerticalValueProperty); }
        set { SetValue(MinItemVerticalValueProperty, value); }
    }
    public static readonly DependencyProperty MinItemVerticalValueProperty =
        DependencyProperty.Register(
            "MinItemVerticalValue",
            typeof(double),
            typeof(AdaptiveView),
            new PropertyMetadata(500.00)
        );

    /// <summary>
    /// 是否允许打开动态监测,默认为不打开
    /// </summary>
    public bool OpenVerticalChanged
    {
        get { return (bool)GetValue(OpenVerticalChangedProperty); }
        set { SetValue(OpenVerticalChangedProperty, value); }
    }

    public static readonly DependencyProperty OpenVerticalChangedProperty =
        DependencyProperty.Register(
            "OpenVerticalChanged",
            typeof(bool),
            typeof(AdaptiveView),
            new PropertyMetadata(false)
        );

    /// <summary>
    /// 在不开启动态检测的的情况下，使用的布局方式，如果要开启，请关闭
    /// </summary>
    public Orientation ItemOrientation
    {
        get { return (Orientation)GetValue(ItemOrientationProperty); }
        set { SetValue(ItemOrientationProperty, value); }
    }

    public static readonly DependencyProperty ItemOrientationProperty = DependencyProperty.Register(
        "ItemOrientation",
        typeof(Orientation),
        typeof(AdaptiveView),
        new PropertyMetadata(Orientation.Horizontal)
    );
    #endregion

    protected override void OnApplyTemplate()
    {
        _repeater = (ItemsRepeater)this.GetTemplateChild("PART_ItemsRepeater");
        _repeater.ElementPrepared += _repeater_ElementPrepared;
        _repeater.SizeChanged += _repeater_SizeChanged;
        ChangDefaultLayout();
        base.OnApplyTemplate();
    }

    private void _repeater_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        ItemSizeChanged();
    }

    public virtual void ItemSizeChanged()
    {
        ChangLayoutItem();
    }

    private void _repeater_ElementPrepared(
        ItemsRepeater sender,
        ItemsRepeaterElementPreparedEventArgs args
    )
    {
        ChangLayoutItem();
    }

    public override void ChangedViewer()
    {

    }

    public virtual void ChangedItemsRepeater()
    {

    }
}
