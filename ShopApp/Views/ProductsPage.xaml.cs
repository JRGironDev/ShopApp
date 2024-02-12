using ShopApp.DataAccess;

namespace ShopApp.Views;

public partial class ProductsPage : ContentPage
{
	public ProductsPage()
	{
		InitializeComponent();

		var dbContext = new ShopDbContex();

		foreach (var product in dbContext.Products)
		{
			container.Children.Add(new Label { Text = product.Nombre });
		}
	}
}


