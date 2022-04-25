using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows;
using MvvmClient.Services;
using System.Collections.Generic;
using MvvmClient.Models;

namespace MvvmClient.ViewModels
{
    public class LoginViewModel: INotifyPropertyChanged
    {

        private DelegateCommand _loginCommand;
        private string _login;
        private string _password;

        private void Auth(object obj)
        {
            try
            {
                var token = HttpRequestService.AuthOrRegister("https://localhost:44351/ToDo/Login", new Dictionary<string, string>
                {
                    ["login"] = Login,
                    ["password"] = Password
                });

                var mainWindow = new NotesListView(new ModelContainer { Token = token});
                mainWindow.Show();
                CloseRequest?.Invoke(this, new EventArgs());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка!");
            }
        }

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged("Login");
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        public event EventHandler CloseRequest;
        public DelegateCommand LoginComand
        {
            get
            {
                return _loginCommand ??
                  (_loginCommand = new DelegateCommand(Auth));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
