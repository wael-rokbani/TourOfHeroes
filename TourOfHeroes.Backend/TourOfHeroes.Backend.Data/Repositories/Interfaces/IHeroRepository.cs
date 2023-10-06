using TourOfHeroes.Backend.Entities;

namespace TourOfHeroes.Backend.Data.Repositories.Interfaces;

public interface IHeroRepository
{
    public Hero? GetById(int id);

    public IEnumerable<Hero> GetAll();

    public IEnumerable<Hero> Search(string searchValue);

    public bool Delete(int id);

    public Hero Create(Hero hero);

    public Hero Update(Hero hero);
}
