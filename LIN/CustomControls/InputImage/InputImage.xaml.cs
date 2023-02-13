namespace LIN.CustomControls;

public partial class InputImage : Grid
{


    //========== Eventos ==========//

    /// <summary>
    /// Evento cuando cambia la imagen seleccionada
    /// </summary>
    public event EventHandler<ImageChanged>? ImageChanged;


    //========== Propiedades ==========//

    /// <summary>
    /// Obtiene la imagen actual
    /// </summary>
    public ImageSource Picture { get => picture.Source; }






    /// <summary>
    /// Constructor
    /// </summary>
    public InputImage()
    {
        InitializeComponent();
    }




    /// <summary>
    /// Carga la imagen
    /// </summary>
    private async void LoadImageEvent(object sender, EventArgs e)
    {
        picture.Source = await OpenImage(); ;
        ImageChanged?.Invoke(this, new() { NewValue = picture.Source });
    }



    /// <summary>
    /// Obtiene la base64 de la imagen actual
    /// </summary>
    public async Task<string> Encode64()
    {
        return await picture.Encode();
    }



    /// <summary>
    /// Carga la imagen de perfil
    /// </summary>
    private static async Task<ImageSource?> OpenImage()
    {

        // Carga el archivo
        var result = await FilePicker.Default.PickAsync();

        // analisa el resultado
        if (result == null)
            return null;


        // Extension del archivo
        if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) || result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
        {

            FileInfo dd = new(result.FullPath);
            var stream = dd.OpenRead();

            MemoryStream ms = new();
            stream.CopyTo(ms);
            var bytes = ms.ToArray();


            MemoryStream ms1 = new(bytes);
            ImageSource NewImage = ImageSource.FromStream(() => ms1);

            return NewImage;


        }


        return null;

    }


}