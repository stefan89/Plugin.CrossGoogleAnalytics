namespace Plugin.Analytics.CrossGoogleAnalytics.Abstractions
{
    public interface IGoogleAnalytics
    {
        void Init(string trackingId, int dispatchIntervalInSeconds = 20);

        void TrackPage(string pageName);

        void TrackEvent(string category, string action, string label = "");
    }
}