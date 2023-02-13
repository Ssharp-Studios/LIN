using Android.Widget;
using Android.Graphics;

namespace CommunityExtensions.ForAndroid
{

    /// <summary>
    /// Image Encoder (Android)
    /// </summary>
    internal class ImageEncoder
    {

        /// <summary>
        /// Convierte a base64
        /// </summary>
        public static async Task<string> ToBase64(Image image)
        {

            // Control convertido en Android 
            ImageView control = (ImageView)(image?.Handler?.PlatformView ?? new());

            // Convierte la imagen
            Bitmap? bitmap = (control.Drawable as Android.Graphics.Drawables.BitmapDrawable)?.Bitmap;

            // Si es Null
            if (bitmap == null)
                return "";

    
            // Compresion
            MemoryStream stream = new();
            await bitmap.CompressAsync(Bitmap.CompressFormat.Png, 100, stream);
            byte[] result = stream.ToArray();

            // Retorna
            return Convert.ToBase64String(result) ?? "";
        }



    }

}
