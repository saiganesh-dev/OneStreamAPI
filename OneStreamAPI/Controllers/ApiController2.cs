using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace OneStreamAPI.Controllers
{
    [Route("api/[controller]")]
    public class ApiController2 : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await Task.Delay(3000);  
            return Ok("Response from API 2");
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string value)
        {

            await Task.Delay(3000);  
            return Ok($"Received '{value}' in API 2");
        }
    }
}
