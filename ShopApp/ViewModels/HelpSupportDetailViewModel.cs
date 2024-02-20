using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using ShopApp.DataAccess;
using CommunityToolkit.Mvvm.Input;
using ShopApp.Services;

namespace ShopApp.ViewModels;
public partial class HelpSupportDetailViewModel : ViewModelGlobal, IQueryAttributable
{
    private readonly IConnectivity _connectivity;

    [ObservableProperty]
    private ObservableCollection<Compra> compras = new ObservableCollection<Compra>();

    [ObservableProperty]
    private int clienteId;

    [ObservableProperty]
    private ObservableCollection<Product> products;

    [ObservableProperty]
    private Product productoSeleccionado;

    [ObservableProperty]
    private int cantidad;

    private CompraService _compraService;
    public HelpSupportDetailViewModel(IConnectivity connectivity, CompraService compraService)
    {
        var database = new ShopDbContex();
        Products = new ObservableCollection<Product>(database.Products);
        AddCommand = new Command(() =>
        {
            var compra = new Compra(
                ClienteId,
                ProductoSeleccionado.Id,
                Cantidad,
                ProductoSeleccionado.Nombre,
                ProductoSeleccionado.Precio,
                ProductoSeleccionado.Precio * Cantidad
            );
            Compras.Add(compra);
        },
        () => true
        );
        _connectivity = connectivity;
        _connectivity.ConnectivityChanged += OnConnectivityChanged;
        _compraService = compraService;
    }

    [RelayCommand(CanExecute = nameof(StatusConnection))]
    private async Task EnviarCompra()
    {
        var resultado = await _compraService.EnviarData(Compras);
        if (resultado)
        {
            await Shell.Current.DisplayAlert("Compra", "Compra realizada con éxito", "Ok");
            Compras.Clear();
        }
    }

    private void OnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
    {
        EnviarCompraCommand.NotifyCanExecuteChanged();
    }

    private bool StatusConnection()
    {
        return _connectivity.NetworkAccess == NetworkAccess.Internet ? true : false;
    }

    public ICommand AddCommand { get; set; }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var clientId = int.Parse(query["id"].ToString());
        ClienteId = clientId;
    }

    [RelayCommand]
    private void EliminarCompra(Compra compra)
    {
        Compras.Remove(compra);
    }
}