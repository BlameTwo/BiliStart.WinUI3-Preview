using IAppContracts.Controls.BiliItemControls;
using Microsoft.UI.Xaml;
using System.Windows.Input;

namespace BiliStart.WinUI3.UI.Controls;

public partial class BiliItemControls
{
    internal DownloadDataDelegate DownloadDataHandle;

    /// <summary>
    /// 触发数据加载事件
    /// </summary>
    public event DownloadDataDelegate DownloadDataEvent
    {
        add { DownloadDataHandle += value; }
        remove { DownloadDataHandle -= value; }
    }

    /// <summary>
    /// 加载数据列表
    /// </summary>
    public ICommand AddDataCommand
    {
        get { return (ICommand)GetValue(AddDataCommandProperty); }
        set { SetValue(AddDataCommandProperty, value); }
    }

    public static readonly DependencyProperty AddDataCommandProperty = DependencyProperty.Register(
        "AddDataCommand",
        typeof(ICommand),
        typeof(BiliItemControls),
        new PropertyMetadata(default, (s, e) => { })
    );

    /// <summary>
    /// 参数，可绑定可更改
    /// </summary>
    public object Paramter
    {
        get { return (object)GetValue(ParamterProperty); }
        set { SetValue(ParamterProperty, value); }
    }

    public static readonly DependencyProperty ParamterProperty = DependencyProperty.Register(
        "Paramter",
        typeof(object),
        typeof(BiliItemControls),
        new PropertyMetadata(default)
    );
}
