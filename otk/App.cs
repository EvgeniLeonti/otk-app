using System;
using Xamarin.Forms;

namespace otk
{
    public partial class App : Application
    {
        public static NavigationPage Navigation = null;

        public App()
        {
            // We have to have this here to stop 'Application.Resources StaticResource not found for key error'
            InitializeComponent();

            Navigation = new NavigationPage(new Welcome());
            Application.Current.MainPage = Navigation;
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

        // Called by the back button in our header/navigation bar.
        public async void OnBackButtonPressed(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}