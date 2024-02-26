using CommunityToolkit.Mvvm.ComponentModel;
using ShopApp.Models.Backend.Inmueble;
using ShopApp.Services;
using System.Collections.ObjectModel;

namespace ShopApp.ViewModels;

public partial class HomeViewModel : ViewModelGlobal
{
    [ObservableProperty]
    string nombreUsuario;

    [ObservableProperty]
    ObservableCollection<CategoryResponse> categories;
        
    public Command GetDataCommand { get; }

    private readonly InmuebleService _inmuebleService;

    public HomeViewModel(InmuebleService inmuebleService)
    {
        _inmuebleService = inmuebleService;
        NombreUsuario = Preferences.Get("nombre", string.Empty);
        GetDataCommand = new Command(async () => await LoadDataAsync());
        GetDataCommand.Execute(this);
    }

    public async Task LoadDataAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var listCategories = await _inmuebleService.GetCategories();
            Categories = new ObservableCollection<CategoryResponse>(listCategories);
        }
        catch (Exception e)
        {
            await Application.Current.MainPage.DisplayAlert("Error", e.Message, "Aceptar");
        }
        finally
        {
            IsBusy = false;
        }


    }

}

