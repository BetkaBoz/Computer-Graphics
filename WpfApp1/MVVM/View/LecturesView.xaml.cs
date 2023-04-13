using ComputerGraphics.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace ComputerGraphics.MVVM.View
{
    public partial class IntroView : UserControl
    {
        MainViewModel viewModel = new();

        public IntroView()
        {
            InitializeComponent();

            DataContext = viewModel;

            viewModel.LoadCurrentUserData();

            SetUpChecks();
        }

        private void SetUpChecks()
        {
            string lectureNum = viewModel.Lectures;

            switch (lectureNum)
            {
                case "1":
                    break;
                case "2":
                    check_1.Visibility = Visibility.Visible;
                    break;
                case "3":
                    check_1.Visibility = Visibility.Visible;
                    check_2.Visibility = Visibility.Visible;
                    break;
                case "4":
                    check_1.Visibility = Visibility.Visible;
                    check_2.Visibility = Visibility.Visible;
                    check_3.Visibility = Visibility.Visible;
                    break;
                case "5":
                    check_1.Visibility = Visibility.Visible;
                    check_2.Visibility = Visibility.Visible;
                    check_3.Visibility = Visibility.Visible;
                    check_4.Visibility = Visibility.Visible;
                    break;
                case "6":
                    check_1.Visibility = Visibility.Visible;
                    check_2.Visibility = Visibility.Visible;
                    check_3.Visibility = Visibility.Visible;
                    check_4.Visibility = Visibility.Visible;
                    check_5.Visibility = Visibility.Visible;
                    break;
                case "7":
                    check_1.Visibility = Visibility.Visible;
                    check_2.Visibility = Visibility.Visible;
                    check_3.Visibility = Visibility.Visible;
                    check_4.Visibility = Visibility.Visible;
                    check_5.Visibility = Visibility.Visible;
                    check_6.Visibility = Visibility.Visible;
                    break;
                case "8":
                    check_1.Visibility = Visibility.Visible;
                    check_2.Visibility = Visibility.Visible;
                    check_3.Visibility = Visibility.Visible;
                    check_4.Visibility = Visibility.Visible;
                    check_5.Visibility = Visibility.Visible;
                    check_6.Visibility = Visibility.Visible;
                    check_7.Visibility = Visibility.Visible;
                    break;
                case "9":
                    check_1.Visibility = Visibility.Visible;
                    check_2.Visibility = Visibility.Visible;
                    check_3.Visibility = Visibility.Visible;
                    check_4.Visibility = Visibility.Visible;
                    check_5.Visibility = Visibility.Visible;
                    check_6.Visibility = Visibility.Visible;
                    check_7.Visibility = Visibility.Visible;
                    check_8.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }
        }
    }
}
