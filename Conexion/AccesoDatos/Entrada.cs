
namespace Conexion.AccesoDatos
{


    /// <summary>
    /// Acceso a datos de 'Entrada'
    /// </summary>
    internal static class Entrada
    {

        // Nombre de la tabla en la base de datos
        private const string TableName = "`ENTRADA`";



        //=========== CREATE ===========//

        #region CREATE


        /// <summary>
        /// Crea una entrada en la base de datos
        /// </summary>
        public static (EResponses response, int lastId) Create(Modelos.Entrada modelo) => Create(modelo, Conexion.Instancia);



        /// <summary>
        /// Crea una entrada en la base de datos (Async)
        /// </summary>
        public async static Task<(EResponses response, int lastId)> CreateAsync(Modelos.Entrada modelo) => await Task.Run(() => Create(modelo, Conexion.GetAnother()));



        /// <summary>
        /// Crea una entrada en la base de datos (Private)
        /// </summary>
        private static (EResponses response, int lastId) Create(Modelos.Entrada modelo, Conexion conexion)
        {

            // Conexion con la base de datos
            if (!conexion.IsConnected)
                return (EResponses.NotConnection, -1);

            // Consulta
            string query = $""" 
                  INSERT INTO {TableName} (`FECHA`, `TIPO`, `USUARIO_FK`) 
                  VALUES ('', {(int)modelo.Tipo}, {modelo.Usuario});

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

                // Registra los detalles


                return new(EResponses.Success, lastIndex);

            }
            catch 
            {
               
            }

            // Error desconocido
            return new(EResponses.Undefined, -1);
        }


        #endregion



        //=========== READ ONE ===========//

        #region READ ONE


        /// <summary>
        /// Obtiene los datos de una Entrada en concreto
        /// </summary>
        /// <param name="id">ID de la entrada</param>
        public static (EResponses response, Modelos.Entrada) ReadOne(int id) => ReadOne(id, Conexion.Instancia);



        /// <summary>
        /// Obtiene los datos de una Entrada en concreto (Async)
        /// </summary>
        /// <param name="id">ID de la entrada</param>
        public async static Task<(EResponses response, Modelos.Entrada)> ReadOneAsync(int id) => await Task.Run(() => ReadOne(id, Conexion.GetAnother()));



        /// <summary>
        /// Obtiene los datos de una Entrada en concreto
        /// </summary>
        private static (EResponses response, Modelos.Entrada) ReadOne(int id, Conexion conexion)
        {
            // Consulta
            string query = $""" SELECT * FROM {TableName} WHERE ID = {id} """;

            // Ejecucion
            return ReadOneQuery(query, conexion);
        }



        /// <summary>
        /// Obtiene los datos de una Entrada en concreto
        /// </summary>
        private static (EResponses response, Modelos.Entrada) ReadOneQuery(string query, Conexion conexion)
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
                    return (EResponses.NotRows, new());
                }

                // Lee los datos
                while (reader.Read())
                {

                    Modelos.Entrada modelo = new()
                    {
                        ID = reader.GetInt32(0),
                        Fecha = reader.GetDateTime(1),
                        Tipo = (EEntradaType)reader.GetInt16(2),
                        Usuario = reader.GetInt32(3)
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



        //=========== READ ===========//

        #region READ ALL


        /// <summary>
        /// Obtiene la lista de 'Entrada' asociados a una cuenta
        /// </summary>
        /// <param name="id">ID de la cuenta</param>
        public static (EResponses response, List<Modelos.Entrada>) ReadAll(int id) => ReadAll(id, Conexion.Instancia);



        /// <summary>
        /// Obtiene la lista de 'Entrada' asociados a una cuenta(Async)
        /// </summary>
        /// <param name="id">ID de la cuenta</param>
        public async static Task<(EResponses response, List<Modelos.Entrada>)> ReadAllAsync(int id) => await Task.Run(() => ReadAll(id, Conexion.GetAnother()));



        /// <summary>
        /// Obtiene la lista de 'Entrada' asociados a una cuenta
        /// </summary>
        private static (EResponses response, List<Modelos.Entrada>) ReadAll(int id, Conexion conexion)
        {

            // Conexion con la base de datos
            if (!conexion.IsConnected)
                return (EResponses.NotConnection, new());

            // Consulta
            string query = $""" SELECT * FROM {TableName} WHERE USUARIO_FK = {id} """;

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
                List<Modelos.Entrada> modelos = new();
                while (reader.Read())
                {

                    Modelos.Entrada modelo = new()
                    {
                        ID = reader.GetInt32(0),
                        Fecha = reader.GetDateTime(1),
                        Tipo = (EEntradaType)reader.GetInt16(2),
                        Usuario = reader.GetInt32(3)
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
