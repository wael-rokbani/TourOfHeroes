using System.ComponentModel.DataAnnotations.Schema;

namespace TourOfHeroes.Backend.Entities;

[Table("Hero", Schema = "sHero")]
public class Hero
{
    public required int Id { get; set; }

    public required string Name { get; set; }

    public string? DisplayName { get; set; }

    [ForeignKey("TypeId")]
    public required HeroType Type { get; set; }

    public int TypeId { get; set; }
}