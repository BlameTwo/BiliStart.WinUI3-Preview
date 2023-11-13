using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Markup;
using System;
using Windows.Devices.Enumeration;

namespace BiliStart.WinUI3.UI.Controls;

[TemplatePart(Name = "TextBoxCentent", Type = typeof(TextBox))]
[TemplatePart(Name = "PanelContent", Type = typeof(ContentPresenter))]
[ContentProperty(Name = nameof(PanelContent))]
[TemplateVisualState(GroupName = "PanelContentState", Name = "PanelShowState")]
[TemplateVisualState(GroupName = "PanelContentState", Name = "PanelHideState")]
[TemplatePart(Name = "TextFlyout",Type =typeof(TextCommandBarFlyout))]
public partial class SearchTextBoxPanel : Control
{
    public SearchTextBoxPanel()
    {
        this.DefaultStyleKey = typeof(SearchTextBoxPanel);
    }

    #region 依赖属性



    public Visibility ItemsVisibility
    {
        get { return (Visibility)GetValue(ItemsVisibilityProperty); }
        set { SetValue(ItemsVisibilityProperty, value); }
    }

    public static readonly DependencyProperty ItemsVisibilityProperty = DependencyProperty.Register(
        "ItemsVisibility",
        typeof(Visibility),
        typeof(SearchTextBoxPanel),
        new PropertyMetadata(Visibility.Collapsed)
    );

    public Visibility PanelVisibility
    {
        get { return (Visibility)GetValue(PanelVisibilityProperty); }
        set { SetValue(PanelVisibilityProperty, value); }
    }

    public static readonly DependencyProperty PanelVisibilityProperty = DependencyProperty.Register(
        "PanelVisibility",
        typeof(Visibility),
        typeof(SearchTextBoxPanel),
        new PropertyMetadata(Visibility.Visible)
    );

    public double PopupOffset
    {
        get { return (double)GetValue(PopupOffsetProperty); }
        set { SetValue(PopupOffsetProperty, value); }
    }

    public static readonly DependencyProperty PopupOffsetProperty = DependencyProperty.Register(
        "PopupOffset",
        typeof(double),
        typeof(SearchTextBoxPanel),
        new PropertyMetadata(0.0)
    );

    public object PanelContent
    {
        get { return (object)GetValue(PanelContentProperty); }
        set { SetValue(PanelContentProperty, value); }
    }

    public static readonly DependencyProperty PanelContentProperty = DependencyProperty.Register(
        "PanelContent",
        typeof(object),
        typeof(SearchTextBoxPanel),
        new PropertyMetadata(null)
    );

    public bool IsPanelShow
    {
        get { return (bool)GetValue(IsPanelShowProperty); }
        set { SetValue(IsPanelShowProperty, value); }
    }

    public static readonly DependencyProperty IsPanelShowProperty = DependencyProperty.Register(
        "IsPanelShow",
        typeof(bool),
        typeof(SearchTextBoxPanel),
        new PropertyMetadata(false, OnPanelShowChanged)
    );

    public object ItemsSource
    {
        get { return (object)GetValue(ItemsSourceProperty); }
        set { SetValue(ItemsSourceProperty, value); }
    }

    public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(
        "ItemsSource",
        typeof(object),
        typeof(SearchTextBoxPanel),
        new PropertyMetadata(null)
    );

    #endregion

    #region 私有变量
    private TextBox _textContent;
    private ContentPresenter _flyoutPresenter;
    private TextCommandBarFlyout textfly;
    #endregion


    private static void OnPanelShowChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (e.NewValue is bool val && d is SearchTextBoxPanel panel)
        {
            panel.ChangShowPanel(val);
        }
    }

    internal void ChangShowPanel(bool value)
    {
        if (value)
        {
            VisualStateManager.GoToState(this, "PanelShowState", false);
        }
        else
        {
            VisualStateManager.GoToState(this, "PanelHideState", false);
        }
    }

    protected override void OnApplyTemplate()
    {
        this._textContent = (TextBox)GetTemplateChild("TextBoxCentent");
        this._flyoutPresenter = (ContentPresenter)GetTemplateChild("PanelContent");
        _textContent.GettingFocus += _textContent_GettingFocus;
        _textContent.LostFocus += _textContent_LostFocus;
        this.SizeChanged += SearchTextBoxPanel_SizeChanged;
        this.textfly = (TextCommandBarFlyout)GetTemplateChild("TextFlyout");
    }

    private void SearchTextBoxPanel_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        this.PopupOffset = (this.ActualWidth / 2) - _flyoutPresenter.ActualWidth / 2;
    }

    private void _textContent_LostFocus(object sender, RoutedEventArgs e)
    {
        this.IsPanelShow = false;
    }

    private void _textContent_GettingFocus(
        UIElement sender,
        Microsoft.UI.Xaml.Input.GettingFocusEventArgs args
    )
    {
        this.PopupOffset = (this.ActualWidth / 2) - _flyoutPresenter.ActualWidth / 2;
        this.IsPanelShow = true;
    }
}
