using System;
using System.Collections.Generic;

using Android.Content;
using Android.Gms.Analytics;

using Plugin.Analytics.CrossGoogleAnalytics.Abstractions;

namespace Plugin.Analytics.CrossGoogleAnalytics
{
    public class GoogleAnalyticsImpl : IGoogleAnalytics
    {
        static Tracker googleAnalyticsTracker;
        public static Context _context;

        public GoogleAnalyticsImpl ()
        {
        }

        public void Init (string trackingId, int dispatchIntervalInSeconds)
        {
            //Set context
            try {
                _context = Android.App.Application.Context;
            } catch (Exception){
                throw new Exception ("Could not load Android Context");
            }

            //Set Tracker
            try {
                googleAnalyticsTracker = Android.Gms.Analytics.GoogleAnalytics.GetInstance (_context).NewTracker (trackingId);
                Android.Gms.Analytics.GoogleAnalytics.GetInstance (_context).SetLocalDispatchPeriod (dispatchIntervalInSeconds);
            } 
            catch (Exception){
                throw new Exception ("Could not create Tracker");
            }
        }

        public void TrackEvent (string category, string action, string label)
        {
            if (googleAnalyticsTracker == null) {
                throw new Exception ("You have to call CrossGoogleAnalytics.Current.Init (<your id>); before tracking an event");
            }

            var eventBuilder = new HitBuilders.EventBuilder ().SetCategory (category).SetAction (action).SetLabel (label).Build ();
            var dataFromEventBuilder = new Dictionary<string, string> ();
            foreach (var key in eventBuilder.Keys) {
                dataFromEventBuilder.Add (key, eventBuilder [key]);
            }
            googleAnalyticsTracker.Send (dataFromEventBuilder);
        }

        public void TrackPage (string pageName)
        {
            if (googleAnalyticsTracker == null) {
                throw new Exception ("You have to call CrossGoogleAnalytics.Current.Init (<your id>); before tracking a page");
            }

            googleAnalyticsTracker.SetScreenName (pageName);

            var screenViewBuilder = new HitBuilders.ScreenViewBuilder ().Build ();
            var dataFromScreenViewBuilder = new Dictionary<string, string> ();
            foreach (var key in screenViewBuilder.Keys) {
                dataFromScreenViewBuilder.Add (key, screenViewBuilder [key]);
            }
            googleAnalyticsTracker.Send (dataFromScreenViewBuilder);
        }
    }
}