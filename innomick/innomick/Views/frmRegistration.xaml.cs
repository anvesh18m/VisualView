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
            pickerContryCode.Items.Add("+91");
            pickerContryCode.Items.Add("+121");
            pickerContryCode.Items.Add("+123");
            pickerContryCode.Items.Add("+124");
            pickerContryCode.Items.Add("+125");
            pickerContryCode.SelectedIndex = 0;
        }

        private async void Registration_Clicked(object sender, EventArgs e)
        {
            string ss = (string)pickerContryCode.SelectedItem;
            App.Current.MainPage = new NavigationPage(new frmUserDetails());
            //if (string.IsNullOrEmpty(entryPassport.Text))
            //{
            //   await DisplayAlert(Constants.AppName, "Please enter passport number.", "OK");
            //    return;
            //}
            //if (string.IsNullOrEmpty(entryFirstName.Text))
            //{
            //    await DisplayAlert(Constants.AppName, "Please enter your first name.", "OK");
            //    return;
            //}
            //if (string.IsNullOrEmpty(entryLastName.Text))
            //{
            //    await DisplayAlert(Constants.AppName, "Please enter your last name.", "OK");
            //    return;
            //}
            //if (string.IsNullOrEmpty(entryEmail.Text))
            //{
            //    await DisplayAlert(Constants.AppName, "Please enter your Email ID.", "OK");
            //    return;
            //}
            //if (string.IsNullOrEmpty(entryPhone.Text))
            //{
            //    await DisplayAlert(Constants.AppName, "Please enter your phone number.", "OK");
            //    return;
            //}
            //UserDetails oUserDetails = new UserDetails()
            //{
            //    UserID = 1,
            //    FirstName = entryFirstName.Text,
            //    LastName = entryLastName.Text,
            //    Email = entryEmail.Text,
            //    CountryCode = (string)pickerContryCode.SelectedItem,
            //    Phone = entryPhone.Text
            //};
            //if (App.DAUtil.SaveUserDetails(oUserDetails) == 1)
            //{
            //    await DisplayAlert(Constants.AppName, "User details has beeen successfully saved.", "OK");

            //}
            //else
            //{
            //    await DisplayAlert("Sorry!", "Something went wrong", "OK");
            //}
        }
    }
}