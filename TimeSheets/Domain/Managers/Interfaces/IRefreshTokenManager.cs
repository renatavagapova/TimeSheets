using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Models;
using TimeSheets.Models.Entities;

namespace TimeSheets.Domain.Managers.Interfaces
{
    public interface IRefreshTokenManager
    {
        void CreateOrUpdate(RefreshToken token);
    }
}
