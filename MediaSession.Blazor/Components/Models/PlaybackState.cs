namespace MediaSession.Blazor.Components.Models;

/// <summary>
/// Indicates whether the current media session is playing or paused.
/// <para><see href="https://developer.mozilla.org/en-US/docs/Web/API/MediaSession/playbackState"/></para>
/// </summary>
public enum PlaybackState
{
    /// <summary>
    /// The browsing context doesn't currently know the current playback state, or the playback state is not available at this time.
    /// </summary>
    None,
    /// <summary>
    /// The browser's media session is currently paused. Playback may be resumed.
    /// </summary>
    Paused,
    /// <summary>
    /// The browser's media session is currently playing media, which can be paused.
    /// </summary>
    Playing
}