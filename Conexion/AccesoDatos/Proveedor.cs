
 

namespace Conexion.AccesoDatos
{

    /// <summary>
    /// Acceso a datos de 'Proveedor'
    /// </summary>
    internal class Proveedor
    {

        // Nombre de la tabla en la base de datos
        private const string TableName = "`PROVEEDORES`";



        //=========== CREATE ===========//

        #region CREATE

        /// <summary>
        /// Crea un Proveedor en la base de datos
        /// </summary>
        public static (EResponses response, int lastId) Create(Modelos.Proveedor modelo) => Create(modelo, Conexion.Instancia);



        /// <summary>
        /// Crea un Proveedor en la base de datos (Async)
        /// </summary>
        public async static Task<(EResponses response, int lastId)> CreateAsync(Modelos.Proveedor modelo) => await Task.Run(() => Create(modelo, Conexion.GetAnother()));



        /// <summary>
        /// Crea un Proveedor en la base de datos (Private)
        /// </summary>
        internal static (EResponses response, int lastId) Create(Modelos.Proveedor modelo, Conexion conexion)
        {

            // Conexion con la base de datos
            if (!conexion.IsConnected)
                return (EResponses.NotConnection, -1);

            // Consulta
            string query = $""" 
                  INSERT INTO {TableName} (`IMAGEN`, `NOMBRE`, `CORREO`, `TELEFONO`, `DIRECCION`, `ESTADO`, `USUARIO_FK`) 
                  VALUES ("{modelo.Imagen}",
                          "{modelo.Nombre}",
                          "{modelo.Correo}",
                          "{modelo.Telefono}",
                          "{modelo.Direccion}",
                          {(int)modelo.Estado},
                           {modelo.Usuario}
                  );
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



        //=========== READ ALL ===========//

        #region READ ALL


        /// <summary>
        /// Obtiene la lista proveedores asociada a una cuenta
        /// </summary>
        /// <param name="id">ID de la cuenta</param>
        public static (EResponses response, List<Modelos.Proveedor>) ReadAll(int id) => ReadAll(id, Conexion.Instancia);



        /// <summary>
        /// Obtiene la lista proveedores asociada a una cuenta (Async)
        /// </summary>
        /// <param name="id">ID de la cuenta</param>
        public async static Task<(EResponses response, List<Modelos.Proveedor>)> ReadAllAsync(int id) => await Task.Run(() => ReadAll(id, Conexion.GetAnother()));



        /// <summary>
        /// Obtiene la lista proveedores asociada a una cuenta
        /// </summary>
        internal static (EResponses response, List<Modelos.Proveedor>) ReadAll(int id, Conexion conexion)
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
                List<Modelos.Proveedor> modelos = new();
                while (reader.Read())
                {
                    Modelos.Proveedor modelo = new()
                    {
                        Id = reader.GetInt32(0),
                        Imagen = reader.GetBlob(1),
                        Nombre = reader.GetString(2),
                        Correo = reader.GetString(3),
                        Telefono = reader.GetString(4),
                        Direccion = reader.GetString(5),
                        Usuario = reader.GetInt32(6)
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



        //=========== READ ONE ===========//

        #region READ ONE


        /// <summary>
        /// Obtiene un elemento 'Proveedor' por medio del ID
        /// </summary>
        /// <param name="id">ID del proveedor</param>
        public static (EResponses response, Modelos.Proveedor) ReadOne(int id) => ReadOne(id, Conexion.Instancia);



        /// <summary>
        /// Obtiene un elemento 'Proveedor' por medio del ID (Async)
        /// </summary>
        /// <param name="id">ID del proveedor</param>
        public async static Task<(EResponses response, Modelos.Proveedor)> ReadOneAsync(int id) => await Task.Run(() => ReadOne(id, Conexion.GetAnother()));



        /// <summary>
        /// Obtiene un elemento 'Proveedor' por medio del ID
        /// </summary>
        internal static (EResponses response, Modelos.Proveedor) ReadOne(int id, Conexion conexion)
        {

            // Conexion con la base de datos
            if (!conexion.IsConnected)
                return (EResponses.NotConnection, new());

            // Consulta
            string query = $""" SELECT * FROM {TableName} WHERE ID = {id} """;

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
                    Modelos.Proveedor modelo = new()
                    {
                        Id = reader.GetInt32(0),
                        Imagen = reader.GetBlob(1),
                        Nombre = reader.GetString(2),
                        Correo = reader.GetString(3),
                        Telefono = reader.GetString(4),
                        Direccion = reader.GetString(5),
                        Usuario = reader.GetInt32(6)
                    };
                    reader?.Close();
                    return (EResponses.Success, modelo);
                }

                reader?.Close();

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
        /// Actualiza la informacion de un Proveedor
        /// </summary>
        public static EResponses Update(Modelos.Proveedor modelo) => Update(modelo, Conexion.Instancia);



        /// <summary>
        /// Actualiza la informacion de un Proveedor (Async)
        /// </summary>
        public async static Task<EResponses> UpdateAsync(Modelos.Proveedor modelo) => await Task.Run(() => Update(modelo, Conexion.GetAnother()));



        /// <summary>
        /// Actualiza la informacion de un Proveedor
        /// </summary>
        internal static EResponses Update(Modelos.Proveedor modelo, Conexion conexion)
        {

            // Conexion con la base de datos
            if (!conexion.IsConnected)
                return EResponses.NotConnection;

            // Consulta
            string query = $""" 
                            UPDATE {TableName} `IMAGEN` = "{modelo.Imagen}",
                                               `NOMBRE`= "{modelo.Nombre}",
                                               `CORREO`= "{modelo.Correo}",
                                               `TELEFONO`= "{modelo.Telefono}"
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
        /// Elimina un proveedor de la base de datos
        /// </summary>
        public static EResponses Delete(Modelos.Proveedor modelo) => Delete(modelo, Conexion.Instancia);



        /// <summary>
        /// Elimina un proveedor de la base de datos (Async)
        /// </summary>
        public async static Task<EResponses> DeleteAsync(Modelos.Proveedor modelo) => await Task.Run(() => Delete(modelo, Conexion.GetAnother()));



        /// <summary>
        /// Elimina un proveedor de la base de datos
        /// </summary>
        internal static EResponses Delete(Modelos.Proveedor modelo, Conexion conexion)
        {

            // Conexion con la base de datos
            if (!conexion.IsConnected)
                return EResponses.NotConnection;

            // Consulta
            string query = $""" DELETE FROM {TableName} WHERE ID = {modelo.Id}; """;

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
