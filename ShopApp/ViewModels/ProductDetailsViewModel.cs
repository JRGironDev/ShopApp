using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using ShopApp.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.ViewModels
{
    public partial class ProductDetailsViewModel : ViewModelGlobal, IQueryAttributable
    {
        [ObservableProperty]
        string nombre;

        [ObservableProperty]
        string descripcion;

        [ObservableProperty]
        decimal precio;

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var dbContext = new ShopDbContext();
            var id = int.Parse(query["id"].ToString());
            var producto = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            Nombre = producto.Nombre;
            Descripcion = producto.Descripcion;
            Precio = producto.Precio;
        }
    }
}
