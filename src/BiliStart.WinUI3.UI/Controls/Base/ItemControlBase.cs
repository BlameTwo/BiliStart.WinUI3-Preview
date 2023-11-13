using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BiliStart.WinUI3.UI.Controls.Base;

/// <summary>
/// 列表视图的控件Base
/// </summary>
public abstract class ItemControlBase : Control
{
    public object ItemsSource
    {
        get { return (object)GetValue(ItemsSourceProperty); }
        set { SetValue(ItemsSourceProperty, value); }
    }

    // Using a DependencyProperty as the backing store for ItemsSource.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(
        "ItemsSource",
        typeof(object),
        typeof(ItemControlBase),
        new PropertyMetadata(default)
    );

    public object Paramter { get; private set; }

    // ToDo:在这里加一个判断，如果数据到底部则不触发命令，这个数据到底部由外部ViewModel提供

    public ICommand AddDataCommand
    {
        get { return (ICommand)GetValue(AddDataCommandProperty); }
        set { SetValue(AddDataCommandProperty, value); }
    }

    public static readonly DependencyProperty AddDataCommandProperty = DependencyProperty.Register(
        "AddDataCommand",
        typeof(ICommand),
        typeof(ItemControlBase),
        new PropertyMetadata(default(ICommand))
    );

    protected override void OnApplyTemplate()
    {
        this.Viewer = (ScrollView)GetTemplateChild("PART_ScrollView");
        Viewer.ViewChanged += _viewer_ViewChanged;;
        base.OnApplyTemplate();
    }

    /// <summary>
    /// 滚动到顶部
    /// </summary>
    public void GoScrollTop()
    {
        _viewer.ScrollTo(_viewer.HorizontalOffset, 0);
    }

    /// <summary>
    /// 滚动到底部
    /// </summary>
    public void GoScrollBootom()
    {
        _viewer.ScrollTo(_viewer.HorizontalOffset, _viewer.ExtentHeight);
    }

    private async void _viewer_ViewChanged(ScrollView sender, object args)
    {
        double verticalOffset = _viewer.VerticalOffset;
        Viewer.ViewChanged -= _viewer_ViewChanged;
        if (sender.VerticalOffset > 10)
            Flage = true;
        else
            Flage = false;
        var flage = sender.VerticalOffset + sender.ViewportHeight;
        if (sender.ExtentHeight - flage < 5 && sender.ViewportHeight != 0)
        {
            //确认当前滚动距离底部小于5，并分别进行命令操作（分异步和同步
            if (AddDataCommand is AsyncRelayCommand asynccommand)
            {
                await asynccommand.ExecuteAsync(parameter: this.Paramter);
            }
            else if (AddDataCommand is RelayCommand command)
            {
                command.Execute(parameter: this.Paramter);
            }
            await Task.Delay(1000);
            Viewer.ScrollTo(Viewer.HorizontalOffset, verticalOffset - 80);
        }
        Viewer.ViewChanged += _viewer_ViewChanged;
    }

    private ScrollView _viewer;

    public ScrollView Viewer
    {
        get => _viewer;
        set
        {
            _viewer = value;
            ChangedViewer();
        }
    }

    public abstract void ChangedViewer();

    bool Flage = false;
}
