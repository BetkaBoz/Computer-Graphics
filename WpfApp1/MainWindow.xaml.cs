using ComputerGraphics.Core;
using ComputerGraphics.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
    public partial class MainWindow : Window
    {
        MainViewModel viewModel = new();

        public List<RadioButton> lectureButtons = new();
        public MainWindow()
        {
            InitializeComponent();

            DataContext = viewModel;

            viewModel.LoadCurrentUserData();

            lectureButtons.Add(lecture2);
            lectureButtons.Add(lecture3);
            lectureButtons.Add(lecture4);
            lectureButtons.Add(lecture5);
            lectureButtons.Add(lecture6);
            lectureButtons.Add(lecture7);
            lectureButtons.Add(lecture8);

            lecture2.IsEnabled = false;
            lecture3.IsEnabled = false;
            lecture4.IsEnabled = false;
            lecture5.IsEnabled = false;
            lecture6.IsEnabled = false;
            lecture7.IsEnabled = false;
            lecture8.IsEnabled = false;

            //lecture2.Visibility = Visibility.Hidden;
            //lecture3.Visibility = Visibility.Hidden;
            //lecture4.Visibility = Visibility.Hidden;
            //lecture5.Visibility = Visibility.Hidden;
            //lecture6.Visibility = Visibility.Hidden;
            //lecture7.Visibility = Visibility.Hidden;
            //lecture8.Visibility = Visibility.Hidden;

            SetUpLectures();

            Loaded += MainWindow_Loaded;
        }

        public void SetUpLectures()
        {
            string lectureNum = viewModel.Lectures;
            switch (lectureNum)
                {
                    case "1":
                        break;
                    case "2":
                    lecture2.IsEnabled = true;
                    //lecture2.Visibility = Visibility.Visible;
                    break;
                    case "3":
                    lecture2.IsEnabled = true;
                    lecture3.IsEnabled = true;
                    //lecture2.Visibility = Visibility.Visible;
                    //lecture3.Visibility = Visibility.Visible;
                    break;
                    case "4":
                    lecture2.IsEnabled = true;
                    lecture3.IsEnabled = true;
                    lecture4.IsEnabled = true;
                    //lecture2.Visibility = Visibility.Visible;
                    //lecture3.Visibility = Visibility.Visible;
                    //lecture4.Visibility = Visibility.Visible;
                    break;
                    case "5":
                    lecture2.IsEnabled = true;
                    lecture3.IsEnabled = true;
                    lecture4.IsEnabled = true;
                    lecture5.IsEnabled = true;
                    //lecture2.Visibility = Visibility.Visible;
                    //    lecture3.Visibility = Visibility.Visible;
                    //    lecture4.Visibility = Visibility.Visible;
                    //    lecture5.Visibility = Visibility.Visible;
                    break;
                    case "6":
                    lecture2.IsEnabled = true;
                    lecture3.IsEnabled = true;
                    lecture4.IsEnabled = true;
                    lecture5.IsEnabled = true;
                    lecture6.IsEnabled = true;
                    //lecture2.Visibility = Visibility.Visible;
                    //    lecture3.Visibility = Visibility.Visible;
                    //    lecture4.Visibility = Visibility.Visible;
                    //    lecture5.Visibility = Visibility.Visible;
                    //    lecture6.Visibility = Visibility.Visible;
                        break;
                    case "7":
                    lecture2.IsEnabled = true;
                    lecture3.IsEnabled = true;
                    lecture4.IsEnabled = true;
                    lecture5.IsEnabled = true;
                    lecture6.IsEnabled = true;
                    lecture7.IsEnabled = true;
                    //lecture2.Visibility = Visibility.Visible;
                    //    lecture3.Visibility = Visibility.Visible;
                    //    lecture4.Visibility = Visibility.Visible;
                    //    lecture5.Visibility = Visibility.Visible;
                    //    lecture6.Visibility = Visibility.Visible;
                    //    lecture7.Visibility = Visibility.Visible;
                    break;
                    case "8":
                    lecture2.IsEnabled = true;
                    lecture3.IsEnabled = true;
                    lecture4.IsEnabled = true;
                    lecture5.IsEnabled = true;
                    lecture6.IsEnabled = true;
                    lecture7.IsEnabled = true;
                    lecture8.IsEnabled = true;
                    //lecture2.Visibility = Visibility.Visible;
                    //    lecture3.Visibility = Visibility.Visible;
                    //    lecture4.Visibility = Visibility.Visible;
                    //    lecture5.Visibility = Visibility.Visible;
                    //    lecture6.Visibility = Visibility.Visible;
                    //    lecture7.Visibility = Visibility.Visible;
                    //    lecture8.Visibility = Visibility.Visible;
                    break;
                    case "9":
                    lecture2.IsEnabled = true;
                    lecture3.IsEnabled = true;
                    lecture4.IsEnabled = true;
                    lecture5.IsEnabled = true;
                    lecture6.IsEnabled = true;
                    lecture7.IsEnabled = true;
                    lecture8.IsEnabled = true;
                    //lecture3.Visibility = Visibility.Visible;
                    //lecture4.Visibility = Visibility.Visible;
                    //lecture5.Visibility = Visibility.Visible;
                    //lecture6.Visibility = Visibility.Visible;
                    //lecture7.Visibility = Visibility.Visible;
                    //lecture8.Visibility = Visibility.Visible;
                    break;
                }
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

        private void lecture_Click(object sender, RoutedEventArgs e)
        {
            RadioButton button = sender as RadioButton;

            Debug.WriteLine($"is button enavled: {button.IsEnabled}");

        }
    }
}
