using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Managers.Interfaces;

namespace TimeSheets.Domain.Managers.Implementation
{
    public class ContractManager : IContractManager
    {
        private readonly IContractRepo _contractRepo;

        public ContractManager(IContractRepo contractRepo)
        {
            _contractRepo = contractRepo;
        }

        public async Task<bool?> CheckContractIsActive(Guid id)
        {
            return await _contractRepo.CheckContractIsActive(id);
        }
    }
}
