using Gamma.Logic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GammaPlatformApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SitesController : ControllerBase
    {
        private readonly IUserService _userService;

        public SitesController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<SitesController>
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            if (long.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var userId))
            {
                var user = await _userService.GetUser(userId);
                if (user != null)
                {
                    return new string[] { user.FirstName, user.LastName };
                }
            }
            return new string[] { "value1", "value2" };
        }

        // GET api/<SitesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SitesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SitesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SitesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
