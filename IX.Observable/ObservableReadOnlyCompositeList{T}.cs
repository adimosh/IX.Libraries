using System.Collections.Specialized;

using IX.Observable.Adapters;

using ReaderWriterLockSlim = IX.Core.Threading.ReaderWriterLockSlim;

namespace IX.Observable;

/// <summary>
///     An observable, composite, thread-safe and read-only list made of multiple lists of the same rank.
/// </summary>
/// <typeparam name="T">The type of the list item.</typeparam>
/// <seealso cref="IDisposable" />
/// <seealso cref="Observable.ObservableReadOnlyCollectionBase{T}" />
[PublicAPI]
public class ObservableReadOnlyCompositeList<T> : ObservableReadOnlyCollectionBase<T>
{
    private readonly Lazy<ReaderWriterLockSlim> _locker;

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableReadOnlyCompositeList{T}" /> class.
    /// </summary>
    public ObservableReadOnlyCompositeList()
        : base(new MultiListListAdapter<T>()) =>
        _locker = EnvironmentSettings.GenerateDefaultLocker();

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableReadOnlyCompositeList{T}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context to use, if any.</param>
    public ObservableReadOnlyCompositeList(SynchronizationContext context)
        : base(
            new MultiListListAdapter<T>(),
            context) =>
        _locker = EnvironmentSettings.GenerateDefaultLocker();

    /// <summary>
    ///     Sets a list.
    /// </summary>
    /// <typeparam name="TList">The type of the list.</typeparam>
    /// <param name="list">The list.</param>
    public void SetList<TList>(TList list)
        where TList : class, IEnumerable<T>, INotifyCollectionChanged
    {
        using (AcquireWriteLock())
        {
            ((MultiListListAdapter<T>)InternalContainer).SetList(list);
        }

        RaiseCollectionReset();
        RaisePropertyChanged(nameof(Count));
        RaisePropertyChanged(Constants.ItemsName);
    }

    /// <summary>
    ///     Removes a list.
    /// </summary>
    /// <typeparam name="TList">The type of the list.</typeparam>
    /// <param name="list">The list.</param>
    public void RemoveList<TList>(TList list)
        where TList : class, IEnumerable<T>, INotifyCollectionChanged
    {
        using (AcquireWriteLock())
        {
            ((MultiListListAdapter<T>)InternalContainer).RemoveList(list);
        }

        RaiseCollectionReset();
        RaisePropertyChanged(nameof(Count));
        RaisePropertyChanged(Constants.ItemsName);
    }

    /// <summary>
    ///     Disposes the managed context.
    /// </summary>
    protected override void DisposeManagedContext()
    {
        if (_locker.IsValueCreated)
        {
            _locker.Value.Dispose();
        }

        base.DisposeManagedContext();
    }
}