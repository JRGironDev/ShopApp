using ShopApp.DataAccess;

namespace ShopApp.Views;

public partial class ClientsPage : ContentPage
{
	public ClientsPage()
	{
		InitializeComponent();

		var dbContext = new ShopDbContex();

		foreach (var client in dbContext.Clients)
		{
			container.Children.Add(new Label { Text = client.Nombre });
		}
	}
}


