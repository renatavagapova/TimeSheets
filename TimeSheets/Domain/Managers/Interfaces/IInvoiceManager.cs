using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Models.Dto;

namespace TimeSheets.Domain.Managers.Interfaces
{
    public interface IInvoiceManager
    {
        Task<Guid> Create(InvoiceRequest request);
    }
}
