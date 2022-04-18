using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Models;

namespace TimeSheets.Data.Implementation
{
    public class ServiceRepo : IServiceRepo
    {
        public Task<Service> GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Service>> GetItems()
        {
            throw new NotImplementedException();
        }

        public Task Add(Service item)
        {
            throw new NotImplementedException();
        }

        public Task Update(Service item)
        {
            throw new NotImplementedException();
        }
    }
}
