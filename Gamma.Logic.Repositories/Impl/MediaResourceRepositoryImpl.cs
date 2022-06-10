using Gamma.Data.EF;
using Gamma.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gamma.Logic.Repositories.Impl
{
    internal class MediaResourceRepositoryImpl : RepositoryBase<MediaResource>, IMediaResourceRepository
    {
        public MediaResourceRepositoryImpl(GammaDbContext context) : base(context) {}

        public MediaResource Delete(MediaResource entity)
        {
            return dbSet.Remove(entity).Entity;
        }

        public async Task<MediaResource?> GetById(long id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<MediaResource?> GetByUid(string uid)
        {
            return await dbSet.FirstOrDefaultAsync(x => x.MediaResourceUid == uid);
        }

        public async Task<MediaResource> Save(MediaResource model)
        {
            var found = await dbSet.FindAsync(model.MediaResourceId);
            if (found == null)
            {
                model.MediaResourceUid = Guid.NewGuid().ToString().Replace("-", "");
                model.CreatedDate = DateTime.Now;
                model.UpdatedDate = model.CreatedDate;
                return (await dbSet.AddAsync(model))?.Entity!;
            }

            found.DefaultAltText = model.DefaultAltText;
            found.LastRevision = model.LastRevision;
            found.Revisions = model.Revisions;
            found.Description = model.Description;
            found.Name = model.Name;
            found.UpdatedDate = DateTime.Now;

            return found;
        }
    }
}
