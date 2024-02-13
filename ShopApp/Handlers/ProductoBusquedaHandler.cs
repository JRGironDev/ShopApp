using Microsoft.Maui.Controls;
using ShopApp.DataAccess;
using ShopApp.Views;
using static ShopApp.DataAccess.ShopDbContex;

namespace ShopApp.Handlers
{
    public class ProductoBusquedaHandler : SearchHandler
    {
        ShopDbContex dbContext;

        public ProductoBusquedaHandler()
        {
            this.dbContext = new ShopDbContex();
        }
        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
                return;
            }
            else
            {
                var resultados = dbContext.Products
                                .Where(p => p.Nombre.ToLowerInvariant()
                                .Contains(newValue.ToLowerInvariant())).ToList();

                ItemsSource = resultados;
            }
        }

        protected override async void OnItemSelected(object item)
        {
            await Shell.Current.GoToAsync($"{nameof(ProductDetailPage)}?id={((Product)item).Id}");
        }
    }

}