using Microsoft.Extensions.Logging;
using ShopApp.DataAccess;
using ShopApp.Services;
using ShopApp.ViewModels;
using ShopApp.Views;

namespace ShopApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<INavegacionService, NavegacionService>();
		builder.Services.AddTransient<HelpSupportViewModel>();
		builder.Services.AddTransient<HelpSupportPage>();
		builder.Services.AddTransient<HelpSupportDetailViewModel>();
		builder.Services.AddTransient<HelpSupportDetailPage>();
		builder.Services.AddTransient<ClientsViewModel>();
		builder.Services.AddTransient<ClientsPage>();
		builder.Services.AddTransient<ProductsViewModel>();
		builder.Services.AddTransient<ProductsPage>();
		builder.Services.AddTransient<ProductDetailViewModal>();
		builder.Services.AddTransient<ProductDetailPage>();
		builder.Services.AddSingleton(Connectivity.Current);

		var dbContext = new ShopDbContex();
		dbContext.Database.EnsureCreated();
		dbContext.Dispose();

		Routing.RegisterRoute(nameof(ProductDetailPage), typeof(ProductDetailPage));
		Routing.RegisterRoute(nameof(HelpSupportDetailPage), typeof(HelpSupportDetailPage));

#if DEBUG
		builder.Logging.AddDebug();
#endif
		return builder.Build();
	}
}

