using System.Diagnostics.CodeAnalysis;

namespace IX.Library.ComponentModel.Events;

internal abstract class EventBusDelegateReference<TEventArgs>
    where TEventArgs : EventArgs
{
    internal abstract bool TryGetReference([NotNullWhen(true)] out Action<object, TEventArgs>? @delegate);
}

internal sealed class StrongEventBusDelegateReference<TKey, TEventArgs> : EventBusDelegateReference<TEventArgs>
    where TKey : notnull
    where TEventArgs : EventArgs
{
    [SuppressMessage(
        "ReSharper",
        "NotAccessedField.Local",
        Justification = "This is intentional, and serves only to have a strong reference to the handler.")]
    private readonly EventHandler<TEventArgs> _delegate;

    private readonly Action<object, TEventArgs> _strategy;

    internal StrongEventBusDelegateReference(
        EventHandler<TEventArgs> @delegate,
        EventSubscriptionSynchronizationOptions options,
        EventBus<TKey> eventBus)
    {
        _delegate = @delegate;
        _strategy = CreateStrategyDelegate(
            @delegate,
            options,
            eventBus);
    }

    internal override bool TryGetReference(out Action<object, TEventArgs> @delegate)
    {
        @delegate = _strategy;
        return true;
    }

    [SuppressMessage(
        "Performance",
        "HAA0301:Closure Allocation Source",
        Justification = "This is acceptable.")]
    [SuppressMessage(
        "Performance",
        "HAA0302:Display class allocation to capture closure",
        Justification = "This is acceptable.")]
    private Action<object, TEventArgs> CreateStrategyDelegate(
        EventHandler<TEventArgs> eventHandler,
        EventSubscriptionSynchronizationOptions options,
        EventBus<TKey> eventBus)
    {
        switch (options)
        {
            case EventSubscriptionSynchronizationOptions.BackgroundThread:
                return (
                    sender,
                    args) =>
                {
                    Work.OnThreadPoolAsync(
                        (Tuple<EventHandler<TEventArgs>, object, TEventArgs> state) =>
                        {
                            var (action, internalSender, internalEventArgs) = state;
                            action.Invoke(
                                internalSender,
                                internalEventArgs);
                        }, new(
                            eventHandler,
                            sender,
                            args));
                };
            case EventSubscriptionSynchronizationOptions.SynchronousWithPublisherThread:
                return new(eventHandler);
            case EventSubscriptionSynchronizationOptions.SynchronouslyOnSynchronizationContext:
                return (
                    sender,
                    args) =>
                {
                    var synchronizationContext = eventBus.SynchronizationContext;

                    if (synchronizationContext is null) throw new InvalidOperationException();

                    synchronizationContext.Send(
                        InvokeOnSyncContext,
                        new Tuple<EventHandler<TEventArgs>, object, TEventArgs>(
                            eventHandler,
                            sender,
                            args));
                };
            case EventSubscriptionSynchronizationOptions.AsynchronouslyOnSynchronizationContext:
                return (
                    sender,
                    args) =>
                {
                    var synchronizationContext = eventBus.SynchronizationContext;

                    if (synchronizationContext is null) throw new InvalidOperationException();

                    synchronizationContext.Post(
                        InvokeOnSyncContext,
                        new Tuple<EventHandler<TEventArgs>, object, TEventArgs>(
                            eventHandler,
                            sender,
                            args));
                };
            default: throw new InvalidOperationException();
        }

        void InvokeOnSyncContext(object? rawState)
        {
            if (rawState is null) throw new InvalidOperationException();

            (EventHandler<TEventArgs> action, var internalSender, TEventArgs internalEventArgs) =
                (Tuple<EventHandler<TEventArgs>, object, TEventArgs>)rawState;
            action.Invoke(
                internalSender,
                internalEventArgs);
        }
    }
}

