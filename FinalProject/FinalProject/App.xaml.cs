using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject
{
    public partial class App : Application
    {
        private static FinalDatabase database;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TabbedPage1());
        }

        public static FinalDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new FinalDatabase();
                }
                return database;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
