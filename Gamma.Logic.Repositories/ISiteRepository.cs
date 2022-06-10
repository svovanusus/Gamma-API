using Gamma.Data.Entities;

namespace Gamma.Logic.Repositories
{
    public interface ISiteRepository : IRepository
    {
        Task<Site?> GetById(long id);
        Task<Site?> GetByName(string name);
        IQueryable<Site> GetAllForUser(long userId);
        Task<Site> Save(Site model);
        Site Delete(Site entity);
    }
}
