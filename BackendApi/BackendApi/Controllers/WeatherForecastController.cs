using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new()
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        private List<string> SortSummaries()
        {
            List<string> sorted = new List<string>();
            sorted.AddRange(Summaries);
            sorted.Sort();

            return sorted;
        }

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll(int? sortStrategy)
        {
            switch(sortStrategy)
            {
                case null:
                    return Ok(Summaries);
                case 1:
                    return Ok(SortSummaries());
                case -1:
                    List<string> reversed = SortSummaries();
                    reversed.Reverse();
                    return Ok(reversed);
                default:
                    return BadRequest("Некорректное значение параметра sortStrategy");
            }
        }

        [HttpPost]
        public IActionResult Add(string name)
        {
            Summaries.Add(name);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(int index, string name)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("Такой индекс неверный!");
            }

            Summaries[index] = name;
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int index) 
        {
            if(index < 0 || index >= Summaries.Count)
            {
                return BadRequest("Такого индекса не существует!");
            }

            Summaries.RemoveAt(index);
            return Ok();
        }

        [HttpGet("{index}")]
        public string GetByIndex(int index)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return "Индекс не найден";
            }

            return Summaries[index];
        }

        [HttpGet("find-by-name")]
        public int NameCount(string name)
        {
            int count = 0;

            foreach(string s in Summaries)
            {
                if(s == name) 
                    count++;
            }

            return count;
        }
    }
}