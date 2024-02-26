using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ShopApp.Models.Backend.Inmueble;
using ShopApp.Models.Config;
using System.Net.Http.Headers;

namespace ShopApp.Services;

public class InmuebleService
{
    private readonly HttpClient client;

    private Settings settings;

    public InmuebleService(HttpClient client, IConfiguration configuration)
    {
        this.client = client;
        this.settings = configuration.GetRequiredSection(nameof(Settings)).Get<Settings>();
    }

    public async Task<List<CategoryResponse>> GetCategories()
    {
        var uri = $"{settings.UrlBase}/api/category";
        client.DefaultRequestHeaders.Authorization = new
            AuthenticationHeaderValue("bearer", Preferences.Get("accesstoken", string.Empty));

        var resultado = await client.GetStringAsync(uri);

        return JsonConvert.DeserializeObject<List<CategoryResponse>>(resultado);
    }

}

