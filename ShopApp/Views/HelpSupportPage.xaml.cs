using ShopApp.ViewModels;

namespace ShopApp.Views;

public partial class HelpSupportPage : ContentPage
{
	public HelpSupportPage()
	{
		InitializeComponent();

	}

	private void Button_Clicked(object sender, EventArgs e)
	{
		var dataObject = Resources["data"] as HelpSupportViewModel;
		dataObject.VisitasPendientes = 30;
	}
}

