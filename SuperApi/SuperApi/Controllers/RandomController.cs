using Microsoft.AspNetCore.Mvc;
using Faker;

namespace SuperApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RandomController : ControllerBase
    {

        [HttpGet("GetRandomInt")]
        public IActionResult GetInt(int min, int max)
        {
            if (min > max)
                return BadRequest();

            var random = new Random();
            return Ok(random.Next(min, max));
        }

        [HttpGet("GetRandomDouble")]
        public IActionResult GetDouble(int min, int max)
        {
            if (min > max)
                return BadRequest();

            var random = new Random();
            var intPart = (double)random.Next(min, max);
            var doublePart = random.NextDouble();
            return Ok(intPart + (intPart < 0 ? -doublePart : doublePart));
        }

        [HttpGet("GetRandomString")]
        public IActionResult GetRandomString(int length)
        {
            if (length < 1)
                return BadRequest();

            var charArray = new char[length];
            var random = new Random();

            for (int i = 0; i < length; i++)
                charArray[i] = (char)random.Next(65, 91);

            return Ok(string.Join("", charArray));
        }

        [HttpGet("Lorem")]
        public IActionResult GetLorem(int count)
        {
            if (count < 1)
                return BadRequest();
            return Ok(string.Join(" ", Lorem.Words(count)));
        }



    }
}
