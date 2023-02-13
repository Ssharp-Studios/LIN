
namespace Conexion.Modelos
{
    public class Entrada
    {

        public int ID { get; set; }
        public EEntradaType Tipo { get; set; }
        public DateTime Fecha { get; set; }
        public List<EntradaDetalle> Detalles { get; set; }
        public int Usuario { get; set; }


    }


}
