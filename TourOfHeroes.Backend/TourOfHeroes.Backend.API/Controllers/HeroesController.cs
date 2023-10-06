using Microsoft.AspNetCore.Mvc;
using TourOfHeroes.Backend.Data.Repositories.Interfaces;
using TourOfHeroes.Backend.Entities;

namespace TourOfHeroes.Backend.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class HeroesController : ControllerBase
{
    private readonly ILogger<HeroesController> _logger;
    private readonly IHeroRepository _heroRepository;
    private readonly IHeroTypeRepository _heroTypeRepository;

    public HeroesController(ILogger<HeroesController> logger, IHeroRepository heroRepository, IHeroTypeRepository heroTypeRepository)
    {
        _logger = logger;
        _heroRepository = heroRepository;
        _heroTypeRepository = heroTypeRepository;
    }

    [HttpGet]
    public IActionResult GetAllHeroes()
    {
        return Ok(_heroRepository.GetAll());
    }

    [HttpGet("Types")]
    public IActionResult GetAllHeroTypes()
    {
        return Ok(new List<HeroType>());
    }

    [HttpGet("{id:int}")]
    public IActionResult GetHero(int id)
    {
        return Ok(new Hero() { Id = id, Name = "pending", Type = new HeroType() { Name = "pending" } });
    }

    [HttpPost]
    public IActionResult CreateHero([FromBody] Hero hero)
    {
        return Created("TODO", hero);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateHero(int id, [FromBody] Hero hero)
    {
        return Ok(hero);
    }


    [HttpDelete("{id:int}")]
    public IActionResult DeleteHero(int id)
    {
        return Ok(id);
    }
}
