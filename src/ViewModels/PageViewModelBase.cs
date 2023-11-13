using Microsoft.UI.Xaml.Controls;

namespace ViewModels;

/// <summary>
/// 普通Page的VM基类
/// </summary>
public partial class PageViewModelBase : ObservableRecipient
{
    public PageViewModelBase(IRootNavigationMethod rootNavigationMethod)
    {
        IsActive = true;
        RootNavigationMethod = rootNavigationMethod;
        TokenSource = new();
    }

    [ObservableProperty]
    string _title;

    [ObservableProperty]
    bool _IsLoaded;

    /// <summary>
    /// 对异步操作的一个约束
    /// </summary>
    public CancellationTokenSource TokenSource;

    public IRootNavigationMethod RootNavigationMethod { get; }
}
