using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinTutorial
{
    public partial class App : Application
    {
        public static string Database = string.Empty;
        public App ()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public App(string databasePath) : this()
        {
            Database = databasePath;
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

