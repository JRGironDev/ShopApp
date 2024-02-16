using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ShopApp
{
    public class BindingUtilObject : INotifyPropertyChanged
    {
        public void RaisePropertyChanged(
            [CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;

    }
}
