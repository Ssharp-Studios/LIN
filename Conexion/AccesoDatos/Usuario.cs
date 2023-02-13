namespace Conexion.AccesoDatos
{

    /// <summary>
    /// Acceso a datos de 'Usuario'
    /// </summary>
    internal class Usuario
    {

        // Nombre de la tabla en la base de datos
        private const string TableName = "`USUARIOS`";


        //=========== CREATE ===========//

        #region CREATE


        /// <summary>
        /// Crea un Usuario en la base de datos
        /// </summary>
        public static (EResponses response, int lastId) Create(Modelos.Usuario modelo) => Create(modelo, Conexion.Instancia);



        /// <summary>
        /// Crea un Usuario en la base de datos (Async)
        /// </summary>
        public async static Task<(EResponses response, int lastId)> CreateAsync(Modelos.Usuario modelo) => await Task.Run(() => Create(modelo, Conexion.GetAnother()));



        /// <summary>
        /// Crea un Usuario en la base de datos (Private)
        /// </summary>
        private static (EResponses response, int lastId) Create(Modelos.Usuario modelo, Conexion conexion)
        {

            // Conexion con la base de datos
            if (!conexion.IsConnected)
                return (EResponses.NotConnection, -1);

            // Consulta
            string query = $""" 
                  INSERT INTO {TableName} (`USUARIO`, `PERFIL`, `NOMBRE`, `CONTRASENA`, `CREACION`, `ESTADO`) 
                  VALUES ("{modelo.UsuarioU}","{modelo.Perfil}","{modelo.Nombre}","{modelo.Contraseña}",'{DateTime.Now:yyyy.MM.dd HH:mm:ss}',{(int)modelo.Estado});

                  SELECT LAST_INSERT_ID();
                  """;


            // Ejecucion
            try
            {
                // Comando
                MySqlCommand comando = new(query, conexion.DataBase);

                // ID del insertado
                var objInt = comando.ExecuteScalar();
                int lastIndex = Convert.ToInt32(objInt);

                return new(EResponses.Success, lastIndex);

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
                    return (EResponses.ExistAccount, -1);
            }

            // Error desconocido
            return new(EResponses.Undefined, -1);
        }


        #endregion



        //=========== READ ONE ===========//

        #region READ ONE


        /// <summary>
        /// Obtiene los datos de una cuenta
        /// </summary>
        /// <param name="id">ID de la cuenta</param>
        public static (EResponses response, Modelos.Usuario) ReadOne(int id) => ReadOne(id, Conexion.Instancia);



        /// <summary>
        /// Obtiene los datos de una cuenta (Async)
        /// </summary>
        /// <param name="id">ID de la cuenta</param>
        public async static Task<(EResponses response, Modelos.Usuario)> ReadOneAsync(int id) => await Task.Run(() => ReadOne(id, Conexion.GetAnother()));



        /// <summary>
        /// Obtiene los datos de una cuenta
        /// </summary>
        public static (EResponses Response, Modelos.Usuario Modelo) ReadOne(string cuenta) => ReadOne(cuenta, Conexion.Instancia);



        /// <summary>
        /// Obtiene los datos de una cuenta (Async)
        /// </summary>
        public async static Task<(EResponses response, Modelos.Usuario)> ReadOneAsync(string cuenta) => await Task.Run(() => ReadOne(cuenta, Conexion.GetAnother()));



        /// <summary>
        /// Obtiene los datos de una cuenta
        /// </summary>
        private static (EResponses response, Modelos.Usuario) ReadOne(int id, Conexion conexion)
        {

            // Consulta
            string query = $""" SELECT * FROM {TableName} WHERE ID = {id} """;

            // Ejecucion
            return ReadOneQuery(query, conexion);
        }



        /// <summary>
        /// Obtiene los datos de una cuenta
        /// </summary>
        private static (EResponses response, Modelos.Usuario) ReadOne(string cuenta, Conexion conexion)
        {

            // Consulta
            string query = $""" SELECT * FROM {TableName} WHERE USUARIO = "{cuenta}" """;

            // Ejecucion
            return ReadOneQuery(query, conexion);
        }



        /// <summary>
        /// Obtiene la lista de productos asociada a una cuenta
        /// </summary>
        private static (EResponses response, Modelos.Usuario) ReadOneQuery(string query, Conexion conexion)
        {

            // Conexion con la base de datos
            if (!conexion.IsConnected)
                return (EResponses.NotConnection, new());

            // Ejecucion
            MySqlDataReader? reader = null;
            try
            {
                // Comando
                MySqlCommand comando = new(query, conexion.DataBase);

                // Reader
                reader = comando.ExecuteReader();

                // No hay columnas
                if (!reader.HasRows)
                {
                    reader?.Close();
                    return (EResponses.NotExistAccount, new());
                }

                // Lee los datos
                while (reader.Read())
                {

                    Modelos.Usuario modelo = new()
                    {
                        Id = reader.GetInt32(0),
                        UsuarioU = reader.GetString(1),
                        Perfil = reader.GetBlob(2),
                        Nombre = reader.GetString(3),
                        Contraseña = reader.GetString(4),
                        Creacion = reader.GetDateTime(5),
                        Estado = (EAccountState)reader.GetInt16(6)
                    };
                    reader?.Close();
                    return (EResponses.Success, modelo);
                }


            }
            catch
            {
                reader?.Close();
            }

            // Error desconocido
            reader?.Close();
            return new(EResponses.Undefined, new());
        }


        #endregion



        //=========== UPDATE ===========//

        #region UPDATE


        /// <summary>
        /// Actualiza la informacion de un Usuario
        /// </summary>
        public static EResponses Update(Modelos.Usuario modelo) => Update(modelo, Conexion.Instancia);



        /// <summary>
        /// Actualiza la informacion de un Usuario (Async)
        /// </summary>
        public async static Task<EResponses> UpdateAsync(Modelos.Usuario modelo) => await Task.Run(() => Update(modelo, Conexion.GetAnother()));



        /// <summary>
        /// Actualiza la informacion de un Usuario
        /// </summary>
        private static EResponses Update(Modelos.Usuario modelo, Conexion conexion)
        {

            // Conexion con la base de datos
            if (!conexion.IsConnected)
                return EResponses.NotConnection;

            // Consulta
            string query = $""" 
                            UPDATE {TableName}
                                 `PERFIL`="{modelo.Perfil}",
                                 `NOMBRE`="{modelo.Nombre}",
                                 `CONTRASENA`="{modelo.Contraseña}",
                                 `ESTADO`={(int)modelo.Estado}
                                  WHERE ID = {modelo.Id}
                            """;

            // Ejecucion
            try
            {
                // Comando
                MySqlCommand comando = new(query, conexion.DataBase);

                // Ejecuta
                comando.ExecuteNonQuery();

                // Retorna
                return EResponses.Success;

            }
            catch
            {
            }

            // Error desconocido
            return EResponses.Undefined;
        }


        #endregion



        //=========== DELETE ===========//

        #region DELETE


        /// <summary>
        /// Elimina un Usuario de la base de datos
        /// </summary>
        public static EResponses Delete(Modelos.Usuario modelo) => Delete(modelo, Conexion.Instancia);



        /// <summary>
        /// Elimina un Usuario de la base de datos (Async)
        /// </summary>
        public async static Task<EResponses> DeleteAsync(Modelos.Usuario modelo) => await Task.Run(() => Delete(modelo, Conexion.GetAnother()));



        /// <summary>
        /// Elimina un Usuario de la base de datos
        /// </summary>
        private static EResponses Delete(Modelos.Usuario modelo, Conexion conexion)
        {

            // Conexion con la base de datos
            if (!conexion.IsConnected)
                return EResponses.NotConnection;

            // Consulta
            string query = $"""
                 UPDATE {TableName}
                     `ESTADO` = {EAccountState.Deleted}
                      WHERE ID = {modelo.Id} 
                """;

            // Ejecucion
            try
            {
                // Comando
                MySqlCommand comando = new(query, conexion.DataBase);

                // Ejecuta
                comando.ExecuteNonQuery();

                // Retorna
                return EResponses.Success;

            }
            catch
            {
            }

            // Error desconocido
            return EResponses.Undefined;
        }


        #endregion


    }

}
