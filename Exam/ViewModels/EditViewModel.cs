using Exam.Infrastucture;
using Exam.Models;
using Exam.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Exam.ViewModels
{
    class EditViewModel
    {
        public FrameworkUIModel Framework { get; set; }
        public ICommand BackToMain { get; set; }
        public EditViewModel(FrameworkUIModel framework)
        {
            this.Framework = framework;
            EditView editView = new EditView {
                DataContext = this
            };
            BackToMain = new RelayCommand(x => {
                editView.Close();
            });
            editView.ShowDialog();
        }
    }
}
