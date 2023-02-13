
namespace Conexion.Modelos
{

    /// <summary>
    /// Modelo de 'Proveedor'
    /// </summary>
    public class Proveedor
    {

        public int Id { get; set; } = -1;
        public string Nombre { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Imagen { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public EProveedorState Estado { get; set; } = EProveedorState.Normal;
        public int Usuario { get; set; } = -1;



        /// <summary>
        /// Clona el objeto
        /// </summary>
        public Proveedor Clone()
        {
            var obj = new Proveedor()
            {
                Id = Id,
                Nombre = Nombre,
                Telefono = Telefono,
                Correo = Correo,
                Imagen = Imagen,
                Usuario = Usuario
            };
            return obj;
        }


    }
}
