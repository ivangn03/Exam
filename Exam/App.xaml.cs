using Exam.Infrastucture;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Exam
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var language = ConfigurationManager.AppSettings["Language"];
            var dictionary = new ResourceDictionary();
            language = string.IsNullOrEmpty(language) ? "Locale-en" : language;
            dictionary.Source = new Uri("Localization/" + language + ".xaml", UriKind.Relative);
            Resources.MergedDictionaries[0] = dictionary;
            var theme = ConfigurationManager.AppSettings["Theme"];
            var dictionary2 = new ResourceDictionary();
            theme = string.IsNullOrEmpty(theme) ? "Defualt": theme;
            dictionary2.Source = new Uri("Themes/" + theme + ".xaml", UriKind.Relative);
            Resources.MergedDictionaries[1] = dictionary2;
            new ViewModelLocator();
        }
    }
}
