using ComputerGraphics.Core;
using ComputerGraphics.MVVM.Model;
using ComputerGraphics.Repositories;
using System.Net;
using System.Security.Principal;
using System.Threading;
using System.Windows.Input;
using ComputerGraphics.HelperScripts;
using System.Diagnostics;
using System;
using System.Data.SqlClient;

namespace ComputerGraphics.MVVM.ViewModel
{
    public class LoginViewModel : ObservableObject
    {
        string _userName;
        string _email;
        string _password;
        string _errorMessage;
        bool _isViewVisible = true;

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

        public bool IsViewVisible
        {
            get => _isViewVisible;
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand RegisterCommand { get; }

        public LoginViewModel()
        {
            userRepository = new UserRepository();
            LoginCommand = new DelegateCommand(ExecuteLoginCommand);
            RegisterCommand = new DelegateCommand(ExecuteRegisterCommand);
        }

        private void ExecuteRegisterCommand(object obj)
        {
            Debug.WriteLine("Prebieha registrácia");
            //userRepository.Add(new UserModel());

            using (SqlConnection connection = new SqlConnection("Server=laptop-7ukrdo46\\SQLExpress01; Database=CGDatabase; Integrated Security=true"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO [User] (UserName, Email, Password, Lecture) VALUES (@UserName, @Email, @Password, @Lecture)", connection);
                command.Parameters.AddWithValue("@UserName", UserName);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@Password", Password);
                command.Parameters.AddWithValue("@Lecture", "1");

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Debug.WriteLine("User registration successful.");
                    ExecuteLoginCommand(command);
                }
                else Debug.WriteLine("User registration failed.");
            }
        }

        private void ExecuteLoginCommand(object obj)
        {
            Debug.WriteLine("Prebieha prihlasovanie");

            var isValidUser = userRepository.AuthenticateUser(new System.Net.NetworkCredential(UserName, Password));

            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(UserName), null);
                IsViewVisible = false;
            }
            else ErrorMessage = "* Nesprávny email alebo heslo";
        }
    }
}
