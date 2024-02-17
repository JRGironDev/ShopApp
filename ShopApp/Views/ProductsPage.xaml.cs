using ShopApp.DataAccess;

namespace ShopApp.Views;

public partial class ProductsPage : ContentPage
{
	public ProductsPage()
	{
		InitializeComponent();

		var database = new ShopDbContex();

		products.ItemsSource = database.Products;
	}
}


