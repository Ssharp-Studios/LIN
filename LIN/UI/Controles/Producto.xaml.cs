using LIN.Observador;
using System.ComponentModel.DataAnnotations;

namespace LIN.UI.Controles;

public partial class Producto : ContentView, IProductable
{


    //========== Eventos ==========//

    // Evento click sobre la imagen
    public event EventHandler<EventArgs>? ImageClick;

    // Evento click sobre los otros campos
    public event EventHandler<EventArgs>? OtherClick;


    /// <summary>
    /// Modelo actual
    /// </summary>
    [Required]
    public Conexion.Modelos.Producto Modelo { get; set; }




    /// <summary>
    /// Constructor
    /// </summary>
    public Producto()
    {
        InitializeComponent();
        this.Modelo = new();
        LoadModelVisible();
    }



    /// <summary>
    /// Constructor
    /// </summary>
    public Producto(Conexion.Modelos.Producto modelo)
    {
        InitializeComponent();
        this.Modelo = modelo;
        ProductoSuscriptor.Suscribe(this);
        LoadModelVisible();
    }




    /// <summary>
    /// Carga el modelo
    /// </summary>
    public void LoadModelVisible()
    {

        if (Modelo.Estado != Conexion.EProductState.Normal)
            this.Hide();

        img.Source = ImageEncoder.DesEncode(Modelo.Imagen);
        lbName.Text = Modelo.Nombre ?? "";
        lbPrecio.Text = $"$ {Modelo.PrecioVenta}";
        lbCategoria.Text = Modelo.Categoria;
        lbCantidad.Text = $"{Modelo.Cantidad} u";
    }


    /// <summary>
    /// Labels
    /// </summary>
    private void LabelsGestures(object sender, EventArgs e)
    {
        OtherClick?.Invoke(this, new());
    }

    /// <summary>
    /// Imagen
    /// </summary>
    private void ImageGestures(object sender, EventArgs e)
    {
        ImageClick?.Invoke(this, new());
    }
}