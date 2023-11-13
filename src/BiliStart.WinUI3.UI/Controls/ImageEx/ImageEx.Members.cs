using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Windows.Media.Casting;

namespace BiliStart.WinUI3.UI.Controls;

public partial class ImageEx
{
    public static readonly DependencyProperty NineGridProperty = DependencyProperty.Register(
        nameof(NineGrid),
        typeof(Thickness),
        typeof(ImageEx),
        new PropertyMetadata(default(Thickness))
    );

    public Thickness NineGrid
    {
        get { return (Thickness)GetValue(NineGridProperty); }
        set { SetValue(NineGridProperty, value); }
    }

    public CastingSource GetAsCastingSource()
    {
        if (IsInitialized && Image is Image image)
        {
            return image.GetAsCastingSource();
        }

        return null;
    }
}
