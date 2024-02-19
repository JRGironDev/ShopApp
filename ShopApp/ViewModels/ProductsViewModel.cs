using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShopApp.DataAccess;
using ShopApp.Services;
using ShopApp.Views;

namespace ShopApp.ViewModels;

public partial class ProductsViewModel : ViewModelGlobal
{
    private readonly INavegacionService navegationService;

    [ObservableProperty]
    ObservableCollection<Product> products;

    [ObservableProperty]
    Product productoSeleccionado;

    [ObservableProperty]
    bool isRefreshing;

    public ProductsViewModel(INavegacionService navegacionService)
    {
        navegationService = navegacionService;
        CargarListaProductos();
        PropertyChanged += ProductsViewModel_PropertyChanged;
    }

    [RelayCommand]
    private async Task Refresh()
    {
        CargarListaProductos();
        await Task.Delay(3000);
        IsRefreshing = false;
    }

    private async void ProductsViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(ProductoSeleccionado))
        {
            var uri = $"{nameof(ProductDetailPage)}?id={ProductoSeleccionado.Id}";
            await navegationService.GoToAsync(uri);
        }
    }

    private void CargarListaProductos()
    {
        var database = new ShopDbContex();
        Products = new ObservableCollection<Product>(database.Products);
        database.Dispose();
    }
}