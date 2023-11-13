using BiliStart.WinUI3.UI.Controls.MediaPlayer;
using IAppContracts.Controls;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Network.Models.Videos;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Windows.Storage.Streams;

namespace BiliStart.WinUI3.UI.Controls;

/// <summary>
/// 流媒体播放控件
/// </summary>
[TemplatePart(Name = "TransportControlsPresenter", Type = typeof(DashMediaTransportControl))]
[TemplatePart(Name = "DanmakuControl", Type = typeof(DanmakuControl))]
[TemplateVisualState(GroupName = "MediaStateGroup", Name = "TopFull")]
[TemplateVisualState(GroupName = "MediaStateGroup", Name = "Full")]
[TemplateVisualState(GroupName = "MediaStateGroup", Name = "Default")]
public partial class DashMediaPlayerElement : ContentControl, IDashMediaPlayerElement
{
    private CancellationTokenSource hideCancellationTokenSource;

    public DashMediaPlayerElement()
    {
        this.DefaultStyleKey = typeof(DashMediaPlayerElement);
    }

    public async Task CloseAsync()
    {
        if (this.TransportControls != null)
            await this.TransportControls.DisposeAsync();
        this.DanmakeControl = null;
        if (MediaPlayer == null)
            return;
        this.MediaPlayer.Pause();
        this.MediaPlayer.Dispose();
        this.MediaPlayer = null;
    }

    public IDanmakuControl DanmakeControl { get; set; }

    public DashMediaTransportControl TransportControls { get; set; }

    public void SetMediaPlayer(Windows.Media.Playback.MediaPlayer mediaPlayer)
    {
        this.PlayerLoading = true;
        if (this.MediaPlayer != null)
        {
            TransportControls.UnControlEvent();
            this.MediaPlayer.Dispose();
            this.MediaPlayer = null;
        }
        this.MediaPlayer = mediaPlayer;
        this.MediaPlayer.PlaybackSession.PlaybackStateChanged +=
            PlaybackSession_PlaybackStateChanged;
    }

    private void PlaybackSession_PlaybackStateChanged(
        Windows.Media.Playback.MediaPlaybackSession sender,
        object args
    )
    {
        this.DispatcherQueue.TryEnqueue(() =>
        {
            if (sender.PlaybackState == Windows.Media.Playback.MediaPlaybackState.Buffering)
            {
                this.IsPlayerMediaLoaded = false;
            }
            else if (sender.PlaybackState == Windows.Media.Playback.MediaPlaybackState.Playing)
            {
                this.IsPlayerMediaLoaded = true;
            }
        });
    }

    public List<DashVideo> VideoList { get; set; }

    private CancellationTokenSource cancellationTokenSource;

    protected override void OnApplyTemplate()
    {
        this.TransportControls = (DashMediaTransportControl)
            this.GetTemplateChild("TransportControlsPresenter");
        //这里绑定媒体控制器的动画
        TransportControls.QualityChanged += TransportControls_QualityChanged;
        TransportControls.MaxScreenClick += TransportControls_MaxScreenClick;
        TransportControls.TopScreenClick += TransportControls_TopScreenClick;
        TransportControls.ChangedState += TransportControls_ChangedState;
        this.TransportControls.DanmakuStateChanged += TransportControls_DanmakuStateChanged;
        this.PointerMoved += DashMediaPlayerElement_PointerMoved;
        this.TransportControls.OpenedChanged += TransportControls_OpenedChanged;
        this.TransportControls.PlayerProgressChanged += TransportControls_PlayerProgressChanged;
        this.DanmakeControl = (IDanmakuControl)this.GetTemplateChild("DanmakuControl");
        this.UpDate();
        base.OnApplyTemplate();
    }

