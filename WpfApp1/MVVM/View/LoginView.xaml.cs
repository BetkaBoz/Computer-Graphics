using ComputerGraphics.HelperScripts;
using ComputerGraphics.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public partial class LoginView : UserControl
    {
        string? stackName;
        public LoginView()
        {
            InitializeComponent();
        }

        private void SwitchStackPanel(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            stackName = textBlock.Name;

            switch (stackName)
            {
                case "registerText":
                    loginUser.Visibility = Visibility.Hidden;
                    registerUser.Visibility = Visibility.Visible;
                    break;
                case "loginText":
                    registerUser.Visibility = Visibility.Hidden;
                    loginUser.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }
        }

        private void Register(object sender, RoutedEventArgs e)
        {
             
        }

        private void Login(object sender, RoutedEventArgs e)
        {

        }
    }
}
