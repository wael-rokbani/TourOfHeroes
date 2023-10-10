using Microsoft.EntityFrameworkCore;
using TourOfHeroes.Backend.Data.Repositories.Interfaces;
using TourOfHeroes.Backend.Entities;

namespace TourOfHeroes.Backend.Data.Repositories.Implementations
{
    public class HeroRepository : IHeroRepository
    {
        private TourOfHeroesContext _context;
        public HeroRepository(TourOfHeroesContext context)
        {

            _context = context;
        }

        public Hero Create(Hero hero)
        {
            _context.Heroes.Add(hero);
            _context.Entry(hero.Type).State = EntityState.Unchanged;
            _context.SaveChanges();

            return hero;
        }

        public bool Delete(int id)
        {
            Hero? heroToRemove = _context.Heroes.Find(id);

            if (heroToRemove != null)
                _context.Heroes.Remove(heroToRemove);

            _context.SaveChanges();

            return true;
        }

        public IEnumerable<Hero> GetAll()
        {
            return _context.Heroes.OrderBy(x => x.Name);
        }

        public Hero? GetById(int id)
        {
            return _context.Heroes.Include(h => h.Type).FirstOrDefault(h => h.Id == id);
        }

        public IEnumerable<Hero> Search(string searchValue)
        {
            return _context.Heroes.Where(x => x.Name.Contains(searchValue) || (!string.IsNullOrWhiteSpace(x.DisplayName) && x.DisplayName.Contains(searchValue)));
        }

        public Hero Update(Hero hero)
        {
            _context.Update(hero);
            _context.Entry(hero.Type).State = EntityState.Unchanged;
            _context.SaveChanges();
            return hero;
        }
    }
}
