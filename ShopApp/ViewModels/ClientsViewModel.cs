using CommunityToolkit.Mvvm.ComponentModel;
using ShopApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.ViewModels
{
    public partial class ClientsViewModel : ViewModelGlobal
    {

        [ObservableProperty]
        ObservableCollection<Client> clients;

        [ObservableProperty]
        Client clientSeleccionado;

        public ClientsViewModel()
        {
            var database = new ShopDbContext();
            Clients = new ObservableCollection<Client>(database.Clients);
        }
    }
}
