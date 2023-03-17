using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using ComputerGraphics.Core;
using ComputerGraphics.MVVM.Model;
using ComputerGraphics.MVVM.View;
using ComputerGraphics.Repositories;

namespace ComputerGraphics.MVVM.ViewModel
{
    class MainViewModel : ObservableObject, ICloseWindow
    {
        object _currentView;
        DelegateCommand _closeCommand;
        UserAccountModel _currentUserAccount;
        IUserRepository userRepository;

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
            LoadCurrentUserData();

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
        private void LoadCurrentUserData()
        {
            //var user = userRepository.GetByUserName(Thread.CurrentPrincipal.Identity.Name);
            //if (user != null)
            //{
            //    CurrentUserAccount.Username = user.UserName;
            //    CurrentUserAccount.DisplayName = $"Welcome {user.Name};)";
            //}
            //else
            //{
            //    CurrentUserAccount.DisplayName = "Invalid user, not logged in";
            //    //Hide child views.
            //}
        }
        private void CloseWindow(object obj)
        {
            Close?.Invoke();
        }
    }
}
