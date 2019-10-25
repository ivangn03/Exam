using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Models;
using Exam.Repositories;
using Ninject.Modules;
namespace Exam.Modules
{
    class UIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<FrameworkUIModel>>().To<FrameworkUIRepository>();
        }
    }
}
