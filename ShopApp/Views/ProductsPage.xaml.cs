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
			var boton = new Button { Text = product.Nombre };
			boton.Clicked += async (s, a) =>
			{
				var uri = $"{nameof(ProductDetailPage)}?id={product.Id}";
				await Shell.Current.GoToAsync(uri);
			};

			container.Children.Add(boton);
		}
	}
}


