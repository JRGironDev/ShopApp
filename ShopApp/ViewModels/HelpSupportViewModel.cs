using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using ShopApp.DataAccess;
using ShopApp.Services;
using ShopApp.Views;

namespace ShopApp.ViewModels;
public partial class HelpSupportViewModel : ViewModelGlobal
{
    [ObservableProperty]
    public int visitasPendientes;

    [ObservableProperty]
    private ObservableCollection<Client> clients;
    [ObservableProperty]

    private Client clienteSeleccionado;
    private readonly INavegacionService _navegacionService;
    public HelpSupportViewModel(INavegacionService navegacionService)
    {
        _navegacionService = navegacionService;
        var database = new ShopDbContex();
        Clients = new ObservableCollection<Client>(database.Clients);

        PropertyChanged += HelpSupportViewModel_PropertyChanged;
    }

    private async void HelpSupportViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(ClienteSeleccionado))
        {
            var uri = $"{nameof(HelpSupportDetailPage)}?id={ClienteSeleccionado.Id}";
            await _navegacionService.GoToAsync(uri);
        }
    }
}