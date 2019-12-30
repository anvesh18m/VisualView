using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using VisualView.Model;
using VisualView.Service;
using Xamarin.Forms;

namespace VisualView.ViewModels
{
    public class EditUserDetailsVM : BaseClass
    {
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged("UserName");

            }
        }
        private string _mobile;

        public string Mobile
        {
            get { return _mobile; }
            set
            {
                _mobile = value;
                OnPropertyChanged("Mobile");
            }
        }
        private string _email;

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");

            }
        }
        private string _gender;

        public string Gender
        {
            get { return _gender; }
            set
            {
                _gender = value;
                OnPropertyChanged("Gender");
            }
        }
        private bool _IsBusy;

        public bool IsBusy
        {
            get { return _IsBusy; }
            set
            {
                _IsBusy = value;
                OnPropertyChanged("IsBusy");
            }
        }

        public ICommand UpdateClick { get; set; }

        public EditUserDetailsVM()
        {
            IsBusy = false;
            UserName = Genaral.Comman.gSelectedUserDetails.fb_name;
            Mobile = Genaral.Comman.gSelectedUserDetails.qrm_wallet;
            Email = Genaral.Comman.gSelectedUserDetails.fb_email;
            Gender = Genaral.Comman.gSelectedUserDetails.fb_gender;
            UpdateClick = new Command(UpdateEvent);

        }

        private async void UpdateEvent(object obj)
        {
            IsBusy = true;
            Genaral.Comman.gSelectedUserDetails.fb_name = UserName;
            Genaral.Comman.gSelectedUserDetails.qrm_wallet = Mobile;
            Genaral.Comman.gSelectedUserDetails.fb_email = Email;
            Genaral.Comman.gSelectedUserDetails.fb_gender = Gender;
            Genaral.Comman.gSelectedUserDetails.updatedAt = DateTime.Now;
            if (Device.RuntimePlatform == Device.Android)
            {
                Genaral.Comman.gSelectedUserDetails.user_os = "Android";
            }
            else if (Device.RuntimePlatform == Device.iOS)
            {
                Genaral.Comman.gSelectedUserDetails.user_os = "IOS";
            }

            UserDetails oUserDetails = await PushService.UpdateUserDetails(Genaral.Comman.gSelectedUserDetails);
            if (oUserDetails != null)
            {
                MessagingCenter.Send<EditUserDetailsVM>(this, "CallGetUserDetails");
                Genaral.Comman.gSelectedUserDetails = Genaral.Comman.gUserDetails.Where(q => q.qrm_wallet == oUserDetails.qrm_wallet).FirstOrDefault();
                await App.Current.MainPage.DisplayAlert(Genaral.Comman.AppName, "Your details has been updated successfully", "OK");
                await App.NavPage.PopAsync();
                return;
            }
            else
            {
                IsBusy = true;
                await App.Current.MainPage.DisplayAlert(Genaral.Comman.AppName, Genaral.Comman.ExceptionMessage, "OK");

            }
        }
    }
}
