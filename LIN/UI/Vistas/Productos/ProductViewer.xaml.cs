using Conexion.Modelos;
using LIN.Observador;

namespace LIN.UI.Vistas.Productos;


public partial class ProductViewer : ContentPage, IProductable
{


    //======== Propiedades ========//

    /// <summary>
    /// Modelo del producto
    /// </summary>
    public Producto Modelo { get; set; }


    /// <summary>
    /// Modelo de la vista (Evitar cambios alternos)
    /// </summary>
    public Producto ModeloVista { get; set; } = new();



    /// <summary>
    /// Constructor
    /// </summary>
    public ProductViewer(Producto modelo)
    {
        // Default
        InitializeComponent();

        // Datos del modelo
        this.Modelo = modelo;

        // Carga el modelo
        LoadModel();

        // Suscripcion
        ProductoSuscriptor.Suscribe(this);

    }




    /// <summary>
    /// Carga la vista (UI) del modelo
    /// </summary>
    public void LoadModelVisible()
    {
        // Si no existe
        if (Modelo == null)
            this.Close();

        // Modelo
        var modelo = ModeloVista ?? new();

        // Metadatos
        lbNombre.Text = modelo.Nombre;
        lbTipo.Text = modelo.Categoria;
        lbCantidad1.Text = modelo.Cantidad.ToString();
        counterCantidad.Value = modelo.Cantidad;
        cardValorVenta.ContentText = $"$ {modelo.PrecioVenta}";
        cardValorCompra.ContentText = $"$ {modelo.PrecioCompra}";
        cardProveedor.ContentText = modelo.Proveedor.Nombre;
        icono.Source = ImageEncoder.DesEncode(modelo.Imagen);

    }



    /// <summary>
    /// Carga la vista del modelo
    /// </summary>
    public void LoadModel()
    {
        ModeloVista = Modelo.Clone();
        LoadModelVisible();
    }




 
    /// <summary>
    /// Cuando cambia el valor de cantidad
    /// </summary>
    private void Counter_OnValueChange(object sender, CustomControls.EventIntValue e)
    {
        ModeloVista.Cantidad = e.NewValue;
        lbCantidad1.Text = ModeloVista.Cantidad.ToString();
    }


    /// <summary>
    /// Guarda los nuevos datos
    /// </summary>
    private async void Save()
    {
        Modelo.PutData(ModeloVista);
        ProductoSuscriptor.Notify(this);
        await Conexion.Controladores.Producto.UpdateAsync(Modelo);
    }



    /// <summary>
    /// Boton guardar
    /// </summary>
    private void Button_Clicked(object sender, EventArgs e)
    {
        Save();
    }



    /// <summary>
    /// Boton eliminar
    /// </summary>
    private async void ButtonDeleteEvent(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Eliminar un producto", $"Desea eliminar el producto '{ModeloVista.Nombre}'", "Si", "No");

        if (answer)
        {
            // Nuevos Datos a los modelos
            Modelo.Estado = Conexion.EProductState.Deleted;
            await Conexion.Controladores.Producto.DeleteAsync(Modelo);

            // Alerta
            ProductoSuscriptor.Notify(this);
            this.Close();
        }

    }



    /// <summary>
    /// Cambiar el nombre
    /// </summary>
    private async void lbNameText(object sender, EventArgs e)
    {
        string newname = await DisplayPromptAsync("Nombre del producto", "Ingrese el nuevo valor");

        if (newname.Trim() == "")
            return;
        ModeloVista.Nombre = newname;
        LoadModelVisible();
    }



    /// <summary>
    /// Cambiar la categoria
    /// </summary>
    private async void lbCategoryText(object sender, EventArgs e)
    {
        string value = await DisplayPromptAsync("Categoria del producto", "Ingrese el nuevo valor");
        ModeloVista.Categoria = value;
        LoadModelVisible();
    }

    public void Notify()
    {
        ModeloVista = Modelo.Clone();
        LoadModelVisible();
    }


}