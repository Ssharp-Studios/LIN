
namespace CommunityExtensions
{
    /// <summary>
    /// Extensiones para Elementos
    /// </summary>
    public static class VisualElementExtensions
    {

        /// <summary>
        /// Muestra el control
        /// </summary>
        public static void Show(this VisualElement context)
        {
            context.IsVisible = true;
        }


        /// <summary>
        /// Oculta el control
        /// </summary>
        public static void Hide(this VisualElement context)
        {
            context.IsVisible = false;
        }


    }
}
