using MediaSession.Blazor.Components.Types;

namespace MediaSession.Blazor.Components.Events;

public class MediaSessionActionEventArgs
{
    /// <summary>
    /// Indicating which type of action needs to be performed.
    /// </summary>
    public MediaSessionActionTypes Action { get; init; }
    /// <summary>
    /// An action may optionally include this property, which is a Boolean value indicating whether or not to perform a "fast" seek.
    /// <para>A "fast" seek is a seek being performed in a rapid sequence, such as when fast-forwarding or reversing through the media, rapidly skipping through it.</para>
    /// <para>This property can be used to indicate that you should use the shortest possible method to seek the media.</para>
    /// <para>is not included on the final action in the seek sequence in this situation.</para>
    /// <para>Action: SeekTo</para>
    /// </summary>
    public bool? FastSeek { get; init; }
    /// <summary>
    /// If the  is either or and this property is present, it is a floating point value which indicates the number of seconds to move the play position forward or backward.
    /// <para>If this property isn't present, those actions should choose a reasonable default distance to skip forward or backward (such as 7 or 10 seconds).</para>
    /// <para>Action: SeekForward SeekBackward</para>
    /// </summary>
    public float? SeekOffset { get; init; }
    /// <summary>
    /// If the  is , this property must be present and must be a floating-point value indicating the absolute time within the media to move the playback position to, where 0 indicates the beginning of the media. 
    /// <para>Action: SeekTo</para>
    /// </summary>
    public float? SeekTime { get; init; }
}