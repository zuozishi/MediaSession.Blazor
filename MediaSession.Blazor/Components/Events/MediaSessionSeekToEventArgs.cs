namespace MediaSession.Blazor.Components.Events;

public class MediaSessionSeekToEventArgs
{
    public bool FastSeek { get; set; }
    public float SeekTime { get; set; }
}