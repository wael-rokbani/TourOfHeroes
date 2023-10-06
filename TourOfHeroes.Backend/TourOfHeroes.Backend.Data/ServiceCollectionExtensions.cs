using Microsoft.Extensions.DependencyInjection;
using TourOfHeroes.Backend.Data.Repositories.Implementations;
using TourOfHeroes.Backend.Data.Repositories.Interfaces;

namespace TourOfHeroes.Backend.Data;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataProviders(this IServiceCollection services)
    {
        services
            .AddScoped<IHeroRepository, HeroRepository>()
            .AddScoped<IHeroTypeRepository, HeroTypeRepository>()
            ;

        return services;
    }
}
