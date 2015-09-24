using MVVM.Model;
using System;
using System.Collections.ObjectModel;

namespace MVVM.ViewModel
{
    public class MainPageViewModel : ObservableObject
    {
        private ObservableCollection<User> _users;
        public ObservableCollection<User> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                RaisePropertyChanged("Users");
            }
        }

        private DelegateCommand _addCommand;
        public DelegateCommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new DelegateCommand
                  ((Object obj) =>
                  {
                      this.Users.Add(new User(DateTime.Now.ToString(),DateTime.Now.Hour));
                      this._addCommand.RaiseCanExecuteChanged();
                      this._delCommand.RaiseCanExecuteChanged();
                  },
                  (Object obj) => this.Users.Count < 5));
            }
        }

        private DelegateCommand _delCommand;
        public DelegateCommand DelCommand
        {
            get
            {
                return _delCommand ?? (_delCommand =
                  new DelegateCommand((Object obj) =>
                  {
                      this.Users.RemoveAt(0);
                      this._addCommand.RaiseCanExecuteChanged();
                      this._delCommand.RaiseCanExecuteChanged();
                  },
                  (Object obj) => this.Users.Count > 1));
            }
        }

        private DelegateCommand _showDialog;
        public DelegateCommand ShowDialog
        {
            get
            {
                return _showDialog ?? (_showDialog= new DelegateCommand(
                    async (Object obj) =>
                    {
                        await new Windows.UI.Popups.MessageDialog(obj.ToString()).ShowAsync();
                    },
                    (Object obj) => true));
            }
        }

        public MainPageViewModel()
        {
            this.Users = User.GetUsers();
        }


    }
}
