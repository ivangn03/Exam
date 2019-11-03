using BLL.DTOs;
using BLL.Services;
using Exam.Infrastucture;
using Exam.Models;
using Exam.Repositories;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Exam.ViewModels
{
    class MainViewModel
    {
        public String Locale { get; set; }
        public String Theme { get; set; }
        public ObservableCollection<FrameworkUIModel> FrameworkUIModels { get; set; }
        public FrameworkUIModel SelectedItem { get; set; }
        #region Commands
        public ICommand AutoSave { get; set; } 
        public ICommand AddItem { get; set; }
        public ICommand RemoveItem { get; set; }
        public ICommand EditItem { get; set; }
        public ICommand ChangeLanguage { get; set; }
        public ICommand ChangeTheme { get; set; }
        #endregion
        public MainViewModel(IRepository<FrameworkUIModel> repository)
        {
            FrameworkUIModels = repository.GetAll();
            AutoSave = new RelayCommand(x=> { repository.SaveAll();  });
            AddItem = new RelayCommand(x=> {
                FrameworkUIModel framework = new FrameworkUIModel { Name = "", Language = "", ImageURL = "" };           
                SelectedItem = framework;  
                new EditViewModel(SelectedItem, Locale);
                repository.CreateOrUpdate(framework);
                FrameworkUIModels.Add(framework);
            });
            RemoveItem = new RelayCommand(x => {
                repository.Delete(SelectedItem);
                FrameworkUIModels.Remove(SelectedItem);
            }, x=>FrameworkUIModels.Count > 0 && SelectedItem!=null);
            EditItem = new RelayCommand(x => {
                new EditViewModel(SelectedItem, Locale);
                repository.CreateOrUpdate(SelectedItem);
            },  x=> SelectedItem !=null
            );
            ChangeTheme = new RelayCommand(x => {
                var theme = x as string;
                var dictionary = new ResourceDictionary();
                var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                configuration.AppSettings.Settings["Theme"].Value = theme;
                configuration.Save();
                theme = string.IsNullOrEmpty(theme) ? "Default":theme;
                dictionary.Source = new Uri("Themes/" + theme + ".xaml", UriKind.Relative);
                Application.Current.Resources.MergedDictionaries[1] = dictionary;
            });
            ChangeLanguage = new RelayCommand(x=> {
                var language = x as string;
                var dictionary = new ResourceDictionary();
                var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                configuration.AppSettings.Settings["Language"].Value = language;
                configuration.Save();

                language= string.IsNullOrEmpty(language)?"Locale-en": language;
                Locale = language;
                dictionary.Source = new Uri("Localization/"+language+".xaml", UriKind.Relative);
                Application.Current.Resources.MergedDictionaries[0] = dictionary;
            });
            MainWindow mainWindow = new MainWindow
            {
                DataContext = this
            };
            mainWindow.ShowDialog();
        }
    }
}
