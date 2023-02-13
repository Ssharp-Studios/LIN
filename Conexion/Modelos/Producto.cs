
namespace Conexion.Modelos
{

    /// <summary>
    /// Modelo de un 'Producto'
    /// </summary>
    public class Producto
    {

        public int Id { get; set; } = -1;
        public string Imagen { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Codigo { get; set; } = string.Empty;
        public int Cantidad { get; set; } = 0;
        public string Categoria { get; set; } = string.Empty;
        public double PrecioCompra { get; set; } = -1;
        public double PrecioVenta { get; set; } = -1;
        public Proveedor Proveedor { get; set; } = new();
        public EProductState Estado { get; set; } = EProductState.Normal;
        public int Usuario { get; set; } = -1;



        /// <summary>
        /// Clona el objeto
        /// </summary>
        public Producto Clone()
        {
            var obj = new Producto()
            {
                Id = Id,
                Imagen = Imagen,
                Nombre = Nombre,
                Codigo = Codigo,
                Cantidad = Cantidad,
                Categoria = Categoria,
                PrecioCompra = PrecioCompra,
                PrecioVenta = PrecioVenta,
                Proveedor = Proveedor,
                Estado = Estado,
                Usuario = Usuario,
            };
            return obj;
        }


        /// <summary>
        /// Rellena el modelo en base a otro
        /// </summary>
        public void PutData(Producto model)
        {
            Id = model.Id;
            Imagen = model.Imagen;
            Nombre = model.Nombre;
            Codigo = model.Codigo;
            Cantidad = model.Cantidad;
            Categoria = model.Categoria;
            PrecioCompra = model.PrecioCompra;
            PrecioVenta = model.PrecioVenta;
            Proveedor = model.Proveedor;
            Estado = model.Estado;
            Usuario = model.Usuario;
        }


    }
}
