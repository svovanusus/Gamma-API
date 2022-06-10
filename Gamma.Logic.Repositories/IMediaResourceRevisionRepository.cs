using Gamma.Data.Entities;

namespace Gamma.Logic.Repositories
{
    public interface IMediaResourceRevisionRepository : IRepository
    {
        Task<MediaResourceRevision?> GetById(long id);
        Task<MediaResourceRevision> Save(MediaResourceRevision model);
        MediaResourceRevision Delete(MediaResourceRevision entity);
    }
}
