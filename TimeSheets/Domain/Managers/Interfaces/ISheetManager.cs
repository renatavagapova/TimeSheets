using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Models;
using TimeSheets.Models.Dto;
using TimeSheets.Models.Entities;

namespace TimeSheets.Domain.Managers.Interfaces
{
    public interface ISheetManager
    {
        Task<Sheet> GetItem(Guid id);
        Task<IEnumerable<Sheet>> GetItems();
        Task<Guid> Create(SheetRequest sheet);
        Task Update(Guid id, SheetRequest sheetRequest);
    }
}
