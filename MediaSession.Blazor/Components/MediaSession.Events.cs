using MediaSession.Blazor.Components.Events;

namespace MediaSession.Blazor.Components;

public partial class MediaSession
{
    public event Action OnPlay;
    public event Action OnPause;
    public event Action OnStop;
    public event Action OnPreviouStrack;
    public event Action OnNextTrack;
    public event Action<MediaSessionSeekToEventArgs> OnSeekTo;
    public event Action OnSeekBackward;
    public event Action OnSeekForward;
}