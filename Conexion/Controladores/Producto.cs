
 

namespace Conexion.Controladores
{

    /// <summary>
    /// Acceso a datos de 'Producto'
    /// </summary>
    public static class Producto
    {

        //=========== CREATE ===========//

        #region CREATE


        /// <summary>
        /// Crea un producto en la base de datos
        /// </summary>
        public static (EResponses response, int lastId) Create(Modelos.Producto modelo)
        {
            return AccesoDatos.Producto.Create(modelo);
        }



        /// <summary>
        /// Crea un producto en la base de datos (Async)
        /// </summary>
        public async static Task<(EResponses response, int lastId)> CreateAsync(Modelos.Producto modelo)
        {
            return await AccesoDatos.Producto.CreateAsync(modelo);
        }



        #endregion



        //=========== READ ALL ===========//

        #region READ ALL


        /// <summary>
        /// Obtiene la lista productos asociada a una cuenta
        /// </summary>
        /// <param name="id">ID de la cuenta</param>
        public static (EResponses response, List<Modelos.Producto>) ReadAll(int id)
        {
            return AccesoDatos.Producto.ReadAll(id);
        }


        /// <summary>
        /// Obtiene la lista productos asociada a una cuenta (Async)
        /// </summary>
        /// <param name="id">ID de la cuenta</param>
        public async static Task<(EResponses response, List<Modelos.Producto>)> ReadAllAsync(int id)
        {
            return await AccesoDatos.Producto.ReadAllAsync(id);
        }

        #endregion



        //=========== UPDATE ===========//

        #region UPDATE


        /// <summary>
        /// Actualiza la informacion de un Producto
        /// </summary>
        public static EResponses Update(Modelos.Producto modelo)
        {
            return AccesoDatos.Producto.Update(modelo);
        }


        /// <summary>
        /// Actualiza la informacion de un Producto (Async)
        /// </summary>
        public async static Task<EResponses> UpdateAsync(Modelos.Producto modelo)
        {
            return await AccesoDatos.Producto.UpdateAsync(modelo);
        }



        #endregion



        //=========== DELETE ===========//

        #region DELETE


        /// <summary>
        /// Elimina un producto de la base de datos
        /// </summary>
        public static EResponses Delete(Modelos.Producto modelo)
        {
            return AccesoDatos.Producto.Delete(modelo);
        }


        /// <summary>
        /// Elimina un producto de la base de datos (Async)
        /// </summary>
        public async static Task<EResponses> DeleteAsync(Modelos.Producto modelo)
        {
            return await AccesoDatos.Producto.DeleteAsync(modelo);
        }


        #endregion


    }

}
