using Gamma.Logic.Models;
using Gamma.Logic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GammaPlatformApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SitesController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ISitesService _sitesService;

        public SitesController(IUserService userService, ISitesService sitesService)
        {
            _userService = userService;
            _sitesService = sitesService;
        }

        // GET api/<SitesController>
        [HttpGet]
        public async Task<SiteListItemModel[]> Get()
        {
            if (long.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var userId))
            {
                return await _sitesService.GetUserSites(userId);
            }

            Response.StatusCode = StatusCodes.Status404NotFound;
            return null!;
        }

        // GET api/<SitesController>/5
        [HttpGet("{id}")]
        public async Task<CreateSiteRequestModel?> Get(int id)
        {
            if (long.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var userId))
            {
                var site = await _sitesService.GetSite(id, userId);
                if (site != null)
                {
                    Response.StatusCode = StatusCodes.Status200OK;
                    return site;
                }
            }

            Response.StatusCode = StatusCodes.Status404NotFound;
            return null;
        }

        // POST api/<SitesController>
        [HttpPost]
        public async Task Post([FromBody] CreateSiteRequestModel model)
        {
            if (long.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var userId))
            {
                var newSite = await _sitesService.CreateSite(model, userId);
                if (newSite != null)
                {
                    Response.StatusCode = StatusCodes.Status201Created;
                    return;
                }
            }

            Response.StatusCode = StatusCodes.Status400BadRequest;
            return;
        }
    }
}
