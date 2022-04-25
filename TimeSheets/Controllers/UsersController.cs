﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models.Dto;

namespace TimeSheets.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        /// <summary> Возвращает запись пользователя </summary>
        [Authorize(Roles = "user")]
        [HttpGet("user/")]
        public IActionResult Get([FromQuery] Guid id)
        {
            var result = _userManager.GetItem(id);
            return Ok(result);
        }

        /// <summary> Возвращает все записи пользователей </summary>
        [Authorize(Roles = "user")]
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var result = await _userManager.GetItems();
            return Ok(result);
        }

        /// <summary> Создает запись пользователя </summary>
        [HttpPost("create/")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            var response = await _userManager.Create(request);

            return Ok(response);
        }

        /// <summary> Обновляет запись пользователя </summary>
        [Authorize(Roles = "user")]
        [HttpPut("update/")]
        public async Task<IActionResult> Update([FromQuery] Guid id, [FromBody] UserRequest sheet)
        {
            await _userManager.Update(id, sheet);
            return Ok();
        }
    }
}
