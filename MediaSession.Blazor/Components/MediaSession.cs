using MediaSession.Blazor.Components.Models;
using Microsoft.JSInterop;

namespace MediaSession.Blazor.Components;

public partial class MediaSession : IMediaSession, IAsyncDisposable
{
    private readonly Lazy<Task<IJSObjectReference>> moduleTask;
    private readonly DotNetObjectReference<MediaSession> objRef;

    public MediaSession(IJSRuntime jsRuntime)
    {
        moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
           "import", "./_content/MediaSession.Blazor/interop.js").AsTask());
        objRef = DotNetObjectReference.Create(this);
        _ = RegisterEvents();
    }

    private async ValueTask RegisterEvents()
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("registerEvents", objRef);
    }

    public async ValueTask<bool> IsSupported()
    {
        var module = await moduleTask.Value;
        return await module.InvokeAsync<bool>("isSupported");
    }

    public async ValueTask<PlaybackState> GetPlaybackState()
    {
        var module = await moduleTask.Value;
        return await module.InvokeAsync<PlaybackState>("getState");
    }

    public async ValueTask SetPlaybackState(PlaybackState state)
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("setState", state);
    }

    public async ValueTask<MediaMetadata> GetMetadata()
    {
        var module = await moduleTask.Value;
        return await module.InvokeAsync<MediaMetadata>("getMetadata");
    }

    public async ValueTask SetMediaMetadata(MediaMetadata metadata)
    {
        if (metadata == null)
            throw new ArgumentNullException(nameof(metadata));
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("setMeatadata", metadata);
    }

    public async ValueTask SetPositionState(PositionState state)
    {
        if (state == null)
            throw new ArgumentNullException(nameof(state));
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("setPositionState", state);
    }

    public async ValueTask DisposeAsync()
    {
        if (moduleTask.IsValueCreated)
        {
            var module = await moduleTask.Value;
            await module.DisposeAsync();
        }
    }
}