internal sealed class WeakEventBusDelegateReference<TKey, TEventArgs> : EventBusDelegateReference<TEventArgs>
    where TKey : notnull
    where TEventArgs : EventArgs
{
    private readonly WeakReference<EventHandler<TEventArgs>> _delegate;
    private readonly Action<object, TEventArgs> _strategy;

    public WeakEventBusDelegateReference(
        EventHandler<TEventArgs> @delegate,
        EventSubscriptionSynchronizationOptions options,
        EventBus<TKey> eventBus)
    {
        _delegate = new(@delegate);
        _strategy = CreateStrategyDelegate(
            _delegate,
            options,
            eventBus);
    }

    internal override bool TryGetReference([NotNullWhen(true)] out Action<object, TEventArgs>? @delegate)
    {
        if (!_delegate.TryGetTarget(out _))
        {
            @delegate = null;
            return false;
        }

        @delegate = _strategy;
        return true;
    }

    [SuppressMessage(
        "Performance",
        "HAA0301:Closure Allocation Source",
        Justification = "This is acceptable.")]
    [SuppressMessage(
        "Performance",
        "HAA0302:Display class allocation to capture closure",
        Justification = "This is acceptable.")]
    private Action<object, TEventArgs> CreateStrategyDelegate(
        WeakReference<EventHandler<TEventArgs>> eventHandler,
        EventSubscriptionSynchronizationOptions options,
        EventBus<TKey> eventBus)
    {
        switch (options)
        {
            case EventSubscriptionSynchronizationOptions.BackgroundThread:
                return (
                    sender,
                    args) =>
                {
                    if (!eventHandler.TryGetTarget(out _)) return;

                    Work.OnThreadPoolAsync(
                        (Tuple<WeakReference<EventHandler<TEventArgs>>, object, TEventArgs> state) =>
                        {
                            var (weakAction, internalSender, internalEventArgs) = state;
                            if (!weakAction.TryGetTarget(out var action)) return;

                            action.Invoke(
                                internalSender,
                                internalEventArgs);
                        }, new(
                            eventHandler,
                            sender,
                            args));
                };
            case EventSubscriptionSynchronizationOptions.SynchronousWithPublisherThread:
                return (
                    sender,
                    args) =>
                {
                    if (!eventHandler.TryGetTarget(out var action)) return;

                    action.Invoke(
                        sender,
                        args);
                };
            case EventSubscriptionSynchronizationOptions.SynchronouslyOnSynchronizationContext:
                return (
                    sender,
                    args) =>
                {
                    if (!eventHandler.TryGetTarget(out _)) return;

                    var synchronizationContext = eventBus.SynchronizationContext;

                    if (synchronizationContext is null) throw new InvalidOperationException();

                    synchronizationContext.Send(
                        InvokeOnSyncContext,
                        new Tuple<WeakReference<EventHandler<TEventArgs>>, object, TEventArgs>(
                            eventHandler,
                            sender,
                            args));
                };
            case EventSubscriptionSynchronizationOptions.AsynchronouslyOnSynchronizationContext:
                return (
                    sender,
                    args) =>
                {
                    if (!eventHandler.TryGetTarget(out _)) return;

                    var synchronizationContext = eventBus.SynchronizationContext;

                    if (synchronizationContext is null) throw new InvalidOperationException();

                    synchronizationContext.Post(
                        InvokeOnSyncContext,
                        new Tuple<WeakReference<EventHandler<TEventArgs>>, object, TEventArgs>(
                            eventHandler,
                            sender,
                            args));
                };
            default: throw new InvalidOperationException();
        }

        void InvokeOnSyncContext(object? rawState)
        {
            if (rawState is null) throw new InvalidOperationException();

            (WeakReference<EventHandler<TEventArgs>> weakAction, var internalSender, TEventArgs internalEventArgs) =
                (Tuple<WeakReference<EventHandler<TEventArgs>>, object, TEventArgs>)rawState;
            if (!weakAction.TryGetTarget(out var action)) return;

            action.Invoke(
                internalSender,
                internalEventArgs);
        }
    }
}