using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiWorldCities.Data;
using WebApiWorldCities.Models;

namespace WebApiWorldCities.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorldCitiesController : ControllerBase
    {
        private readonly WebApiWorldCitiesContext _context;

        public WorldCitiesController(WebApiWorldCitiesContext context)
        {
            _context = context;
        }

        // GET: api/WorldCities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorldCity>>> GetWorldCity()
        {
            return await _context.WorldCity.ToListAsync();
        }

        // GET: api/WorldCities/OrderByCity
        [HttpGet("OrderByCity")]
        public async Task<ActionResult<IEnumerable<WorldCity>>> GetWorldCityOrderByCity()
        {
            return await _context.WorldCity.OrderBy(x => x.City).ToListAsync();
        }

        // GET: api/WorldCities/Country
        [HttpGet("OrderByCountry")]
        public async Task<ActionResult<IEnumerable<WorldCity>>> GetWorldCityOrderByCountry()
        {
            return await _context.WorldCity.OrderBy(x => x.Country).ToListAsync();
        }

        // GET: api/WorldCities/Population"
        [HttpGet("OrderByPopulation")]
        public async Task<ActionResult<IEnumerable<WorldCity>>> GetWorldCityOrderByPopulation()
        {
            return await _context.WorldCity.OrderByDescending(x => x.Population).ToListAsync();
        }


        // GET: api/WorldCities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorldCity>> GetWorldCity(int id)
        {
            var worldCity = await _context.WorldCity.FindAsync(id);

            if (worldCity == null)
            {
                return NotFound();
            }

            return worldCity;
        }

        [HttpPost("Add")]
        public async Task<ActionResult<WorldCity>> AddWorldCity(string City, string Country, int Population)
        {
            WorldCity worldCity = new WorldCity();
            worldCity.City = City;
            worldCity.Country = Country;
            worldCity.Population = Population;
            _context.WorldCity.Add(worldCity);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetWorldCity", new { id = worldCity.Id }, worldCity);
        }

        [HttpPost("Update/{id}")]
        public async Task<ActionResult<WorldCity>> UpdateWorldCity(int id,string City, string Country, int Population)
        {
            var worldCity = await _context.WorldCity.FindAsync(id);
            if (worldCity == null)
            {
                return NotFound();
            }
            worldCity.City = City;
            worldCity.Country = Country;
            worldCity.Population = Population;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> DeleteWorldCity(int id)
        {
            var worldCity = await _context.WorldCity.FindAsync(id);
            if (worldCity == null)
            {
                return NotFound();
            }

            _context.WorldCity.Remove(worldCity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
