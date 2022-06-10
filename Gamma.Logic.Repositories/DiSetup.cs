using Gamma.Logic.Repositories.Impl;
using Microsoft.Extensions.DependencyInjection;

namespace Gamma.Logic.Repositories
{
    public static class DiSetup
    {
        public static void Setup(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepositoryImpl>();
            services.AddScoped<IDomainRepository, DomainRepositoryImpl>();
            services.AddScoped<IMediaResourceRepository, MediaResourceRepositoryImpl>();
            services.AddScoped<IMediaResourceRevisionRepository, MediaResourceRevisionRepositoryImpl>();
            services.AddScoped<ISitePageRepository, SitePageRepositoryImpl>();
            services.AddScoped<ISiteRepository, SiteRepositoryImpl>();
        }
    }
}
