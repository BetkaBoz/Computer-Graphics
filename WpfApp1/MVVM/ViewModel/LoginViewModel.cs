using ComputerGraphics.Core;
using ComputerGraphics.MVVM.Model;
using ComputerGraphics.MVVM.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;
using WpfApp1;

namespace ComputerGraphics.MVVM.ViewModel
{
    public class LoginViewModel : ObservableObject
    {
        string _userName;
        string _email;
        string _password;
        string _errorMessage;
        bool _isSignedIn = false;

        IUserRepository userRepository;

        public string UserName 
        { 
            get => _userName;
            set {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string Password { 
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string ErrorMessage { 
            get => _errorMessage; 
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
            
        }

        public bool IsSignedIn
        {
            get => _isSignedIn;
            set
            {
                _isSignedIn = value;
                OnPropertyChanged(nameof(IsSignedIn));
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new DelegateCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new DelegateCommand(p => ExecuteRecoverPassCommand("", ""));
        }

        private void ExecuteRecoverPassCommand(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Email) || Email.Length < 3 ||
                Password == null || Password.Length < 3)
                validData = false;
            else
                validData = true;
            return validData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            var isValidUser = userRepository.AuthenticateUser(new NetworkCredential(UserName, Password));
            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(UserName), null);
                IsSignedIn = true;
                //LoginFrame.NavigationService.Navigate(new HomeView());
            }
            else
            {
                ErrorMessage = "* Nesprávny email alebo heslo";
            }
        }
    }
}
