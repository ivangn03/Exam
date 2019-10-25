using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    class FrameworkUIModel : INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private string _language;
        private string _imageURL;

        public int Id { get => _id; set { _id = value; Notify(); } }
        public string Name { get => _name; set { _name = value; Notify(); } }
        public string Language { get => _language; set { _language = value; Notify(); } }
        public string ImageURL { get => _imageURL; set { _imageURL = value; Notify(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void Notify([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
