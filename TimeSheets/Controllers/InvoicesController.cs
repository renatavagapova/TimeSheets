using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Domain.Managers.Interfaces;
using TimeSheets.Models.Dto;

namespace TimeSheets.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoicesController : TimesheetsBaseController
    {
        private readonly IInvoiceManager _invoiceManager;
        private readonly IContractManager _contractManager;

        public InvoicesController(IInvoiceManager invoiceManager, IContractManager contractManager)
        {
            _invoiceManager = invoiceManager;
            _contractManager = contractManager;
        }

        /// <summary> Создает клиентский счет </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InvoiceRequest invoiceRequest)
        {
            var isAllowedToCreate = await _contractManager.CheckContractIsActive(invoiceRequest.ContractId);

            if (isAllowedToCreate != null && !(bool)isAllowedToCreate)
            {
                return BadRequest($"Contract {invoiceRequest.ContractId} is not active or not found.");
            }

            var id = await _invoiceManager.Create(invoiceRequest);
            return Ok(id);
        }
    }
}
