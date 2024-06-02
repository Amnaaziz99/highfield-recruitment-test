using HighfieldRecruitment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HighfieldRecruitment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public TestController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDTO>> Get()
        {
            try
            {
                var response = await _httpClient.GetStringAsync("https://recruitment.highfieldqualifications.com/api/test");

                var users = JsonSerializer.Deserialize<List<UserEntity>>(response, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true 
                });

                if (users == null)
                {
                    return NotFound();
                }

                var ages = users.Select(user =>
                {
                    var age = DateTime.Now.Year - user.Dob.Year;
                    return new AgePlusTwentyDTO
                    {
                        UserId = user.Id,
                        OriginalAge = age,
                        AgePlusTwenty = age + 20
                    };
                }).ToList();

                var topColours = users.Where(user => user != null && user.FavouriteColour != null)
                    .GroupBy(user => user.FavouriteColour.ToLower())
                    .Select(group => new TopColoursDTO
                    {
                        Colour = group.Key,
                        Count = group.Count()
                    })
                    .OrderByDescending(colour => colour.Count)
                    .ThenBy(colour => colour.Colour)
                    .ToList();

                var responseDTO = new ResponseDTO { Users = users, Ages = ages, TopColours = topColours };

                return responseDTO;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] ResponseDTO response)
        {
            return Ok();
        }
    }
}
