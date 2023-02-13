
namespace LIN.UI.Popups;

public partial class DefaultPopup : Popup
{
    
    /// <summary>
    /// Obtiene o establece el texto
    /// </summary>
    public string Text
    {
        get => lbText.Text;
        set => lbText.Text = value;
    }


    /// <summary>
    /// Evento click sobre el Popup
    /// </summary>
    public event EventHandler<EventArgs>? Clicked;


	public DefaultPopup()
	{
		InitializeComponent();
	}

	
	/// <summary>
	/// Evento Text
	/// </summary>
	private void TapGestureRecognizer_Tapped(object sender, EventArgs e) => Clicked?.Invoke(this, new());


}