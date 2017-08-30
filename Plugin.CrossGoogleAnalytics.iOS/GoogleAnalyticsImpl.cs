using System;
using System.Diagnostics;

using Google.Analytics;

using Plugin.Analytics.CrossGoogleAnalytics.Abstractions;

namespace Plugin.Analytics.CrossGoogleAnalytics
{
    public class GoogleAnalyticsImpl : IGoogleAnalytics
    {
        public static ITracker Tracker;

        public GoogleAnalyticsImpl ()
        {
        }

        public void Init (string trackingId, int dispatchIntervalInSeconds)
        {
            //Set Tracker
            try {
                Gai.SharedInstance.DispatchInterval = dispatchIntervalInSeconds;
                Gai.SharedInstance.TrackUncaughtExceptions = true;

                Tracker = Gai.SharedInstance.GetTracker (trackingId);
            }
            catch (Exception ex) {
                Debug.WriteLine (ex.Message);
                throw new Exception ("Could not create Tracker");
            }
        }

        public void TrackEvent (string category, string action, string label)
        {
            if (Tracker == null) {
                throw new Exception ("You have to call CrossGoogleAnalytics.Current.Init (<your id>); before tracking an event");
            }

            Gai.SharedInstance.DefaultTracker.Send (DictionaryBuilder.CreateEvent (category, action, label, null).Build ());
        }

        public void TrackPage (string pageName)
        {
            if (Tracker == null) {
                throw new Exception ("You have to call CrossGoogleAnalytics.Current.Init (<your id>); before tracking a page");
            }

            Gai.SharedInstance.DefaultTracker.Set (GaiConstants.ScreenName, pageName);
            Gai.SharedInstance.DefaultTracker.Send (DictionaryBuilder.CreateScreenView ().Build ());
        }
    }
}