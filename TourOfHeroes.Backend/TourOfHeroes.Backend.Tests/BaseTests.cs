using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace TourOfHeroes.Backend.Tests
{
    public abstract class BaseTests
    {
        protected readonly WebApplicationFactory<Program> App;

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
}
