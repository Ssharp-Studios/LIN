namespace LIN.UI.Vistas;

public partial class Singin : ContentPage
{

    /// <summary>
    /// Constructor
    /// </summary>
    public Singin()
    {
        InitializeComponent();
    }



    /// <summary>
    /// Abre la ventana de 'Login'
    /// </summary>
    private void GoLoginEvent(object sender, EventArgs e)
    {
        new Login().Show(this);
        this.Close();
    }



    /// <summary>
    /// Cuando el texto de las entradas de Usuario, Nombre y Contraseña cambian
    /// </summary>
    private void txtChanged(object sender, TextChangedEventArgs e)
    {
        lbInfo.Hide();
    }



    /// <summary>
    /// Boton de crear cuenta
    /// </summary>
    private async void btnCrear_Clicked(object sender, EventArgs e)
    {

        // Modo de carga
        EnableChargeMode();

        await Task.Delay(100);

        // Variables
        string user = txtUser.Text ?? "";
        string name = txtName.Text ?? "";
        string pass = txtPassword.Text ?? "";

        // Campos vacios
        if (string.IsNullOrEmpty(user.Trim()) || string.IsNullOrEmpty(name.Trim()) || string.IsNullOrEmpty(pass.Trim()))
        {
            DisableChargeMode();
            lbInfo.Text = "Completa todos los campos";
            lbInfo.Show();
            return;
        }


        // Contraseña Lenght
        if (pass.Length < 4)
        {
            DisableChargeMode();
            lbInfo.Text = "La contraseña debe de tener minimo 4 digitos";
            lbInfo.Show();
            return;
        }


        // Modelo
        Conexion.Modelos.Usuario modelo = new()
        {
            Nombre = name,
            UsuarioU = user,
            Contraseña = pass,
            Perfil = await inpImg.Encode64(),
            Estado = Conexion.EAccountState.Normal
        };

        // Creacion
        var res = Conexion.Controladores.Usuario.Create(modelo);

        // Respuesta
        switch (res.response)
        {

            case Conexion.EResponses.Success:
                break;

            case Conexion.EResponses.NotConnection:
                DisableChargeMode();
                lbInfo.Text = "Error conexion";
                lbInfo.IsVisible = true;
                return;

            case Conexion.EResponses.ExistAccount:
                DisableChargeMode();
                lbInfo.Text = $"Ya existe un usuario con el nombre '{user}'";
                lbInfo.IsVisible = true;
                return;

            default:
                DisableChargeMode();
                lbInfo.Text = "Error grave";
                lbInfo.IsVisible = true;
                return;
        }


        Conexion.EPlatform platform;


        if (DeviceInfo.Current.Platform == DevicePlatform.Android)
            platform = Conexion.EPlatform.Android;
        else if (DeviceInfo.Current.Platform == DevicePlatform.WinUI)
            platform = Conexion.EPlatform.Windows;
        else
            platform = Conexion.EPlatform.Undefined;


        // Inicio de sesion
        var (Sesion, Response) = await Conexion.Sesion.LoginWith(user, pass, platform);


        // Evaluacion
        Login form;
        switch (Response)
        {

            case Conexion.EResponses.Success:
                break;


            case Conexion.EResponses.NotExistAccount:
                form = new();
                form.Show(this);
                this.Close();
                return;

          
            case Conexion.EResponses.InvalidPassword:
                form = new();
                form.Show(this);
                this.Close();
                return;

           
            case Conexion.EResponses.NotConnection:
                DisableChargeMode();
                lbInfo.Text = "No hay conexion";
                lbInfo.Show();
                return;

            // Hubo un error grave
            default:
                form = new();
                form.Show(this);
                this.Close();
                return;

        }


        await this.ShowPopupAsync(new Popups.Welcome());

        // Abre la nueva ventana
        var home = new Home();
        home.Show(this);

        this.Close();

    }



    /// <summary>
    /// Modo de carga
    /// </summary>
    private void EnableChargeMode()
    {
        btnCrear.Hide();
        lbInfo.Hide();
        lbsCrear.Hide();
        indicador.Show();
    }



    /// <summary>
    /// Deshabilita el modo de carga
    /// </summary>
    private void DisableChargeMode()
    {
        btnCrear.Show();
        lbInfo.Hide();
        lbsCrear.Show();
        indicador.Hide();
    }



}