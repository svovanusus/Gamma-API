using Gamma.Data.Configurations;
using Gamma.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Gamma.Data.EF
{
    public class GammaDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Domain> Domains { get; set; } = null!;
        public DbSet<Site> Sites { get; set; } = null!;
        public DbSet<SitePage> SitePages { get; set; } = null!;
        public DbSet<MediaResource> MediaResources { get; set; } = null!;
        public DbSet<MediaResourceRevision> MediaResourceRevisions { get; set; } = null!;

        public GammaDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("GammaDb"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UserConfiguration().Configure(modelBuilder.Entity<User>());
            new DomainConfiguration().Configure(modelBuilder.Entity<Domain>());
            new SiteConfiguration().Configure(modelBuilder.Entity<Site>());
            new SitePageConfiguration().Configure(modelBuilder.Entity<SitePage>());
            new MediaResourceConfiguration().Configure(modelBuilder.Entity<MediaResource>());
            new MediaResourceRevisionConfiguration().Configure(modelBuilder.Entity<MediaResourceRevision>());
        }
    }
}
