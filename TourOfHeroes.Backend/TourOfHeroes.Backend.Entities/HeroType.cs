using System.ComponentModel.DataAnnotations.Schema;

namespace TourOfHeroes.Backend.Entities;

[Table("HeroType", Schema = "sHero")]
public class HeroType
{
    public int Id { get; set; }

    public string Name { get; set; }
}
