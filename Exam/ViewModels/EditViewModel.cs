using Exam.Models;
using Exam.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.ViewModels
{
    class EditViewModel
    {
        public FrameworkUIModel Framework { get; set; }
        public EditViewModel(FrameworkUIModel framework)
        {
            this.Framework = framework;
            EditView editView = new EditView {
                DataContext = this
            };
            editView.ShowDialog();
        }
    }
}
