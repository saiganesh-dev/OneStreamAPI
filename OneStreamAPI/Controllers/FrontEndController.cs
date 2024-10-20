using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace OneStreamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrontEndController : ControllerBase
    {
        private readonly HttpClient _httpClient;

    public FrontEndController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response1 = await _httpClient.GetStringAsync("https://localhost:5001/api/ApiController1");
        var response2 = await _httpClient.GetStringAsync("https://localhost:5001/api/ApiController2");
        return Ok(new { response1, response2 });
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] string value)
    {
            var jsonContent = new StringContent("{\"value\":\"This is a required string.\"}", Encoding.UTF8, "application/json");
            var response1 = await _httpClient.PostAsync("https://localhost:/api/ApiController1", jsonContent);
            var response2 = await _httpClient.PostAsync("https://localhost:5001/api/ApiController2", jsonContent);

            var result1 = await response1.Content.ReadAsStringAsync();
        var result2 = await response2.Content.ReadAsStringAsync();
        
        return Ok(new { result1, result2 });
    }
    }
}
