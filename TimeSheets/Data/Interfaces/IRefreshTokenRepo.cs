﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Models;

namespace TimeSheets.Data.Interfaces
{
    public interface IRefreshTokenRepo
    {
        Task<RefreshToken> GetItem(Guid id);
        Task Update(RefreshToken tokenRow);

        Task Add(RefreshToken tokenRow);
    }
}
