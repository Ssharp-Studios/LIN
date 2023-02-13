using Conexion.Modelos;
using LIN.Observador;

namespace LIN.CustomControls;

public partial class Contacto : ContentView, IProveedorable
{

    //======== Eventos =========//

    public event EventHandler<EventArgs>? Clicked;


    private static Color[] Colors = {
        Color.FromRgb(241, 148, 138),
        Color.FromRgb(195, 155, 211),
        Color.FromRgb(187, 143, 206),
        Color.FromRgb(127, 179, 213),
        Color.FromRgb(118, 215, 196),
        Color.FromRgb(125, 206, 160),
        Color.FromRgb(247, 220, 111),
        Color.FromRgb(248, 196, 113),
        Color.FromRgb(229, 152, 102),
        Color.FromRgb(191, 201, 202),
        Color.FromRgb(133, 146, 158)
};

    public Proveedor Modelo { get; set; }


    public Contacto(Proveedor modelo)
    {
        InitializeComponent();
        this.Modelo = modelo;
        LoadModelVisible();
    }



    public void LoadModelVisible()
    {

        if (Modelo.Estado == Conexion.EProveedorState.Deleted)
        {
            IsVisible = false;
            return;
        }

        lbName.Text = Modelo.Nombre;
        lbMail.Text = Modelo.Correo;
        lbTelefono.Text = Modelo.Telefono;

        // Si no hay imagen que mostar
        if (Modelo.Imagen == "")
        {
            img.Hide();
            lbPic.Show();
            lbPic.Text = lbName.Text[0].ToString().ToUpper();
            bgImg.BackgroundColor = RandonColor();
        }
        else
        {
            lbPic.Hide();
            img.Show();
            bgImg.BackgroundColor = Microsoft.Maui.Graphics.Colors.Transparent;
            img.Source = ImageEncoder.DesEncode(Modelo.Imagen);
        }

    }


    private Color RandonColor()
    {
        var rd = new Random();
        var value = rd.Next(0, Colors.Length - 1);
        return Colors[value];
    }

    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        Clicked?.Invoke(this, new());
    }


}