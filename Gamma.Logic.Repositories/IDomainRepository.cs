using Gamma.Data.Entities;

namespace Gamma.Logic.Repositories
{
    public interface IDomainRepository : IRepository
    {
        Task<Domain?> GetById(long id);
        Task<Domain?> GetByName(string name);
        Task<Domain> Save(Domain model);
        Domain Delete(Domain entity);
    }
}
