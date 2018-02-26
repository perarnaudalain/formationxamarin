using Xamarin.Forms;

namespace deezerapp
{
    public partial class deezerappPage : ContentPage
    {
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            if(iddeezer.Text.Equals("")) {
                DisplayAlert("alert", "pas d'id deezer", "Ok");
            } else {
                DisplayAlert("alert", "mon id deezer : " + iddeezer.Text, "Ok");
            }
        }

        public deezerappPage()
        {
            InitializeComponent();
        }
    }
}
