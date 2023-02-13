
namespace Conexion
{

    /// <summary>
    /// Sesion 
    /// </summary>
    public sealed class Sesion
    {

        /// <summary>
        /// Informacion del usuario
        /// </summary>
        public Modelos.Usuario Informacion { get; private set; }



        /// <summary>
        /// Si la sesion es activa
        /// </summary>
        public static bool IsOpen { get; set; } = false;



        /// <summary>
        /// Recarga o inicia una sesion
        /// </summary>
        public static async Task<(Sesion? Sesion, EResponses Response)> LoginWith(string username, string password, EPlatform platform, bool priv = false)
        {

            // Cierra la sesion Actual
            CloseSesion();

            //var ip = Utilidades.Utilidades.GetIpPublica();
            var ip = Extensions.Utilidades.GetIpPublica();

            // Validacion de user
            var (Response, Modelo) = AccesoDatos.Usuario.ReadOne(username);
            if (Response != EResponses.Success)
                return (null, Response);


            // Validacion de contraseña
            if (Modelo.Contraseña != Seguridad.Encript.Encriptar(Conexion.SecrectWord + password))
                return (null, EResponses.InvalidPassword);


            // Agregacion de la sesion
            if (!priv)
            {
                // Modelo
                Modelos.Login m = new()
                {
                    IP = await ip,
                    Plataforma = platform,
                    Usuario = Modelo.Id,
                    Fecha = DateTime.Now,
                };

                AccesoDatos.Login.Create(m);

            }


            // Datos de la instancia
            Instance.Informacion = Modelo;
            IsOpen = true;

            return (Instance, EResponses.Success);
        }



        /// <summary>
        /// Cierra la sesion
        /// </summary>
        public static void CloseSesion()
        {
            IsOpen = false;
            Instance.Informacion = new();


   

        }






        //==================== Singletong ====================//


        private readonly static Sesion _instance = new();

        private Sesion()
        {
            this.Informacion = new();
        }


        public static Sesion Instance => _instance;
    }


}
