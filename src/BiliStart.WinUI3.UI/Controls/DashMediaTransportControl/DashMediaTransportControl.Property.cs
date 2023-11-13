using App.Models.Enum;
using CommunityToolkit.Mvvm.Input;
using IAppContracts.Controls;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Network.Models.Videos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BiliStart.WinUI3.UI.Controls;

partial class DashMediaTransportControl
{
    #region 控件私有变量
    Button _startbth;
    MenuFlyoutItem maxbth,
        topbth = null;
    ListView _qualityListView,
        _spendListview;
    Slider _progressSlider;
    ToggleButton toggleButton = null;

    #endregion

    public List<double> SpendList
    {
        get { return (List<double>)GetValue(SpendListProperty); }
        set { SetValue(SpendListProperty, value); }
    }

    public static readonly DependencyProperty SpendListProperty = DependencyProperty.Register(
        "SpendList",
        typeof(List<double>),
        typeof(DashMediaTransportControl),
        new PropertyMetadata(null)
    );

    public TimeSpan NowProgress
    {
        get { return (TimeSpan)GetValue(NowProgressProperty); }
        set { SetValue(NowProgressProperty, value); }
    }

    public static readonly DependencyProperty NowProgressProperty = DependencyProperty.Register(
        "NowProgress",
        typeof(TimeSpan),
        typeof(DashMediaTransportControl),
        new PropertyMetadata(0.0)
    );

    /// <summary>
    /// 清晰度列表
    /// </summary>
    public object QualityList
    {
        get { return (object)GetValue(QualityListProperty); }
        set { SetValue(QualityListProperty, value); }
    }

    public static readonly DependencyProperty QualityListProperty = DependencyProperty.Register(
        "QualityList",
        typeof(object),
        typeof(DashMediaTransportControl),
        new PropertyMetadata(default)
    );

    public DataTemplate QualityDataTemplate
    {
        get { return (DataTemplate)GetValue(QualityDataTemplateProperty); }
        set { SetValue(QualityDataTemplateProperty, value); }
    }
    public static readonly DependencyProperty QualityDataTemplateProperty =
        DependencyProperty.Register(
            "QualityDataTemplate",
            typeof(DataTemplate),
            typeof(DashMediaTransportControl),
            new PropertyMetadata(null)
        );

    /// <summary>
    /// 最大化屏幕的命令（对外开放
    /// </summary>
    public ICommand MaxScreen
    {
        get { return (ICommand)GetValue(MaxScreenProperty); }
        set { SetValue(MaxScreenProperty, value); }
    }

    public static readonly DependencyProperty MaxScreenProperty = DependencyProperty.Register(
        "MaxScreen",
        typeof(ICommand),
        typeof(DashMediaTransportControl),
        new PropertyMetadata(null)
    );

    public object QualitySelectItem
    {
        get { return (object)GetValue(QualitySelectItemProperty); }
        set { SetValue(QualitySelectItemProperty, value); }
    }

    // Using a DependencyProperty as the backing store for QualitySelectItem.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty QualitySelectItemProperty =
        DependencyProperty.Register(
            "QualitySelectItem",
            typeof(object),
            typeof(DashMediaTransportControl),
            new PropertyMetadata(null)
        );

    public string StartGlyph
    {
        get { return (string)GetValue(StartGlyphProperty); }
        set { SetValue(StartGlyphProperty, value); }
    }

    public static readonly DependencyProperty StartGlyphProperty = DependencyProperty.Register(
        "StartGlyph",
        typeof(string),
        typeof(DashMediaTransportControl),
        new PropertyMetadata("\uE102")
    );

    public double MaxSliderValue
    {
        get { return (double)GetValue(MaxSliderValueProperty); }
        set { SetValue(MaxSliderValueProperty, value); }
    }

