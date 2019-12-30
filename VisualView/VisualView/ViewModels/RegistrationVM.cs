using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using VisualView.Model;
using VisualView.Service;
using VisualView.Views;
using Xamarin.Forms;

namespace VisualView.ViewModels
{
    public class RegistrationVM : BaseClass
    {
        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged("FirstName");

            }
        }
        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
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

        public ICommand SubmitClick { get; set; }
        public ICommand BackClick { get; set; }
        public RegistrationVM()
        {
            SubmitClick = new Command(SubmitEvent);
            BackClick = new Command(BackEvent);
        }
        private void BackEvent(object obj)
        {
            App.Current.MainPage = new LoginPage();
        }

        private async void SubmitEvent(object obj)
        {
            Random r = new Random();
            int randNum = r.Next(1000000);
            string sixDigitNumber = randNum.ToString("D6");
            UserDetails objUserDetails = new UserDetails()
            {
                createdAt = DateTime.Now,
                fb_email = Email,
                fb_friends = null,
                fb_gender = Gender,
                fb_id = sixDigitNumber,
                fb_link = null,
                fb_name = FirstName + " " + LastName,
                fb_picture = null,
                install_id = null,
                qrm_memberOf = null,
                qrm_TxFamily = null,
                qrm_wallet = Mobile,
                stq_score = "6",
                updatedAt = DateTime.Now,
                user_os = Device.RuntimePlatform,
                _id = null
            };

            UserDetails oUserDetails = await PushService.SaveUserDetails(objUserDetails);
            if (oUserDetails != null)
            {
                if (!string.IsNullOrWhiteSpace(oUserDetails._id))
                {
                    MessagingCenter.Send<RegistrationVM>(this, "CallGetUserDetails");
                    await App.Current.MainPage.DisplayAlert(Genaral.Comman.AppName, "Your details has been submitted successfully", "OK");
                    Genaral.Comman.gSelectedUserDetails = Genaral.Comman.gUserDetails.Where(q => q.qrm_wallet == oUserDetails.qrm_wallet).FirstOrDefault();

                    App.NavPage = new NavigationPage(new AllUserInformation()) { BarBackgroundColor = Color.FromHex("#0EA3B7") };


                    App.Current.MainPage = new MasterDetailPage()
                    {
                        Master = new MasterPage() { Title = "Menu" },
                        Detail = App.NavPage
                    };
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert(Genaral.Comman.AppName, "Your details not submitted", "OK");
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert(Genaral.Comman.AppName, Genaral.Comman.ExceptionMessage, "OK");

            }
        }

    }
}
