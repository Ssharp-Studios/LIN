
namespace Conexion.Modelos
{

    /// <summary>
    /// Modelo de 'Login'
    /// </summary>
    public class Login
    {

        public int Id { get; set; } = -1;
        public string IP { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public EPlatform Plataforma { get; set; } = EPlatform.Undefined;
        public int Usuario { get; set; } = -1;


        /// <summary>
        /// Clona el objeto
        /// </summary>
        public Login Clone()
        {
            var obj = new Login()
            {
                Id= Id,
                IP= IP,
                Fecha= Fecha,
                Plataforma = Plataforma,
                Usuario = Usuario
            }; 
            return obj; 

        }


    }
}