    // Using a DependencyProperty as the backing store for MaxSliderValue.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty MaxSliderValueProperty = DependencyProperty.Register(
        "MaxSliderValue",
        typeof(double),
        typeof(DashMediaTransportControl),
        new PropertyMetadata(0.0)
    );

    public string MaxContent
    {
        get { return (string)GetValue(MaxContentProperty); }
        set { SetValue(MaxContentProperty, value); }
    }

    // Using a DependencyProperty as the backing store for MaxContent.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty MaxContentProperty = DependencyProperty.Register(
        "MaxContent",
        typeof(string),
        typeof(DashMediaTransportControl),
        new PropertyMetadata("\uE1D9")
    );

    public string TopContent
    {
        get { return (string)GetValue(TopContentProperty); }
        set { SetValue(TopContentProperty, value); }
    }

    // Using a DependencyProperty as the backing store for TopContent.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty TopContentProperty = DependencyProperty.Register(
        "TopContent",
        typeof(string),
        typeof(DashMediaTransportControl),
        new PropertyMetadata("\uEA3A")
    );

    public bool IsFull
    {
        get { return (bool)GetValue(IsFullProperty); }
        set { SetValue(IsFullProperty, value); }
    }

    // Using a DependencyProperty as the backing store for IsFull.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty IsFullProperty = DependencyProperty.Register(
        "IsFull",
        typeof(bool),
        typeof(DashMediaTransportControl),
        new PropertyMetadata(
            false,
            (s, e) =>
            {
                var obj = (s as DashMediaTransportControl);
                if ((bool)e.NewValue)
                {
                    obj.MaxContent = "\uE1D8";
                    obj.IsTop = false;
                }
                else
                {
                    obj.MaxContent = "\uE1D9";
                }

                if (obj.MaxScreenClickHandle != null)
                    obj.MaxScreenClickHandle.Invoke(obj, (bool)e.NewValue);
            }
        )
    );

    public bool IsTop
    {
        get { return (bool)GetValue(IsTopProperty); }
        set { SetValue(IsTopProperty, value); }
    }

    public static readonly DependencyProperty IsTopProperty = DependencyProperty.Register(
        "IsTop",
        typeof(bool),
        typeof(DashMediaTransportControl),
        new PropertyMetadata(
            false,
            (s, e) =>
            {
                var obj = (s as DashMediaTransportControl);
                if ((bool)e.NewValue)
                {
                    obj.TopContent = "\uEA38";
                    obj.IsFull = false;
                }
                else
                {
                    obj.TopContent = "\uEA3A";
                }

                if (obj.TopScreenClickHandle != null)
                    obj.TopScreenClickHandle.Invoke(obj, (bool)e.NewValue);
            }
        )
    );

    public double ControlVolumn
    {
        get { return (double)GetValue(ControlVolumnProperty); }
        set { SetValue(ControlVolumnProperty, value); }
    }

    public static readonly DependencyProperty ControlVolumnProperty = DependencyProperty.Register(
        "ControlVolumn",
        typeof(double),
        typeof(DashMediaTransportControl),
        new PropertyMetadata(
            100,
            (s, e) =>
            {
                //计算占比
                if ((s as DashMediaTransportControl).MediaPlayer == null)
                    return;
                double newValue = (double)e.NewValue;
                double minValue = 1;
                double maxValue = 100;
                double mappedMinValue = 0;
                double mappedMaxValue = 1.0;
                double mappedValue =
                    mappedMinValue
                    + (mappedMaxValue - mappedMinValue)
                        * (newValue - minValue)
                        / (maxValue - minValue);
                (s as DashMediaTransportControl).MediaPlayer.Volume = (double)mappedValue;
            }
        )
    );

    public RelayCommand<bool> OpenDanmankuControlCommand
    {
        get { return (RelayCommand<bool>)GetValue(OpenDanmankuControlCommandProperty); }
        set { SetValue(OpenDanmankuControlCommandProperty, value); }
    }

    // Using a DependencyProperty as the backing store for OpenDanmankuControlComman.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty OpenDanmankuControlCommandProperty =
        DependencyProperty.Register(
            "OpenDanmankuControlComman",
            typeof(RelayCommand<bool>),
            typeof(DashMediaTransportControl),
            new PropertyMetadata(null)
        );

    public RelayCommand<double> DanmakuOpacityChangedCommand
    {
        get { return (RelayCommand<double>)GetValue(DanmakuOpacityChangedCommandProperty); }
        set { SetValue(DanmakuOpacityChangedCommandProperty, value); }
    }

    // Using a DependencyProperty as the backing store for DanmakuOpacityChangedCommand.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty DanmakuOpacityChangedCommandProperty =
        DependencyProperty.Register(
            "DanmakuOpacityChangedCommand",
            typeof(RelayCommand<double>),
            typeof(DashMediaTransportControl),
            new PropertyMetadata(null)
        );

    public RelayCommand<double> DanmakuSpendChangedCommand
    {
        get { return (RelayCommand<double>)GetValue(DanmakuSpendChangedCommandProperty); }
        set { SetValue(DanmakuSpendChangedCommandProperty, value); }
    }

    // Using a DependencyProperty as the backing store for DanmakuSpendChangedCommand.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty DanmakuSpendChangedCommandProperty =
        DependencyProperty.Register(
            "DanmakuSpendChangedCommand",
            typeof(RelayCommand<double>),
            typeof(DashMediaTransportControl),
            new PropertyMetadata(null)
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
        typeof(DashMediaTransportControl),
        new PropertyMetadata(true)
    );

    public List<string> FontFamilys
    {
        get { return (List<string>)GetValue(FontFamilysProperty); }
        set { SetValue(FontFamilysProperty, value); }
    }

    // Using a DependencyProperty as the backing store for FontFamilys.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty FontFamilysProperty = DependencyProperty.Register(
        "FontFamilys",
        typeof(List<string>),
        typeof(DashMediaTransportControl),
        new PropertyMetadata(default)
    );

    public RelayCommand<string> DanmakuFontChangedCommand
    {
        get { return (RelayCommand<string>)GetValue(DanmakuFontChangedCommandProperty); }
        set { SetValue(DanmakuFontChangedCommandProperty, value); }
    }

    // Using a DependencyProperty as the backing store for DanmakuFontChangedCommand.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty DanmakuFontChangedCommandProperty =
        DependencyProperty.Register(
            "DanmakuFontChangedCommand",
            typeof(RelayCommand<string>),
            typeof(DashMediaTransportControl),
            new PropertyMetadata(default)
        );

    public RelayCommand<double> DanmakuAreaChangedCommand
    {
        get { return (RelayCommand<double>)GetValue(DanmakuAreaChangedCommandProperty); }
        set { SetValue(DanmakuAreaChangedCommandProperty, value); }
    }

    // Using a DependencyProperty as the backing store for DanmakuAreaChangedCommand.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty DanmakuAreaChangedCommandProperty =
        DependencyProperty.Register(
            "DanmakuAreaChangedCommand",
            typeof(RelayCommand<double>),
            typeof(DashMediaTransportControl),
            new PropertyMetadata(null)
        );

    public RelayCommand SkipLengthCommand
    {
        get { return (RelayCommand)GetValue(SkipLengthCommandProperty); }
        set { SetValue(SkipLengthCommandProperty, value); }
    }

    // Using a DependencyProperty as the backing store for SkipLengthCommand.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty SkipLengthCommandProperty =
        DependencyProperty.Register(
            "SkipLengthCommand",
            typeof(RelayCommand),
            typeof(DashMediaTransportControl),
            new PropertyMetadata(null)
        );

    public bool IsMediaPlayerLoaded
    {
        get { return (bool)GetValue(IsMediaPlayerLoadedProperty); }
        set { SetValue(IsMediaPlayerLoadedProperty, value); }
    }

    // Using a DependencyProperty as the backing store for IsMediaPlayerLoaded.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty IsMediaPlayerLoadedProperty =
        DependencyProperty.Register(
            "IsMediaPlayerLoaded",
            typeof(bool),
            typeof(DashMediaTransportControl),
            new PropertyMetadata(true)
        );

    public RelayCommand DanmakuSendCommand
    {
        get { return (RelayCommand)GetValue(DanmakuSendCommandProperty); }
        set { SetValue(DanmakuSendCommandProperty, value); }
    }

    // Using a DependencyProperty as the backing store for DanmakuSendCommand.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty DanmakuSendCommandProperty =
        DependencyProperty.Register(
            "DanmakuSendCommand",
            typeof(RelayCommand),
            typeof(DashMediaTransportControl),
            new PropertyMetadata(null)
        );

    public string DanmakuContent
    {
        get { return (string)GetValue(DanmakuContentProperty); }
        set { SetValue(DanmakuContentProperty, value); }
    }

    // Using a DependencyProperty as the backing store for  DanmakuContent.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty DanmakuContentProperty = DependencyProperty.Register(
        " DanmakuContent",
        typeof(string),
        typeof(DashMediaTransportControl),
        new PropertyMetadata(null)
    );

    public TransportEnum MediaPlayerType
    {
        get { return (TransportEnum)GetValue(MediaPlayerTypeProperty); }
        set { SetValue(MediaPlayerTypeProperty, value); }
    }

    // Using a DependencyProperty as the backing store for MediaPlayerType.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty MediaPlayerTypeProperty = DependencyProperty.Register(
        "MediaPlayerType",
        typeof(TransportEnum),
        typeof(DashMediaTransportControl),
        new PropertyMetadata(TransportEnum.DashVideo)
    );

    public TimeSpan LiveTimeSpan
    {
        get { return (TimeSpan)GetValue(LiveTimeSpanProperty); }
        set { SetValue(LiveTimeSpanProperty, value); }
    }

    // Using a DependencyProperty as the backing store for LiveTimeSpan.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty LiveTimeSpanProperty = DependencyProperty.Register(
        "LiveTimeSpan",
        typeof(TimeSpan),
        typeof(DashMediaTransportControl),
        new PropertyMetadata(null)
    );

    public ICommand RefershSourceCommand
    {
        get { return (ICommand)GetValue(RefershSourceCommandProperty); }
        set { SetValue(RefershSourceCommandProperty, value); }
    }

    // Using a DependencyProperty as the backing store for RefershSourceCommand.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty RefershSourceCommandProperty =
        DependencyProperty.Register(
            "RefershSourceCommand",
            typeof(ICommand),
            typeof(DashMediaTransportControl),
            new PropertyMetadata(default)
        );

    public MediaState MediaState
    {
        get { return (MediaState)GetValue(MediaStateProperty); }
        set { SetValue(MediaStateProperty, value); }
    }

    // Using a DependencyProperty as the backing store for MediaState.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty MediaStateProperty = DependencyProperty.Register(
        "MediaState",
        typeof(MediaState),
        typeof(DashMediaTransportControl),
        new PropertyMetadata(MediaState.Default,OnMediaStateChanged)
    );

    private static void OnMediaStateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is DashMediaTransportControl control)
            control.UpDate();
    }

    internal void UpDate()
    {
        switch (this.MediaState)
        {
            case MediaState.Full:
                VisualStateManager.GoToState(this, "Full", false);
                break;
            case MediaState.Default:
                VisualStateManager.GoToState(this, "Default", false);
                break;
            case MediaState.TopFull:
                VisualStateManager.GoToState(this, "TopFull", false);
                break;
        }
    }
}
