namespace App.Models.Popups;

public class ImagePopupArgs
{
    public ImagePopupArgs (string Uri, double Width, double Height)
    {
        this.Uri = Uri;
        this.Width = Width;
        this.Height = Height;
    }

    public string Uri { get; }
    public double Width { get; }
    public double Height { get; }
}