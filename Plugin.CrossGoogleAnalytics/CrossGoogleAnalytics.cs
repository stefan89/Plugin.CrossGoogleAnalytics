using System;
using System.Threading;
using System.Diagnostics;

using Plugin.Analytics.CrossGoogleAnalytics.Abstractions;

namespace Plugin.Analytics.CrossGoogleAnalytics
{
    public static class CrossGoogleAnalytics
    {
        static Lazy<IGoogleAnalytics> Implementation = new Lazy<IGoogleAnalytics> (() => CreateGoogleAnalyticsImpl (), LazyThreadSafetyMode.PublicationOnly);

        public static IGoogleAnalytics Current {
            get {
                var ret = Implementation.Value;
                if (ret == null) {
                    throw NotImplementedInReferenceAssembly ();
                }
                return ret;
            }
        }

        static IGoogleAnalytics CreateGoogleAnalyticsImpl ()
        {
            try {
#if PORTABLE
                return null;
#else
                return new GoogleAnalyticsImpl();
#endif
            }
            catch (Exception ex) {
                Debug.WriteLine (ex.Message);
                return null;
            }
        }

        internal static Exception NotImplementedInReferenceAssembly ()
        {
            return new NotImplementedException ("This functionality is not implemented in the portable version of this assembly.  You should reference the Plugin.CrossGoogleAnalytics NuGet package from your main application project in order to reference the platform-specific implementation.");
        }
    }
}