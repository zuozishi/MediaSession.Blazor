using System.Runtime.InteropServices;

namespace MediaSession.Blazor.Components.Events;

public delegate void TypedEventHandler<TSender>([In] TSender sender);

public delegate void TypedEventHandler<TSender, TResult>([In] TSender sender, [In] TResult args);