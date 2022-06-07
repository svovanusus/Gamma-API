using Gamma.Data.Entities;

namespace Gamma.Logic.Repositories
{
    public interface IUserRepository : IRepository
    {
        Task<User?> GetById(long id);
        Task<User?> GetByLogin(string login);
        Task<User> Save(User model);
        User Delete(User entity);
    }
}
