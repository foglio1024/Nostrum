using System;
using Nostrum.WPF.Extensions;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;
using System.Configuration;

namespace Nostrum.WPF.ThreadSafe;

/// <summary>
/// An object which keeps a reference to a <see cref="Dispatcher"/> and invokes <see cref="INotifyPropertyChanged.PropertyChanged"/> notifications on the relative thread if needed.
/// </summary>
public class ThreadSafeObservableObject : ObservableObject
{
    protected Dispatcher _dispatcher;
    /// <summary>
    /// The dispatcher used to invoke the NotifyPropertyChanged event.
    /// </summary>
    public Dispatcher Dispatcher
    {
        get => _dispatcher;
        set => _dispatcher = value;
    }

    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="dispatcher">the dispatcher. If null, <see cref="Dispatcher.CurrentDispatcher"/> will be used.</param>
    public ThreadSafeObservableObject(Dispatcher? dispatcher = null)
    {
        _dispatcher = dispatcher ?? Dispatcher.CurrentDispatcher;
    }

    /// <summary>
    /// Returns the underlying <see cref="Dispatcher"/>.
    /// </summary>
    /// <returns></returns>
    [Obsolete("Use the Dispatcher property instead.")]
    public Dispatcher? GetDispatcher()
    {
        return _dispatcher;
    }

    /// <summary>
    /// Sets a new <see cref="Dispatcher"/>.
    /// </summary>
    /// <param name="newDispatcher"></param>
    [Obsolete("Use the Dispatcher property instead.")]
    public void SetDispatcher(Dispatcher newDispatcher)
    {
        _dispatcher = newDispatcher;
    }

    /// <inheritdoc />
    [Obsolete($"Use {nameof(RaiseAndSetIfChanged)} instead.")]
    protected sealed override void N([CallerMemberName] string? propertyName = null, int delayMs = 0)
    {
        base.N(propertyName, delayMs);
    }

    protected sealed override bool RaiseAndSetIfChanged<T>(T value, ref T backingField, [CallerMemberName] string? propertyName = null, int delayMs = 0)
    {
        return base.RaiseAndSetIfChanged(value, ref backingField, propertyName, delayMs);
    }

    /// <inheritdoc />
    protected sealed override void InvokePropertyChanged(string? propertyName)
    {
        _dispatcher.InvokeAsyncIfRequired(() => base.InvokePropertyChanged(propertyName), DispatcherPriority.DataBind);
    }
}