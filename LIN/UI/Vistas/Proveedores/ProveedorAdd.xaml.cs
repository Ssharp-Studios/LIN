using Conexion;
using Conexion.Modelos;

namespace LIN.UI.Vistas.Proveedores;

public partial class ProveedorAdd : ContentPage
{


    public ProveedorAdd()
    {
        InitializeComponent();
    }


    private async void btnLogin_Clicked(object sender, EventArgs e)
    {

        // Modelo
        Proveedor proveedor = new()
        {
            Nombre = txtName.Text,
            Imagen = await inputImage.Encode64(),
            Correo = txtMail.Text,
            Telefono = txtPhone.Text,
            Direccion = txtDireccion.Text,
            Estado = EProveedorState.Normal,
            Usuario = Sesion.Instance.Informacion.Id
        };

        // Registra el modelo
        Conexion.Controladores.Proveedor.Create(proveedor);

        // Muestra el popup
        await this.ShowPopupAsync(new Popups.DefaultPopup() { Text = "Agregado" });

    }


}