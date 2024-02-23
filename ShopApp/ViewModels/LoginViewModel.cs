using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShopApp.Services;

namespace ShopApp.ViewModels;

public partial class LoginViewModel : ViewModelGlobal
{
    private readonly IConnectivity _connectivity;

    [ObservableProperty]
    private string email;

    [ObservableProperty]
    private string password;

    private readonly SecurityService _securityService;

    public LoginViewModel(IConnectivity connectivity, SecurityService securityService)
    {
        _connectivity = connectivity;
        _securityService = securityService;
        _connectivity.ConnectivityChanged += _connectivity_OnConnectivityChanged;
    }

    [RelayCommand(CanExecute = nameof(StatusConnection))]
    private async Task LoginMethod()
    {
        var resultado = await _securityService.Login(Email, Password);
        if (resultado)
        {
            Application.Current.MainPage = new AppShell();
        }
        else
        {
            await Shell.Current.DisplayAlert("Error", "Usuario o contraseña incorrectos", "Aceptar");
        }
    }

    private void _connectivity_OnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
    {
        LoginMethodCommand.NotifyCanExecuteChanged();
    }

    private bool StatusConnection() => _connectivity.NetworkAccess == NetworkAccess.Internet;
}