using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Repositories
{
    public interface IRepository<T> where T : class
    {
        void CreateOrUpdate(T data);
        T Delete(T data);
        T Get(int id);
        ObservableCollection<T> GetAll();
        void SaveAll();
    }
}
