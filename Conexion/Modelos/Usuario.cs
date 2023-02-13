
namespace Conexion.Modelos
{

    /// <summary>
    /// Modelo de 'Usuario'
    /// </summary>
    public class Usuario
    {

        public int Id { get; set; } = 0;
        public string UsuarioU { get; set; } = string.Empty;
        public string Perfil { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Contraseña { get; set; } = string.Empty;
        public DateTime Creacion { get; set; }
        public EAccountState Estado { get; set; } = EAccountState.Normal;


        /// <summary>
        /// Clona el objeto
        /// </summary>
        public Usuario Clone()
        {
            var obj = new Usuario()
            {
                Id = Id,
                UsuarioU = UsuarioU,
                Perfil = Perfil,
                Nombre = Nombre,
                Contraseña = Contraseña,
                Creacion = Creacion,
                Estado = Estado
            };
            return obj;
        }


    }
}
