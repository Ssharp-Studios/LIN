
namespace LIN.Observador
{

    /// <summary>
    /// IProveedorable
    /// </summary>
    public interface IProveedorable
    {

        /// <summary>
        /// Modelo de producto
        /// </summary>
        Conexion.Modelos.Proveedor Modelo { get; set; }


        /// <summary>
        /// Envia notificacion de cambio del modelo
        /// </summary>
        public void SubmitModel()
        {
            ProveedorSuscriptor.Notify(this);
        }


        /// <summary>
        /// Carga el modelo de producto
        /// </summary>
        void LoadModelVisible();


    }
}
