using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Markup;
using System;
using System.Diagnostics;
using Windows.ApplicationModel.DataTransfer;
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
    private MenuFlyout textfly;
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
        this.textfly = (MenuFlyout)GetTemplateChild("TextFlyout");
        InitUI();
    }

    private void InitUI()
    {
        var copy = new MenuFlyoutItem() { Text = "复制", Command = Copy, KeyboardAcceleratorTextOverride = "Ctrl + C", Icon = new SymbolIcon { Symbol = Symbol.Copy } };
        var paste = new MenuFlyoutItem() { Text = "粘贴", Command = Paste, KeyboardAcceleratorTextOverride = "Ctrl + V", Icon = new SymbolIcon { Symbol = Symbol.Paste } };
        var cut = new MenuFlyoutItem() { Text = "剪切", Command = Cut, KeyboardAcceleratorTextOverride = "Ctrl + X", Icon = new SymbolIcon { Symbol = Symbol.Cut } };
        textfly.Items.Add(copy); textfly.Items.Add(paste); textfly.Items.Add(cut);
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



    public  IRelayCommand Copy => new RelayCommand(() =>
    {
        copy();
    });


    public  IRelayCommand Paste => new RelayCommand(() =>
    {
        paste();
    });

    public IRelayCommand Cut => new RelayCommand(() =>
    {
        cut();
    });

    private  void copy()
    {
        try
        {
            DataPackage dataPackage = new DataPackage();
            dataPackage.SetText(_textContent.SelectedText);
            dataPackage.RequestedOperation = DataPackageOperation.Copy;
            Clipboard.SetContent(dataPackage);
        }
        catch (OutOfMemoryException)
        {
            return;
        }
    }

    private  async void paste()
    {
        try
        {
            DataPackageView dataPackageView = Clipboard.GetContent();
            if (dataPackageView.Contains(StandardDataFormats.Text))
            {
                string text = null;
                try
                {
                    text = await dataPackageView.GetTextAsync();
                    _textContent.Text += text;
                }
                catch (Exception ex) //When longer holding Ctrl + V the clipboard may throw an exception:
                {
                    Debug.WriteLine("Clipboard exception: " + ex.Message);
                    return;
                }
            }
        }
        catch (OutOfMemoryException)
        {

        }
    }

    private void cut(bool handleException = true)
    {
        try
        {
            DataPackage dataPackage = new DataPackage();
            dataPackage.SetText(_textContent.SelectedText);
            dataPackage.RequestedOperation = DataPackageOperation.Move;
            Clipboard.SetContent(dataPackage);
            _textContent.Text = _textContent.Text.Replace(_textContent.SelectedText, "");
        }
        catch (OutOfMemoryException)
        {
            
        }
    }
}
