using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualView.Model;
using VisualView.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VisualView.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserInformation : ContentPage
    {
        public UserInformation(UserDetails oUserDetails)
        {
            InitializeComponent();
            this.BindingContext = new UserInformationVM(oUserDetails);
        }
    }
}