


namespace Conexion.AccesoDatos
{

    /// <summary>
    /// Acceso a datos de 'Login'
    /// </summary>
    internal static class Login
    {

        // Nombre de la tabla en la base de datos
        private const string TableName = "`LOGINS`";


        //=========== CREATE ===========//

        #region CREATE

        /// <summary>
        /// Registra un nuevo registro de 'login' en la base de datos
        /// </summary>
        public static (EResponses response, int lastId) Create(Modelos.Login modelo) => Create(modelo, Conexion.Instancia);



        /// <summary>
        /// Registra un nuevo registro de 'login' en la base de datos (Async)
        /// </summary>
        public async static Task<(EResponses response, int lastId)> CreateAsync(Modelos.Login modelo) => await Task.Run(() => Create(modelo, Conexion.GetAnother()));



        /// <summary>
        /// Registra un nuevo registro de 'login' en la base de datos (Private)
        /// </summary>
        private static (EResponses response, int lastId) Create(Modelos.Login modelo, Conexion conexion)
        {

            // Conexion con la base de datos
            if (!conexion.IsConnected)
                return (EResponses.NotConnection, -1);

            // Consulta
            string query = $"""
                  INSERT INTO {TableName} (`IP`, `FECHA`, `PLATAFORMA`, `USUARIO_FK`) 
                  VALUES ("{modelo.IP}",
                          '{modelo.Fecha:yyyy.MM.dd HH:mm:ss}',
                           {(int)modelo.Plataforma},
                           {modelo.Usuario});

                  SELECT LAST_INSERT_ID();
                  """;


            // Ejecucion
            try
            {
                // Comando
                MySqlCommand comando = new(query, conexion.DataBase);

                // ID del insertado
                int lastIndex = Convert.ToInt32(comando.ExecuteScalar());

                return new(EResponses.Success, lastIndex);

            }
            catch
            {
            }


            // Error desconocido
            return new(EResponses.Undefined, -1);
        }


        #endregion



        //=========== READ ===========//

        #region READ ALL


        /// <summary>
        /// Obtiene la lista de 'Login' asociados a una cuenta
        /// </summary>
        /// <param name="id">ID de la cuenta</param>
        public static (EResponses response, List<Modelos.Login>) ReadAll(int id) => ReadAll(id, Conexion.Instancia);



        /// <summary>
        /// Obtiene la lista de 'Login' asociados a una cuenta(Async)
        /// </summary>
        /// <param name="id">ID de la cuenta</param>
        public async static Task<(EResponses response, List<Modelos.Login>)> ReadAllAsync(int id) => await Task.Run(() => ReadAll(id, Conexion.GetAnother()));



        /// <summary>
        /// Obtiene la lista de 'Login' asociados a una cuenta
        /// </summary>
        private static (EResponses response, List<Modelos.Login>) ReadAll(int id, Conexion conexion)
        {

            // Conexion con la base de datos
            if (!conexion.IsConnected)
                return (EResponses.NotConnection, new());

            // Consulta
            string query = $""" SELECT * FROM {TableName} WHERE USUARI0_FK = {id} """;

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
                    return (EResponses.Success, new());
                }

                // Lee los datos
                List<Modelos.Login> modelos = new();
                while (reader.Read())
                {
                    Modelos.Login modelo = new()
                    {
                        Id = reader.GetInt32(0),
                        IP = reader.GetString(1),
                        Fecha = reader.GetDateTime(2),
                        Plataforma = (EPlatform)reader.GetInt16(3),
                        Usuario = reader.GetInt32(4),
                    };
                    modelos.Add(modelo);
                }
                reader?.Close();
                return (EResponses.Success, modelos);

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


    }

}
