
namespace Conexion.Controladores
{

    /// <summary>
    /// Controlador de 'Entrada'
    /// </summary>
    public static class Entrada
    {


        //=========== CREATE ===========//

        #region CREATE

        /// <summary>
        /// Registra un nuevo registro de 'login' en la base de datos
        /// </summary>
        public static (EResponses response, int lastId) Create(Modelos.Entrada modelo)
        {
           return AccesoDatos.Entrada.Create(modelo);
        }



        /// <summary>
        /// Registra un nuevo registro de 'login' en la base de datos (Async)
        /// </summary>
        public async static Task<(EResponses response, int lastId)> CreateAsync(Modelos.Entrada modelo)
        {
            return await AccesoDatos.Entrada.CreateAsync(modelo);
        }



        #endregion



        //=========== READ ===========//

        #region READ ALL


        /// <summary>
        /// Obtiene la lista de 'Login' asociados a una cuenta
        /// </summary>
        /// <param name="id">ID de la cuenta</param>
        public static (EResponses response, List<Modelos.Entrada>) ReadAll(int id)
        {
            return AccesoDatos.Entrada.ReadAll(id);
        }



        /// <summary>
        /// Obtiene la lista de 'Login' asociados a una cuenta(Async)
        /// </summary>
        /// <param name="id">ID de la cuenta</param>
        public async static Task<(EResponses response, List<Modelos.Entrada>)> ReadAllAsync(int id)
        {
            return await AccesoDatos.Entrada.ReadAllAsync(id);
        }



        #endregion



    }

}
