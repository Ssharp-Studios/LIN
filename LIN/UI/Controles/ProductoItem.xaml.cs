using LIN.Observador;
using System.ComponentModel.DataAnnotations;

namespace LIN.UI.Controles;

public partial class ProductoItem : ContentView, IProductable
{


    public event EventHandler<EventArgs>? ImageClick;

    public event EventHandler<EventArgs>? OtherClick;


    /// <summary>
    /// Modelo actual
    /// </summary>
    [Required]
    public Conexion.Modelos.Producto Modelo { get; set; }





    public ProductoItem()
    {
        InitializeComponent();
        this.Modelo = new();
        LoadModelVisible();
    }


    public ProductoItem(Conexion.Modelos.Producto modelo)
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
        lbCantidad.Text = $"{Modelo.Cantidad} u";
    }


    // Labels
    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        OtherClick?.Invoke(this, new());
    }

    // Imagen
    private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
    {
        ImageClick?.Invoke(this, new());
    }
}