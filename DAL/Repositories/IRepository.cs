using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IRepository<T> where T:class
    {
        void CreateOrUpdate(T data);
        T Delete(T data);
        T Get(int id);
        IEnumerable<T> GetAll();
        void SaveAll();
    }
}
