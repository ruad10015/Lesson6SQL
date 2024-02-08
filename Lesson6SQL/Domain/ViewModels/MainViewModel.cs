using Lesson6SQL.Command;
using Lesson6SQL.DataAcces.SqlServer;
using Lesson6SQL.Domain.Services;
using Lesson6SQL.Domain.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Lesson6SQL.Domain.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            LoginCommand = new RelayCommand(Login);
        }

        private string username;
        public string Username
        {
            get { return username; }
            set { username = value; OnPropertyChanged(); }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; private set; }

        private void Login()
        {
            if (Username == "admin" && Password == "admin")
            {
                var dataWindow = new DataWindow();
                dataWindow.Show();
                Application.Current.MainWindow.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }
    }
}
