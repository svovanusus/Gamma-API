using Gamma.Data.Entities;
using Gamma.Logic.Models;
using Gamma.Logic.Repositories;
using Gamma.Utils;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Gamma.Logic.Services.Impl
{
    internal class AuthServiceImpl : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthServiceImpl(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<AuthTokenResponseModel?> SignIn(SignInRequestModel model)
        {
            var foundUser = await _userRepository.GetByLogin(model.Login);
            if (foundUser != null && !foundUser.IsDeleted)
            {
                if (VerifyPassword(model.Password, foundUser.Password))
                {
                    var now = DateTime.Now;
                    var jwt = new JwtSecurityToken(
                        issuer: AuthConfig.ISSUER,
                        audience: AuthConfig.AUDIENCE,
                        notBefore: now,
                        claims: new List<Claim>
                        {
                            new Claim(ClaimTypes.NameIdentifier, foundUser.UserId.ToString()),
                            new Claim(ClaimTypes.Name, foundUser.Login),
                            new Claim(ClaimTypes.Role, foundUser.Role.ToString())
                        },
                        expires: now.Add(TimeSpan.FromSeconds(AuthConfig.LIFETIME)),
                        signingCredentials: new SigningCredentials(AuthConfig.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
                    var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                    return new AuthTokenResponseModel
                    {
                        Token = encodedJwt,
                    };
                }
            }

            return null;
        }

        public Task<bool> SignOut()
        {
            throw new NotImplementedException();
        }

        public async Task<AuthResponseModel> SignUp(SignUpRequestModel model)
        {
            var found = await _userRepository.GetByLogin(model.Login);
            if (found != null) return new AuthResponseModel
            {
                Status = "error",
                Message = "Login is already exists.",
            };

            var user = new User
            {
                Login = model.Login,
                Password = EncryptPassword(model.Password),
                FirstName = model.FirstName,
                LastName = model.LastName,
            };

            user = await _userRepository.Save(user);
            await _userRepository.CommitChangesAsync();

            if (user != null)
            {
                return new AuthResponseModel
                {
                    Status = "success",
                    Message = ""
                };
            }

            return new AuthResponseModel
            {
                Status = "error",
                Message = "Unknown Error"
            };
        }

        public Task<bool> VerifyLogin(string login)
        {
            throw new NotImplementedException();
        }

        public Task<bool> VerifyPassword(string password)
        {
            throw new NotImplementedException();
        }

        private bool VerifyPassword(string password, string hash)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(password, hash);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private string EncryptPassword(string password)
        {
            var salt = BCrypt.Net.BCrypt.GenerateSalt();
            return BCrypt.Net.BCrypt.HashPassword(password, salt);
        }
    }
}
