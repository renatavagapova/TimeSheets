using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Data
{
    public interface IRepoBase<T>
    {
        T GetItem(int id);
        IEnumerable<T> GetItemByName(string name);
        IEnumerable<T> GetItems(int skip, int take);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        int GetCount();
    }
}
