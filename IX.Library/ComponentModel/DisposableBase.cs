using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace IX.Library.ComponentModel;

/// <summary>
///     An abstract base class for correctly implementing the disposable pattern.
/// </summary>
/// <seealso cref="IDisposable" />
[DataContract(Namespace = Constants.DataContractNamespace)]
[SuppressMessage(
    "IDisposableAnalyzers.Correctness",
    "IDISP025:Class with no virtual dispose method should be sealed.",
    Justification = "The pattern is not followed here, because, instead of overriding Dispose, one can and should override the two (managed and general) methods.")]
public abstract partial class DisposableBase : IDisposable
{
    /// <summary>
    ///     The thread-safe dispose signal.
    /// </summary>
    private int _disposeSignaled;

    /// <summary>
    ///     Finalizes an instance of the <see cref="DisposableBase" /> class.
    /// </summary>
    ~DisposableBase() => Dispose(false);

    /// <summary>
    ///     Gets a value indicating whether this <see cref="DisposableBase" /> is disposed.
    /// </summary>
    /// <value>
    ///     <c>true</c> if disposed; otherwise, <c>false</c>.
    /// </value>
    internal bool Disposed { get; private set; }

    /// <summary>
    ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {
        if (Interlocked.Exchange(
                ref _disposeSignaled,
                1) !=
            0)
        {
            return;
        }

        GC.SuppressFinalize(this);
        Dispose(true);
    }

    /// <summary>
    ///     Throws if the current object is disposed.
    /// </summary>
    /// <exception cref="ObjectDisposedException">If the current object is disposed, this exception will be thrown.</exception>
    protected internal void ThrowIfCurrentObjectDisposed()
    {
        if (Disposed)
        {
            throw new ObjectDisposedException(
                GetType()
                    .FullName);
        }
    }

    /// <summary>
    ///     Anchor for automatic disposal of this instance.
    /// </summary>
    protected virtual void DisposeAutomatically() { }

    /// <summary>
    ///     Invokes an action if the current instance is not disposed.
    /// </summary>
    /// <param name="action">The action to invoke.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="action" /> is <see langword="null" /> (
    ///     <see langword="Nothing" /> in Visual Basic).
    /// </exception>
    protected void InvokeIfNotDisposed(Action action)
    {
        ThrowIfCurrentObjectDisposed();

        Requires.NotNull(action)();
    }

    /// <summary>
    ///     Invokes an action if the current instance is not disposed.
    /// </summary>
    /// <typeparam name="TReturn">The return type.</typeparam>
    /// <param name="func">The function to invoke.</param>
    /// <returns>The object returned by the action.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="func" /> is <see langword="null" /> (
    ///     <see langword="Nothing" /> in Visual Basic).
    /// </exception>
    protected TReturn InvokeIfNotDisposed<TReturn>(Func<TReturn> func)
    {
        ThrowIfCurrentObjectDisposed();

        return Requires.NotNull(func)();
    }

    /// <summary>
    ///     Disposes in the managed context.
    /// </summary>
    protected virtual void DisposeManagedContext() { }

    /// <summary>
    ///     Disposes in the general (managed and unmanaged) context.
    /// </summary>
    protected virtual void DisposeGeneralContext() { }

    /// <summary>
    ///     Releases unmanaged and - optionally - managed resources.
    /// </summary>
    /// <param name="disposing">
    ///     <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only
    ///     unmanaged resources.
    /// </param>
    private void Dispose(bool disposing)
    {
        try
        {
            if (disposing)
            {
                DisposeAutomatically();

                DisposeManagedContext();
            }

            DisposeGeneralContext();
        }
        finally
        {
            Disposed = true;
        }
    }
}