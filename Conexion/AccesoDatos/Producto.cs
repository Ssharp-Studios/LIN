
 

namespace Conexion.AccesoDatos
{

    /// <summary>
    /// Acceso a datos de 'Producto'
    /// </summary>
    internal class Producto
    {

        // Nombre de la tabla en la base de datos
        private const string TableName = "`PRODUCTOS`";



        //=========== CREATE ===========//

        #region CREATE


        /// <summary>
        /// Crea un producto en la base de datos
        /// </summary>
        public static (EResponses response, int lastId) Create(Modelos.Producto modelo) => Create(modelo, Conexion.Instancia);



        /// <summary>
        /// Crea un producto en la base de datos (Async)
        /// </summary>
        public async static Task<(EResponses response, int lastId)> CreateAsync(Modelos.Producto modelo) => await Task.Run(() => Create(modelo, Conexion.GetAnother()));



        /// <summary>
        /// Crea un producto en la base de datos (Private)
        /// </summary>
        private static (EResponses response, int lastId) Create(Modelos.Producto modelo, Conexion conexion)
        {

            // Conexion con la base de datos
            if (!conexion.IsConnected)
                return (EResponses.NotConnection, -1);

            // Consulta
            string query = $""" 
                  INSERT INTO {TableName} (`IMAGEN`, `NOMBRE`, `CODIGO`, `CANTIDAD`, `CATEGORIA`, `PRECIO_COMPRA`, `PRECIO_VENTA`, `ESTADO`, `PROVEEDOR_FK`, `USUARIO_FK`) 
                  VALUES ("{modelo.Imagen}","{modelo.Nombre}","{modelo.Codigo}",{modelo.Cantidad},"{modelo.Categoria}",'{modelo.PrecioCompra}','{modelo.PrecioVenta}',{(int)modelo.Estado},{modelo.Proveedor.Id},{modelo.Usuario});

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
        /// Obtiene la lista productos asociada a una cuenta
        /// </summary>
        /// <param name="id">ID de la cuenta</param>
        public static (EResponses response, List<Modelos.Producto>) ReadAll(int id) => ReadAll(id, Conexion.Instancia);



        /// <summary>
        /// Obtiene la lista productos asociada a una cuenta (Async)
        /// </summary>
        /// <param name="id">ID de la cuenta</param>
        public async static Task<(EResponses response, List<Modelos.Producto>)> ReadAllAsync(int id) => await Task.Run(() => ReadAll(id, Conexion.GetAnother()));



        /// <summary>
        /// Obtiene la lista de productos asociada a una cuenta
        /// </summary>
        private static (EResponses response, List<Modelos.Producto>) ReadAll(int id, Conexion conexion)
        {

            // Conexion con la base de datos
            if (!conexion.IsConnected)
                return (EResponses.NotConnection, new());

            // Consulta
            string query = $""" SELECT * FROM {TableName} WHERE USUARIO_FK = {id} AND ESTADO = 1 """;

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
                List<Modelos.Producto> modelos = new();
                while (reader.Read())
                {

                    Modelos.Producto modelo = new()
                    {
                        Id = reader.GetInt32(0),
                        Imagen = reader.GetBlob(1),
                        Nombre = reader.GetString(2),
                        Codigo = reader.GetString(3),
                        Cantidad = reader.GetInt32(4),
                        Categoria= reader.GetString(5),
                        PrecioCompra = reader.GetDouble(6),
                        PrecioVenta= reader.GetDouble(7),
                        Estado =  (EProductState)reader.GetInt16(8),
                        Proveedor = Proveedor.ReadOne(reader.GetInt32(9), Conexion.GetAnother()).Item2,
                        Usuario = reader.GetInt32(10)
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



        //=========== UPDATE ===========//

        #region UPDATE


        /// <summary>
        /// Actualiza la informacion de un Producto
        /// </summary>
        public static EResponses Update(Modelos.Producto modelo) => Update(modelo, Conexion.Instancia);



        /// <summary>
        /// Actualiza la informacion de un Producto (Async)
        /// </summary>
        public async static Task<EResponses> UpdateAsync(Modelos.Producto modelo) => await Task.Run(() => Update(modelo, Conexion.GetAnother()));



        /// <summary>
        /// Actualiza la informacion de un Producto
        /// </summary>
        private static EResponses Update(Modelos.Producto modelo, Conexion conexion)
        {

            // Conexion con la base de datos
            if (!conexion.IsConnected)
                return EResponses.NotConnection;

            // Consulta
            string query = $""" 
                            UPDATE {TableName} SET
                                 `IMAGEN`="{modelo.Imagen}",
                                 `NOMBRE`="{modelo.Nombre}",
                                 `CODIGO`="{modelo.Codigo}",
                                 `CANTIDAD`={modelo.Cantidad},
                                 `CATEGORIA`="{modelo.Categoria}",
                                 `PRECIO_COMPRA`='{modelo.PrecioCompra}',
                                 `PRECIO_VENTA`='{modelo.PrecioVenta}',
                                 `ESTADO`={(int)modelo.Estado},
                                 `PROVEEDOR_FK`={modelo.Proveedor.Id}
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
        /// Elimina un producto de la base de datos
        /// </summary>
        public static EResponses Delete(Modelos.Producto modelo) => Delete(modelo, Conexion.Instancia);



        /// <summary>
        /// Elimina un producto de la base de datos (Async)
        /// </summary>
        public async static Task<EResponses> DeleteAsync(Modelos.Producto modelo) => await Task.Run(() => Delete(modelo, Conexion.GetAnother()));



        /// <summary>
        /// Elimina un producto de la base de datos
        /// </summary>
        private static EResponses Delete(Modelos.Producto modelo, Conexion conexion)
        {

            // Conexion con la base de datos
            if (!conexion.IsConnected)
                return EResponses.NotConnection;

            // Consulta
            string query = $"""
                 UPDATE {TableName} SET
                     `ESTADO` = {(int)EProductState.Deleted}
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
