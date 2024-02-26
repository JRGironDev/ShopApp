using ShopApp.DataAccess;

namespace ShopApp.Views;

public partial class AboutPage : ContentPage
{
	public AboutPage()
	{
		InitializeComponent();
	}

	protected override async void OnAppearing()
	{
		var accessToken = Preferences.Get("accessToken", string.Empty);
		if (string.IsNullOrEmpty(accessToken))
		{
			await Shell.Current.GoToAsync($"{nameof(LoginPage)}");
		}
	}
}


