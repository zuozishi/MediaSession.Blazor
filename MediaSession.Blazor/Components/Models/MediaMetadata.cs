namespace MediaSession.Blazor.Components.Models;

/// <summary>
/// Allows a web page to provide rich media metadata for display in a platform UI.
/// <para><see href="https://developer.mozilla.org/en-US/docs/Web/API/MediaMetadata"/></para>
/// </summary>
public class MediaMetadata
{
    /// <summary>
    /// The title of the media to be played.
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// The name of the artist, group, creator, etc. of the media to be played.
    /// </summary>
    public string Artist { get; set; }
    /// <summary>
    /// The name of the album or collection containing the media to be played.
    /// </summary>
    public string Album { get; set; }
    /// <summary>
    /// An array of images associated with playing media.
    /// </summary>
    public IEnumerable<MediaArtwork> Artwork { get; set; }
}