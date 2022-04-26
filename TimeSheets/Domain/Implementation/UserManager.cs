using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Infrastructure.Extensions;
using TimeSheets.Models;
using TimeSheets.Models.Dto;

namespace TimeSheets.Domain.Implementation
{
    public class UserManager : IUserManager
    {
        private readonly IRefreshTokenRepo _refreshTokenRepo; 
        private readonly IUserRepo _userRepo;

        public UserManager(IUserRepo userRepo, IRefreshTokenRepo refreshTokenRepo)
        {
            _userRepo = userRepo;
            _refreshTokenRepo = refreshTokenRepo;
        }

        public async Task<User> GetItem(Guid id)
        {
            var result = await _userRepo.GetItem(id);
            return result;
        }

        public async Task<IEnumerable<User>> GetItems()
        {
            return await _userRepo.GetItems();
        }

        public async Task<User> GetUser(LoginRequest request)
        {
            var passwordHash = GetPasswordHash(request.Password);
            var user = await _userRepo.GetByLoginAndPasswordHash(request.Login, passwordHash);

            return user;
        }

        public async Task<Guid> Create(CreateUserRequest request)
        {
            request.EnsureNotNull(nameof(request)); 
            
            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = request.Username,
                PasswordHash = GetPasswordHash(request.Password),
                Role = request.Role
            };
            await _userRepo.Create(user);

            return user.Id;
        }

        public async Task Update(Guid id, UserRequest userRequest)
        {
            var user = new User
            {
                Id = id,
                FirstName = userRequest.FirstName,
                MiddleName = userRequest.MiddleName,
                LastName = userRequest.LastName,
                Comment = userRequest.Comment,
                Email = userRequest.Email,
                Username = userRequest.Username
            };
            await _userRepo.Update(user);
        }

        private static byte[] GetPasswordHash(string password)
        {
            using (var sha1 = new SHA1CryptoServiceProvider())
            {
                return sha1.ComputeHash(Encoding.Unicode.GetBytes(password));
            }
        }
    }
}
