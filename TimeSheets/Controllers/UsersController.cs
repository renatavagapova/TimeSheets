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
        [HttpGet("user/")]
        public IActionResult Get([FromQuery] Guid id)
        {
            var result = _userManager.GetItem(id);
            return Ok(result);
        }

        /// <summary> Возвращает все записи пользователей </summary>
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var result = await _userManager.GetItems();
            return Ok(result);
        }

        /// <summary> Создает запись пользователя </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserRequest user)
        {
            var id = await _userManager.Create(user);
            return Ok(id);
        }

        /// <summary> Обновляет запись пользователя </summary>
        [HttpPut("update/")]
        public async Task<IActionResult> Update([FromQuery] Guid id, [FromBody] UserRequest sheet)
        {
            await _userManager.Update(id, sheet);
            return Ok();
        }
    }
}
