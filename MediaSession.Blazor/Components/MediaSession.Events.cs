using MediaSession.Blazor.Components.Events;
using Microsoft.JSInterop;

namespace MediaSession.Blazor.Components;

public partial class MediaSession
{
    public event TypedEventHandler<IMediaSession, MediaSessionActionEventArgs> OnMediaSessionAction;
    public event TypedEventHandler<IMediaSession> OnPictureInPictureEnter;
    public event TypedEventHandler<IMediaSession> OnPictureInPictureLeave;

    [JSInvokable]
    public void OnMediaSessionActionCallback(MediaSessionActionEventArgs args) => OnMediaSessionAction?.Invoke(this, args);

    [JSInvokable]
    public void OnPictureInPictureEnterCallback() => OnPictureInPictureEnter?.Invoke(this);

    [JSInvokable]
    public void OnOnPictureInPictureLeaveCallback() => OnPictureInPictureLeave?.Invoke(this);
}