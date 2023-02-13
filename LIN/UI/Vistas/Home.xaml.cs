namespace LIN.UI.Vistas;

public partial class Home : ContentPage
{
	public Home()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		new Productos.ListaProductos().Show(this);
    }

   

    private void Button_Clicked_1(object sender, EventArgs e)
    { 
        new Proveedores.Index().Show(this);

    }

    private void bt3_Clicked(object sender, EventArgs e)
    {
        new Entradas.Index().Show(this);
    }
}