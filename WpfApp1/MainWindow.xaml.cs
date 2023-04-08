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
        SolidColorBrush disableColor = new(Colors.LightGray);
        SolidColorBrush enableColor = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF424242");

        public List<RadioButton> lectureButtons = new();
        public MainWindow()
        {
            InitializeComponent();

            DataContext = viewModel;

            //viewModel.LoadCurrentUserData();

            lectureButtons.Add(lecture2);
            lectureButtons.Add(lecture3);
            lectureButtons.Add(lecture4);
            lectureButtons.Add(lecture5);
            lectureButtons.Add(lecture6);
            lectureButtons.Add(lecture7);
            lectureButtons.Add(lecture8);

            //lecture2.IsEnabled = false;
            //lecture3.IsEnabled = false;
            //lecture4.IsEnabled = false;
            //lecture5.IsEnabled = false;
            //lecture6.IsEnabled = false;
            //lecture7.IsEnabled = false;
            //lecture8.IsEnabled = false;

            lecture2.IsEnabled = true;
            lecture3.IsEnabled = true;
            lecture4.IsEnabled = true;
            lecture5.IsEnabled = true;
            lecture6.IsEnabled = true;
            lecture7.IsEnabled = true;
            lecture8.IsEnabled = true;

            //lecture2.Foreground = disableColor;
            //lecture3.Foreground = disableColor;
            //lecture4.Foreground = disableColor;
            //lecture5.Foreground = disableColor; 
            //lecture6.Foreground = disableColor;
            //lecture7.Foreground = disableColor;
            //lecture8.Foreground = disableColor;

            //SetUpLectures();

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

                    lecture2.Foreground = enableColor;
                    break;
                    case "3":
                    lecture2.IsEnabled = true;
                    lecture3.IsEnabled = true;

                    lecture2.Foreground = enableColor;
                    lecture3.Foreground = enableColor;
                    break;
                    case "4":
                    lecture2.IsEnabled = true;
                    lecture3.IsEnabled = true;
                    lecture4.IsEnabled = true;

                    lecture2.Foreground = enableColor;
                    lecture3.Foreground = enableColor;
                    lecture4.Foreground = enableColor;
                    break;
                    case "5":
                    lecture2.IsEnabled = true;
                    lecture3.IsEnabled = true;
                    lecture4.IsEnabled = true;
                    lecture5.IsEnabled = true;

                    lecture2.Foreground = enableColor;
                    lecture3.Foreground = enableColor;
                    lecture4.Foreground = enableColor;
                    lecture5.Foreground = enableColor;
                    break;
                    case "6":
                    lecture2.IsEnabled = true;
                    lecture3.IsEnabled = true;
                    lecture4.IsEnabled = true;
                    lecture5.IsEnabled = true;
                    lecture6.IsEnabled = true;

                    lecture2.Foreground = enableColor;
                    lecture3.Foreground = enableColor;
                    lecture4.Foreground = enableColor;
                    lecture5.Foreground = enableColor;
                    lecture6.Foreground = enableColor;
                    break;
                    case "7":
                    lecture2.IsEnabled = true;
                    lecture3.IsEnabled = true;
                    lecture4.IsEnabled = true;
                    lecture5.IsEnabled = true;
                    lecture6.IsEnabled = true;
                    lecture7.IsEnabled = true;

                    lecture2.Foreground = enableColor;
                    lecture3.Foreground = enableColor;
                    lecture4.Foreground = enableColor;
                    lecture5.Foreground = enableColor;
                    lecture6.Foreground = enableColor;
                    lecture7.Foreground = enableColor;
                    break;
                    case "8":
                    lecture2.IsEnabled = true;
                    lecture3.IsEnabled = true;
                    lecture4.IsEnabled = true;
                    lecture5.IsEnabled = true;
                    lecture6.IsEnabled = true;
                    lecture7.IsEnabled = true;
                    lecture8.IsEnabled = true;

                    lecture2.Foreground = enableColor;
                    lecture3.Foreground = enableColor;
                    lecture4.Foreground = enableColor;
                    lecture5.Foreground = enableColor;
                    lecture6.Foreground = enableColor;
                    lecture7.Foreground = enableColor;
                    lecture8.Foreground = enableColor;
                    break;
                    case "9":
                    lecture2.IsEnabled = true;
                    lecture3.IsEnabled = true;
                    lecture4.IsEnabled = true;
                    lecture5.IsEnabled = true;
                    lecture6.IsEnabled = true;
                    lecture7.IsEnabled = true;
                    lecture8.IsEnabled = true;

                    lecture2.Foreground = enableColor;
                    lecture3.Foreground = enableColor;
                    lecture4.Foreground = enableColor;
                    lecture5.Foreground = enableColor;
                    lecture6.Foreground = enableColor;
                    lecture7.Foreground = enableColor;
                    lecture8.Foreground = enableColor;
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
    }
}
