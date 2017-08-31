using Xamarin.Forms;

using Plugin.Analytics.CrossGoogleAnalytics;

namespace GASample
{
    public partial class App : Application
    {
        public App ()
        {
            InitializeComponent ();

            CrossGoogleAnalytics.Current.Init (<Set your UA-ID here>);

            MainPage = new NavigationPage(new FirstPage ());
        }

        protected override void OnStart ()
        {
            // Handle when your app starts
        }

        protected override void OnSleep ()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume ()
        {
            // Handle when your app resumes
        }
    }
}