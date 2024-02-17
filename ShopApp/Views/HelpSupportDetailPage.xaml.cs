﻿using System.Collections.ObjectModel;
using System.Windows.Input;
using ShopApp.DataAccess;
using static ShopApp.DataAccess.ShopDbContex;

namespace ShopApp.Views;

public partial class HelpSupportDetailPage : ContentPage, IQueryAttributable
{
	public HelpSupportDetailPage()
	{
		InitializeComponent();
	}

	public void ApplyQueryAttributes(IDictionary<string, object> query)
	{
		Title = $"Cliente {query["id"]}";
	}
}

public class HelpSupportDetailData : BindingUtilObject
{
	public HelpSupportDetailData()
	{
		var database = new ShopDbContex();
		Products = new ObservableCollection<Product>(database.Products);
	}

	public ICommand AddCommand { get; set; }

	private ObservableCollection<Product> _products;
	public ObservableCollection<Product> Products
	{
		get { return _products; }
		set
		{
			if (_products != value)
			{
				_products = value;
				RaisePropertyChanged();
			}
		}
	}

	private Product _productoSeleccionado;
	public Product ProductoSeleccionado
	{
		get { return _productoSeleccionado; }
		set
		{
			if (_productoSeleccionado != value)
			{
				_productoSeleccionado = value;
				RaisePropertyChanged();
			}
		}
	}

	private int _cantidad;
	public int Cantidad
	{
		get { return _cantidad; }
		set
		{
			if (_cantidad != value)
			{
				_cantidad = value;
				RaisePropertyChanged();
			}
		}
	}


}
