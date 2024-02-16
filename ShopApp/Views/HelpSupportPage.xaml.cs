using System.Collections.ObjectModel;
using System.ComponentModel;
using ShopApp.DataAccess;
using static ShopApp.DataAccess.ShopDbContex;

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

public class HelpSupportData : BindingUtilObject
{
	public HelpSupportData()
	{
		var database = new ShopDbContex();
		Clients = new ObservableCollection<Client>(database.Clients);
	}
	public int _visitasPendientes;

	public int VisitasPendientes
	{
		get { return _visitasPendientes; }
		set
		{
			if (_visitasPendientes != value)
			{
				_visitasPendientes = value;
				RaisePropertyChanged();
			}
		}
	}

	private ObservableCollection<Client> _clients;

	public ObservableCollection<Client> Clients
	{
		get { return _clients; }
		set
		{
			if (_clients != value)
			{
				_clients = value;
				RaisePropertyChanged();
			}
		}
	}
}

