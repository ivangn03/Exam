using DAL.Context;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class FrameworkRepository : IRepository<Framework>
    {  
        DbContext context;
        IDbSet<Framework> dbSet;
        public FrameworkRepository()
        {
            context = new FrameworkContext();
            dbSet = context.Set<Framework>();           
        }
        public void CreateOrUpdate(Framework data)
        {
            dbSet.AddOrUpdate<Framework>(data);  
        }

        public Framework Delete(Framework data)
        {
            dbSet.Remove(data);
            return data;
            
        }

        public Framework Get(int id)
        {
            return dbSet.Find(id);    
        }

        public IEnumerable<Framework> GetAll()
        {
            return dbSet;
        }

        public void SaveAll()
        {
            context.SaveChanges();
        }
        ~FrameworkRepository()
        {
            context.Dispose();
        }
    }
}
