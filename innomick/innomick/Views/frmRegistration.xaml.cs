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
    public partial class frmRegistration : ContentPage
    {
        public frmRegistration()
        {
            InitializeComponent();
            pickerContryCode.Items.Add("+91"); //India
            pickerContryCode.Items.Add("+1");  //USA
            pickerContryCode.Items.Add("+971"); //UAE
            pickerContryCode.Items.Add("+44"); //UK
            pickerContryCode.Items.Add("+94"); //Sri lanka
            pickerContryCode.SelectedIndex = 0;
        }

        private async void Registration_Clicked(object sender, EventArgs e)
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
            var result = await DisplayAlert(Constants.AppName, "Are you sure you want to submit?", "OK", "Cancel");
            if (!result)
            {
                return;
            }
            UserDetails oUserDetails = new UserDetails()
            {
                UserID = 1,
                FirstName = entryFirstName.Text,
                LastName = entryLastName.Text,
                Email = entryEmail.Text,
                CountryCode = (string)pickerContryCode.SelectedItem,
                Phone = entryPhone.Text,
                Passport = entryPassport.Text
            };
            if (App.DAUtil.SaveUserDetails(oUserDetails) == 1)
            {
                await DisplayAlert(Constants.AppName, "User details has beeen successfully saved.", "OK");
                App.Current.MainPage = new NavigationPage(new frmUserDetails());
            }
            else
            {
                await DisplayAlert("Sorry!", "Something went wrong", "OK");
            }
        }
    }
}