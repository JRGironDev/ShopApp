using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using ShopApp.DataAccess;
using ShopApp.Services;

namespace ShopApp.ViewModels;

public partial class ProductsViewModel : ViewModelGlobal
{
    private readonly INavegacionService navigationService;

    [ObservableProperty]
    ObservableCollection<Product> products;

    [ObservableProperty]
    Product productSelected;
}