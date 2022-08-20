using System;
using System.Collections.Generic;
using System.Linq;
using Plugin.Geolocator;
using SQLite;
using Xamarin.Forms;
using XamarinTutorial.Logic;
using XamarinTutorial.Models;

namespace XamarinTutorial.Pages
{
    public partial class NewTravelPage : ContentPage
    {
        public NewTravelPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();
            Console.WriteLine("Getting places");
            var venues = await VenueLogic.GetVenues(position.Latitude, position.Longitude);
            venueListView.ItemsSource = venues.results;
            Console.WriteLine("Finished getting places");
        }

        void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {
            var selectedPlace = venueListView.SelectedItem as Result;
            var firstCategory = selectedPlace.categories.FirstOrDefault();
            var post = new Post
            {
                Experience = experience.Text,
                CategoryId = firstCategory.id,
                CategoryName = firstCategory.name,
                Address = selectedPlace.location.formatted_address,
                VenueName = selectedPlace.name,
                Distance = selectedPlace.distance,
                Latitude = selectedPlace.geocodes.main.latitude,
                Longitude = selectedPlace.geocodes.main.longitude 
            };

            SQLiteConnection connection = new SQLiteConnection(App.Database);
            connection.CreateTable<Post>();
            var ins = connection.Insert(post);
            if (ins > 0)
                DisplayAlert("Success", "Your experience has been added", "Ok");
            else
                DisplayAlert("Error", "Sorry, we could not save your experience", "Ok");
            connection.Close();
        }
    }
}

