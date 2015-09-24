using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MVVMLightDemo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace MVVMLightDemo.ViewModel
{
    class MainPageViewModel:ViewModelBase
    {
        private ObservableCollection<User> _user;

        public ObservableCollection<User> Users
        {
            get { return _user; }
            set
            {
                _user = value;
                RaisePropertyChanged("Users");
            }
        }


        /// <summary>
        /// 快捷键mvvmrelaycanexecute
        /// </summary>

        #region Command

        private RelayCommand _addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand= new RelayCommand
                  (() =>
                  {
                      this.Users.Add(new User(DateTime.Now.ToString()));
                      this.AddCommand.RaiseCanExecuteChanged();
                      this.DelCommand.RaiseCanExecuteChanged();
                  },
                  () => this.Users.Count < 5));
            }
        }

        private RelayCommand _delCommand;
        public RelayCommand DelCommand
        {
            get
            {
                return _delCommand ?? (_delCommand =
                  new RelayCommand(() => 
                  {
                      this.Users.RemoveAt(0);
                      this.AddCommand.RaiseCanExecuteChanged();
                      this.DelCommand.RaiseCanExecuteChanged();
                  },
                  () => this.Users.Count > 1));
            }
        }

        private RelayCommand _showDialog;

        /// <summary>
        /// Gets the ShowDialog.
        /// </summary>
        public RelayCommand ShowDialog
        {
            get
            {
                return _showDialog
                    ?? (_showDialog = new RelayCommand(
                        async () =>
                    {
                        await new MessageDialog("test").ShowAsync();
                    },
                    () => true));
            }
        }

        #endregion

        public MainPageViewModel()
        {
            this.Users = User.GetUsers();
        }

    }
}
