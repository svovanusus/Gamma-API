using Gamma.Logic.Repositories.Impl;
using Microsoft.Extensions.DependencyInjection;

namespace Gamma.Logic.Repositories
{
    public static class DiSetup
    {
        public static void Setup(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepositoryImpl>();
        }
    }
}