    private void TransportControls_DanmakuStateChanged(
        DanmakuStateValueChangedType type,
        object value
    )
    {
        if (type == DanmakuStateValueChangedType.Switch && value is bool val)
        {
            this.DanmakuControlVisibility = val == true ? Visibility.Visible : Visibility.Collapsed;
            this.DanmakeControl.IsOpen = val;
        }
        else if (type == DanmakuStateValueChangedType.DanmakuOpactiy && value is double opacity)
        {
            this.DanmakeControl.DanmakuOpacity = opacity;
        }
        else if (type == DanmakuStateValueChangedType.DanmakuSpend && value is double spend)
        {
            this.DanmakeControl.DanmakuDuration = Convert.ToInt32(spend);
        }
        else if (type == DanmakuStateValueChangedType.DanmakuFontFamily && value is string font)
        {
            this.DanmakeControl.DanmakuFont = new FontFamily(font);
        }
        else if (type == DanmakuStateValueChangedType.DanmakuArea && value is double area)
        {
            this.DanmakeControl.DanmakuArea = area;
        }
        else if (type == DanmakuStateValueChangedType.DanmakuContent && value is string content)
        {
            if (DanmakuSendHandler != null)
                this.DanmakuSendHandler.Invoke(ViewConverter.Models.DanmakuType.Scrool, content);
        }
        if (this.DanmakuStateChangedHandler != null)
            DanmakuStateChangedHandler.Invoke(type, value);
    }

    private void TransportControls_PlayerProgressChanged(object source, TimeSpan time)
    {
        if (PlayerProgressHandler != null)
            this.PlayerProgressHandler.Invoke(source, time);
    }

    private void TransportControls_ChangedState(
        object source,
        App.Models.Enum.MediaState controlState
    )
    {
        if (this.ChangeStateHandle != null)
            this.ChangeStateHandle.Invoke(source, controlState);
    }

    private void TransportControls_TopScreenClick(object source, bool istop)
    {
        if (this.TopScreenClickHandle != null)
            this.TopScreenClickHandle.Invoke(source, istop);
    }

    private void TransportControls_MaxScreenClick(object source, bool isScreen)
    {
        if (this.MaxScreenClickHandle != null)
            this.MaxScreenClickHandle.Invoke(source, isScreen);
    }

    private void TransportControls_OpenedChanged(object source)
    {
        if (PlayerOpenedHandler != null)
            this.PlayerOpenedHandler.Invoke(true);
        IsPlayerMediaLoaded = true;
        this.PlayerLoading = false;
    }

    private async void DashMediaPlayerElement_PointerMoved(object sender, PointerRoutedEventArgs e)
    {
        cancellationTokenSource?.Cancel();
        VisualStateManager.GoToState(this, "VisibleState", true);
        cancellationTokenSource = new CancellationTokenSource();
        try
        {
            await Task.Delay(TimeSpan.FromSeconds(3), cancellationTokenSource.Token);
        }
        catch (TaskCanceledException)
        {
            // 延迟操作被取消
            return;
        }

        VisualStateManager.GoToState(this, "HiddenState", true);
    }

    private void TransportControls_QualityChanged(ListView sender, object SelectItem)
    {
        if (TransportQualityListChangedHandler == null)
            return;
        //设置附加属性
        TransportQualityListChangedHandler.Invoke(sender, SelectItem);
    }

    public void RefreshSystemVideoTitle(string title, string subTitle, string picurl)
    {
        this.MediaPlayer.SystemMediaTransportControls.DisplayUpdater.Type = Windows
            .Media
            .MediaPlaybackType
            .Video;
        this.MediaPlayer.SystemMediaTransportControls.DisplayUpdater.VideoProperties.Title = title;
        this.MediaPlayer.SystemMediaTransportControls.DisplayUpdater.VideoProperties.Subtitle =
            subTitle;
        this.MediaPlayer.SystemMediaTransportControls.DisplayUpdater.Thumbnail =
            RandomAccessStreamReference.CreateFromUri(new Uri(picurl));
        this.MediaPlayer.SystemMediaTransportControls.DisplayUpdater.Update();
    }
}
