using innomick.Models;
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
    public partial class frmUserDetails : ContentPage
    {
        public frmUserDetails()
        {
            InitializeComponent();
          
        }

        private void Update_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new frmEditAccount());
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            UserDetails OUserDetails = App.DAUtil.GetUserDetails(1);
            if (OUserDetails != null)
            {
                labelPassport.Text = ":" + OUserDetails.Passport;
                labelFirstName.Text = ":" + OUserDetails.FirstName;
                labelLastName.Text = ":" + OUserDetails.LastName;
                labelEmail.Text = ":" + OUserDetails.Email;
                labelPhone.Text = ":" + OUserDetails.CountryCode + " " + OUserDetails.Phone;
                labelUserName.Text = OUserDetails.FirstName + " " + OUserDetails.LastName;
                labelEmailID.Text = OUserDetails.Email;
                if (!string.IsNullOrEmpty(OUserDetails.UserProfile))
                {
                    byte[] bytesCamera = Convert.FromBase64String(OUserDetails.UserProfile);
                    imageUserProfile.Source = ImageSource.FromStream(() => new MemoryStream(bytesCamera));
                }
            }

        }
    }
}