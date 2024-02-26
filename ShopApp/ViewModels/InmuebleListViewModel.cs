using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using ShopApp.Models.Backend.Inmueble;
using ShopApp.Services;

namespace ShopApp.ViewModels;

public partial class InmuebleListViewModel : ViewModelGlobal, IQueryAttributable
{
    private readonly INavegacionService _navegacionService;

    [ObservableProperty]
    ObservableCollection<InmuebleResponse> inmuebles;

    private readonly InmuebleService _inmuebleService;

    public InmuebleListViewModel(
        INavegacionService navegacionService,
        InmuebleService inmuebleService)
    {
        _navegacionService = navegacionService;
        _inmuebleService = inmuebleService;
    }

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var id = int.Parse(query["id"].ToString());
        await LoadDataAsync(id);
    }

    public async Task LoadDataAsync(int categoryId)
    {
        if (IsBusy)
        {
            return;
        }

        try
        {
            IsBusy = true;
            var listInmuebles = await _inmuebleService.GetInmueblesByCategory(categoryId);
            Inmuebles = new ObservableCollection<InmuebleResponse>(listInmuebles);
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
