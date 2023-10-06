using TourOfHeroes.Backend.Data.Repositories.Interfaces;
using TourOfHeroes.Backend.Entities;

namespace TourOfHeroes.Backend.Data.Repositories.Implementations
{
    public class HeroTypeRepository : IHeroTypeRepository
    {
        private TourOfHeroesContext _context;

        public HeroTypeRepository(TourOfHeroesContext context)
        {
            _context = context;
        }

        public IEnumerable<HeroType> GetAll()
        {
            return _context.HeroTypes.OrderBy(t => t.Name);
        }
    }
}
