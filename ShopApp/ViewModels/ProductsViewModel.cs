using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShopApp.DataAccess;
using ShopApp.Services;
using ShopApp.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ShopApp.ViewModels
{
    public partial class ProductsViewModel : ViewModelGlobal
    {
        private readonly INavegacionService navegacionService;

        [ObservableProperty]
        ObservableCollection<Product> products;

        [ObservableProperty]
        Product productoSeleccionado;

        [ObservableProperty]
        bool isRefreshing;

        public ProductsViewModel(INavegacionService navegacionService)
        {
            this.navegacionService = navegacionService;
            CargarListaProductos();
            PropertyChanged += ProductsViewModel_PropertyChanged;

        }

        [RelayCommand]
        private async Task Refresh()
        {
            CargarListaProductos();
            await Task.Delay(3000);
            // invocar la llamada a un rest service
            // la data almacenarla en la base de datos
            // volver a consultar la data de la base de datos local

            IsRefreshing = false;
        }

        private async void ProductsViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ProductoSeleccionado))
            {
                var uri = $"{nameof(ProductDetailPage)}?id={ProductoSeleccionado.Id}";
                await navegacionService.GoToAsync(uri) ;
            }

        }

        private void CargarListaProductos()
        {
            var database = new ShopDbContext();
            Products = new ObservableCollection<Product>(database.Products);
            database.Dispose();
        }
    }
}
