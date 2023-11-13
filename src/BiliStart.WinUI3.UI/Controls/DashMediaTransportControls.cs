using App.Models.Enum;
using BiliStart.WinUI3.UI.Controls.MediaPlayer;
using CommunityToolkit.Mvvm.Input;
using IAppContracts.Controls;
using Lib.Helper;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Input;
using Network.Models.Videos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Media.Playback;
using WinRT;

namespace BiliStart.WinUI3.UI.Controls;

/// <summary>
/// 流媒体控制器
/// </summary>
[TemplatePart(Name = "StartBth", Type = typeof(Button))]
[TemplatePart(Name = "QualityListView", Type = typeof(ListView))]
[TemplatePart(Name = "SpendListView", Type = typeof(ListView))]
[TemplatePart(Name = "VolumeSlider", Type = typeof(Slider))]
[TemplatePart(Name = "VideoProgressSlider", Type = typeof(Slider))]
[TemplatePart(Name = "MaxScreenButton", Type = typeof(MenuFlyoutItem))]
[TemplatePart(Name = "TopScreenButton", Type = typeof(MenuFlyoutItem))]
[TemplateVisualState(GroupName = "MediaStateGroup",Name = "TopFull")]
[TemplateVisualState(GroupName = "MediaStateGroup",Name = "Full")]
[TemplateVisualState(GroupName = "MediaStateGroup",Name = "Default")]
public partial class DashMediaTransportControl
    : Control,
        IAsyncDisposable,
        IDashMediaTransportControl
{
    public DashMediaTransportControl()
    {
        this.DefaultStyleKey = typeof(DashMediaTransportControl);
        this.SpendList = new() { 2, 1.5, 1, 0.75, 0.5 };
        InstalledFontCollection fontCollection = new InstalledFontCollection();

        FontFamily[] fontFamilies = fontCollection.Families;
        this.FontFamilys = new();
        foreach (var item in fontFamilies)
        {
            FontFamilys.Add(item.Name);
        }
        this.DanmakuFontChangedCommand = new(
            (val) => SetState(DanmakuStateValueChangedType.DanmakuFontFamily, val)
        );
        this.OpenDanmankuControlCommand = new RelayCommand<bool>(
            (val) => SetState(DanmakuStateValueChangedType.Switch, val)
        );
        this.DanmakuOpacityChangedCommand = new(
            (val) => SetState(DanmakuStateValueChangedType.DanmakuOpactiy, val / 100)
        );
        this.DanmakuSpendChangedCommand = new(
            (val) => SetState(DanmakuStateValueChangedType.DanmakuSpend, val)
        );
        this.DanmakuAreaChangedCommand = new(
            (val) => SetState(DanmakuStateValueChangedType.DanmakuArea, val)
        );
        this.DanmakuSendCommand = new(
            () => SetState(DanmakuStateValueChangedType.DanmakuContent, DanmakuContent)
        );
        this.SkipLengthCommand = new RelayCommand(() => SkipLength());
    }

    private void SkipLength()
    {
        if (this.MediaPlayer.CanSeek == false)
            return;
        this.MediaPlayer.Position = this.MediaPlayer.Position.Add(TimeSpan.FromSeconds(5));
    }

    private void SetState(DanmakuStateValueChangedType type, object val)
    {
        this.DanmakuStateChangedHandler.Invoke(type, val);
    }


    /// <summary>
    /// 刷新视频源
    /// </summary>
    public void RefershMediaPlayer(Windows.Media.Playback.MediaPlayer mediaPlayer)
    {
        this.MediaPlayer = mediaPlayer;
        MediaPlayerSetEvent();
        ControlSetEvent();
    }

    private void MediaPlayer_MediaOpened(Windows.Media.Playback.MediaPlayer sender, object args)
    {
        this.DispatcherQueue.TryEnqueue(() =>
        {
            this.MaxSliderValue = MediaPlayer.PlaybackSession.NaturalDuration.TotalSeconds;
            this.MediaTranControlLoadedHandler.Invoke(true);
        });
    }

    private void MediaPlayerSetEvent()
    {
        if (this.MediaPlayer == null)
            return;
        this.MediaPlayer.PlaybackSession.PlaybackStateChanged +=
            PlaybackSession_PlaybackStateChanged;
        this.MediaPlayer.MediaOpened += MediaPlayer_MediaOpened;
        this.MediaPlayer.PlaybackSession.PositionChanged += PlaybackSession_PositionChanged;
    }

    private void UnMediaPlayerSetEvent()
    {
        if (this.MediaPlayer == null)
            return;
        this.MediaPlayer.PlaybackSession.PlaybackStateChanged -=
            PlaybackSession_PlaybackStateChanged;
        this.MediaPlayer.MediaOpened -= MediaPlayer_MediaOpened;
        this.MediaPlayer.PlaybackSession.PositionChanged -= PlaybackSession_PositionChanged;
        if (this._progressSlider != null)
            this._progressSlider.ClearValue(Slider.ValueProperty);
    }

    private void PlaybackSession_PositionChanged(MediaPlaybackSession sender, object args)
    {
        if (this.DispatcherQueue == null)
            return;
        this.DispatcherQueue.TryEnqueue(() =>
        {
            if (sender.PlaybackState == MediaPlaybackState.None)
                return;
            if (isdrag)
                return;
            if (_progressSlider != null)
                _progressSlider.Value = sender.Position.TotalSeconds;
            NowProgress = sender.Position;
            this.PlayerProgressHandler.Invoke(this, sender.Position);
        });
    }

    private void PlaybackSession_PlaybackStateChanged(MediaPlaybackSession sender, object args)
    {
        this.DispatcherQueue.TryEnqueue(() =>
        {
            this.StartGlyph = sender.PlaybackState
                is MediaPlaybackState.None
                    or MediaPlaybackState.Opening
                    or MediaPlaybackState.Paused
                ? "\uE102"
                : "\uE103";
        });
    }

    private void ControlSetEvent()
    {
        this.DispatcherQueue.TryEnqueue(() =>
        {
            _startbth.Click += _startbth_Click;
            _qualityListView.SelectionChanged += _qualityListView_SelectionChanged;
            if (_spendListview == null)
                return;
            _spendListview.SelectionChanged += _spendListview_SelectionChanged;
            //对Slider的进度条拖动控制
            if (_progressSlider == null)
                return;
            _progressSlider.AddHandler(
                UIElement.PointerPressedEvent,
                new PointerEventHandler(Progress_PointerPressed),
                true
            );
            _progressSlider.AddHandler(
                UIElement.PointerReleasedEvent,
                new PointerEventHandler(Progress_OnPointerReleased),
                true
            );
        });
    }

    private void _spendListview_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.AddedItems.Count == 0)
            return;
        if (e.AddedItems[0] is double val)
        {
            this.MediaPlayer.PlaybackSession.PlaybackRate = val;
        }
    }

    private void UnControlSetEvent()
    {
        this.DispatcherQueue.TryEnqueue(() =>
        {
            _startbth.Click -= _startbth_Click;
            _qualityListView.SelectionChanged -= _qualityListView_SelectionChanged;
            if (_spendListview == null)
                return;
            _spendListview.SelectionChanged -= _spendListview_SelectionChanged;
            if (_progressSlider == null)
                return;
            _progressSlider.RemoveHandler(
                UIElement.PointerPressedEvent,
                new PointerEventHandler(Progress_PointerPressed)
            );
            _progressSlider.RemoveHandler(
                UIElement.PointerReleasedEvent,
                new PointerEventHandler(Progress_OnPointerReleased)
            );
        });
    }

    bool isdrag = false;

    private void Progress_PointerPressed(object sender, PointerRoutedEventArgs e)
    {
        isdrag = true;
    }

    private void Progress_OnPointerReleased(object sender, PointerRoutedEventArgs e)
    {
        isdrag = false;
        //释放后进行定位
        MediaPlayer.Position = new TimeSpan(0, 0, (int)(sender as Slider).Value);
    }

    private void _qualityListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (this.QualityListChangedHandle == null)
            return;
        if (e.AddedItems.Count == 0)
            return;
        this.QualityListChangedHandle.Invoke((ListView)sender, e.AddedItems[0]);
    }

    private void _startbth_Click(object sender, RoutedEventArgs e)
    {
        this.DispatcherQueue.TryEnqueue(() =>
        {
            if (this.MediaPlayer.PlaybackSession.PlaybackState == MediaPlaybackState.Playing)
            {
                this.MediaPlayer.Pause();
            }
            else if (this.MediaPlayer.PlaybackSession.PlaybackState == MediaPlaybackState.Paused)
            {
                this.MediaPlayer.Play();
            }
        });
    }

    protected override void OnApplyTemplate()
    {
        if (this.MediaPlayerType == TransportEnum.DashVideo)
        {
            _progressSlider = (Slider)this.GetTemplateChild("VideoProgressSlider");
            _spendListview = (ListView)this.GetTemplateChild("SpendListView");
        }
        _startbth = (Button)this.GetTemplateChild("StartBth");
        _qualityListView = (ListView)this.GetTemplateChild("QualityListView");
        maxbth = (MenuFlyoutItem)this.GetTemplateChild("MaxScreenButton");
        topbth = (MenuFlyoutItem)this.GetTemplateChild("TopScreenButton");
        topbth.Click += Topbth_Click;
        maxbth.Click += Maxbth_Click;
        ControlSetEvent();
        this.UpDate();
        base.OnApplyTemplate();
    }

    private void Maxbth_Click(object sender, RoutedEventArgs e)
    {
        this.IsFull = !IsFull;

        if (this.ChangeStateHandle != null)
        {
            this.ChangeStateHandle.Invoke(
                this,
                IsFull == true ? App.Models.Enum.MediaState.Full : this.MediaState
            );
        }
    }

    void setControl(bool state) { }

    private void Topbth_Click(object sender, RoutedEventArgs e)
    {
        this.IsTop = !IsTop;
        if (this.ChangeStateHandle != null)
        {
            this.ChangeStateHandle.Invoke(
                this,
                IsTop == true ? App.Models.Enum.MediaState.TopFull : this.MediaState
            );
        }
    }

    /// <summary>
    /// 关闭控件事件
    /// </summary>
    /// <returns></returns>
    public async ValueTask DisposeAsync()
    {
        //等待切断控件事件
        await Task.Run(() =>
        {
            this.UnControlSetEvent();
        });
    }

    public void UnControlEvent()
    {
        UnControlSetEvent();
        UnMediaPlayerSetEvent();
    }

    private Windows.Media.Playback.MediaPlayer _mediaplayer;
    private bool disposedValue;

    public Windows.Media.Playback.MediaPlayer MediaPlayer
    {
        get { return _mediaplayer; }
        set { _mediaplayer = value; }
    }
}
