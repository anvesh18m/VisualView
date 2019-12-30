using System;
using VisualView.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VisualView
{
    public partial class App : Application
    {
        public static NavigationPage NavPage;
        public App()
        {
            InitializeComponent();

            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
