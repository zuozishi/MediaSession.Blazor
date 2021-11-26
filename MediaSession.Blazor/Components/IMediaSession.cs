using MediaSession.Blazor.Components.Models;

namespace MediaSession.Blazor.Components;

/// <summary>
/// The MediaSession interface of the <see href="https://developer.mozilla.org/en-US/docs/Web/API/Media_Session_API">Media Session API</see> allows a web page to provide custom behaviors for standard media playback interactions, and to report metadata that can be sent by the user agent to the device or operating system for presentation in standardized user interface elements.
/// </summary>
public interface IMediaSession : IMediaSessionEvents
{
    ValueTask<bool> IsSupported();

    ValueTask<MediaMetadata> GetMetadata();

    Task SetPlaybackState(PlaybackState state);

    ValueTask<PlaybackState> GetPlaybackState();

    Task SetMediaMetadata(MediaMetadata metadata);

    Task SetPositionState(PositionState state);

    ValueTask<bool> IsDebugMode();

    Task SetDebugMode(bool mode);

    Task RequestPictureInPicture();

    Task ExitPictureInPicture();

    ValueTask<bool> IsPictureInPictureEnabled();
}