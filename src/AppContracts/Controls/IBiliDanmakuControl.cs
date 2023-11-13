using Microsoft.UI.Xaml.Media;
using ViewConverter.Models;

namespace IAppContracts.Controls;

/// <summary>
/// 弹幕接口
/// </summary>
public interface IDanmakuControl
{
    public void AddTopDanmaku(DanmakuSession session);

    public void AddScrollDanmaku(DanmakuSession session);

    public void AddBottomDanmaku(DanmakuSession session);

    public bool IsOpen { get; set; }

    public double DanmakuOpacity { get; set; }

    public double DanmakuZoom { get; set; }

    public double DanmakuArea { get; set; }

    public FontFamily DanmakuFont { get; set; }

    public int DanmakuDuration { get; set; }
}
