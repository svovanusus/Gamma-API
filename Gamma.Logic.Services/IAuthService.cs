using Gamma.Logic.Models;

namespace Gamma.Logic.Services
{
    public interface IAuthService
    {
        Task<AuthTokenResponseModel?> SignIn(SignInRequestModel model);
        Task<AuthResponseModel> SignUp(SignUpRequestModel model);
        Task<bool> SignOut();
        Task<bool> VerifyLogin(string login);
        Task<bool> VerifyPassword(string password);
    }
}
