using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Model;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController: ControllerBase
    {
        
        [HttpGet("{city}")]
        public async Task<IActionResult> GetWeather(string city) // PascalCase 
        {

            HttpClient client = new HttpClient(); 

            var response = await client.GetAsync("http://api.weatherstack.com/current?access_key=f9b2a1bee26124cf6193f4aaa1f555f7&query="+city);

            var responseStream = await response.Content.ReadAsStreamAsync();

            var result = await JsonSerializer.DeserializeAsync<Root>(responseStream);

            var weatherModel = new Weather 
            {
                Name = result.location.name,
                Temperature = result.current.temperature,
                Localtime = result.location.localtime,
                FeelsLike = result.current.feelslike,
                RuzgarYonu = result.current.wind_dir
            };


            return Ok(weatherModel);
        }

    }
}