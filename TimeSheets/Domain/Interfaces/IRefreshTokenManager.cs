using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Models;

namespace TimeSheets.Domain.Interfaces
{
    public interface IRefreshTokenManager
    {
        void CreateOrUpdate(RefreshToken token);
    }
}
