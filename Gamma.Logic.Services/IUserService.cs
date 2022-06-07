using Gamma.Logic.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamma.Logic.Services
{
    public interface IUserService
    {
        Task<UserModel?> GetUser(long userId);
    }
}
