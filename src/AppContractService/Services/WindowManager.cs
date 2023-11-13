/*
 2023.7.9
此类主要管理应用的窗体和Page的XamlRoot，和Dialog弹出的控制

 */

using CommunityToolkit.Mvvm.Messaging;
using H.NotifyIcon;
using IAppContracts.Controls;
using IAppContracts.Handler;
using Microsoft.UI.Composition.SystemBackdrops;
using static BiliStart.WinUI3.UI.Controls.TitleBar;

namespace AppContractService.Services;

public sealed class WindowManager : IWindowManager
{
    Window _window = null;
    Page _page = null;
    ContentDialog _dialog = null;
    bool _show = true;

    public void ChangedMaxHeight(double value)
    {
        if (_window != null)
            (WinUIEx.WindowManager.Get(_window)).MaxHeight = value;
    }

    Application _application;

    public Application BiliApplication
    {
        get => _application;
        set => _application = value;
    }

    [DllImport("Shcore.dll", SetLastError = true)]
    public static extern int GetDpiForMonitor(
        IntPtr hmonitor,
        Monitor_DPI_Type dpiType,
        out uint dpiX,
        out uint dpiY
    );

    public double GetScaleAdjustment()
    {
        IntPtr hWnd = WindowNative.GetWindowHandle(
            AppService.GetService<IWindowManager>().GetWindow()
        );
        WindowId wndId = Win32Interop.GetWindowIdFromWindow(hWnd);
        DisplayArea displayArea = DisplayArea.GetFromWindowId(wndId, DisplayAreaFallback.Primary);
        IntPtr hMonitor = Win32Interop.GetMonitorFromDisplayId(displayArea.DisplayId);

        // Get DPI.
        int result = GetDpiForMonitor(
            hMonitor,
            Monitor_DPI_Type.MDT_Default,
            out uint dpiX,
            out uint _
        );
        if (result != 0)
        {
            throw new Exception("Could not get DPI for monitor.");
        }

        uint scaleFactorPercent = (uint)(((long)dpiX * 100 + (96 >> 1)) / 96);
        return scaleFactorPercent / 100.0;
    }

    public void ChangedMaxWidth(double value)
    {
        if (_window != null)
            (WinUIEx.WindowManager.Get(_window)).MaxWidth = value;
    }

    public void ChangedMinHeight(double value)
    {
        if (_window != null)
            (WinUIEx.WindowManager.Get(_window)).MinHeight = value;
    }

    public void ChangedMinWidth(double value)
    {
        
        if (_window != null)
            (WinUIEx.WindowManager.Get(_window)).MinWidth = value;
    }

    public void CloseDialog()
    {
        if (_dialog == null)
            return;
        _dialog.Hide();
        _dialog = null;
    }

    public AppWindow GetAppWindow() => WindowRectHelper.GetAppWindowForCurrentWindow(this._window);

    public Window GetWindow() => _window;

    public XamlRoot GetXamlRoot() => _page.XamlRoot;

    public void InitPopupParent(UIElement parent)
    {
        this._parent = parent;
    }

    public void InitPage(Page page)
    {
        _page = page;
    }

    public void InitWindow(Window window)
    {
        _window = window;
    }

    public void SetWindowResizable(bool IsResizable)
    {
        (WinUIEx.WindowManager.Get(_window)).IsResizable = IsResizable;
    }

    public async Task ShowDialog<T>(T dialog)
        where T : ContentDialog
    {
        dialog.XamlRoot = this.GetXamlRoot();
        this._dialog = dialog;
        await dialog.ShowAsync();
    }

    public void SetWindowBackup(string backup)
    {
        Microsoft.UI.Xaml.Media.SystemBackdrop backdrop = null;
        switch (backup)
        {
            case "Mica":
                backdrop = new MicaBackdrop()
                {
                    Kind = Microsoft.UI.Composition.SystemBackdrops.MicaKind.Base
                };
                break;
            case "MicaAlt":
                backdrop = new MicaBackdrop()
                {
                    Kind = Microsoft.UI.Composition.SystemBackdrops.MicaKind.BaseAlt
                };
                break;
            case "Acrylic":
                backdrop = new DesktopAcrylicBackdrop();
                break;
            case "None":
                backdrop = null;
                break;
        }

        if (backdrop == null)
        {
            //进行动态设定一个背景颜色
            Binding obj = new();
            obj.Source = XamlReader.Load(
                "<SolidColorBrush xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" Color=\"{ThemeResource SolidBackgroundFillColorBase}\"/>"
            );
            obj.Mode = BindingMode.OneWay;
            (this._window.Content as Page).SetBinding(Page.BackgroundProperty, obj);
        }
        else
        {
            (this._window.Content as Page).Background = new SolidColorBrush(Colors.Transparent);
        }
        this._window.SystemBackdrop = backdrop;
    }

    public void SetWindowState(AppWindowPresenterKind kind)
    {
        if (
            kind == AppWindowPresenterKind.FullScreen
            || kind == AppWindowPresenterKind.CompactOverlay
        )
        {
            WeakReferenceMessenger.Default.Send<WindowMaxMesssager>(new(true));
        }
        else if (kind == AppWindowPresenterKind.Default)
        {
            WeakReferenceMessenger.Default.Send<WindowMaxMesssager>(new(false));
        }
        this.GetAppWindow().SetPresenter(kind);
    }

    public void SetWindowTitle(string title)
    {
        this.GetWindow().Title = title;
    }

    public void SetWindowHide()
    {
        if (_show)
        {
            this._window.Hide(true);
            _show = false;
        }
        else
        {
            this._window.Show(true);
            _show = true;
        }
        if (WindowHideHandler == null)
            return;
        WindowHideHandler.Invoke(_window, _show);
    }

    public void ShowContentPopup(IContentPopup content)
    {
        if (
            this._window.Content is RootPage root
            && this._parent != null
            && this._parent is Grid grid
            && content is UIElement element
        )
        {
            grid.Children.Add(element);
            content.Showed();
        }
    }

    public void CloseContentPopup(IContentPopup content)
    {
        if (
            this._window.Content is RootPage root
            && this._parent != null
            && this._parent is Grid grid
            && content is UIElement element
            && grid.Children.Contains(element)
        )
        {
            content.Hide();
            grid.Children.Remove(element);
            element = null;
            GC.Collect();
        }
    }

    public void TryDispatcherAction(Action action)
    {
        this._window.DispatcherQueue.TryEnqueue(() => action());
    }

    public void SetWindowSize(double Height, double Width)
    {
        this._window.SetWindowSize(Width, Height);
    }

    private WindowHideDelegate WindowHideHandler;
    private UIElement _parent;

    public event WindowHideDelegate WindowHideChanged
    {
        add => WindowHideHandler += value;
        remove => WindowHideHandler -= value;
    }
}
