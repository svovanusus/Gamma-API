using Gamma.Data.Entities;

namespace Gamma.Logic.Repositories
{
    public interface IMediaResourceRepository : IRepository
    {
        Task<MediaResource?> GetById(long id);
        Task<MediaResource?> GetByUid(string uid);
        Task<MediaResource> Save(MediaResource model);
        MediaResource Delete(MediaResource entity);
    }
}
