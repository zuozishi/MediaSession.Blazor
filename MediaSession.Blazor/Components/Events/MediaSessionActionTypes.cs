namespace MediaSession.Blazor.Components.Types;

/// <summary>
/// The enumerated type describes an action that the user may perform in a media session.
/// <para><see href="https://developer.mozilla.org/en-US/docs/Web/API/MediaSessionAction"/></para>
/// </summary>
public enum MediaSessionActionTypes
{
    /// <summary>
    /// Begins (or resumes) playback of the media.
    /// </summary>
    Play = 0,
    /// <summary>
    /// Pauses playback of the media.
    /// </summary>
    Pause = 1,
    /// <summary>
    /// Halts playback entirely.
    /// </summary>
    Stop = 2,
    /// <summary>
    /// Moves back to the previous track.
    /// </summary>
    PreviousTrack = 3,
    /// <summary>
    /// Advances playback to the next track.
    /// </summary>
    NextTrack = 4,
    /// <summary>
    /// Seeks backward through the media from the current position.
    /// <para>The <see cref="Events.MediaSessionActionEventArgs"/> property <see cref="Events.MediaSessionActionEventArgs.S">SeekOffset</see> specifies the amount of time to seek backward.</para>
    /// </summary>
    SeekBackward = 5,
    /// <summary>
    /// Seeks forward from the current position through the media.
    /// <para>The <see cref="Events.MediaSessionActionEventArgs"/> property <see cref="Events.MediaSessionActionEventArgs.FastSeek">SeekOffset</see> specifies the amount of time to seek forward.</para>
    /// </summary>
    SeekForward = 6,
    /// <summary>
    /// Moves the playback position to the specified time within the media.
    /// <para>The time to which to seek is specified in the <see cref="Events.MediaSessionActionEventArgs"/> property <see cref="Events.MediaSessionActionEventArgs.SeekTime">SeekTime</see>.</para>
    /// </summary>
    SeekTo = 7,
    /// <summary>
    /// Skips past the currently playing advertisement or commercial. 
    /// <para>This action may or may not be available, depending on the platform and user agent, or may be disabled due to subscription level or other circumstances.</para>
    /// </summary>
    Skipad = 8
}