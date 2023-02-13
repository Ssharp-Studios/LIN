
namespace LIN.Observador
{

    /// <summary>
    /// IProductable
    /// </summary>
    public interface IProductable
    {

        /// <summary>
        /// Modelo de producto
        /// </summary>
        Conexion.Modelos.Producto Modelo { get; set; }


        /// <summary>
        /// Envia notificacion de cambio del modelo
        /// </summary>
        public void SubmitModel()
        {
            ProductoSuscriptor.Notify(this);
        }


        /// <summary>
        /// Carga el modelo de producto
        /// </summary>
        void LoadModelVisible();


    }
}
