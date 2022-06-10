using Gamma.Data.EF;
using Gamma.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gamma.Logic.Repositories.Impl
{
    internal class DomainRepositoryImpl : RepositoryBase<Domain>, IDomainRepository
    {
        public DomainRepositoryImpl(GammaDbContext context) : base(context) {}

        public Domain Delete(Domain entity)
        {
            return dbSet.Remove(entity).Entity;
        }

        public async Task<Domain?> GetById(long id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<Domain?> GetByName(string name)
        {
            return await dbSet.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<Domain> Save(Domain model)
        {
            var found = await GetByName(model.Name);
            if (found != null) return null!;

            model.CreatedDate = DateTime.Now;
            model.UpdatedDate = model.CreatedDate;

            return (await dbSet.AddAsync(model))?.Entity!;
        }
    }
}
