using Xamarin.Forms;

using Plugin.Analytics.CrossGoogleAnalytics;

namespace GASample
{
    public partial class SecondPage : ContentPage
    {
        public SecondPage ()
        {
            InitializeComponent ();
        }

        protected override void OnAppearing ()
        {
            base.OnAppearing ();
            
            CrossGoogleAnalytics.Current.TrackPage ("SecondPage");
        }
    }
}