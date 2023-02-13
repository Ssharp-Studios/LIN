
namespace LIN.Observador
{

    /// <summary>
    /// Susvriptor de producto
    /// </summary>
    public class ProductoSuscriptor
    {

        /// <summary>
        /// Lista de suscripciones
        /// </summary>
        public static readonly Dictionary<int, HashSet<IProductable>> Data = new();



        /// <summary>
        /// Suscribe un elemento
        /// </summary>
        public static void Suscribe(IProductable productable)
        {
            // Index
            var obj = Data.Where(T => T.Key == productable.Modelo.Id).FirstOrDefault();

            // Si no se encontro
            if (obj.Value == null)
                Data.Add(productable.Modelo.Id, new() { productable });

            // Si se encontro
            else
                obj.Value.Add(productable);

        }



        /// <summary>
        /// Notifica cambios en el modelo
        /// </summary>
        public static void Notify(IProductable productable)
        {
            NotifyPrivate(productable.Modelo.Id);
        }



        /// <summary>
        /// Notifica cambios en el modelo
        /// </summary>
        public static void Notify(int id)
        {
            NotifyPrivate(id);
        }



        /// <summary>
        /// Notifica cambios en el modelo
        /// </summary>
        private static void NotifyPrivate(int id)
        {

            // Objeto
            var obj = Data.Where(T => T.Key == id).FirstOrDefault();

            // Si no se encontro
            if (obj.Value == null)
                return;

            // Notifica
            foreach(var e in obj.Value)
                e.LoadModelVisible();
            
        }



    }
}
