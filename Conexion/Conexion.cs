
namespace Conexion
{

    /// <summary>
    /// Conexion con la base de datos
    /// </summary>
    public class Conexion
    {

        //========== Constantes ==========//
        private string Server = "";
        private string DataBaseName = "";
        private string User = "";
        private string Password = "";
        private string Port = "";

        // Palabra para la encriptacion
        public static readonly string SecrectWord = "ipass:";



        /// <summary>
        /// Obtiene la base de datos
        /// </summary>
        public readonly MySqlConnection? DataBase = null;


        /// <summary>
        /// Obtiene si la base de datos esta conectada
        /// </summary>
        public bool IsConnected { get => DataBase?.State == System.Data.ConnectionState.Open; }



        /// <summary>
        /// Nueva conexion
        /// </summary>
        private Conexion()
        {
            try
            {
                SetLocalBase();
                //SetOnlineBase();
                DataBase = new($"server={Server}; database={DataBaseName}; user={User}; password={Password}; port={Port};");
                DataBase.Open();
            }
            catch 
            {
            }
        }




        /// <summary>
        /// Cambia la configuracion de base de datos a LocalHost
        /// </summary>
        private void SetLocalBase()
        {
            Server = "localhost";
            DataBaseName = "lin";
            User = "root";
            Password = "";
            Port = "";
        }



        /// <summary>
        /// Cambia la configuracion de base de datos a Online
        /// </summary>
        private void SetOnlineBase()
        {
            Server = "sql9.freesqldatabase.com";
            DataBaseName = "sql9596119";
            User = "sql9596119";
            Password = "CK4vIf5UzD";
            Port = "3306";
        }



        /// <summary>
        /// Obtiene una conexion alterna a la base de datos
        /// </summary>
        public static Conexion GetAnother()
        {
            return new();
        }



        // Instancia
        private static Conexion? _instance;



        /// <summary>
        /// Obtiene la instancia de conexion
        /// </summary>
        public static Conexion Instancia
        {
            get
            {
                _instance ??= new();
                return _instance;
            }
        }



    }

}
