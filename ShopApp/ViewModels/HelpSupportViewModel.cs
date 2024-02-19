using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ShopApp.DataAccess;
using ShopApp.Services;
using ShopApp.Views;

namespace ShopApp.ViewModels;
public class HelpSupportViewModel : BindingUtilObject
{
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

    public int _visitasPendientes;

    public int VisitasPendientes
    {
        get { return _visitasPendientes; }
        set
        {
            if (_visitasPendientes != value)
            {
                _visitasPendientes = value;
                RaisePropertyChanged();
            }
        }
    }

    private ObservableCollection<Client> _clients;

    public ObservableCollection<Client> Clients
    {
        get { return _clients; }
        set
        {
            if (_clients != value)
            {
                _clients = value;
                RaisePropertyChanged();
            }
        }
    }

    private Client _clienteSeleccionado;
    public Client ClienteSeleccionado
    {
        get { return _clienteSeleccionado; }
        set
        {
            if (_clienteSeleccionado != value)
            {
                _clienteSeleccionado = value;
                RaisePropertyChanged();
            }
        }
    }
}