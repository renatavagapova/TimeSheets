using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Domain.ValueObjects;

namespace TimeSheets.Models.Entities
{
    public class Invoice
    {
        public Guid Id { get; set; }
        public Guid ContractId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public Money Sum { get; protected set; }

        public Contract Contract { get; set; }
        public List<Sheet> Sheets { get; set; } = new List<Sheet>();

        protected Invoice() { }
    }
}
