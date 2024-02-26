using ShopApp.ViewModels;

namespace ShopApp.Views;

public partial class HelpSupportPage : ContentPage
{
	public HelpSupportPage(HelpSupportViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
	   
}



