using Exam.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using BLL.Modules;
using Exam.Modules;

namespace Exam.Infrastucture
{
    class ViewModelLocator
    {
        public MainViewModel MainViewModel { get; set; }
        IKernel kernel;
        public ViewModelLocator()
        {
            kernel = new StandardKernel( new BLLModule(), new UIModule());
            MainViewModel = kernel.Get<MainViewModel>();
        }
    }
}
