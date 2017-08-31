using System;

using Xamarin.Forms;

using Plugin.Analytics.CrossGoogleAnalytics;

namespace GASample
{
    public partial class FirstPage : ContentPage
    {
        public FirstPage ()
        {
            InitializeComponent ();
        }

        protected override void OnAppearing ()
        {
            base.OnAppearing ();

            CrossGoogleAnalytics.Current.TrackPage ("FirstPage");
        }

        async void OnButtonClicked (object sender, EventArgs args)
        {
            await Navigation.PushAsync (new SecondPage ());

            CrossGoogleAnalytics.Current.TrackEvent ("Button", "Click", "ButtonNavigateToSecondPage");
        }
    }
}