using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using ShopApp.DataAccess;

namespace ShopApp.ViewModels;
public partial class ClientsViewModel : ViewModelGlobal
{
    [ObservableProperty]
    ObservableCollection<Client> clients;

    [ObservableProperty]
    Client clientSeleccionado;

    public ClientsViewModel()
    {
        var database = new ShopDbContex();
        Clients = new ObservableCollection<Client>(database.Clients);
    }

}
