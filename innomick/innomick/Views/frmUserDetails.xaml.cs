using innomick.Models;
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
    public partial class frmUserDetails : ContentPage
    {
        public frmUserDetails()
        {
            InitializeComponent();
            UserDetails OUserDetails = App.DAUtil.GetUserDetails(1);
            if (OUserDetails != null)
            {
                labelPassport.Text =":"+ OUserDetails.Passport;
                labelFirstName.Text = ":" + OUserDetails.FirstName;
                labelLastName.Text = ":" + OUserDetails.LastName;
                labelEmail.Text = ":" + OUserDetails.Email;
                labelPhone.Text = ":" + OUserDetails.CountryCode+" "+OUserDetails.Phone ;
                labelUserName.Text = OUserDetails.FirstName+" "+OUserDetails.LastName;
                labelEmailID.Text = OUserDetails.Email;

            }
        }

        private void Update_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new frmEditAccount());
        }
    }
}