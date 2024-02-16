using System.ComponentModel;
using ShopApp.DataAccess;

namespace ShopApp.Views;

public partial class HelpSupportPage : ContentPage
{
	public HelpSupportPage()
	{
		InitializeComponent();

	}

	private void Button_Clicked(object sender, EventArgs e)
	{
		var dataObject = Resources["data"] as HelpSupportData;
		dataObject.VisitasPendientes = 30;
	}
}

public class HelpSupportData : INotifyPropertyChanged
{
	/// <summary>
	/// public int VisitasPendientes { get; set; }
	/// </summary>
	/// 
	public int _visitasPendientes;

	public int VisitasPendientes
	{
		get { return _visitasPendientes; }
		set
		{
			_visitasPendientes = value;
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("VisitasPendientes"));
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;
}

