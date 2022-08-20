using SQLite;
using Xamarin.Forms;
using XamarinTutorial.Models;

namespace XamarinTutorial.Pages
{
    public partial class PostDetailsPage : ContentPage
    {
        Post _post = null;
        public PostDetailsPage()
        {
            InitializeComponent();
        }

        public PostDetailsPage(Post post) : this()
        {
            _post = post;
            experience.Text = post.Experience;
        }

        void updateButton_Clicked(System.Object sender, System.EventArgs e)
        {
            using(SQLiteConnection conn = new SQLiteConnection(App.Database))
            {
                _post.Experience = experience.Text;
                conn.CreateTable<Post>();
                var res = conn.Update(_post);
                if (res > 0)
                    DisplayAlert("Success", "Post has been updated", "Ok");
                else
                    DisplayAlert("Error", "Unable to update post", "Ok");
            }
        }

        void deleteButton_Clicked(System.Object sender, System.EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.Database))
            {
                _post.Experience = experience.Text;
                conn.CreateTable<Post>();
                var res = conn.Delete(_post);
                if (res > 0)
                    DisplayAlert("Success", "Post has been deleted", "Ok");
                else
                    DisplayAlert("Error", "Unable to delete post", "Ok");
            }
        }
    }
}

