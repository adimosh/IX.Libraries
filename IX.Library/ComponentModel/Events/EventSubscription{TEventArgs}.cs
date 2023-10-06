namespace IX.Library.ComponentModel.Events;

internal sealed class EventSubscription<TEventArgs>
    where TEventArgs : EventArgs
{
    private readonly EventBusDelegateReference<TEventArgs> _actionToTake;
    private int _stillSubscribed = 1;

    internal EventSubscription(EventBusDelegateReference<TEventArgs> actionToTake)
    {
        _actionToTake = actionToTake;
        Id = Guid.NewGuid();
    }

    internal Guid Id { get; }

    internal bool InvokeAction(
        object sender,
        TEventArgs args)
    {
        if (_stillSubscribed == 0) return false;

        if (_actionToTake.TryGetReference(out var action))
        {
            action(sender, args);
            return true;
        }

        return false;
    }

    internal IPublishedEventSubscriptionToken CreateToken() => new PublishedEventSubscriptionToken(Id, Unsubscribe);

    private void Unsubscribe() => Interlocked.Exchange(ref _stillSubscribed, 0);
}