using App.Models.Enum;
using BiliStart.WinUI3.UI.Controls.MediaPlayer;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using Network.Models.Videos;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Media.Playback;

namespace IAppContracts.Controls;

public interface IDashMediaPlayerElement
{
    /// <summary>
    /// 本MediaPlayer
    /// </summary>
    MediaPlayer MediaPlayer { get; set; }

    /// <summary>
    /// 设置系统媒体控制器标题以及样式
    /// </summary>
    /// <param name="title"></param>
    /// <param name="subTitle"></param>
    /// <param name="picurl"></param>
    void RefreshSystemVideoTitle(string title, string subTitle, string picurl);

    /// <summary>
    /// 清晰度列表模板
    /// </summary>
    DataTemplate QualityItemTemplate { get; set; }

    event DanmakuStateChangedDelegate DanmakuStateChanged;

    IDanmakuControl DanmakeControl { get; set; }

    object QualitySelectItem { get; set; }

    /// <summary>
    /// 清晰度列表
    /// </summary>
    object QualityList { get; set; }

    MediaState MediaState { get; set; }

    /// <summary>
    /// 视频对其方式
    /// </summary>
    Stretch Stretch { get; set; }

    /// <summary>
    /// 啊，没什莫卵用，正在想办法利用起来
    /// </summary>
    List<DashVideo> VideoList { get; set; }

    /// <summary>
    /// 切断媒体并释放控件
    /// </summary>
    /// <returns></returns>
    public Task CloseAsync();

    /// <summary>
    /// 清晰度选择
    /// </summary>

    event TransportQualityListChangedDelegate TransportQualityListChanged;

    /// <summary>
    /// 媒体准备完毕事件
    /// </summary>
    event PlayerOpenedDelegate PlayOpenedEvent;

    /// <summary>
    /// 最大化事件
    /// </summary>
    event MaxScreenClickDelegate MaxScreenClick;

    /// <summary>
    /// 更改播放状态事件
    /// </summary>
    event ChangedStateDelegate ChangedState;

    event DanmakuSendDelegate DanmakuSend;

    /// <summary>
    /// 固定到桌面上事件
    /// </summary>
    event TopScreenClickDelegate TopScreenClick;

    /// <summary>
    /// 播放中进度更改
    /// </summary>
    event PlayerProgressChangedDelegate PlayerProgressChanged;

    /// <summary>
    /// 设置MediaPlayer主媒体方法
    /// </summary>
    /// <param name="mediaPlayer"></param>
    void SetMediaPlayer(MediaPlayer mediaPlayer);

    /// <summary>
    /// 媒体是否加载完毕
    /// </summary>
    bool IsPlayerMediaLoaded { get; set; }

    /// <summary>
    /// 媒体是否缓冲中
    /// </summary>
    bool PlayerLoading { get; set; }

    ICommand RefershSourceCommand { get; }
}
