﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models.Dto;

namespace TimeSheets.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : TimesheetsBaseController
    {
        private readonly ILoginManager _loginManager;
        private readonly IUserManager _userManager;
        private readonly IRefreshTokenRepo _refreshTokenRepo;

        public LoginController(ILoginManager loginManager, IUserManager userManager,
            IRefreshTokenRepo refreshTokenRepo)
        {
            _loginManager = loginManager;
            _userManager = userManager;
            _refreshTokenRepo = refreshTokenRepo;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userManager.GetUser(request);

            if (user == null) return Unauthorized();

            var loginResponse = _loginManager.Authenticate(user);

            return Ok(loginResponse);
        }

        [HttpPost("/refreshtoken")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            //var token = await _refreshTokenRepo.GetItem(request.Token);
            //if (token == null) return Unauthorized();

            //var user = await _userManager.GetItem(token.UserId);
            //if (user == null) return Unauthorized();

            //var loginResponse = _loginManager.Authenticate(user);

            return Ok();
        }
    }
}
