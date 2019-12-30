using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using VisualView.Views;
using Xamarin.Forms;

namespace VisualView.ViewModels
{
    public class OTPValidationVM
    {
        private string _otp;

        public string OTP
        {
            get { return _otp; }
            set { _otp = value; }
        }
        public ICommand OTPClick { get; set; }
        public ICommand BackClick { get; set; }

        public OTPValidationVM()
        {
            OTPClick = new Command(OTPEvent);
            BackClick = new Command(BackEvent);
        }

        private void BackEvent(object obj)
        {
            App.Current.MainPage = new LoginPage();
        }

        private void OTPEvent(object obj)
        {

        }

    }
}
