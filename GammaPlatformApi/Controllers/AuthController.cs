using Gamma.Logic.Models;
using Gamma.Logic.Services;
using Microsoft.AspNetCore.Mvc;

namespace GammaPlatformApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("signin")]
        public async Task<AuthTokenResponseModel?> SignIn([FromBody] SignInRequestModel model)
        {
            var result = await _authService.SignIn(model);
            if (result == null)
            {
                Response.StatusCode = StatusCodes.Status401Unauthorized;
            }

            return result;
        }

        [HttpPost("signup")]
        public async Task<AuthResponseModel> SignUp([FromBody] SignUpRequestModel model)
        {
            return await _authService.SignUp(model);
        }
    }
}
