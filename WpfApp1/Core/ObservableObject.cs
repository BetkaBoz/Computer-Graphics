using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ComputerGraphics.Core
{
    public class ObservableObject : INotifyPropertyChanged
    {
        private bool _isEnabled;

        public bool IsEnabled
        {
            get => _isEnabled; 
            set
            {
                if (_isEnabled != value)
                {
                    _isEnabled = value;
                    OnPropertyChanged(nameof(IsEnabled));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        //protected void OnPropertyChanged([CallerMemberName] string name = null)
        public void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
