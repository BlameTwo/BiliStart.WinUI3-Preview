using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;

namespace App.Models;

public class RootNavigationModel<T>
{
    public T Data { get; set; }

    public object VM { get; set; }

    public AppWindow AWindow { get; set; }

    public Window Window { get; set; }
}

/// <summary>
/// 不带参的一个传送类型
/// </summary>
public class RootNavigationModel
{
    public object VM { get; set; }

    public AppWindow AWindow { get; set; }

    public Window Window { get; set; }
}
