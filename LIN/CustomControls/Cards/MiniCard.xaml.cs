namespace LIN.CustomControls;

public partial class MiniCard : ContentView
{

    //=========== Eventos ===========//

    /// <summary>
    /// Evento Click sobre Titulo
    /// </summary>
    public event EventHandler<EventArgs>? Clicked;



    //=========== Propiedades ===========//

    /// <summary>
    /// Obtiene o establece el titulo de la carta
    /// </summary>
    public string Titulo
    {
        get => (string)GetValue(TituloProperty);
        set { SetValue(TituloProperty, value); }
    }


    /// <summary>
    /// Obtiene o establece el contenido de la carta
    /// </summary>
    public string Contenido
    {
        get => (string)GetValue(ContentTextProperty);
        set { SetValue(ContentTextProperty, value); }
    }


    public ImageSource Source
    {
        get => (ImageSource)GetValue(SourceProperty);
        set { SetValue(SourceProperty, value); }
    }




    /// <summary>
    /// Constructor
    /// </summary>
    public MiniCard()
    {
        InitializeComponent();
    }


    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        Clicked?.Invoke(this, new());
    }




    #region BINDABLE


    /// <summary>
    /// Propiedad Contenido
    /// </summary>
    public static readonly BindableProperty ContentTextProperty = BindableProperty.Create(
        propertyName: nameof(Contenido),
        returnType: typeof(string),
        declaringType: typeof(MiniCard),
        defaultValue: "",
        defaultBindingMode: BindingMode.TwoWay);


    /// <summary>
    /// Propiedad Titulo
    /// </summary>
    public static readonly BindableProperty TituloProperty = BindableProperty.Create(
        propertyName: nameof(Titulo),
        returnType: typeof(string),
        declaringType: typeof(MiniCard),
        defaultValue: "",
        defaultBindingMode: BindingMode.TwoWay);


    /// <summary>
    /// Propiedad Source
    /// </summary>
    public static readonly BindableProperty SourceProperty = BindableProperty.Create(
        propertyName: nameof(Source),
        returnType: typeof(ImageSource),
        declaringType: typeof(MiniCard),
        defaultValue: ImageSource.FromResource("icono.png"),
        defaultBindingMode: BindingMode.TwoWay);



    #endregion


}