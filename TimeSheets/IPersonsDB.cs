using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Models;

namespace TimeSheets
{
    public interface IPersonsDB
    {
        List<Person> Persons { get; set; }
        int GetCount();
    }
}
