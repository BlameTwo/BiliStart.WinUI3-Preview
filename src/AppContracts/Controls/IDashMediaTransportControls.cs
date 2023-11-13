using App.Models.Enum;
using BiliStart.WinUI3.UI.Controls.MediaPlayer;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Media.Playback;

namespace IAppContracts.Controls;

public enum TransportEnum
{
    DashVideo,
    Live
}

public interface IDashMediaTransportControl
{
    #region 弹幕控件的命令
    /// <summary>
    /// 开启弹幕命令
    /// </summary>
    RelayCommand<bool> OpenDanmankuControlCommand { get; set; }

    RelayCommand<double> DanmakuOpacityChangedCommand { get; set; }

    RelayCommand<double> DanmakuSpendChangedCommand { get; set; }

    RelayCommand<string> DanmakuFontChangedCommand { get; set; }

    RelayCommand<double> DanmakuAreaChangedCommand { get; set; }

    RelayCommand DanmakuSendCommand { get; set; }

    #endregion

    #region 其他命令
    RelayCommand SkipLengthCommand { get; set; }
    #endregion
    double ControlVolumn { get; set; }
    ICommand MaxScreen { get; set; }
    MediaPlayer MediaPlayer { get; set; }
    DataTemplate QualityDataTemplate { get; set; }
    object QualityList { get; set; }
    string StartGlyph { get; set; }

    event QualityListChangedDelegate QualityChanged;

    event MediaTranControlLoadedDelegate OpenedChanged;

    event PlayerProgressChangedDelegate PlayerProgressChanged;

    event DanmakuStateChangedDelegate DanmakuStateChanged;

    TransportEnum MediaPlayerType { get; set; }

    bool IsOpen { get; set; }

    bool IsMediaPlayerLoaded { get; set; }
    ValueTask DisposeAsync();
    void RefershMediaPlayer(MediaPlayer mediaPlayer);

    MediaState MediaState { get; set; }
    string DanmakuContent { get; set; }

    ICommand RefershSourceCommand { get; }
}
