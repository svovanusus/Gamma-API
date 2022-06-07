using Gamma.Data.EF;
using Microsoft.EntityFrameworkCore;

namespace Gamma.Logic.Repositories
{
    internal abstract class RepositoryBase<TEntity> : IRepository
        where TEntity : class
    {
        protected readonly GammaDbContext context = null!;
        protected readonly DbSet<TEntity> dbSet = null!;

        protected RepositoryBase(GammaDbContext context)
        {
            this.context = context;
            dbSet = this.context.Set<TEntity>();
        }

        public async Task CommitChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
