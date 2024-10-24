using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Data;
using server.Model;
using server.Data;
using server.Model;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly WeatherForecastContext _context;

        // Konstruktor prima kontekst baze podataka
        public WeatherForecastController(WeatherForecastContext context)
        {
            _context = context;
        }

        // GET: api/weatherforecast
        // Vraca sve vremenske prognoze iz baze
        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            return await _context.WeatherForecasts.ToListAsync();
        }

        // POST: api/weatherforecast
        // Dodaje novu vremensku prognozu u bazu
        [HttpPost(Name = "AddWeatherForecast")]
        public async Task<IActionResult> Post([FromBody] WeatherForecast forecast)
        {
            _context.WeatherForecasts.Add(forecast);  // Dodajemo novu prognozu u bazu
            await _context.SaveChangesAsync();        // cuvamo promene u bazi
            return Ok();                              // Vracamo status OK nakon uspešnog dodavanja
        }

        // PUT: api/weatherforecast/{id}
        // Ažurira postoje u vremensku prognozu po ID-ju
        [HttpPut("{id}", Name = "UpdateWeatherForecast")]
        public async Task<IActionResult> Put(int id, [FromBody] WeatherForecast updatedForecast)
        {
            var existingForecast = await _context.WeatherForecasts.FindAsync(id); // Pronalazimo postojecu prognozu
            existingForecast.Date = updatedForecast.Date;                         // Ažuriramo datum
            existingForecast.TemperatureC = updatedForecast.TemperatureC;         // Ažuriramo temperaturu
            existingForecast.Summary = updatedForecast.Summary;                   // Ažuriramo opis prognoze
            await _context.SaveChangesAsync();                                     // cuvamo promene
            return Ok();                                                          // Vra?amo status OK
        }

        // DELETE: api/weatherforecast/{id}
        // Briše vremensku prognozu po ID-ju
        [HttpDelete("{id}", Name = "DeleteWeatherForecast")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingForecast = await _context.WeatherForecasts.FindAsync(id);  // Pronalazimo prognozu po ID-ju
            _context.WeatherForecasts.Remove(existingForecast);                    // Brišemo prognozu iz baze
            await _context.SaveChangesAsync();                                     // cuvamo promene
            return Ok();                                                          // Vracamo status OK
        }
    }
}
