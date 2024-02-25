using ShopApp.DataAccess;
using ShopApp.Views;

namespace ShopApp;

public partial class App : Application
{
	public App(LoginPage loginPage, ShopOutDbContext context)
	{
		InitializeComponent();
		context.Database.EnsureCreated();
		var accesstoken = Preferences.Get("accessToken", string.Empty);

		if (string.IsNullOrEmpty(accesstoken))
		{
			MainPage = loginPage;
		}
		else
		{
			MainPage = new AppShell();
		}
	}
}

