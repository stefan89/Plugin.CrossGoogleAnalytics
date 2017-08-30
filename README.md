## GoogleAnalytics Plugin voor Xamarin.Android, Xamarin.iOS and Xamarin.Forms

### Setup

Add the nuget package to your PCL project and the platform specific project(s) (Xamarin.iOS and/or Xamarin.Android).

**Platform Support**

|Platform|Supported|Version|
| ------------------- | :-----------: | :------------------: |
|Xamarin.iOS Unified|Yes|iOS 8+|
|Xamarin.Android|Yes|API 21+|


### API Usage

Before you can track an activity, you first need to call the initialise method once with the UA-ID of your project.

Here you can create an UA ID for your project: https://analytics.google.com


Initialise method:
```c#
CrossGoogleAnalytics.Current.Init ("<UA ID of your project>");
```


Now you are ready to track a page view or event to the Google Analytics portal


Track page call:
```c#
CrossGoogleAnalytics.Current.TrackPage ("<page name>");
```


Track event call:
```c#
CrossGoogleAnalytics.Current.TrackEvent ("<category>", "<action>", "<label>");
```


### Releases

Current release: 1.0.0.5<br />
Release notes: initial version



### Contributors
v1.0.0.5 - Stefan Collette