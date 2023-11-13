using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using System;

namespace BiliStart.WinUI3.UI;

public sealed partial class UIImage : UserControl
{
    public UIImage()
    {
        this.InitializeComponent();
    }

    private bool _isRing = false;

    public object Source
    {
        get { return (object)GetValue(SourceProperty); }
        set { SetValue(SourceProperty, value); }
    }

    public static readonly DependencyProperty SourceProperty = DependencyProperty.Register(
        "Source",
        typeof(object),
        typeof(UIImage),
        new PropertyMetadata(null, Onchanged)
    );

    private static void Onchanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (e.NewValue != e.OldValue)
        {
            var instance = d as UIImage;
            if (instance._isRing)
                VisualStateManager.GoToState(instance, "Ringing", false);
            else
                VisualStateManager.GoToState(instance, "Loading", false);
            if (e.NewValue == null)
            {
                instance.Image.Source = null;
                VisualStateManager.GoToState(instance, "Error", false);
            }
            else if (
                e.NewValue is string url && (url.StartsWith("http") || url.StartsWith("https"))
            )
            {
                var img = new BitmapImage() { DecodePixelType = DecodePixelType.Logical };

                instance.Image.Source = img;
                if (string.IsNullOrEmpty(url))
                    instance.Image.Source = null;
                else
                    img.UriSource = new Uri(url);
            }
            else if (e.NewValue is ImageSource image)
            {
                instance.Image.Source = image;
            }
        }
    }

    public Stretch Stretch
    {
        get { return (Stretch)GetValue(StretchProperty); }
        set { SetValue(StretchProperty, value); }
    }
    public static readonly DependencyProperty StretchProperty = DependencyProperty.Register(
        "Stretch",
        typeof(Stretch),
        typeof(UIImage),
        new PropertyMetadata(Stretch.UniformToFill)
    );

    private void Image_ImageOpened(object sender, RoutedEventArgs e)
    {
        VisualStateManager.GoToState(this, "Loading", false);
    }

    private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
    {
        VisualStateManager.GoToState(this, "Error", false);
    }
}
