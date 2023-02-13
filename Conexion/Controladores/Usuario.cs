
 

namespace Conexion.Controladores
{

    /// <summary>
    /// Acceso a datos de 'Usuario'
    /// </summary>
    public static class Usuario
    {

        //=========== CREATE ===========//

        #region CREATE


        /// <summary>
        /// Crea un Usuario en la base de datos
        /// </summary>
        public static (EResponses response, int lastId) Create(Modelos.Usuario modelo) 
        {

            // Formato de las cadenas (Para evitar errores)
            modelo.Nombre = StringFormat.FormatoString.AlphaNumericFormat(modelo.Nombre);

            // Encripta la contraseña
            modelo.Contraseña = Seguridad.Encript.Encriptar(Conexion.SecrectWord + modelo.Contraseña);

            return AccesoDatos.Usuario.Create(modelo);
        }


        /// <summary>
        /// Crea un Usuario en la base de datos (Async)
        /// </summary>
        public async static Task<(EResponses response, int lastId)> CreateAsync(Modelos.Usuario modelo)
        {
            // Formato de las cadenas (Para evitar errores)
            modelo.Nombre = StringFormat.FormatoString.AlphaNumericFormat(modelo.Nombre);

            // Encripta la contraseña
            modelo.Contraseña = Seguridad.Encript.Encriptar(Conexion.SecrectWord + modelo.Contraseña);

            
            return await AccesoDatos.Usuario.CreateAsync(modelo);
        }


        #endregion



        //=========== READ ONE ===========//

        #region READ ONE


        /// <summary>
        /// Obtiene los datos de una cuenta
        /// </summary>
        /// <param name="id">ID de la cuenta</param>
        public static (EResponses response, Modelos.Usuario) ReadOne(int id)
        {
            return AccesoDatos.Usuario.ReadOne(id);
        }



        /// <summary>
        /// Obtiene los datos de una cuenta (Async)
        /// </summary>
        /// <param name="id">ID de la cuenta</param>
        public async static Task<(EResponses response, Modelos.Usuario)> ReadOneAsync(int id)
        {
            return await AccesoDatos.Usuario.ReadOneAsync(id);
        }


        /// <summary>
        /// Obtiene los datos de una cuenta
        /// </summary>
        public static (EResponses Response, Modelos.Usuario Modelo) ReadOne(string cuenta)
        {
            return AccesoDatos.Usuario.ReadOne(cuenta);
        }


        /// <summary>
        /// Obtiene los datos de una cuenta (Async)
        /// </summary>
        public async static Task<(EResponses response, Modelos.Usuario)> ReadOneAsync(string cuenta)
        {
            return await AccesoDatos.Usuario.ReadOneAsync(cuenta);
        }



        #endregion



        //=========== UPDATE ===========//

        #region UPDATE


        /// <summary>
        /// Actualiza la informacion de un Usuario
        /// </summary>
        public static EResponses Update(Modelos.Usuario modelo)
        {
            return AccesoDatos.Usuario.Update(modelo);
        }


        /// <summary>
        /// Actualiza la informacion de un Usuario (Async)
        /// </summary>
        public async static Task<EResponses> UpdateAsync(Modelos.Usuario modelo)
        {
            return await AccesoDatos.Usuario.UpdateAsync(modelo);
        }


        #endregion



        //=========== DELETE ===========//

        #region DELETE


        /// <summary>
        /// Elimina un Usuario de la base de datos
        /// </summary>
        public static EResponses Delete(Modelos.Usuario modelo)
        {
            return AccesoDatos.Usuario.Delete(modelo);
        }


        /// <summary>
        /// Elimina un Usuario de la base de datos (Async)
        /// </summary>
        public async static Task<EResponses> DeleteAsync(Modelos.Usuario modelo)
        {
            return await AccesoDatos.Usuario.DeleteAsync(modelo);
        }


        #endregion


    }

}
