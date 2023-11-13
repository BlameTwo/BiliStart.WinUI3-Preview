namespace App.Models.AppTabView;

/// <summary>
/// 不包含Y轴的拖动范围
/// </summary>
/// <param name="height">高度</param>
/// <param name="width">宽度</param>
/// <param name="x">自窗口的X轴位置</param>
public record TabAreaLength(double height,double width,double x);