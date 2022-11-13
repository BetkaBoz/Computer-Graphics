using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ComputerGraphics.Core;

namespace ComputerGraphics.MVVM.ViewModel
{
    class MainViewModel : ObservableObject, ICloseWindows
    {
        private object _currentView;
        private DelegateCommand _closeCommand;

        public DelegateCommand CloseCommand => _closeCommand ?? (_closeCommand = new DelegateCommand(CloseWindow));
        public Action Close { get; set; }

        public RelayCommand homeViewCommand { get; set; }
        public RelayCommand lecturesViewCommand { get; set; }
        public RelayCommand lectureOneViewCommand { get; set; }
        public RelayCommand lectureTwoViewCommand { get; set; }
        public RelayCommand lectureThreeViewCommand { get; set; }

        public HomeViewModel homeViewModel { get; set; }
        public LecturesViewModel lecturesViewModel { get; set; }
        public LectureOneViewModel lectureOneViewModel { get; set; }
        public LectureTwoViewModel lectureTwoViewModel { get; set; }
        public LectureThreeViewModel lectureThreeViewModel { get; set; }


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
            homeViewModel = new HomeViewModel();
            lecturesViewModel = new LecturesViewModel();
            lectureOneViewModel = new LectureOneViewModel();
            lectureTwoViewModel = new LectureTwoViewModel();
            lectureThreeViewModel = new LectureThreeViewModel();

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
        }

        private void CloseWindow(object obj)
        {
            Close?.Invoke();
        }
    }

    interface ICloseWindows
    {
        Action Close { get; set; }
    }
}
