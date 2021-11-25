namespace MediaSession.Blazor.Components.Models;

public class MediaMetadata
{
    public string Title { get; set; }
    public string Artist { get; set; }
    public string Album { get; set; }
    public IEnumerable<MediaArtwork> Artwork { get; set; }
}