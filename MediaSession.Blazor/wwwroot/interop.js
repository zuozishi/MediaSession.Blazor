let debugMode = false;
let hasInit = false;

const canvas = document.createElement('canvas');
canvas.width = canvas.height = 512;
const canvasContext = canvas.getContext('2d');

const video = document.createElement('video');
video.srcObject = canvas.captureStream();
video.muted = true;

function debugLog(msg, obj) {
    if (!debugMode) return;
    if (obj === undefined || obj === null)
        console.log("MediaSession", msg);
    else
        console.log("MediaSession", msg, obj);
}

export function isDebugMode() {
    return debugMode;
}

export function setDebugMode(mode) {
    debugMode = mode;
}

export function isSupported() {
    return 'mediaSession' in navigator;
}

async function setCanvasImage() {
    if (navigator.mediaSession.metadata?.artwork === undefined || navigator.mediaSession.metadata.artwork === null || navigator.mediaSession.metadata.artwork.length === 0)
        return;
    const image = new Image();
    image.crossOrigin = true;
    image.src = navigator.mediaSession.metadata.artwork[0].src;
    await image.decode();
    canvasContext.fillRect(0, 0, canvas.width, canvas.height);
    canvasContext.drawImage(image, 0, 0, canvas.width, canvas.height);
}

async function showPictureInPictureWindow() {
    await video.play();
    await video.requestPictureInPicture();
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
        case 1: navigator.mediaSession.playbackState = 'paused'; video.pause(); break;
        case 2: navigator.mediaSession.playbackState = 'playing'; video.play(); break;
        default: navigator.mediaSession.playbackState = 'none'; video.pause();
    }
    debugLog("SetState:", navigator.mediaSession.playbackState);
}

export function setMeatadata(value) {
    if (!isSupported() || value === null) return;
    debugLog("SetMeatadata:", value);
    navigator.mediaSession.metadata = new MediaMetadata(value);
    setCanvasImage();
}

export function getMetadata() {
    if (!isSupported()) return null;
    const { title, artist, album, artwork } = navigator.mediaSession.metadata;
    return { title, artist, album, artwork };
}

export function setPositionState(state) {
    if (!isSupported()) return null;
    debugLog("SetPositionState:", state);
    navigator.mediaSession.setPositionState(state);
}

export function requestPictureInPicture() {
    debugLog("requestPictureInPicture");
    if (isSupported() && navigator.mediaSession?.metadata?.artwork !== undefined && navigator.mediaSession.metadata.artwork.length > 0)
        showPictureInPictureWindow();
}

export function exitPictureInPicture() {
    debugLog("exitPictureInPicture");
    if (isPictureInPictureEnabled())
        document.exitPictureInPicture();
}

export function isPictureInPictureEnabled() {
    return document.pictureInPictureElement !== undefined && document.pictureInPictureElement !== null;
}

export function registerEvents(dotNet) {
    if (hasInit) return;
    if (isSupported()) {
        const actions = ['play', 'pause', 'stop', 'previoustrack', 'nexttrack', 'seekbackward', 'seekforward', 'seekto', 'skipad'];
        actions.forEach(act => {
            debugLog("setActionHandler:", act);
            navigator.mediaSession.setActionHandler(act, event => {
                debugLog(`OnEvent-${event.action}`, event);
                dotNet.invokeMethodAsync("OnMediaSessionActionCallback", {
                    action: actions.indexOf(event.action),
                    fastSeek: event.fastSeek,
                    seekOffset: event.seekOffset,
                    seekTime: event.seekTime
                });
            });
        });

        video.addEventListener('enterpictureinpicture', function () {
            debugLog("EnterPictureInPicture");
            dotNet.invokeMethodAsync("OnPictureInPictureEnterCallback");
        });
        video.addEventListener('leavepictureinpicture', function () {
            debugLog("LeavePictureInPicture");
            dotNet.invokeMethodAsync("OnOnPictureInPictureLeaveCallback");
        });
    }
    hasInit = true;
}