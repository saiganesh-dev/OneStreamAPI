using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace OneStreamAPI.Controllers
{
    [Route("api/[controller]")]
    public class ApiController1 : ControllerBase
    {
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await Task.Delay(2000);  
            return Ok("Response From API 1");
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string value)
        {
            await Task.Delay(2000);  
            return Ok($"Received '{value}' in API 1");
        }
    }
}
