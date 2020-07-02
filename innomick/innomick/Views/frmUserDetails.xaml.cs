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
        }

        private void Update_Clicked(object sender, EventArgs e)
        {

        }
    }
}