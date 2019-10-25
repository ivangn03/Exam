using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs;
using BLL.Services;
using DAL.Models;
using DAL.Repositories;
using Ninject.Modules;
namespace BLL.Modules
{
    public class BLLModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Framework>>().To<FrameworkRepository>();
            Bind<IService<FrameworkDTO>>().To<FrameworkService>();
        }
    }
}
