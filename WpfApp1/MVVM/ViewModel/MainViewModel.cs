using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Xml.Serialization;
using ComputerGraphics.Core;
using ComputerGraphics.MVVM.Model;
using ComputerGraphics.MVVM.View;
using ComputerGraphics.Repositories;
using MaterialDesignThemes.Wpf;
using WpfApp1;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace ComputerGraphics.MVVM.ViewModel
{
    class MainViewModel : ObservableObject, ICloseWindow
    {
        string _lectures;
        string _userName;
        string _email;
        ObservableCollection<ObservableObject> _dataItems = new();
        Visibility _buttonVisibility;
        object _currentView;
        DelegateCommand _closeCommand;
        UserAccountModel _currentUserAccount;
        IUserRepository userRepository;

        public string Lectures
        {
            get => _lectures;
            set
            {
                _lectures = value;
                OnPropertyChanged(nameof(Lectures));
            }
        }

        public string UserName
        {
            get => _userName;
            set
            {
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

        public Visibility ButtonVisibility
        {
            get => _buttonVisibility;
            set
            {
                _buttonVisibility = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ObservableObject> DataItems
        {
            get { return _dataItems; }
            set
            {
                _dataItems = value;
                OnPropertyChanged(nameof(DataItems));
            }
        }

        public ICommand VisibleCommand { get; }

        public UserAccountModel CurrentUserAccount
        {
            get => _currentUserAccount;
            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }

        public DelegateCommand CloseCommand => _closeCommand ?? (_closeCommand = new DelegateCommand(CloseWindow));

        public Action Close { get; set; }

        public RelayCommand homeViewCommand { get; set; }
        public RelayCommand lecturesViewCommand { get; set; }
        public RelayCommand lectureOneViewCommand { get; set; }
        public RelayCommand lectureTwoViewCommand { get; set; }
        public RelayCommand lectureThreeViewCommand { get; set; }
        public RelayCommand lectureFourViewCommand { get; set; }
        public RelayCommand lectureFiveViewCommand { get; set; }
        public RelayCommand lectureSixViewCommand { get; set; }
        public RelayCommand lectureSevenViewCommand { get; set; }
        public RelayCommand lectureEightViewCommand { get; set; }
        public RelayCommand loginViewCommand { get; set; }

        public HomeViewModel homeViewModel { get; set; }
        public LecturesViewModel lecturesViewModel { get; set; }
        public LectureOneViewModel lectureOneViewModel { get; set; }
        public LectureTwoViewModel lectureTwoViewModel { get; set; }
        public LectureThreeViewModel lectureThreeViewModel { get; set; }
        public LectureFourViewModel lectureFourViewModel { get; set; }
        public LectureFiveViewModel lectureFiveViewModel { get; set; }
        public LectureSixViewModel lectureSixViewModel { get; set; }
        public LectureSevenViewModel lectureSevenViewModel { get; set; }
        public LectureEightViewModel lectureEightViewModel { get; set; }
        public LoginViewModel loginViewModel { get; set; }

        public object CurrentView
        {
            get { return _currentView; }
            set 
            { 
                _currentView = value; 
                OnPropertyChanged();
            } 
        }

        public MainViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();

            //LoadCurrentUserData();

            homeViewModel = new HomeViewModel();
            lecturesViewModel = new LecturesViewModel();
            lectureOneViewModel = new LectureOneViewModel();
            lectureTwoViewModel = new LectureTwoViewModel();
            lectureThreeViewModel = new LectureThreeViewModel();
            lectureFourViewModel = new LectureFourViewModel();  
            lectureFiveViewModel = new LectureFiveViewModel();
            lectureSixViewModel = new LectureSixViewModel();
            lectureSevenViewModel = new LectureSevenViewModel();
            lectureEightViewModel = new LectureEightViewModel();
            loginViewModel = new LoginViewModel();

            CurrentView = homeViewModel;

            homeViewCommand = new RelayCommand(o =>
            {
                CurrentView = homeViewModel;
            });

            lecturesViewCommand = new RelayCommand(o =>
            {
                CurrentView = lecturesViewModel;
            });

            lectureOneViewCommand = new RelayCommand(o =>
            {
                CurrentView = lectureOneViewModel;
            });

            lectureTwoViewCommand = new RelayCommand(o =>
            {
                CurrentView = lectureTwoViewModel;
            });

            lectureThreeViewCommand = new RelayCommand(o =>
            {
                CurrentView = lectureThreeViewModel;
            });

            lectureFourViewCommand = new RelayCommand(o =>
            {
                CurrentView= lectureFourViewModel;
            });

            lectureFiveViewCommand = new RelayCommand(o =>
            {
                CurrentView = lectureFiveViewModel;
            });

            lectureSixViewCommand = new RelayCommand(o =>
            {
                CurrentView = lectureSixViewModel;
            });

            lectureSevenViewCommand = new RelayCommand(o =>
            {
                CurrentView = lectureSevenViewModel;
            });

            lectureEightViewCommand = new RelayCommand(o =>
            {
                CurrentView = lectureEightViewModel;
            });

            loginViewCommand = new RelayCommand(o =>
            {
                CurrentView = loginViewModel;
            });
        }

        public void LoadCurrentUserData()
        {
            var user = userRepository.GetByUserName(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                CurrentUserAccount.Email = $"{user.Email}";
                CurrentUserAccount.Lecture = user.Lecture;
                Lectures = user.Lecture;
            }
        }

        public void SetLectures(string lectures)
        {
            var user = userRepository.GetByUserName(Thread.CurrentPrincipal.Identity.Name);
            Lectures = lectures;

            if (user != null)
            {
                using (SqlConnection connection = new SqlConnection("Server=laptop-7ukrdo46\\SQLExpress01; Database=CGDatabase; Integrated Security=true"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("UPDATE [User] SET Lecture=@Lecture WHERE UserName=@UserName", connection);
                    command.Parameters.AddWithValue("@Lecture", Lectures);
                    command.Parameters.AddWithValue("@UserName", user.UserName); ;

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0) Debug.WriteLine("User edit successful.");
                    else Debug.WriteLine("User edit failed.");
                }
            }
            Application.Current.Dispatcher.Invoke(() =>
            {
                MainWindow main = new();
                for (int i = 1; i <= Int32.Parse(Lectures); i++)
                {
                    foreach (var child in main.lectureButtons)
                    {
                        if (child.Name == $"lecture{i}")
                        {
                            Debug.WriteLine("is the name");
                            child.IsEnabled = true;
                        }
                    }
                }
            });
        }

        private void CloseWindow(object obj)
        {
            Close?.Invoke();
        }
    }
}
