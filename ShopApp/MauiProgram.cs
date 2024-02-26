using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ShopApp.DataAccess;
using ShopApp.Services;
using ShopApp.ViewModels;
using ShopApp.Views;
using System.Reflection;

namespace ShopApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var assemblyInstance = Assembly.GetExecutingAssembly();
		using var stream = assemblyInstance.GetManifestResourceStream("ShopApp.appsettings.json");

		var config = new ConfigurationBuilder()
			.AddJsonStream(stream)
			.Build();


		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Configuration.AddConfiguration(config);

		builder.Services.AddSingleton<INavegacionService, NavegacionService>();
		builder.Services.AddTransient<HelpSupportViewModel>();
		builder.Services.AddTransient<HelpSupportPage>();
		builder.Services.AddTransient<HelpSupportDetailViewModel>();
		builder.Services.AddTransient<HelpSupportDetailPage>();
		builder.Services.AddTransient<ClientsViewModel>();
		builder.Services.AddTransient<ClientsPage>();
		builder.Services.AddTransient<ProductsViewModel>();
		builder.Services.AddTransient<ProductsPage>();
		builder.Services.AddTransient<ProductDetailsViewModel>();
		builder.Services.AddTransient<ProductDetailPage>();
		builder.Services.AddTransient<ResumenViewModel>();
		builder.Services.AddTransient<ResumenPage>();
		builder.Services.AddSingleton(Connectivity.Current);
		builder.Services.AddSingleton<CompraService>();
		builder.Services.AddSingleton<InmuebleService>();
		builder.Services.AddSingleton<HttpClient>();
		builder.Services.AddSingleton<IDatabaseRutaService, DatabaseRutaService>();
		builder.Services.AddDbContext<ShopOutDbContext>();

		builder.Services.AddSingleton<SecurityService>();
		builder.Services.AddTransient<LoginViewModel>();
		builder.Services.AddTransient<LoginPage>();

		builder.Services.AddTransient<HomeViewModel>();
		builder.Services.AddTransient<HomePage>();

		builder.Services.AddTransient<BookmarkViewModel>();
		builder.Services.AddTransient<BookmarkPage>();

		builder.Services.AddTransient<SettingsViewModel>();
		builder.Services.AddTransient<SettingsPage>();


		var dbContext = new ShopDbContext();
		dbContext.Database.EnsureCreated();
		dbContext.Dispose();

		Routing.RegisterRoute(nameof(ProductDetailPage), typeof(ProductDetailPage));
		Routing.RegisterRoute(nameof(HelpSupportDetailPage), typeof(HelpSupportDetailPage));
		Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));


#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
