using TourOfHeroes.Backend.Entities;

namespace TourOfHeroes.Backend.API.Validators
{
    public static class ApiDataValidators
    {
        public static bool IsValid(this Hero hero)
        {
            return hero != null
                    && !string.IsNullOrWhiteSpace(hero.Name)
                    && hero.Type?.Id > 0;
        }
    }
}
