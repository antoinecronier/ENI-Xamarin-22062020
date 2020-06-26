using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ENI_Xamarin_30032020.Models
{
    public class ErrorSwitch : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private bool isErrorVisible;
        private String errorText;
        private String errorColor;

        public bool IsErrorVisible
        {
            get { return isErrorVisible; }
            set
            {
                isErrorVisible = value;
                OnPropertyChanged("IsErrorVisible");
            }
        }

        public String ErrorText
        {
            get { return errorText; }
            set 
            { 
                errorText = value;
                OnPropertyChanged("ErrorText");
            }
        }

        public String ErrorColor
        {
            get { return errorColor; }
            set 
            { 
                errorColor = value;
                OnPropertyChanged("ErrorColor");
            }
        }
    }
}
