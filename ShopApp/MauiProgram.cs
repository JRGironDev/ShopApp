﻿using Microsoft.Extensions.Logging;
using ShopApp.DataAccess;

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

		var dbContext = new ShopDbContex();
		dbContext.Database.EnsureCreated();
		dbContext.Dispose();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

