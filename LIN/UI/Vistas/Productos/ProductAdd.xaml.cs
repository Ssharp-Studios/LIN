using Conexion;
using Conexion.Modelos;

namespace LIN.UI.Vistas.Productos;

public partial class ProductAdd : ContentPage
{

    private List<Proveedor> proveedorList = new();

    public ProductAdd()
    {
        InitializeComponent();
        FillProveedores();
    }


    public async void FillProveedores()
    {

        proveedorList = (await Conexion.Controladores.Proveedor.ReadAllAsync(Sesion.Instance.Informacion.Id)).Item2;
        RenderList();
    }

    private async void btnLogin_Clicked(object sender, EventArgs e)
    {

        // Proveedor
        var proveedorS = proveedorList.Where(E => E.Nombre == ((Picker)proveedorContent[0]).SelectedItem.ToString()).FirstOrDefault();


        // Modelo
        Producto producto = new()
        {
            Nombre = txtName.Text,
            Cantidad = cantidad.Value,
            Categoria = txtCategoria.Text,
            Usuario = Sesion.Instance.Informacion.Id,
            Imagen = await inputImage.Encode64(),
            Proveedor = proveedorS ?? new(),
            PrecioVenta = double.Parse(txtPrecioVenta.Text),
            PrecioCompra = double.Parse(txtPrecioCompra.Text),
            Estado = EProductState.Normal
        };

        // Crea el producto
        Conexion.Controladores.Producto.Create(producto);

        await this.ShowPopupAsync(new Popups.DefaultPopup() { Text = "Agregado" });

    }

    private  void RenderList()
    {
        var list = new List<string>();
        foreach (var e in proveedorList)
            list.Add(e.Nombre);


        Picker picker = new()
        {
            ItemsSource = list,
            WidthRequest = 300,
            FontFamily = "QSM",
            FontSize = 12,
            HorizontalOptions = LayoutOptions.Center,
          
        };

        proveedorContent.Clear();
        proveedorContent.Add(picker);
      
    }



}