using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace VisualView.ViewModels
{
    public class BaseClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string PropertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(PropertyName));
        }


    }
}
