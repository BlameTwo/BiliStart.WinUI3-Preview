namespace Views.Bases;

/// <summary>
/// 包含一个GridView和更新列表项的Page视图
/// 其中包含一个BaseItemControl，主要为获得控件中的滚动试图。
/// </summary>
public class ViewerPageBase : Page
{
    public ItemsControl BaseItemControl { get; private set; }

    public ScrollViewer _viewer { get; private set; }

    public object Paramter { get; private set; }

    public void SetGridView(ListView grid, object paramter)
    {
        this.BaseItemControl = grid;
        this._viewer = (VisualTreeHelper.GetChild(grid, 0) as Border)!.Child as ScrollViewer;
        this.Paramter = paramter;
        this._viewer.ViewChanged += Viewer_ViewChanged;
    }

    private async void Viewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
    {
        double verticalOffset = _viewer.VerticalOffset;
        _viewer.ViewChanged -= Viewer_ViewChanged;
        var sv = sender as ScrollViewer;
        if (sv.VerticalOffset > 10)
            Flage = true;
        else
            Flage = false;
        var flage = sv.VerticalOffset + sv.ViewportHeight;
        if (sv.ExtentHeight - flage < 5 && sv.ViewportHeight != 0)
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
            _viewer.ChangeView(null, verticalOffset - 50, null);
        }
        _viewer.ViewChanged += Viewer_ViewChanged;
    }

    bool Flage = false;

    /// <summary>
    /// 加载命令
    /// </summary>
    public ICommand AddDataCommand
    {
        get { return (ICommand)GetValue(AddDataCommandProperty); }
        set { SetValue(AddDataCommandProperty, value); }
    }

    public static readonly DependencyProperty AddDataCommandProperty = DependencyProperty.Register(
        "AddDataCommand",
        typeof(ICommand),
        typeof(ViewerPageBase),
        new PropertyMetadata(default(ICommand))
    );
}
