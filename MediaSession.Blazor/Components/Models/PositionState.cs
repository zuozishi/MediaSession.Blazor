namespace MediaSession.Blazor.Components.Models;

public class PositionState
{
    public double Duration { get; set; } = 0;
    public float PlaybackRate { get; set; } = 1;
    public double Position { get; set; }
}