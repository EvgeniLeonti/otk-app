using System;
using Xamarin.Forms;

namespace otk
{
    public partial class Welcome : ContentPage
    {
        public Welcome()
        {
            InitializeComponent();
        }

        async void OnLoginClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

    }
}


