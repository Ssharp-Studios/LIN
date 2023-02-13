
namespace CommunityExtensions
{

    /// <summary>
    /// Image Encoder 
    /// </summary>
    public static class ImageEncoder
    {


        /// <summary>
        /// Retroa una imagen
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static ImageSource DesEncode(string inputString)
        {
            byte[] NewBytes = Convert.FromBase64String(inputString);

            MemoryStream ms1 = new(NewBytes);
            ImageSource NewImage = ImageSource.FromStream(() => ms1);

            return NewImage;
        }



        /// <summary>
        /// Convierte una imagen a Base64
        /// </summary>
        /// <param name="image">Imagen a convertir</param>
        /// <returns></returns>
        public static async Task<string> Encode(this Image image)
        {

#if ANDROID
            return await ForAndroid.ImageEncoder.ToBase64(image);
#elif WINDOWS
            return await ForWindows.ImageEncoder.ToBase64(image);
#else
            return await Task.Run(() => ""); 
#endif
        }


    }

}
