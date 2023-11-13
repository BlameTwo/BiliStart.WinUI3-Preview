using App.Models.Enum;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using ViewConverter.Models;

namespace BiliStart.WinUI3.UI.Controls.MediaPlayer;

/*注：本人没有在WinUI和UWP上找到一个冒泡的路由事件，所以在此直接用委托解决。*/

/// <summary>
/// 控制器清晰度选择
/// </summary>
/// <param name="source"></param>
/// <param name="SelectItem"></param>
public delegate void TransportQualityListChangedDelegate(object source, object SelectItem);

public delegate void PlayerProgressChangedDelegate(object source, TimeSpan time);

/// <summary>
/// 清晰度选择
/// </summary>
/// <param name="sender"></param>
/// <param name="SelectItem"></param>
public delegate void QualityListChangedDelegate(ListView sender, object SelectItem);

/// <summary>
/// 视频准备完毕
/// </summary>
/// <param name="source">源，不定类型</param>
public delegate void PlayerOpenedDelegate(object source);

/// <summary>
/// 控制器上的最大化按钮变化
/// </summary>
/// <param name="source"></param>
/// <param name="isScreen"></param>
public delegate void MaxScreenClickDelegate(object source, bool isScreen);

/// <summary>
/// 固定到桌面事件
/// </summary>
/// <param name="source"></param>
/// <param name="istop"></param>
public delegate void TopScreenClickDelegate(object source, bool istop);

/// <summary>
/// 控制器状态更改事件
/// </summary>
/// <param name="source"></param>
/// <param name="controlState"></param>
public delegate void ChangedStateDelegate(object source, MediaState controlState);

/// <summary>
/// 控制器准备完毕
/// </summary>
/// <param name="source"></param>
public delegate void MediaTranControlLoadedDelegate(object source);

/// <summary>
/// 弹幕控制器更改
/// </summary>
/// <param name="type"></param>
/// <param name="value"></param>
public delegate void DanmakuStateChangedDelegate(DanmakuStateValueChangedType type, object value);

public delegate void DanmakuSendDelegate(DanmakuType type, string content);

public enum DanmakuStateValueChangedType
{
    /// <summary>
    /// 弹幕开关
    /// </summary>
    Switch,

    /// <summary>
    /// 弹幕速度
    /// </summary>
    DanmakuSpend,

    /// <summary>
    /// 弹幕字体
    /// </summary>
    DanmakuFontFamily,

    /// <summary>
    /// 弹幕范围
    /// </summary>
    DanmakuArea,

    /// <summary>
    /// 弹幕透明度
    /// </summary>
    DanmakuOpactiy,

    /// <summary>
    /// 发送弹幕
    /// </summary>
    DanmakuContent
}
