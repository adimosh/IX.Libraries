// <copyright file="ConcurrentObservableList{T}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Diagnostics;
using System.Runtime.Serialization;
using IX.Observable.DebugAide;

using ReaderWriterLockSlim = IX.Library.Threading.ReaderWriterLockSlim;

namespace IX.Observable;

/// <summary>
///     A concurrent observable list.
/// </summary>
/// <typeparam name="T">The type of the items in the list.</typeparam>
/// <seealso cref="ObservableList{T}" />
[DebuggerDisplay("ObservableList, Count = {" + nameof(Count) + "}")]
[DebuggerTypeProxy(typeof(CollectionDebugView<>))]
[CollectionDataContract(
    Namespace = Constants.DataContractNamespace,
    Name = "ConcurrentObservable{0}List",
    ItemName = "Item")]
[PublicAPI]
public class ConcurrentObservableList<T> : ObservableList<T>
{
    private Lazy<ReaderWriterLockSlim> _locker;

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableList{T}" /> class.
    /// </summary>
    public ConcurrentObservableList() => _locker = EnvironmentSettings.GenerateDefaultLocker();

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableList{T}" /> class.
    /// </summary>
    /// <param name="source">The source.</param>
    public ConcurrentObservableList(IEnumerable<T> source)
        : base(source) =>
        _locker = EnvironmentSettings.GenerateDefaultLocker();

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableList{T}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context to use, if any.</param>
    public ConcurrentObservableList(SynchronizationContext context)
        : base(context) =>
        _locker = EnvironmentSettings.GenerateDefaultLocker();

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableList{T}" /> class.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="context">The context.</param>
    public ConcurrentObservableList(
        IEnumerable<T> source,
        SynchronizationContext context)
        : base(
            source,
            context) =>
        _locker = EnvironmentSettings.GenerateDefaultLocker();

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableList{T}" /> class.
    /// </summary>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ConcurrentObservableList(bool suppressUndoable)
        : base(suppressUndoable) =>
        _locker = EnvironmentSettings.GenerateDefaultLocker();

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableList{T}" /> class.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ConcurrentObservableList(
        IEnumerable<T> source,
        bool suppressUndoable)
        : base(
            source,
            suppressUndoable) =>
        _locker = EnvironmentSettings.GenerateDefaultLocker();

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableList{T}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context to use, if any.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ConcurrentObservableList(
        SynchronizationContext context,
        bool suppressUndoable)
        : base(
            context,
            suppressUndoable) =>
        _locker = EnvironmentSettings.GenerateDefaultLocker();

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableList{T}" /> class.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="context">The context.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ConcurrentObservableList(
        IEnumerable<T> source,
        SynchronizationContext context,
        bool suppressUndoable)
        : base(
            source,
            context,
            suppressUndoable) =>
        _locker = EnvironmentSettings.GenerateDefaultLocker();

    /// <summary>
    ///     Gets a synchronization lock item to be used when trying to synchronize read/write operations between threads.
    /// </summary>
    protected override IReaderWriterLock SynchronizationLock => _locker.Value;

    /// <summary>
    ///     Called when the object is being deserialized, in order to set the locker to a new value.
    /// </summary>
    /// <param name="context">The streaming context.</param>
    [OnDeserializing]
    internal void OnDeserializingMethod(StreamingContext context) =>
        Interlocked.Exchange(
            ref _locker,
            EnvironmentSettings.GenerateDefaultLocker());

    /// <summary>
    ///     Disposes the managed context.
    /// </summary>
    protected override void DisposeManagedContext()
    {
        var l = Interlocked.Exchange(
            ref _locker!,
            null);
        if (l?.IsValueCreated ?? false)
        {
            l.Value.Dispose();
        }

        base.DisposeManagedContext();
    }

    /// <summary>
    ///     Disposes the general context.
    /// </summary>
    protected override void DisposeGeneralContext()
    {
        _ = Interlocked.Exchange(
            ref _locker!,
            null!);

        base.DisposeGeneralContext();
    }
}