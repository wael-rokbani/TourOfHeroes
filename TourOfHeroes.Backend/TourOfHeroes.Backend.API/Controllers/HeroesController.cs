using Microsoft.AspNetCore.Mvc;
using System.Net;
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
    [ProducesResponseType(typeof(IEnumerable<Hero>), (int)HttpStatusCode.OK)]
    public IActionResult GetAllHeroes()
    {
        return Ok(_heroRepository.GetAll());
    }


    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(Hero), (int)HttpStatusCode.OK)]
    public IActionResult GetHero(int id)
    {
        return Ok(_heroRepository.GetById(id));
    }

    [HttpPost]
    [ProducesResponseType(typeof(Hero), (int)HttpStatusCode.Created)]
    public IActionResult CreateHero([FromBody] Hero hero)
    {
        //TODO 
        //Data validation
        return Created("TODO", _heroRepository.Create(hero));
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(Hero), (int)HttpStatusCode.OK)]
    public IActionResult UpdateHero(int id, [FromBody] Hero hero)
    {
        //TODO 
        //Data validation
        return Ok(_heroRepository.Update(hero));
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
    public IActionResult DeleteHero(int id)
    {
        return Ok(_heroRepository.Delete(id));
    }


    [HttpGet("Types")]
    [ProducesResponseType(typeof(IEnumerable<HeroType>), (int)HttpStatusCode.OK)]
    public IActionResult GetAllHeroTypes()
    {
        return Ok(new List<HeroType>()); //TODO
    }
}
