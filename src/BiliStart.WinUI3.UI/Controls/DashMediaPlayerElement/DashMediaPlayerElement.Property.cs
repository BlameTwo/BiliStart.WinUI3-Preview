using App.Models.Enum;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using Network.Models.Videos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BiliStart.WinUI3.UI.Controls;

partial class DashMediaPlayerElement
{
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
            typeof(DashMediaPlayerElement),
            new PropertyMetadata(null)
        );

    public bool IsPlayerMediaLoaded
    {
        get { return (bool)GetValue(IsPlayerMediaLoadedProperty); }
        set { SetValue(IsPlayerMediaLoadedProperty, value); }
    }

    public static readonly DependencyProperty IsPlayerMediaLoadedProperty =
        DependencyProperty.Register(
            "IsPlayerMediaLoaded",
            typeof(bool),
            typeof(DashMediaPlayerElement),
            new PropertyMetadata(false)
        );

    public Stretch Stretch
    {
        get { return (Stretch)GetValue(StretchProperty); }
        set { SetValue(StretchProperty, value); }
    }

    public static readonly DependencyProperty StretchProperty = DependencyProperty.Register(
        "Stretch",
        typeof(Stretch),
        typeof(DashMediaPlayerElement),
        new PropertyMetadata(Stretch.Uniform)
    );

    public object QualityList
    {
        get { return (object)GetValue(QualityListProperty); }
        set { SetValue(QualityListProperty, value); }
    }

    // Using a DependencyProperty as the backing store for QualityList.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty QualityListProperty = DependencyProperty.Register(
        "QualityList",
        typeof(object),
        typeof(DashMediaPlayerElement),
        new PropertyMetadata(null)
    );

    public Windows.Media.Playback.MediaPlayer MediaPlayer
    {
        get { return (Windows.Media.Playback.MediaPlayer)GetValue(MediaPlayerProperty); }
        set
        {
            SetValue(MediaPlayerProperty, value);
            this.TransportControls.RefershMediaPlayer(value);
        }
    }

    public static readonly DependencyProperty MediaPlayerProperty = DependencyProperty.Register(
        "MediaPlayer",
        typeof(Windows.Media.Playback.MediaPlayer),
        typeof(DashMediaPlayerElement),
        new PropertyMetadata(null)
    );

    public DataTemplate QualityItemTemplate
    {
        get { return (DataTemplate)GetValue(QualityItemTemplateProperty); }
        set { SetValue(QualityItemTemplateProperty, value); }
    }

    // Using a DependencyProperty as the backing store for QualityItemTemplate.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty QualityItemTemplateProperty =
        DependencyProperty.Register(
            "QualityItemTemplate",
            typeof(DataTemplate),
            typeof(DashMediaPlayerElement),
            new PropertyMetadata(null)
        );

    public Visibility DanmakuControlVisibility
    {
        get { return (Visibility)GetValue(DanmakuControlVisibilityProperty); }
        set { SetValue(DanmakuControlVisibilityProperty, value); }
    }

    public static readonly DependencyProperty DanmakuControlVisibilityProperty =
        DependencyProperty.Register(
            "DanmakuControlVisibility",
            typeof(Visibility),
            typeof(DashMediaPlayerElement),
            new PropertyMetadata(Visibility.Visible)
        );

    public bool PlayerLoading
    {
        get { return (bool)GetValue(PlayerLoadingProperty); }
        set { SetValue(PlayerLoadingProperty, value); }
    }

    // Using a DependencyProperty as the backing store for PlayerLoading.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty PlayerLoadingProperty = DependencyProperty.Register(
        "PlayerLoading",
        typeof(bool),
        typeof(DashMediaPlayerElement),
        new PropertyMetadata(false)
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
            typeof(DashMediaPlayerElement),
            new PropertyMetadata(default)
        );



    public MediaState MediaState
    {
        get { return (MediaState)GetValue(MediaStateProperty); }
        set { SetValue(MediaStateProperty, value); }
    }

    // Using a DependencyProperty as the backing store for MediaState.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty MediaStateProperty =
        DependencyProperty.Register("MediaState", typeof(MediaState), typeof(DashMediaPlayerElement), new PropertyMetadata(MediaState.Default,OnMediaStateChanged));

    private static void OnMediaStateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is DashMediaPlayerElement control)
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
