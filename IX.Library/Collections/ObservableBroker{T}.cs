using System.Diagnostics.CodeAnalysis;

namespace IX.Library.Collections;

/// <summary>
/// A broker for the Observable pattern.
/// </summary>
/// <typeparam name="T">The type of data observed.</typeparam>
[PublicAPI]
public abstract class ObservableBroker<T> : DisposableBase,
                                            IObservable<T>
{
    [SuppressMessage(
        "IDisposableAnalyzers.Correctness",
        "IDISP006:Implement IDisposable",
        Justification = "IDisposable is implemented.")]
    private readonly WeakReferenceCollection<IObserver<T>> _observers;

    private readonly Settings _settings;

    /// <summary>
    /// Initializes a new instance of the <see cref="IX.Library.Collections.ObservableBroker{T}"/> class.
    /// </summary>
    protected ObservableBroker()
    : this(default)
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="IX.Library.Collections.ObservableBroker{T}"/> class.
    /// </summary>
    /// <param name="settings">The settings to use for this broker.</param>
    protected ObservableBroker(Settings settings)
    {
        _observers = new();
        _settings = settings;
    }

    /// <summary>Notifies the provider that an observer is to receive notifications.</summary>
    /// <param name="observer">The object that is to receive notifications.</param>
    /// <returns>A reference to an interface that allows observers to stop receiving notifications before the provider has finished sending them.</returns>
    public IDisposable Subscribe(IObserver<T> observer)
    {
        var weakReference = _observers.AddWeakReference(observer);

        return new ObserverDisposable(
            weakReference,
            _observers);
    }

    /// <summary>
    ///     Disposes in the managed context.
    /// </summary>
    protected override void DisposeManagedContext()
    {
        if (!_settings.DontSendCompletedWhenDisposing)
        {
            SendCompleted();
        }

        _observers.Dispose();

        base.DisposeManagedContext();
    }

    /// <summary>
    /// Sends the next batch of data for observers to consume.
    /// </summary>
    /// <param name="data">The data to send.</param>
    [SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "The enumerator has to be a reference in this case.")]
    protected void SendNext(T data)
    {
        foreach (var observer in _observers)
        {
            observer.OnNext(data);
        }
    }

    /// <summary>
    /// Sends an error for the observers to consume.
    /// </summary>
    /// <param name="ex">The exception to send to the observers.</param>
    [SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "The enumerator has to be a reference in this case.")]
    protected void SendError(Exception ex)
    {
        foreach (var observer in _observers)
        {
            observer.OnError(ex);
        }
    }

    /// <summary>
    /// Sends a message to observers saying that the observable has completed.
    /// </summary>
    [SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "The enumerator has to be a reference in this case.")]
    protected void SendCompleted()
    {
        foreach (var observer in _observers)
        {
            observer.OnCompleted();
        }

        if (!_settings.KeepObserverReferencesAfterSendingFinished)
        {
            _observers.Clear();
        }
    }

    /// <summary>
    /// Settings for an observable broker.
    /// </summary>
    public readonly struct Settings
    {
        /// <summary>
        /// Don't purge observers when the <see cref="IX.Library.Collections.ObservableBroker{T}.SendCompleted()"/> method is called.
        /// </summary>
        /// <remarks>
        /// <param>The default behavior is to purge the list of all observers when the <see cref="IX.Library.Collections.ObservableBroker{T}.SendCompleted()"/> method is called, so that a new list of observers can take its place.</param>
        /// <param>By setting this to <c>true</c>, the list is kept as-is.</param>
        /// </remarks>
        public bool KeepObserverReferencesAfterSendingFinished { get; init; }

        /// <summary>
        /// Don't call <see cref="IX.Library.Collections.ObservableBroker{T}.SendCompleted()"/> when disposing the broker instance.
        /// </summary>
        public bool DontSendCompletedWhenDisposing { get; init; }
    }

    private sealed class ObserverDisposable : IDisposable
    {
        private readonly WeakReference<IObserver<T>> _observer;
        private readonly WeakReferenceCollection<IObserver<T>> _collection;

        internal ObserverDisposable(
            WeakReference<IObserver<T>> observer,
            WeakReferenceCollection<IObserver<T>> collection)
        {
            _observer = observer;
            _collection = collection;
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            if (_observer.TryGetTarget(out var observerObject))
            {
                _ = _collection.Remove(observerObject);
            }
        }
    }
}