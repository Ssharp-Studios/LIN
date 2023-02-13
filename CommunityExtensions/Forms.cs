
namespace CommunityExtensions
{

    /// <summary>
    /// Extensiones para ContextPages
    /// </summary>
    public static class ContextPageExtensions
    {

        /// <summary>
        /// Abre una nueva ventana 
        /// </summary>
        public static async void Show(this ContentPage newContext, ContentPage actualContext)
        {
            newContext.Title = "";
            await actualContext.Navigation.PushAsync(newContext, true);
        }


        /// <summary>
        /// Cierra la ventana una nueva ventana
        /// </summary>
        public static void Close(this ContentPage context)
        {
            context?.Navigation.RemovePage(context);
        }


    }
}
