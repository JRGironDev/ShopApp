using CommunityToolkit.Mvvm.ComponentModel;
using ShopApp.DataAccess;
using ShopApp.Services;
using ShopApp.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace ShopApp.ViewModels;


public partial class HelpSupportViewModel : ViewModelGlobal
{
    [ObservableProperty]
    private int visitasPendientes;

    [ObservableProperty]
    private ObservableCollection<Client> clients;

    [ObservableProperty]
    private Client clienteSeleccionado;


    private readonly INavegacionService _navegacionService;
    public HelpSupportViewModel(INavegacionService navegacionService)
    {
        var database = new ShopDbContext();
        Clients = new ObservableCollection<Client>(database.Clients);
        PropertyChanged += HelpSupportData_PropertyChanged;
        _navegacionService = navegacionService;
    }

    private async void HelpSupportData_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(ClienteSeleccionado))
        {
            var uri = $"{nameof(HelpSupportDetailPage)}?id={ClienteSeleccionado.Id}";
            await _navegacionService.GoToAsync(uri);
        }
    }

    

}


