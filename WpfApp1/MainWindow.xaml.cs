using ComputerGraphics.Core;
using ComputerGraphics.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        MainViewModel viewModel = new();
        public MainWindow()
        {
            InitializeComponent();

            DataContext = viewModel;

            viewModel.LoadCurrentUserData();

            

            SetUpLectures();

            Loaded += MainWindow_Loaded;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SetUpLectures()
        {
            string lectureNum = viewModel.Lectures;

            switch (lectureNum)
            {
                case "1":
                    break;
                case "2":
                    lecture2.Visibility = Visibility.Visible;
                    break;
                case "3":
                    lecture2.Visibility = Visibility.Visible;
                    lecture3.Visibility = Visibility.Visible;
                    break;
                case "4":
                    lecture2.Visibility = Visibility.Visible;
                    lecture3.Visibility = Visibility.Visible;
                    lecture4.Visibility = Visibility.Visible;
                    break;
                case "5":
                    lecture2.Visibility = Visibility.Visible;
                    lecture3.Visibility = Visibility.Visible;
                    lecture4.Visibility = Visibility.Visible;
                    lecture5.Visibility = Visibility.Visible;
                    break;
                case "6":
                    lecture2.Visibility = Visibility.Visible;
                    lecture3.Visibility = Visibility.Visible;
                    lecture4.Visibility = Visibility.Visible;
                    lecture5.Visibility = Visibility.Visible;
                    lecture6.Visibility = Visibility.Visible;
                    break;
                case "7":
                    lecture2.Visibility = Visibility.Visible;
                    lecture3.Visibility = Visibility.Visible;
                    lecture4.Visibility = Visibility.Visible;
                    lecture5.Visibility = Visibility.Visible;
                    lecture6.Visibility = Visibility.Visible;
                    lecture7.Visibility = Visibility.Visible;
                    break;
                case "8":
                    lecture2.Visibility = Visibility.Visible;
                    lecture3.Visibility = Visibility.Visible;
                    lecture4.Visibility = Visibility.Visible;
                    lecture5.Visibility = Visibility.Visible;
                    lecture6.Visibility = Visibility.Visible;
                    lecture7.Visibility = Visibility.Visible;
                    lecture8.Visibility = Visibility.Visible;
                    break;
                case "9":
                    lecture2.Visibility = Visibility.Visible;
                    lecture3.Visibility = Visibility.Visible;
                    lecture4.Visibility = Visibility.Visible;
                    lecture5.Visibility = Visibility.Visible;
                    lecture6.Visibility = Visibility.Visible;
                    lecture7.Visibility = Visibility.Visible;
                    lecture8.Visibility = Visibility.Visible;
                    break;
            }
            lecturesLV.Items.Refresh();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is ICloseWindow vm)
            {
                vm.Close += () =>
                {
                    this.Close();
                };
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }
    }
}
