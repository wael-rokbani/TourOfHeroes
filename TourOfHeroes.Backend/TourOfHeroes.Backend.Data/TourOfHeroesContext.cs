using Microsoft.EntityFrameworkCore;
using TourOfHeroes.Backend.Entities;

namespace TourOfHeroes.Backend.Data;

public class TourOfHeroesContext : DbContext
{
    public TourOfHeroesContext(DbContextOptions<TourOfHeroesContext> options) : base(options) { }

    public DbSet<HeroType> HeroTypes { get; set; }
    public DbSet<Hero> Heroes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HeroType>().ToTable("HeroType", "sHero").HasKey(k => k.Id);
        modelBuilder.Entity<Hero>().ToTable("Hero", "sHero").HasKey(k => k.Id);
    }
}