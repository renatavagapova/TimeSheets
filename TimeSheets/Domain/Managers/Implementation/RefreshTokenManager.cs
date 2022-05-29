using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Managers.Interfaces;
using TimeSheets.Models;
using TimeSheets.Models.Entities;

namespace TimeSheets.Domain.Managers.Implementation
{
    public class RefreshTokenManager : IRefreshTokenManager
    {
        private readonly IRefreshTokenRepo _refreshTokenRepo;

        public RefreshTokenManager(IRefreshTokenRepo refreshTokenRepo)
        {
            _refreshTokenRepo = refreshTokenRepo;
        }
        public async void CreateOrUpdate(RefreshToken token)
        {
            var tokenFromBase = await _refreshTokenRepo.GetItem(token.UserId);
            if (tokenFromBase.Token == null)
            {
                await _refreshTokenRepo.Add(token);
            }
            else
            {
                await _refreshTokenRepo.Update(token);
            }
        }
    }
}
