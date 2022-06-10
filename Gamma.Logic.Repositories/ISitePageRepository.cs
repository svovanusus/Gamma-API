using Gamma.Data.Entities;

namespace Gamma.Logic.Repositories
{
    public interface ISitePageRepository : IRepository
    {
        Task<SitePage?> GetById(long id);
        Task<SitePage?> GetByName(string name);
        Task<SitePage> Save(SitePage model);
        SitePage Delete(SitePage entity);
    }
}
