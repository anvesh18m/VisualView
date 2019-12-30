using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using VisualView.Model;
using VisualView.Views;
using Xamarin.Forms;

namespace VisualView.ViewModels
{
    public class MasterPageVM : BaseClass
    {
        private List<MenuItems> _listMenuItem;

        public List<MenuItems> ListMenuItems
        {
            get { return _listMenuItem; }
            set { _listMenuItem = value; }
        }
        private MenuItems _selectedMenuItem;

        public MenuItems SelectedMenuItem
        {
            get { return _selectedMenuItem; }
            set
            {
                _selectedMenuItem = value;
                OnPropertyChanged("SelectedMenuItem");
            }
        }


        public ICommand SelectItem { get; set; }
        public MasterPageVM()
        {
            ListMenuItems = new List<MenuItems>();
            ListMenuItems.Add(new MenuItems() { ImageName = "MenuProfile.png", Name = "User Profile" });
            ListMenuItems.Add(new MenuItems() { ImageName = "MenuEditProfile.png", Name = "Edit Profile" });
            ListMenuItems.Add(new MenuItems() { ImageName = "MenuLogout.png", Name = "Logout" });

            SelectItem = new Command(SelectItemEvent);

        }

        private async void SelectItemEvent(object obj)
        {
            //var varMenuItem = (((ListView)sender).SelectedItem as MenuItems).ItemName;
            NavigationPage NP = ((NavigationPage)((MasterDetailPage)App.Current.MainPage).Detail);
            App.NavPage = NP;
            MasterDetailPage MasterPage = ((MasterDetailPage)App.Current.MainPage);
            switch (SelectedMenuItem.Name)
            {
                case "Home":
                    //MasterPage.IsPresented = false;
                    //  App.Current.MainPage = new NavigationPage(new frmDashBoard("frmMenu")) { BarBackgroundColor = Color.FromHex("#555253") };
                    break;
                case "User Profile":

                    MasterPage.IsPresented = false;
                    await App.NavPage.PushAsync(new UserInformation(Genaral.Comman.gSelectedUserDetails));
                    break;
                case "Edit Profile":

                    MasterPage.IsPresented = false;
                    await App.NavPage.PushAsync(new EditUserDetails());
                    break;
                case "Logout":

                    MasterPage.IsPresented = false;
                    App.Current.MainPage = new LoginPage();
                    break;


                default:

                    break;
            }
            SelectedMenuItem = null;
        }
    }
}
