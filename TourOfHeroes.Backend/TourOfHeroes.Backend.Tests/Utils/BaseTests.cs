using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace TourOfHeroes.Backend.Tests.Utils;

public abstract class BaseTests
{
    protected readonly WebApplicationFactory<Program> App;

    private HttpClient? _apiClient;
    protected HttpClient ApiClient
    {
        get => _apiClient ??= App.CreateClient("api/v1");
        set => _apiClient = value;
    }

    public BaseTests(Action<IServiceCollection>? servicesConfiguration = null)
    {
        App = new WebApplicationFactory<Program>()
        .WithWebHostBuilder(builder =>
        {
            if (servicesConfiguration != null)
                builder.ConfigureServices(servicesConfiguration);
        });
    }

}
