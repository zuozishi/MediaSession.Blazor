using MediaSession.Blazor.Components.Models;

namespace MediaSession.Blazor.Sample;

public class MusicItem
{
    public string Title { get; set; }

    public string Artist { get; set; }

    public string Album { get; set; }

    public string Cover { get; set; }

    public string Source { get; set; }

    public MediaMetadata ToMediaMetadata()
        => new()
        {
            Title = Title,
            Artist = Artist,
            Album = Album,
            Artwork = new MediaArtwork[]
            {
                new()
                {
                    Src = Cover,
                    Sizes = new(128),
                    Type = "image/jpeg"
                }
            }
        };
}