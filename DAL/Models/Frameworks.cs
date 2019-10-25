using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Framework
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public string ImageURL { get; set; }
        public static IEnumerable<Framework> GetFrameworks()
        {
            return new List<Framework>
            {
                new Framework{Id = 1, Name = "React", Language = "JS", ImageURL="https://hackernoon.com/hn-images/1*y6C4nSvy2Woe0m7bWEn4BA.png"},
                new Framework{Id = 2, Name = "Angular", Language = "JS", ImageURL="https://vegibit.com/wp-content/uploads/2018/11/AngularJS.png"},
                new Framework{Id = 3, Name = "Vue", Language = "JS", ImageURL="https://miro.medium.com/max/1200/1*-PlqbnwqjqJi_EVmrhmuDQ.jpeg"},
                new Framework{Id = 4, Name = "Flutter", Language = "Dart", ImageURL="https://upload.wikimedia.org/wikipedia/commons/1/17/Google-flutter-logo.png"},
            };
        }
    }
}
