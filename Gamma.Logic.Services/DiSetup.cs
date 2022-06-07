using Gamma.Logic.Services.Impl;
using Microsoft.Extensions.DependencyInjection;

namespace Gamma.Logic.Services
{
    public static class DiSetup
    {
        public static void Setup(IServiceCollection services)
        {
            services.AddTransient<IAuthService, AuthServiceImpl>();
            services.AddTransient<IUserService, UserServiceImpl>();
        }
    }
}
