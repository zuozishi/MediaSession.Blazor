using MediaSession.Blazor.Components.Events;

namespace MediaSession.Blazor.Components;

public interface IMediaSessionEvents
{
    /// <summary>
    /// Sets a handler for a media session action.
    /// <para>These actions let a web app receive notifications when the user engages a device's built-in physical or onscreen media controls, such as play, stop, or seek buttons.</para>
    /// <para><see href="https://developer.mozilla.org/en-US/docs/Web/API/MediaSession/setActionHandler"/></para>
    /// </summary>
    event TypedEventHandler<IMediaSession, MediaSessionActionEventArgs> OnMediaSessionAction;

    event TypedEventHandler<IMediaSession> OnPictureInPictureEnter;

    event TypedEventHandler<IMediaSession> OnPictureInPictureLeave;
}