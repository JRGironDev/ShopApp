using ShopApp.DataAccess;
using ShopApp.ViewModels;

namespace ShopApp.Views;

public partial class ProductsPage : ContentPage
{
	public ProductsPage(ProductsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext= viewModel;
		
	}
}