using MediaSession.Blazor.Components.Converter;
using System.Text.Json.Serialization;

namespace MediaSession.Blazor.Components.Models;

/// <summary>
/// Describes the images associated with a media resource's <see cref="MediaMetadata"/>.
/// <para><see href="https://developer.mozilla.org/en-US/docs/Web/API/MediaImage"/></para>
/// </summary>
public class MediaArtwork
{
    /// <summary>
    /// The URL from which the user agent fetches the image's data.
    /// </summary>
    public string Src { get; set; }
    /// <summary>
    /// Specifies the resource in multiple sizes so the user agent doesn't have to scale a single image.
    /// </summary>
    [JsonConverter(typeof(MediaArtworkSizeJsonConverter))]
    public MediaArtworkSize Sizes { get; set; }
    /// <summary>
    /// The <see href="https://developer.mozilla.org/en-US/docs/Glossary/MIME_type">MIME type</see> hint for the user agent that allows it to ignore images of types that it doesn't support.
    /// <para>However, the user agent may still use MIME type sniffing after downloading the image to determine its type.</para>
    /// </summary>
    public string Type { get; set; }
}