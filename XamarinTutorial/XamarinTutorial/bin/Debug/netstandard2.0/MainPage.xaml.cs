
using Xamarin.Forms;
using XamarinTutorial.Pages;

namespace XamarinTutorial
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            iconImage.Source = ImageSource.FromResource("XamarinTutorial.Assets.Images.plane.png", typeof(MainPage));
        }

        void LoginButton_Clicked_1(System.Object sender, System.EventArgs e)
        {
            bool isEmptyEmail = string.IsNullOrWhiteSpace(email.Text);
            bool isEmptyPassword = string.IsNullOrWhiteSpace(password.Text);

            if(isEmptyEmail || isEmptyPassword)
            {
                //donot navigae
                //DisplayAlert("Error", "Email or password is not corect", "");
            }
            else
            {
                //navigate
                Navigation.PushAsync(new HomePage());
            }
        }
    }
}

