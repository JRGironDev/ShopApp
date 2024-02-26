using ShopApp.ViewModels;

namespace ShopApp.Views;

public partial class HelpSupportDetailPage : ContentPage
{
	public HelpSupportDetailPage(HelpSupportDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

 

   
}

