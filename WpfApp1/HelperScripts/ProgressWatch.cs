using ComputerGraphics.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1;

namespace ComputerGraphics.HelperScripts
{
    public static class ProgressWatch
    {
        static MainViewModel viewModel = new();
        static MainWindow mainWindow = new();

        public static bool IsProgress(bool check, int progressNumb)
        {
            int userLecture = Int32.Parse(viewModel.Lectures);

            if (check == true && userLecture < progressNumb)
            {
                string lectures = $"{progressNumb}";
                viewModel.SetLectures(lectures);

                return true;
            }
            else return false;
            return true;
        }
    }
}
