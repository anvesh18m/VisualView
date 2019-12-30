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
    public class LoginPageVM : BaseClass
    {
        private string _mobile;

        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }


        public ICommand SubmitClick { get; set; }
        public LoginPageVM()
        {
            SubmitClick = new Command(SubmitEvent);
            GetUserDetails();
            MessagingCenter.Subscribe<EditUserDetailsVM>(this, "CallGetUserDetails", (sender) =>
            {
                GetUserDetails();
            });
            MessagingCenter.Subscribe<RegistrationVM>(this, "CallGetUserDetails", (sender) =>
            {
                GetUserDetails();
            });

        }

        private async void GetUserDetails()
        {
            UserDetails[] colUserDetails = await PushService.GetUserDetails();
            if (colUserDetails != null)
            {
                if (colUserDetails.Length > 0)
                {
                    Genaral.Comman.gUserDetails = new System.Collections.ObjectModel.ObservableCollection<UserDetails>(colUserDetails);
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert(Genaral.Comman.AppName, "User details not found", "OK");
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert(Genaral.Comman.AppName, Genaral.Comman.ExceptionMessage, "OK");
            }
        }

        private async void SubmitEvent(object obj)
        {
            if (string.IsNullOrWhiteSpace(Mobile))
            {
                await App.Current.MainPage.DisplayAlert(Genaral.Comman.AppName, "Please enter your Mobile number", "OK");
                return;
            }
            if (Genaral.Comman.gUserDetails != null)
            {

                if (Genaral.Comman.gUserDetails.Any(q => q.qrm_wallet == Mobile))
                {
                    //App.Current.MainPage = new OTPValidation();
                    Genaral.Comman.gSelectedUserDetails = Genaral.Comman.gUserDetails.Where(q => q.qrm_wallet == Mobile).FirstOrDefault();

                    App.NavPage = new NavigationPage(new AllUserInformation()) { BarBackgroundColor = Color.FromHex("#0EA3B7") };


                    App.Current.MainPage = new MasterDetailPage()
                    {
                        Master = new MasterPage() { Title = "Menu" },
                        Detail = App.NavPage
                    };
                }
                else
                {
                    App.Current.MainPage = new Registration();
                }
            }

        }
    }
}
