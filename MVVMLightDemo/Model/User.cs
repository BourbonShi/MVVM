using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMLightDemo.Model
{
    public class User: ObservableObject
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }
        public User(string name)
        {
            this.Name = name;
        }
        public static ObservableCollection<User> GetUsers()
        {
            return new ObservableCollection<User>()
            {
                new User("1"),
                new User("2"),
                new User("3")
            };
        }


    }
}
