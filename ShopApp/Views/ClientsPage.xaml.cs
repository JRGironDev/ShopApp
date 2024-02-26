using ShopApp.DataAccess;
using ShopApp.ViewModels;

namespace ShopApp.Views;

public partial class ClientsPage : ContentPage
{
	public ClientsPage(ClientsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
}