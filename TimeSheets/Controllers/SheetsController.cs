﻿using Microsoft.AspNetCore.Mvc;
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
    public class SheetsController :  ControllerBase
    {
        private readonly IContractManager _contractManager;
        private readonly ISheetManager _sheetManager;

        public SheetsController(ISheetManager sheetManager, IContractManager contractManager)
        {
            _sheetManager = sheetManager;
            _contractManager = contractManager;
        }

        /// <summary> Возвращает запись табеля </summary>
        [HttpGet("sheets/")]
        public IActionResult Get([FromQuery] Guid id)
        {
            var result = _sheetManager.GetItem(id);
            return Ok(result);
        }

        /// <summary> Возвращает все записи табеля </summary>
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var result = await _sheetManager.GetItems();
            return Ok(result);
        }

        /// <summary> Создает запись табеля </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SheetRequest sheet)
        {
            var isAllowedToCreate = await _contractManager.CheckContractIsActive(sheet.ContractId);

            if (isAllowedToCreate != null && !(bool)isAllowedToCreate)
                return BadRequest($"Contract {sheet.ContractId} is not active or not found.");

            var id = await _sheetManager.Create(sheet);
            return Ok(id);
        }

        /// <summary> Обновляет запись табеля </summary>
        [HttpPut("update/")]
        public async Task<IActionResult> Update([FromQuery] Guid id, [FromBody] SheetRequest sheet)
        {
            var isAllowedToCreate = await _contractManager.CheckContractIsActive(sheet.ContractId);

            if (isAllowedToCreate != null && !(bool)isAllowedToCreate)
                return BadRequest($"Contract {sheet.ContractId} is not active or not found.");

            await _sheetManager.Update(id, sheet);

            return Ok();
        }
    }
}
