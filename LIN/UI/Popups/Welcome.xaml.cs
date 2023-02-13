
namespace LIN.UI.Popups;

public partial class Welcome : Popup
{
    
 
    /// <summary>
    /// Evento click sobre el Popup
    /// </summary>
    public event EventHandler<EventArgs>? Clicked;


	public Welcome()
	{
		InitializeComponent();
	}

	
	/// <summary>
	/// Evento Text
	/// </summary>
	private void TapGestureRecognizer_Tapped(object sender, EventArgs e) => Clicked?.Invoke(this, new());


}