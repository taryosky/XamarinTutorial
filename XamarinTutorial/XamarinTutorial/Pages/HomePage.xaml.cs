using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinTutorial.Pages
{
    public partial class HomePage : TabbedPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        void AddTravel_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new NewTravelPage());
        }
    }
}

