namespace LIN.UI.Vistas;

public partial class Login : ContentPage
{


    /// <summary>
    /// Constructor
    /// </summary>
    public Login()
    {
        InitializeComponent();
    }


    /// <summary>
    /// Va a la ventana de crear cuenta
    /// </summary>
    private void NotAccountEvent(object sender, EventArgs e)
    {

        new Singin().Show(this);
        this.Close();
    }



    /// <summary>
    /// Click sobre boton iniciar sesion
    /// </summary>
    public async void Button_Clicked(object sender, EventArgs e)
    {
        await Sesion(txtUser.Text, txtPass.Text);
    }




    /// <summary>
    /// Click sobre boton iniciar sesion
    /// </summary>
    public async Task Sesion(string user, string pass)
    {

        // Interfaz de carga
        EnableChargeMode();
        await Task.Delay(100);


        // Campos vacios
        if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
        {
            DisableChargeMode();
            lbInfo.Text = "Completa todos los campos";
            lbInfo.Show();

            return;
        }

        // Conexion a internet
        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        {
            DisableChargeMode();
            lbInfo.Text = "No hay conexion a internet";
            lbInfo.IsVisible = true;
            return;
        }


        try
        {

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
            switch (Response)
            {
                // Ok
                case Conexion.EResponses.Success:
                    break;

                // No existe el usuario
                case Conexion.EResponses.NotExistAccount:
                    DisableChargeMode();
                    lbInfo.Text = "No existe este usuario";
                    lbInfo.Show();
                    return;

                // No existe el usuario
                case Conexion.EResponses.InvalidPassword:
                    DisableChargeMode();
                    lbInfo.Text = "Contraseña incorrecta";
                    lbInfo.IsVisible = true;
                    return;

                // No existe el usuario
                case Conexion.EResponses.NotConnection:
                    DisableChargeMode();
                    lbInfo.Text = "No hay conexion";
                    lbInfo.Show();
                    return;

                // Hubo un error grave
                default:
                    DisableChargeMode();
                    lbInfo.Text = "Intentalo mas tarde";
                    lbInfo.Show();
                    return;

            }


            // Abre la nueva ventana
            new Home().Show(this);
            this.Close();

        }
        catch (Exception ex)
        {
#if DEBUG
            await DisplayAlert("Error", ex.Source + "\n" + ex.Message + "\n" + ex.StackTrace, "OK");
#endif
            DisableChargeMode();
            lbInfo.Text = "Hubo un error";
            lbInfo.Show();
            return;
        }

    }



    /// <summary>
    /// Modo de carga
    /// </summary>
    private void EnableChargeMode()
    {
        btnIniciar.Hide();
        lbInfo.Hide();
        lbsCrear.Hide();
        indicador.Show();
    }



    /// <summary>
    /// Deshabilita el modo de carga
    /// </summary>
    private void DisableChargeMode()
    {
        btnIniciar.Show();
        lbInfo.Hide();
        lbsCrear.Show();
        indicador.Hide();
    }


}