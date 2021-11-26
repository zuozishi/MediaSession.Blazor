# MediaSession.Blazor

A Blazor JSInterop wrapper for [Media Session API](https://developer.mozilla.org/en-US/docs/Web/API/Media_Session_API).

[![NuGet: MediaSession.Blazor](https://buildstats.info/nuget/MediaSession.Blazor)](https://www.nuget.org/packages/MediaSession.Blazor)

> The Media Session API provides a way to customize media notifications. It does this by providing metadata for display by the user agent for the media your web app is playing.

> It also provides action handlers that the browser can use to access platform media keys such as hardware keys found on keyboards, headsets, remote controls, and software keys found in notification areas and on lock screens of mobile devices. So you can seamlessly control web-provided media via your device, even when not looking at the web page.

![edge_windows](https://raw.githubusercontent.com/Zuozishi/MediaSession.Blazor/master/resources/edge_windows.png"edge_windows")

![chrome](https://raw.githubusercontent.com/Zuozishi/MediaSession.Blazor/master/resources/chrome.jpg"chrome")

## Live Demo

[https://zuozishi.github.io/MediaSession.Blazor/](https://zuozishi.github.io/MediaSession.Blazor/)

## Usage

### Install the NuGet

```powershell
PM> Install-Package MediaSession.Blazor
```

### Add the required dependency injections

``` cs
builder.Services.AddScoped<IMediaSession, MediaSession.Blazor.Components.MediaSession>();
```

### Inject services

```diff
@page "/example"
@using Howler.Blazor.Components

+ @inject IMediaSession MediaSession
```

### Methods

```cs
// Check browser is or not support MediaSession API.
var isSupport = await MediaSession.IsSupported();

// Set the current media session is playing or paused.
// PlaybackState.None | PlaybackState.Playing | PlaybackState.Paused
await MediaSession.SetPlaybackState(PlaybackState.Playing);

// Get the current media session state.
var state = await MediaSession.GetPlaybackState();

/// Set the current media session metadata.
await MediaSession.SetMediaMetadata(new MediaMetadata{
    Title = "audio title",
    Artist = "artist",
    Album = "album name",
    Artwork = new MediaArtwork[]
    {
        new()
        {
            Src = "https://sample.com/cover.jpg",
            Sizes = new MediaArtworkSize(128),
            Type = "image/jpeg"
        }
    }
});

/// Get the current media session metadata.
var mediaMetadata = await MediaSession.GetMediaMetadata();

// Set the playback position and speed of the playing media.
await MediaSession.SetPositionState(new PositionState{
    Duration = mediaTotalTimeSpan.TotalSeconds,
    PlaybackRate = 1,
    Position = mediaCurrentTimeSpan.TotalSeconds
});

// Set debug mode switch.
// When debugMode = true, will log same info to console.
var isDebugMode = IsDebugMode();
await SetDebugMode(true);
```

### Subscribe Envents

```cs
MediaSession.OnMediaSessionAction += (s, e) =>
{
    switch (e.Action)
    {
        case MediaSessionActionTypes.Play:
            player.Play();
            break;
        case MediaSessionActionTypes.Pause:
            player.Pause();
            break;
        case MediaSessionActionTypes.Stop:
            player.Stop();
            break;
        case MediaSessionActionTypes.PreviousTrack:
            playlist.MovePrevious();
            break;
        case MediaSessionActionTypes.NextTrack:
            playlist.MoveNext();
            break;
        case MediaSessionActionTypes.SeekBackward:
            break;
        case MediaSessionActionTypes.SeekForward:
            break;
        case MediaSessionActionTypes.SeekTo:
            player.Seek(TimeSpan.FromSeconds(e.SeekTime.Value));
            break;
        case MediaSessionActionTypes.Skipad:
            break;
        default:
            break;
    }
};
```
