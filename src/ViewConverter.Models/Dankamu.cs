namespace ViewConverter.Models;

public class DanmakuSession
{
    public string Text { get; set; }

    public DanmakuColor Color { get; set; }

    public string Id { get; set; }

    public TimeSpan Progress { get; set; }

    public int FontSize { get; set; }

    public long Publish { get; set; }

    public string MidHash { get; set; }

    public int Weight { get; set; }

    public DanmakuType Mode { get; set; }
}

/// <summary>
/// 弹幕模式,5为顶部弹幕，4是底部弹幕，1是滚动弹幕
/// </summary>
public enum DanmakuType
{
    Scrool = 1,
    Top = 5,
    Bottom = 4,
    None
}

public record DanmakuColor(byte red, byte green, byte blue);
