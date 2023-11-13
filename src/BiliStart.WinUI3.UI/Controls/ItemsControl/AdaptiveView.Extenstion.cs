using IAppContracts.ItemsViewModels;
using Microsoft.UI.Xaml.Controls;
using System.Collections;
using System.Diagnostics;
using Windows.Foundation;

namespace BiliStart.WinUI3.UI.Controls;

partial class AdaptiveView
{
    /// <summary>
    /// 更改
    /// </summary>
    public void ChangLayoutItem()
    {
        if (!this.OpenVerticalChanged)
        {
            ChangDefaultLayout();
            return;
        }
        Orientation orientation = Orientation.Horizontal;
        if (_repeater.ActualWidth < MinItemVerticalValue)
            orientation = Orientation.Vertical;
        if (this.ItemsSource is ICollection items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                var UI = _repeater.TryGetElement(i);
                if (UI == null)
                    continue;
                if (UI is IDynamicItemOrientation obj)
                {
                    obj.ChangedOrientation(orientation);
                }
            }
        }
        ChangedLayout(orientation);
    }



    /// <summary>
    /// 使用默认的布局方式
    /// </summary>
    void ChangDefaultLayout()
    {
        if (this.ItemOrientation == Orientation.Horizontal)
        {
            this._repeater.Layout = this.UniformGridLayout;
        }
        else
        {
            this._repeater.Layout = this.StackLayout;
        }
    }

    /// <summary>
    /// 更改布局容器
    /// </summary>
    /// <param name="orientation"></param>
    void ChangedLayout(Orientation orientation)
    {
        switch (orientation)
        {
            case Orientation.Vertical:
                this._repeater.DispatcherQueue.TryEnqueue(() =>
                {
                    this._repeater.Layout = this.StackLayout;
                });
                break;
            case Orientation.Horizontal:
                this._repeater.DispatcherQueue.TryEnqueue(() =>
                {
                    this._repeater.Layout = this.UniformGridLayout;
                });
                break;
        }
    }

    internal Size GetAdaptiveItemSize()
    {
        if (this.ItemsSource == null && this.ItemsSource is ICollection items && items.Count == 0)
            return default;
        var UI = this._repeater.TryGetElement(0);
        if (UI != null)
            return UI.DesiredSize;
        else
            return default;
    }

}
