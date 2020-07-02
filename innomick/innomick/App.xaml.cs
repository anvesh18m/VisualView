using innomick.DataBase;
using innomick.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace innomick
{
    public partial class App : Application
    {
        static DataAccess dbUtils;

        public App()
        {
            InitializeComponent();

            MainPage = new frmRegistration();
        }
        public static DataAccess DAUtil
        {
            get
            {
                if (dbUtils == null)
                {
                    dbUtils = new DataAccess(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Innomick.db3"));
                }
                return dbUtils;
            }
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
