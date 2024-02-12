﻿using ShopApp.DataAccess;

namespace ShopApp.Views;

public partial class CategoriesPage : ContentPage
{
	public CategoriesPage()
	{
		InitializeComponent();

		var dbContext = new ShopDbContex();

		foreach (var category in dbContext.Categories)
		{
			container.Children.Add(new Label { Text = category.Mombre });
		}
	}
}


