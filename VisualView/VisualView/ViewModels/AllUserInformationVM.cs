using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using VisualView.Model;
using VisualView.Views;
using Xamarin.Forms;

namespace VisualView.ViewModels
{
    public class AllUserInformationVM : BaseClass
    {
        private UserDetails _selectedDetails;

        public UserDetails SelectedDetails
        {
            get { return _selectedDetails; }
            set { _selectedDetails = value; }
        }

        public ICommand ItemSelected { get; set; }

        public AllUserInformationVM()
        {
            ItemSelected = new Command(ItemSelectedEvent);
        }

        private void ItemSelectedEvent(object obj)
        {
            if (SelectedDetails != null)
            {
                App.NavPage.Navigation.PushAsync(new UserInformation(SelectedDetails));
            }
        }
    }
}
