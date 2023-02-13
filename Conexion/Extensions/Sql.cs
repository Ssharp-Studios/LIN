namespace Conexion
{

    /// <summary>
    /// Extensiones para MySQL y MySQL Connector
    /// </summary>
    public static class Sql
    {

        /// <summary>
        /// Obtiene un archivo Blob
        /// </summary>
        public static string GetBlob(this MySqlDataReader reader, int i)
        {

#if WINDOWS
            return reader.GetString(i);
#elif ANDROID
            return Encoding.UTF8.GetString((byte[])reader.GetValue(i));
#else
            return "";
#endif

        }

    }
}
