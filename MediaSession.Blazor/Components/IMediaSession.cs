using MediaSession.Blazor.Components.Models;

namespace MediaSession.Blazor.Components;

public interface IMediaSession : IMediaSessionEvents
{
    ValueTask<bool> IsSupported();

    ValueTask<MediaMetadata> GetMetadata();

    ValueTask SetPlaybackState(PlaybackState state);

    ValueTask<PlaybackState> GetPlaybackState();

    ValueTask SetMediaMetadata(MediaMetadata metadata);

    ValueTask SetPositionState(PositionState state);
}