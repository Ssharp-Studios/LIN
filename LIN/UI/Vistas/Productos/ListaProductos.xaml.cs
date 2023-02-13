using LIN.Observador;

namespace LIN.UI.Vistas.Productos;

public partial class ListaProductos : ContentPage
{


    /// <summary>
    /// Lista de los prodructos
    /// </summary>
    private readonly List<Controles.Producto> Elementos = new();



    /// <summary>
    /// Constructor
    /// </summary>
    public ListaProductos()
    {
        InitializeComponent();
        LoadControls();
    }


    //============== Funciones ==============//


    /// <summary>
    /// Carga los controles de la base de datos y los renderiza
    /// </summary>
    private void LoadControls()
    {

        // Elimina los controles preexistentes
        Elementos.Clear();

        // Consulta a la BD
        var items = from B in Conexion.Controladores.Producto.ReadAll(Conexion.Sesion.Instance.Informacion.Id).Item2
                    orderby B.Cantidad descending
                    select B;

        // Agrega los controles
        foreach (var e in items)
        {
            var control = new Controles.Producto(e ?? new());
            control.OtherClick += ClickEventProduct!;
            Elementos.Add(control);
        }


        // Si no hay productos
        if (!Elementos.Any())
        {
            lbInfo.Text = "Nada que mostrar aqui...";
            return;
        }


        // Mensaje
        lbInfo.Text = $"{Elementos.Count} Productos";

        // Renderiza la lista
        RenderList(Elementos);
    }



    /// <summary>
    /// Busqueda de un producto
    /// </summary>
    private void SearhProducto(string pattern)
    {

        // Elimina la ultima informacion
        lbInfo.Text = "";


        // Si el patron esta vacio
        if (pattern == null || pattern.Trim() == "")
        {
            RenderList(Elementos);
            lbInfo.Text = $"{Elementos.Count} Productos";
            return;
        }

        // Formato del patron
        pattern = pattern.Trim().ToLower().Normalize();

        // Filtrado
        var items = Elementos.Where(T => T.Modelo.Nombre.ToLower().Contains(pattern) ||
                                          T.Modelo.Categoria.ToLower().Contains(pattern) ||
                                          T.Modelo.Codigo.ToLower().Contains(pattern));

        // Analisis de resultados
        if (!items.Any())
        {
            lbInfo.Text = $"No se encontraron resultados para '{pattern}'";
            RenderList();
            return;
        }


        // Renderiza la lista
        RenderList(items);
        lbInfo.Text = $"{items.Count()} resultados para '{pattern}'";

    }



    /// <summary>
    /// Renderiza la lista de controles
    /// </summary>
    private void RenderList(IEnumerable<Controles.Producto> lista)
    {
        // Elimina los elementos visibles
        content.Clear();
        foreach (var e in lista)
        {
            e.Show();
            content.Add(e);
        }
    }



    /// <summary>
    /// Renderiza una lista vacia de productos
    /// </summary>
    private void RenderList()
    {
        RenderList(new List<Controles.Producto>());
    }



    //============== Eventos ==============//


    /// <summary>
    /// Evento click de cada producto
    /// </summary>
    private void ClickEventProduct(object sender, EventArgs e)
    {
        var obj = (IProductable)sender;
        new ProductViewer(obj.Modelo).Show(this);
    }



    /// <summary>
    /// EVENTO: Busqueda de productos (Precionar buscar)
    /// </summary>
    private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
    {
        SearhProducto(src.Text ?? "");
    }



    /// <summary>
    /// EVENTO: Busqueda de productos (Escribir)
    /// </summary>
    private void src_TextChanged(object sender, TextChangedEventArgs e)
    {
        SearhProducto(src.Text ?? "");
    }



    /// <summary>
    /// Agrega un nuevo producto
    /// </summary>
    private void Button_Clicked(object sender, EventArgs e)
    {
        new ProductAdd().Show(this);
    }


}