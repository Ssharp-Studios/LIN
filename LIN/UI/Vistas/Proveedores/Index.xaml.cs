using LIN.Observador;

namespace LIN.UI.Vistas.Proveedores;

public partial class Index : ContentPage
{
    public Index()
    {
        InitializeComponent();
        Load();
    }


    private void Load()
    {
        // Elimina los controles preexistentes
        content.Clear();

        // Consulta
        var items = from B in Conexion.Controladores.Proveedor.ReadAll(Conexion.Sesion.Instance.Informacion.Id).Item2
                    orderby B.Nombre ascending
                    select B;

        // Agrega los controles
        foreach (var e in items)
        {
            var control = new CustomControls.Contacto(e ?? new());
            control.Clicked += Event!;
            content.Add(control);
        }
    }

    public void Event(object sender, EventArgs args)
    {
        var obj = (IProveedorable)sender;
        var popup = new Popups.ContactoView(obj.Modelo);
        this.ShowPopup(popup);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        new ProveedorAdd().Show(this);

    }
}