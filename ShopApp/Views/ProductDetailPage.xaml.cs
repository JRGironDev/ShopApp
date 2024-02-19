using ShopApp.ViewModels;

namespace ShopApp.Views;

public partial class ProductDetailPage : ContentPage
{
	public ProductDetailPage(ProductDetailViewModal viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}


