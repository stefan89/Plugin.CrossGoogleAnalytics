## GoogleAnalytics Plugin voor Xamarin.Android, Xamarin.iOS and Xamarin.Forms

<br />
### Setup

Add the nuget package to your PCL project and the platform specific project(s) (Xamarin.iOS and/or Xamarin.Android).

<br />
<br />
**Platform Support**

|Platform|Supported|Version|
| ------------------- | :-----------: | :------------------: |
|Xamarin.iOS Unified|Yes|iOS 8+|
|Xamarin.Android|Yes|API 21+|

<br />
### API Usage

Before you can track an activity, you first need to call the initialise method once with the UA-ID of your project.

Here you can create an UA ID for your project: https://analytics.google.com

<br />
Initialise method:
```csharp
CrossGoogleAnalytics.Current.Init ("<UA ID of your project>");
```

<br />
Now you are ready to track a page view or event to the Google Analytics portal

<br />
Track page call:
```csharp
CrossGoogleAnalytics.Current.TrackPage ("<page name>");
```

<br />
Track event call:
```csharp
CrossGoogleAnalytics.Current.TrackEvent ("<category>", "<action>", "<label>");
```

<br />
### Releases

Current release: 1.0.0.4<br />
Release notes: initial version


<br />
### Contributors
v1.0.0.4 - Stefan Collette