using System;
using Xamarin.Forms;

namespace otk
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        async void OnSetChallengeClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SetChallenge());
        }
    }
}