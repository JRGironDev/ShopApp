using ShopApp.DataAccess;
using ShopApp.Views;
using System.ComponentModel;


namespace ShopApp.Handlers
{
    public class ProductoBusquedaHandler : SearchHandler
    {

        ShopDbContext dbContext;

        public ProductoBusquedaHandler()
        {
            this.dbContext = new ShopDbContext();

        }

        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
                return;
            }

            var resultados = dbContext.Products
                .Where(p => p.Nombre.ToLowerInvariant()
                            .Contains(newValue.ToLowerInvariant())).ToList();

            

            ItemsSource = resultados;

        }

        

        protected async override void OnItemSelected(object item)
        {
            var product = item as Product;
            var uri = $"{nameof(ProductDetailPage)}?id={product.Id}";
            Shell.Current.CurrentItem = Shell.Current.CurrentItem.Items[0];
            await Shell.Current.GoToAsync(uri, false);
        }

         

    }
}
