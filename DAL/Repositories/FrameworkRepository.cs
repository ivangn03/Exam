using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class FrameworkRepository : IRepository<Framework>
    {
        List<Framework> frameworks;
        public FrameworkRepository()
        {
            frameworks = Framework.GetFrameworks() as List<Framework>;
        }
        public void CreateOrUpdate(Framework data)
        {
            frameworks.Add(data);
            //TODO throw new NotImplementedException();
        }

        public Framework Delete(Framework data)
        {
            frameworks.Remove(data);
            return data;
            //TODO throw new NotImplementedException();
        }

        public Framework Get(int id)
        {
            return frameworks.FirstOrDefault(x => x.Id == id);
            // throw new NotImplementedException();
        }

        public IEnumerable<Framework> GetAll()
        {
            return frameworks;
        }

        public void SaveAll()
        {
            //TODO
        }
    }
}
