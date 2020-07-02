using innomick.Models;
using innomick.Utilities;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
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
        string base64 = string.Empty;
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
                if (!string.IsNullOrEmpty(OUserDetails.UserProfile))
                {
                    byte[] bytesCamera = Convert.FromBase64String(OUserDetails.UserProfile);
                    base64 = System.Convert.ToBase64String(bytesCamera);
                    imageUserProfile.Source = ImageSource.FromStream(() => new MemoryStream(bytesCamera));
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
            var result = await DisplayAlert(Constants.AppName, "Are you sure you want to submit?", "OK", "Cancel");
            if (!result)
            {
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
                Passport = entryPassport.Text,
            };
            if (!string.IsNullOrEmpty(base64))
            {
                objUserDetails.UserProfile = base64;
            }
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

        private async void ProfileUpdate_Tapped(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet(Utilities.Constants.AppName, "Cancel", null, "Camera", "Galary");
            switch (action)
            {
                case "Camera":
                    await CrossMedia.Current.Initialize();

                    if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                    {
                        await DisplayAlert("No Camera", ":( No camera available.", "OK");
                        return;
                    }

                    var fileCamera = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                    {
                        Directory = "Sample",
                        Name = "Innomick" + DateTime.Now + ".jpg",
                    });

                    if (fileCamera == null)
                        return;

                    byte[] bytesCamera = GetImageStreamAsBytes(fileCamera.GetStream());
                    base64 = System.Convert.ToBase64String(bytesCamera);
                    imageUserProfile.Source = ImageSource.FromStream(() => new MemoryStream(bytesCamera));

                    break;

                case "Galary":
                    await CrossMedia.Current.Initialize();

                    if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                    {
                        await DisplayAlert("No Camera", ":( No camera available.", "OK");
                        return;
                    }
                    var fileGalery = await CrossMedia.Current.PickPhotoAsync();
                    if (fileGalery == null)
                        return;

                    byte[] bytesGalery = GetImageStreamAsBytes(fileGalery.GetStream());
                    base64 = System.Convert.ToBase64String(bytesGalery);
                    imageUserProfile.Source = ImageSource.FromStream(() => new MemoryStream(bytesGalery));
                    break;
            }
        }
        private byte[] GetImageStreamAsBytes(Stream input)
        {
            //throw new NotImplementedException();
            var buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}