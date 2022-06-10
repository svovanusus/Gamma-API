using Gamma.Data.EF;
using Gamma.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gamma.Logic.Repositories.Impl
{
    internal class MediaResourceRevisionRepositoryImpl : RepositoryBase<MediaResourceRevision>, IMediaResourceRevisionRepository
    {
        public MediaResourceRevisionRepositoryImpl(GammaDbContext context) : base(context) {}

        public MediaResourceRevision Delete(MediaResourceRevision entity)
        {
            return dbSet.Remove(entity).Entity;
        }

        public async Task<MediaResourceRevision?> GetById(long id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<MediaResourceRevision> Save(MediaResourceRevision model)
        {
            var found = await dbSet.FindAsync(model.MediaResourceRevisionId);
            if (found == null)
            {
                model.CreatedDate = DateTime.Now;
                model.UpdatedDate = model.CreatedDate;
                return (await dbSet.AddAsync(model))?.Entity!;
            }

            return found;
        }
    }
}
