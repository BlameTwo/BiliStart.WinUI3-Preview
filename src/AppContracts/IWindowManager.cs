using IAppContracts.Controls;
using IAppContracts.Handler;
using IAppExtension.Contract;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Threading.Tasks;

namespace IAppContracts;

public interface IWindowManager
{
    /// <summary>
    /// 注册主窗口
    /// </summary>
    /// <param name="window"></param>
    void InitWindow(Window window);

    /// <summary>
    /// Window窗体
    /// </summary>
    /// <returns></returns>
    Window GetWindow();

    /// <summary>
    /// 应用的Application
    /// </summary>
    Application BiliApplication { get; set; }

    void InitPopupParent(UIElement parent);
    Microsoft.UI.Windowing.AppWindow GetAppWindow();

    /// <summary>
    /// 最小宽度
    /// </summary>
    /// <param name="value"></param>
    void ChangedMinWidth(double value);

    /// <summary>
    /// 最小高度
    /// </summary>
    /// <param name="value"></param>
    void ChangedMinHeight(double value);

    void SetWindowResizable(bool IsResizable);

    /// <summary>
    /// DPI缩放
    /// </summary>
    /// <returns></returns>
    double GetScaleAdjustment();

    /// <summary>
    /// 更换Window背景材料
    /// </summary>
    /// <param name="backup"></param>
    void SetWindowBackup(string backup);

    /// <summary>
    /// 最大宽度
    /// </summary>
    /// <param name="value"></param>
    void ChangedMaxWidth(double value);

    /// <summary>
    /// 最小高度
    /// </summary>
    /// <param name="value"></param>
    void ChangedMaxHeight(double value);

    /// <summary>
    /// 注册主页面
    /// </summary>
    /// <param name="page"></param>
    void InitPage(Page page);

    void SetWindowSize(double Height, double Width);

    /// <summary>
    /// 获得Xaml树
    /// </summary>
    /// <returns></returns>
    XamlRoot GetXamlRoot();

    /// <summary>
    /// 显示一个对话框
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="dialog"></param>
    Task ShowDialog<T>(T dialog)
        where T : ContentDialog;

    /// <summary>
    /// 关闭对话框
    /// </summary>
    void CloseDialog();

    /// <summary>
    /// 回归UI线程
    /// </summary>
    /// <param name="action"></param>
    void TryDispatcherAction(Action action);

    void SetWindowTitle(string title);
    void SetWindowState(AppWindowPresenterKind kind);

    public event WindowHideDelegate WindowHideChanged;
    void SetWindowHide();
    public void CloseContentPopup(IContentPopup content);

    public void ShowContentPopup(IContentPopup content);
}
