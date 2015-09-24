using System.Collections.ObjectModel;

namespace MVVM.Model
{
    public class User:ObservableObject
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

        private int _age;

        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                RaisePropertyChanged("Age");
            }
        }

        public User(string name,int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public static ObservableCollection<User> GetUsers()
        {
            return new ObservableCollection<User>()
            {
                new User("hippieZhou",23),
                new User("小明",12),
                new User("老王",50)
            };
        }
    }
}
