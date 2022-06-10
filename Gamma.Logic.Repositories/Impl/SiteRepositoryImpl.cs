using Gamma.Data.EF;
using Gamma.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gamma.Logic.Repositories.Impl
{
    internal class SiteRepositoryImpl : RepositoryBase<Site>, ISiteRepository
    {
        public SiteRepositoryImpl(GammaDbContext context) : base(context) {}

        public Site Delete(Site entity)
        {
            return dbSet.Remove(entity).Entity;
        }

        public async Task<Site?> GetById(long id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<Site?> GetByName(string name)
        {
            return await dbSet.FirstOrDefaultAsync(x => x.Name == name);
        }

        public IQueryable<Site> GetAllForUser(long userId)
        {
            return dbSet.Include(x => x.Owner).Where(x => x.Owner.UserId == userId);
        }

        public async Task<Site> Save(Site model)
        {
            var found = await dbSet.FindAsync(model.SiteId);
            if (found == null)
            {
                model.CreatedDate = DateTime.Now;
                model.UpdatedDate = model.CreatedDate;
                return (await dbSet.AddAsync(model))?.Entity!;
            }

            found.Name = model.Name;
            found.UpdatedDate = DateTime.Now;

            return found;
        }
    }
}
