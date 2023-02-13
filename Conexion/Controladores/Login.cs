
 

namespace Conexion.Controladores
{

    /// <summary>
    /// Acceso a datos de 'Login'
    /// </summary>
    public static class Login
    {


        //=========== CREATE ===========//

        #region CREATE

        /// <summary>
        /// Registra un nuevo registro de 'login' en la base de datos
        /// </summary>
        public static (EResponses response, int lastId) Create(Modelos.Login modelo)
        {
           return AccesoDatos.Login.Create(modelo);
        }



        /// <summary>
        /// Registra un nuevo registro de 'login' en la base de datos (Async)
        /// </summary>
        public async static Task<(EResponses response, int lastId)> CreateAsync(Modelos.Login modelo)
        {
            return await AccesoDatos.Login.CreateAsync(modelo);
        }



        #endregion



        //=========== READ ===========//

        #region READ ALL


        /// <summary>
        /// Obtiene la lista de 'Login' asociados a una cuenta
        /// </summary>
        /// <param name="id">ID de la cuenta</param>
        public static (EResponses response, List<Modelos.Login>) ReadAll(int id)
        {
            return AccesoDatos.Login.ReadAll(id);
        }



        /// <summary>
        /// Obtiene la lista de 'Login' asociados a una cuenta(Async)
        /// </summary>
        /// <param name="id">ID de la cuenta</param>
        public async static Task<(EResponses response, List<Modelos.Login>)> ReadAllAsync(int id)
        {
            return await AccesoDatos.Login.ReadAllAsync(id);
        }



        #endregion



    }

}
