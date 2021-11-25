using MediaSession.Blazor.Components.Converter;
using System.Text.Json.Serialization;

namespace MediaSession.Blazor.Components.Models;

public class MediaArtwork
{
    public string Src { get; set; }
    [JsonConverter(typeof(MediaArtworkSizeJsonConverter))]
    public MediaArtworkSize Sizes { get; set; }
    public string Type { get; set; }
}