using Microsoft.UI.Xaml.Media.Imaging;
using QRCoder;
using System;
using System.Threading.Tasks;
using Windows.Storage.Streams;

namespace Lib.Helper;

public class QrConverter
{
    public static async Task<BitmapImage> Convert(string value)
    {
        var qrGenerator = new QRCodeGenerator();
        var qrCodeData = qrGenerator.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);
        var qrCode = new BitmapByteQRCode(qrCodeData);
        var qrCodeImage = qrCode.GetGraphic(20);
        using (var stream = new InMemoryRandomAccessStream())
        {
            using (var writer = new DataWriter(stream.GetOutputStreamAt(0)))
            {
                writer.WriteBytes(qrCodeImage);
                await writer.StoreAsync();
            }
            BitmapImage bitmapImage = new BitmapImage();
            await bitmapImage.SetSourceAsync(stream);
            return bitmapImage;
        }
    }
}
