namespace MediaSession.Blazor.Components.Models;

public class MediaArtworkSize
{
    public int Width { get; set; }
    public int Height { get; set; }

    public MediaArtworkSize() { }

    public MediaArtworkSize(int size)
    {
        Width = size;
        Height = size;
    }

    public MediaArtworkSize(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public override string ToString() => $"{Width}x{Height}";
}