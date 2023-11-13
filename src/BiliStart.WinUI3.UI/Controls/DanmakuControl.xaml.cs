using IAppContracts.Controls;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using System;
using System.Collections.Generic;
using System.Linq;
using ViewConverter.Models;
using CommunityToolkit.WinUI;
using Windows.Foundation;
using CommunityToolkit.WinUI.Media;

namespace BiliStart.WinUI3.UI.Controls;

public sealed partial class DanmakuControl : UserControl, IDanmakuControl
{
    public DanmakuControl()
    {
        this.InitializeComponent();
        this.Loaded += DanmakuControl_Loaded;
    }

    protected override Size MeasureOverride(Size availableSize)
    {
        SetGridRow(availableSize.Height);
        return base.MeasureOverride(availableSize);
    }

    private void DanmakuControl_SizeChanged(object sender, SizeChangedEventArgs e) { }

    private void DanmakuControl_Loaded(object sender, RoutedEventArgs e) { }

    List<Storyboard> topbottomStory = new List<Storyboard>();
    List<Storyboard> ScrollStory = new List<Storyboard>();

    private void SetGridRow(double height)
    {
        var test = new TextBlock() { Text = "SetRow", FontSize = 25 * this.DanmakuZoom };
        _top.RowDefinitions.Clear();
        _Bottom.RowDefinitions.Clear();
        _Scroll.RowDefinitions.Clear();
        test.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
        var rowheight = test.DesiredSize.Height;
        int max = Convert.ToInt32(height / rowheight);
        for (int i = 0; i < max; i++)
        {
            _top.RowDefinitions.Add(new());
        }
        for (int i = 0; i < max; i++)
        {
            _Bottom.RowDefinitions.Add(new());
        }
        for (int i = 0; i < max; i++)
        {
            _Scroll.RowDefinitions.Add(new());
        }
    }

    int GetTopRow()
    {
        var screen = _top.RowDefinitions.Count / 2;
        for (int i = 0; i < screen; i++)
        {
            var row = _top.Children.FirstOrDefault(x => Grid.GetRow((x as FrameworkElement)) == i);
            if (row != null)
                continue;
            else
                return i;
        }
        return -1;
    }

    int GetBottomRow()
    {
        var screen = _Bottom.RowDefinitions.Count / 2;
        for (int i = 0; i < screen; i++)
        {
            var rowNum = this._Bottom.RowDefinitions.Count - i;
            var row = _Bottom.Children.FirstOrDefault(
                x => Grid.GetRow((x as FrameworkElement)) == rowNum
            );
            return rowNum;
        }
        return -1;
    }

    private int GetScrollRow(Grid item)
    {
        var width = _Scroll.ActualWidth;
        item.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
        var newWidth = item.DesiredSize.Width;
        if (newWidth <= 0)
            return -1;
        var max = _Scroll.RowDefinitions.Count * DanmakuArea;
        for (int i = 0; i < max; i++)
        {
            var lastItem = _Scroll.Children.LastOrDefault(
                x => Grid.GetRow((x as FrameworkElement)) == i
            );
            if (lastItem == null)
            {
                return i;
            }

            var lastWidth = (lastItem as FrameworkElement).ActualWidth;
            var lastX = (lastItem.RenderTransform as TranslateTransform).X;
            if (lastX > width - lastWidth)
            {
                continue;
            }
            var lastSpeed = (lastWidth + width) / DanmakuDuration;
            var newSpeed = (newWidth + width) / DanmakuDuration;
            if (newSpeed <= lastSpeed)
            {
                return i;
            }
            var runDistance = width - lastX;
            var t1 = (runDistance - newWidth) / (newSpeed - lastSpeed);
            var t2 = lastX / lastSpeed;
            if (t1 > t2)
            {
                return i;
            }
        }
        return -1;
    }

    public void AddTopDanmaku(DanmakuSession session)
    {
        if (IsOpen == false)
            return;
        var itemcontrol = CreateDanmakuControl(session);
        itemcontrol.HorizontalAlignment = HorizontalAlignment.Center;
        itemcontrol.VerticalAlignment = VerticalAlignment.Top;
        var r = GetTopRow();
        if (r == -1)
            return;
        Grid.SetRow(itemcontrol, r);
        _top.Children.Add(itemcontrol);
        TranslateTransform moveTransform = new TranslateTransform();
        DoubleAnimation opacityAnimation = new DoubleAnimation
        {
            To = 1,
            Duration = TimeSpan.FromSeconds(5)
        };
        Storyboard storyboard = new Storyboard();
        storyboard.Children.Add(opacityAnimation);
        Storyboard.SetTarget(opacityAnimation, itemcontrol);
        Storyboard.SetTargetProperty(opacityAnimation, "Opacity");
        topbottomStory.Add(storyboard);
        storyboard.Completed += new EventHandler<object>(
            (senders, obj) =>
            {
                _top.Children.Remove(itemcontrol);
                itemcontrol = null;
                topbottomStory.Remove(storyboard);
                storyboard.Stop();
                storyboard = null;
            }
        );
        storyboard.Begin();
    }

