using System;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;
using XamarinTutorial.Models;

namespace XamarinTutorial.Pages
{
    public partial class HistoryPage : ContentPage
    {
        public HistoryPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.Database))
            {
                conn.CreateTable<Post>();
                var posts = conn.Table<Post>().ToList();
                travelListView.ItemsSource = posts;
            }
                
        }

        void travelListView_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var selectedItem = travelListView.SelectedItem as Post;
            Navigation.PushAsync(new PostDetailsPage(selectedItem));
        }
    }
}

