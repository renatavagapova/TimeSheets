using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Infrastructure.Extensions;
using TimeSheets.Models;
using TimeSheets.Models.Dto;
using TimeSheets.Models.Dto.Authentication;

namespace TimeSheets.Domain.Implementation
{
    public class LoginManager : ILoginManager
    {
        private readonly JwtAccessOptions _jwtAccessOptions;
        private readonly JwtRefreshOptions _jwtRefreshOptions;
        private readonly IRefreshTokenManager _refreshTokenManager;

        public LoginManager(IOptions<JwtAccessOptions> jwtAccessOptions,
            IOptions<JwtRefreshOptions> jwtRefreshOptions,
            IRefreshTokenManager refreshTokenManager)
        {
            _jwtAccessOptions = jwtAccessOptions.Value;
            _jwtRefreshOptions = jwtRefreshOptions.Value;
            _refreshTokenManager = refreshTokenManager;
        }

        public LoginResponse Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new(JwtRegisteredClaimNames.UniqueName, user.Username),
                new(ClaimsIdentity.DefaultRoleClaimType, user.Role)
            };

            var accessTokenRaw = _jwtAccessOptions.GenerateToken(claims);
            var securityHandler = new JwtSecurityTokenHandler();
            var accessToken = securityHandler.WriteToken(accessTokenRaw);

            var refreshTokenRaw = _jwtRefreshOptions.GenerateToken(claims);
            var refreshHandler = new JwtSecurityTokenHandler();
            var refreshToken = refreshHandler.WriteToken(refreshTokenRaw);
            _refreshTokenManager.CreateOrUpdate(new RefreshToken()
            { Token = refreshToken, UserId = user.Id, Date = DateTime.UtcNow });

            var loginResponse = new LoginResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                ExpiresIn = accessTokenRaw.ValidTo.ToEpochTime(),
            };

            return loginResponse;
        }
    }
}
