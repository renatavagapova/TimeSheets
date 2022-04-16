using System.Collections.Generic;
using TimeSheets.Models;
using TimeSheets.Models.Dto;

namespace TimeSheets.Domain.Interfaces
{
    public interface IPersonsManager
    {
        Person GetItem(int id);
        List<Person> GetItemByName(string name);
        List<Person> GetAll(int skip, int take);
        int Create(PersonDto item);
        void Update(Person item);
        void Delete(int id);
    }
}
