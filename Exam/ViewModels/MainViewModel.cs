using BLL.DTOs;
using BLL.Services;
using Exam.Infrastucture;
using Exam.Models;
using Exam.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Exam.ViewModels
{
    class MainViewModel
    {
        public ObservableCollection<FrameworkUIModel> FrameworkUIModels { get; set; }
        public FrameworkUIModel SelectedItem { get; set; }
        #region Commands
        public ICommand AutoSave { get; set; } 
        public ICommand AddItem { get; set; }
        public ICommand RemoveItem { get; set; }
        public ICommand EditItem { get; set; }

        #endregion
        public MainViewModel(IRepository<FrameworkUIModel> repository)
        {
            FrameworkUIModels = repository.GetAll();
            AutoSave = new RelayCommand(x=> { repository.SaveAll();  });
            AddItem = new RelayCommand(x=> {
                FrameworkUIModel framework = new FrameworkUIModel { Name = "", Language = "", ImageURL = "" };           
                SelectedItem = framework;  
                new EditViewModel(SelectedItem);
                repository.CreateOrUpdate(framework);
                FrameworkUIModels.Add(framework);
            });
            RemoveItem = new RelayCommand(x => {
                repository.Delete(SelectedItem);
                FrameworkUIModels.Remove(SelectedItem);
            }, x=>FrameworkUIModels.Count > 0 && SelectedItem!=null);
            EditItem = new RelayCommand(x => {
                new EditViewModel(SelectedItem);
                repository.CreateOrUpdate(SelectedItem);
            },  x=> SelectedItem !=null
            );
            MainWindow mainWindow = new MainWindow
            {
                DataContext = this
            };
            mainWindow.ShowDialog();
        }
    }
}
