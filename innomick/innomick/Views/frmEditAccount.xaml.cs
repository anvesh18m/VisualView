using innomick.Models;
using innomick.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace innomick.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class frmEditAccount : ContentPage
    {
        UserDetails OUserDetails = null;
        public frmEditAccount()
        {
            InitializeComponent();
            OUserDetails = App.DAUtil.GetUserDetails(1);
            if (OUserDetails != null)
            {
                entryPassport.Text = OUserDetails.Passport;
                entryFirstName.Text = OUserDetails.FirstName;
                entryLastName.Text = OUserDetails.LastName;
                entryEmail.Text = OUserDetails.Email;
                entryPhone.Text = OUserDetails.Phone;
                labelUserName.Text = OUserDetails.FirstName + " " + OUserDetails.LastName;
                labelEmailID.Text = OUserDetails.Email;

                pickerContryCode.Items.Add("+91"); //India
                pickerContryCode.Items.Add("+1");  //USA
                pickerContryCode.Items.Add("+971"); //UAE
                pickerContryCode.Items.Add("+44"); //UK
                pickerContryCode.Items.Add("+94"); //Sri lanka
                switch (OUserDetails.CountryCode)
                {
                    case "+91":
                        pickerContryCode.SelectedIndex = 0;
                        break;
                    case "+1":
                        pickerContryCode.SelectedIndex = 0;
                        break;
                    case "+971":
                        pickerContryCode.SelectedIndex = 0;
                        break;
                    case "+44":
                        pickerContryCode.SelectedIndex = 0;
                        break;
                    case "+94":
                        pickerContryCode.SelectedIndex = 0;
                        break;
                }


            }
        }

        private async void Update_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(entryPassport.Text))
            {
                await DisplayAlert(Constants.AppName, "Please enter passport number.", "OK");
                return;
            }
            if (string.IsNullOrEmpty(entryFirstName.Text))
            {
                await DisplayAlert(Constants.AppName, "Please enter your first name.", "OK");
                return;
            }
            if (string.IsNullOrEmpty(entryLastName.Text))
            {
                await DisplayAlert(Constants.AppName, "Please enter your last name.", "OK");
                return;
            }
            
            UserDetails objUserDetails = new UserDetails()
            {
                UserID = OUserDetails.UserID,
                FirstName = entryFirstName.Text,
                LastName = entryLastName.Text,
                Email = entryEmail.Text,
                CountryCode = (string)pickerContryCode.SelectedItem,
                Phone = entryPhone.Text,
                Passport = entryPassport.Text
            };
            if (App.DAUtil.UpdateUserDetails(objUserDetails) == 1)
            {
                await DisplayAlert(Constants.AppName, "User details has beeen successfully saved.", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Sorry!", "Something went wrong", "OK");
            }
        }

        private void BackButton_Tapped(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}