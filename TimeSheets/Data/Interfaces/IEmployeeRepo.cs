using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Models;
using TimeSheets.Models.Entities;

namespace TimeSheets.Data.Interfaces
{
    public interface IEmployeeRepo : IRepoBase<Employee>
    {
        Task Delete(Guid id);
    }
}
