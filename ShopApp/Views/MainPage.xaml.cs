
using ShopApp.DataAccess;

namespace ShopApp.Views;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();

		var dbContext = new ShopDbContext();
		category.Text = dbContext.Categories.Count().ToString();
		product.Text = dbContext.Products.Count().ToString();
		client.Text = dbContext.Clients.Count().ToString();

	}

  
}

