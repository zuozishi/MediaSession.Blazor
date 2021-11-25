using MediaSession.Blazor.Components.Events;

namespace MediaSession.Blazor.Components;

public interface IMediaSessionEvents
{
    event Action OnPlay;

    event Action OnPause;

    event Action OnStop;

    event Action OnPreviouStrack;

    event Action OnNextTrack;

    event Action<MediaSessionSeekToEventArgs> OnSeekTo;

    event Action OnSeekBackward;

    event Action OnSeekForward;
}