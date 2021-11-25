using MediaSession.Blazor.Components.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MediaSession.Blazor.Components.Converter;

public class MediaArtworkSizeJsonConverter : JsonConverter<MediaArtworkSize>
{
    public override MediaArtworkSize Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string text = reader.GetString();
        if (string.IsNullOrEmpty(text) || !text.Contains("x")) return null;
        var split = text.Split('x');
        if (!int.TryParse(split[0], out var width)) return null;
        if (!int.TryParse(split[1], out var height)) return null;
        return new MediaArtworkSize(width, height);
    }

    public override void Write(Utf8JsonWriter writer, MediaArtworkSize value, JsonSerializerOptions options)
    {
        if (value == null)
            writer.WriteNullValue();
        else
            writer.WriteStringValue(value.ToString());
    }
}