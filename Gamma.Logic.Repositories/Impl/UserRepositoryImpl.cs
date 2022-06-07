using Gamma.Data.EF;
using Gamma.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gamma.Logic.Repositories.Impl
{
    internal class UserRepositoryImpl : RepositoryBase<User>, IUserRepository
    {
        public UserRepositoryImpl(GammaDbContext context) : base(context) { }

        public async Task<User?> GetById(long userId)
        {
            return await dbSet.FindAsync(userId);
        }

        public Task<User?> GetByLogin(string login)
        {
            return dbSet.FirstOrDefaultAsync(x => x.Login == login && !x.IsDeleted);
        }

        public async Task<User> Save(User model)
        {
            var entity = await dbSet.FindAsync(model.UserId);
            if (entity == null)
            {
                model.CreatedDate = DateTime.Now;
                model.UpdatedDate = model.CreatedDate;
                return (await dbSet.AddAsync(model)).Entity;
            }
            else
            {
                entity.Role = model.Role;
                entity.Login = model.Login;
                entity.Password = model.Password;
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.IsDeleted = model.IsDeleted;
                entity.UpdatedDate = DateTime.Now;
            }
            return entity;
        }

        public User Delete(User entity)
        {
            return dbSet.Remove(entity).Entity;
        }
    }
}
