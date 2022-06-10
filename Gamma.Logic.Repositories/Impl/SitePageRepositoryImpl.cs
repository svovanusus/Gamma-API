using Gamma.Data.EF;
using Gamma.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gamma.Logic.Repositories.Impl
{
    internal class SitePageRepositoryImpl : RepositoryBase<SitePage>, ISitePageRepository
    {
        public SitePageRepositoryImpl(GammaDbContext context) : base(context) {}

        public SitePage Delete(SitePage entity)
        {
            return dbSet.Remove(entity).Entity;
        }

        public async Task<SitePage?> GetById(long id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<SitePage?> GetByName(string name)
        {
            return await dbSet.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<SitePage> Save(SitePage model)
        {
            var found = await dbSet.FindAsync(model.SitePageId);
            if (found == null)
            {
                model.CreatedDate = DateTime.Now;
                model.UpdatedDate = model.CreatedDate;
                return (await dbSet.AddAsync(model))?.Entity!;
            }

            found.Name = model.Name;
            found.Url = model.Url;
            found.ContentJson = model.ContentJson;
            found.UpdatedDate = DateTime.Now;

            return found;
        }
    }
}
