using Microsoft.AspNetCore.Mvc.Testing;

namespace TourOfHeroes.Backend.Tests.Utils;

public static class TestExtensions
{
    public static HttpClient CreateClient<T>(this WebApplicationFactory<T> app, string baseAddress)
where T : class
=> app.CreateClient(new WebApplicationFactoryClientOptions { BaseAddress = new Uri("http://localhost/" + baseAddress), });

}
