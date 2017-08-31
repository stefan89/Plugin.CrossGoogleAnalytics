using Android.OS;
using Android.App;
using Android.Content.PM;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace GASample.Droid
{
    [Activity (Label = "GASample.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate (Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate (savedInstanceState);

            Forms.Init (this, savedInstanceState);

            LoadApplication (new App ());
        }
    }
}