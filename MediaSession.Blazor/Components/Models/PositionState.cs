namespace MediaSession.Blazor.Components.Models;

/// <summary>
/// Providing updated information about the playback position and speed of the document's ongoing media.
/// <para><see href="https://developer.mozilla.org/en-US/docs/Web/API/MediaSession/setPositionState"/></para>
/// </summary>
public class PositionState
{
    /// <summary>
    /// A floating-point value giving the total duration of the current media in seconds.
    /// <para>This should always be a positive number, with positive infinity (<see href="https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Infinity">Infinity</see>) indicating media without a defined end, such as a live stream.</para>
    /// </summary>
    public double Duration { get; set; } = 0;
    /// <summary>
    /// A floating-point value indicating the rate at which the media is being played, as a ratio relative to its normal playback speed.
    /// <para>Thus, a value of 1 is playing at normal speed, 2 is playing at double speed, and so forth.</para>
    /// <para>Negative values indicate that the media is playing in reverse; -1 indicates playback at the normal speed but backward, -2 is double speed in reverse, and so on.</para>
    /// </summary>
    public float PlaybackRate { get; set; } = 1;
    /// <summary>
    /// A floating-point value indicating the last reported playback position of the media in seconds.
    /// <para>This must always be a positive value.</para>
    /// </summary>
    public double Position { get; set; }
}