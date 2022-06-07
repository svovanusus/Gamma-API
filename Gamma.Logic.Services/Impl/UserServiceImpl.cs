using Gamma.Logic.Repositories;
using Gamma.Logic.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamma.Logic.Services.Impl
{
    internal class UserServiceImpl : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserServiceImpl(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserModel?> GetUser(long userId)
        {
            var entity = await _userRepository.GetById(userId);

            if (entity == null) return null;

            return new UserModel
            {
                UserId = entity.UserId,
                CreatedDate = entity.CreatedDate,
                FirstName = entity.FirstName,
                IsDeleted = entity.IsDeleted,
                LastName = entity.LastName,
                Login = entity.Login,
                Password = entity.Password,
                Role = entity.Role,
                UpdatedDate = entity.UpdatedDate
            };
        }
    }
}
