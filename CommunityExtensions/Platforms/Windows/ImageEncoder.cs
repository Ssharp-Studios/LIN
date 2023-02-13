using Microsoft.UI.Xaml.Media.Imaging;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;

namespace CommunityExtensions.ForWindows
{

    /// <summary>
    /// Image Encoder de Windows
    /// </summary>
    internal class ImageEncoder
    {


        /// <summary>
        /// Convierte una imagen en string Base64
        /// </summary>
        public static async Task<string> ToBase64(Image image)
        {
            // Control convertido en WinUI
            Microsoft.UI.Xaml.Controls.Image control = (Microsoft.UI.Xaml.Controls.Image)(image?.Handler?.PlatformView ?? new());
            
            // Convierte a la base 64
            string base64 = await ToBase64(control);
            return base64 ?? "";
        }


        /// <summary>
        /// Convierte una imagen en string Base64
        /// </summary>
        private static async Task<string> ToBase64(Microsoft.UI.Xaml.Controls.Image control)
        {
            var bitmap = new RenderTargetBitmap();
            await bitmap.RenderAsync(control, 900, 900);
            return await ToBase64(bitmap);
        }

        private static async Task<string> ToBase64(WriteableBitmap bitmap)
        {
            var bytes = bitmap.PixelBuffer.ToArray();
            return await ToBase64(bytes, (uint)bitmap.PixelWidth, (uint)bitmap.PixelHeight);
        }

        private static async Task<string> ToBase64(StorageFile bitmap)
        {

            var stream = await bitmap.OpenAsync(FileAccessMode.Read);
            var decoder = await BitmapDecoder.CreateAsync(stream);
            var pixels = await decoder.GetPixelDataAsync();
            var bytes = pixels.DetachPixelData();
            return await ToBase64(bytes, (uint)decoder.PixelWidth, (uint)decoder.PixelHeight, decoder.DpiX, decoder.DpiY);
        }

        private static async Task<string> ToBase64(RenderTargetBitmap bitmap)
        {
            var bytes = (await bitmap.GetPixelsAsync()).ToArray();
            return await ToBase64(bytes, (uint)bitmap.PixelWidth, (uint)bitmap.PixelHeight);
        }

        private static async Task<string> ToBase64(byte[] image, uint height, uint width, double dpiX = 96, double dpiY = 96)
        {
            // encode image
            var encoded = new InMemoryRandomAccessStream();
            var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, encoded);
            encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Straight, height, width, dpiX, dpiY, image);
            await encoder.FlushAsync();
            encoded.Seek(0);

            // read bytes
            var bytes = new byte[encoded.Size];
            await encoded.AsStream().ReadAsync(bytes, 0, bytes.Length);

            // create base64
            return Convert.ToBase64String(bytes);
        }

    }


}
