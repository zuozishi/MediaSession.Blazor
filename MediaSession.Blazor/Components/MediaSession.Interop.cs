using MediaSession.Blazor.Components.Events;
using Microsoft.JSInterop;

namespace MediaSession.Blazor.Components;

public partial class MediaSession
{
    [JSInvokable]
    public void OnPlayCallback() => OnPlay?.Invoke();

    [JSInvokable]
    public void OnPauseCallback() => OnPause?.Invoke();

    [JSInvokable]
    public void OnStopCallback() => OnStop?.Invoke();

    [JSInvokable]
    public void OnPreviouStrackCallback() => OnPreviouStrack?.Invoke();

    [JSInvokable]
    public void OnNextTrackCallback() => OnNextTrack?.Invoke();

    [JSInvokable]
    public void OnSeekToCallback(MediaSessionSeekToEventArgs e) => OnSeekTo?.Invoke(e);

    [JSInvokable]
    public void OnSeekBackwardCallback() => OnSeekBackward?.Invoke();

    [JSInvokable]
    public void OnSeekForwardCallback() => OnSeekForward?.Invoke();
}