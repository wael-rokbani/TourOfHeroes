using TourOfHeroes.Backend.Entities;

namespace TourOfHeroes.Backend.Data.Repositories.Interfaces;

public interface IHeroTypeRepository
{
    public IEnumerable<HeroType> GetAll();
}
