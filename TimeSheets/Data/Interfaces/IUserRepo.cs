using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Models;

namespace TimeSheets.Data.Interfaces
{
    public interface IUserRepo : IRepoBase<User>
    {
       Task Delete(Guid id);
       Task Create(User user);
       Task<User> GetByLoginAndPasswordHash(string requestLogin, byte[] passwordHash);
    }
}