    public void AddBottomDanmaku(DanmakuSession session)
    {
        if (IsOpen == false)
            return;
        var itemcontrol = CreateDanmakuControl(session);
        itemcontrol.HorizontalAlignment = HorizontalAlignment.Center;
        itemcontrol.VerticalAlignment = VerticalAlignment.Bottom;
        var r = GetBottomRow();
        if (r == -1)
            return;
        Grid.SetRow(itemcontrol, r);
        _Bottom.Children.Add(itemcontrol);
        TranslateTransform moveTransform = new TranslateTransform();
        DoubleAnimation opacityAnimation = new DoubleAnimation
        {
            To = 1,
            Duration = TimeSpan.FromSeconds(5)
        };
        Storyboard storyboard = new Storyboard();
        storyboard.Children.Add(opacityAnimation);
        Storyboard.SetTarget(opacityAnimation, itemcontrol);
        Storyboard.SetTargetProperty(opacityAnimation, "Opacity");
        topbottomStory.Add(storyboard);
        storyboard.Completed += new EventHandler<object>(
            (senders, obj) =>
            {
                _Bottom.Children.Remove(itemcontrol);
                itemcontrol = null;
                topbottomStory.Remove(storyboard);
                storyboard.Stop();
                storyboard = null;
            }
        );
        storyboard.Begin();
    }

    public void AddScrollDanmaku(DanmakuSession session)
    {
        if (IsOpen == false)
            return;
        var itemcontrol = CreateDanmakuControl(session);
        var r = GetScrollRow(itemcontrol);
        if (r == -1)
            return;
        Grid.SetRow(itemcontrol, r);
        itemcontrol.HorizontalAlignment = HorizontalAlignment.Left;
        itemcontrol.VerticalAlignment = VerticalAlignment.Center;
        itemcontrol.UpdateLayout();
        TranslateTransform moveTransform = new TranslateTransform();
        moveTransform.X = this.ActualWidth;
        itemcontrol.RenderTransform = moveTransform;
        _Scroll.Children.Add(itemcontrol);
        Duration duration = new Duration(TimeSpan.FromSeconds(DanmakuDuration));
        DoubleAnimation myDoubleAnimationX = new DoubleAnimation();
        myDoubleAnimationX.Duration = duration;
        Storyboard moveStoryboard = new Storyboard();
        moveStoryboard.Duration = duration;
        myDoubleAnimationX.To = -(itemcontrol.ActualWidth);
        moveStoryboard.Children.Add(myDoubleAnimationX);
        Storyboard.SetTarget(myDoubleAnimationX, moveTransform);
        Storyboard.SetTargetProperty(myDoubleAnimationX, "X");
        ScrollStory.Add(moveStoryboard);
        moveStoryboard.Completed += new EventHandler<object>(
            (senders, obj) =>
            {
                _Scroll.Children.Remove(itemcontrol);
                itemcontrol = null;
                ScrollStory.Remove(moveStoryboard);
                moveStoryboard.Stop();
                moveStoryboard = null;
            }
        );
        moveStoryboard.Begin();
    }

    private Grid CreateDanmakuControl(DanmakuSession session)
    {
        Grid grid = new();
        Grid parentgrid = new();
        var shadow = new AttachedDropShadow
        {
            BlurRadius = 2,
            Opacity = 0.8,
            Offset = "1,1,0",
            Color = session.Color.red <= 80 ? Colors.White : Colors.Black,
        };
        TextBlock text = new() { Text = session.Text };
        Effects.SetShadow(text, new AttachedDropShadow() { CastTo= parentgrid});
        text.Foreground = new SolidColorBrush(
            new Windows.UI.Color()
            {
                A = 255,
                R = session.Color.red,
                G = session.Color.green,
                B = session.Color.blue
            }
        );
        text.FontFamily = this.DanmakuFont;
        text.Height = 35;
        text.FontSize = session.FontSize * DanmakuZoom;
        text.Opacity = this.DanmakuOpacity;
        grid.Children.Add(parentgrid);
        grid.Children.Add(text);
        return grid;
    }
}
