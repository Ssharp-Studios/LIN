using LIN.Observador;


namespace LIN.UI.Popups;

public partial class ProductPicker : Popup
{
	public ProductPicker()
	{
		InitializeComponent();
		Load();
	}

	public async void Load()
	{
		await Task.Delay(200);

        LoadControls();




	}

    /// <summary>
	/// Lista de elementos visuales
	/// </summary>
	private readonly List<Controles.ProductoItem> UIElements = new();

    /// <summary>
    /// Carga los controles de la base de datos y los renderiza
    /// </summary>
    private async void LoadControls()
    {

        // Elimina los controles preexistentes
        UIElements.Clear();

        // Consulta
        var items = from B in (await Conexion.Controladores.Producto.ReadAllAsync(Conexion.Sesion.Instance.Informacion.Id)).Item2
                    orderby B.Cantidad descending
                    select B;

        // Agrega los controles
        foreach (var e in items)
        {
            var control = new Controles.ProductoItem(e ?? new());
            control.OtherClick += ClickEventProduct!;
            UIElements.Add(control);
        }


        // Mensaje
        if (!UIElements.Any())
        {

        }

        // Renderiza la lista
        RenderList(UIElements);
    }


    private void ClickEventProduct(object sender, EventArgs e)
    {
        var obj = (IProductable)sender;

        //
        return;

    }



    /// <summary>
    /// Renderiza la lista de controles
    /// </summary>
    private void RenderList(IEnumerable<Controles.ProductoItem> lista)
    {
        // Elimina los elementos visibles
        content.Clear();
        foreach (var e in lista)
        {
            e.Show();
            content.Add(e);
        }
    }
}