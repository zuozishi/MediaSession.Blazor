export function isSupported() {
    return 'mediaSession' in navigator;
}

export function getState() {
    if (!isSupported())
        return 0;
    switch (navigator.mediaSession.playbackState) {
        case 'paused': return 1;
        case 'playing': return 2;
        default: return 0;
    }
}

export function setState(value) {
    if (!isSupported()) return;
    switch (value) {
        case 1: navigator.mediaSession.playbackState = 'paused'; break;
        case 2: navigator.mediaSession.playbackState = 'playing'; return 2;
        default: navigator.mediaSession.playbackState = 'none';
    }
}

export function setMeatadata(value) {
    if (!isSupported() || value === null) return;
    navigator.mediaSession.metadata = new MediaMetadata(value);
}

export function getMetadata() {
    if (!isSupported()) return null;
    const { title, artist, album, artwork } = navigator.mediaSession.metadata;
    return { title, artist, album, artwork };
}

export function setPositionState(state) {
    if (!isSupported()) return null;
    navigator.mediaSession.setPositionState(state);
}

export function registerEvents(dotNet) {
    if (isSupported()) {
        navigator.mediaSession.setActionHandler('play', function (event) {
            dotNet.invokeMethodAsync("OnPlayCallback");
        });
        navigator.mediaSession.setActionHandler('pause', function (event) {
            dotNet.invokeMethodAsync("OnPauseCallback");
        });
        navigator.mediaSession.setActionHandler('stop', function () {
            dotNet.invokeMethodAsync("OnStopCallback");
        });
        navigator.mediaSession.setActionHandler('seekto', function (event) {
            dotNet.invokeMethodAsync("OnSeekToCallback", event);
        });
        navigator.mediaSession.setActionHandler('previoustrack', function () {
            dotNet.invokeMethodAsync("OnPreviouStrackCallback");
        });
        navigator.mediaSession.setActionHandler('nexttrack', function () {
            dotNet.invokeMethodAsync("OnNextTrackCallback");
        });
        navigator.mediaSession.setActionHandler('seekbackward', function () {
            dotNet.invokeMethodAsync("OnSeekBackwardCallback");
        });
        navigator.mediaSession.setActionHandler('seekforward', function () {
            dotNet.invokeMethodAsync("OnSeekForwardCallback");
        });
    }
}