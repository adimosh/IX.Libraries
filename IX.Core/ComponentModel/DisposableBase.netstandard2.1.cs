#if FRAMEWORK_ADVANCED
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace IX.Core.ComponentModel;

/// <summary>
///     An abstract base class for correctly implementing the disposable pattern.
/// </summary>
/// <seealso cref="IDisposable" />
public abstract partial class DisposableBase : IAsyncDisposable
{
    /// <summary>
    ///     Asynchronously performs application-defined tasks associated with freeing, releasing, or resetting unmanaged
    ///     resources.
    /// </summary>
    /// <returns>
    ///     A value task representing the completed dispose operation.
    /// </returns>
    [SuppressMessage(
        "Usage",
        "CA1816:Dispose methods should call SuppressFinalize",
        Justification = "This is a dispose method.")]
    public async ValueTask DisposeAsync()
    {
        if (Interlocked.Exchange(
                ref _disposeSignaled,
                1) !=
            0)
        {
            return;
        }

        GC.SuppressFinalize(this);
        await DisposeAsync(true)
            .ConfigureAwait(false);
    }

    /// <summary>
    ///     Disposes in the managed context.
    /// </summary>
    /// <returns>
    ///     A value task representing the completed dispose operation.
    /// </returns>
    protected virtual ValueTask DisposeManagedContextAsync()
    {
        DisposeManagedContext();

        return new(Task.CompletedTask);
    }

    /// <summary>
    ///     Disposes in the general (managed and unmanaged) context.
    /// </summary>
    /// <returns>
    ///     A value task representing the completed dispose operation.
    /// </returns>
    protected virtual ValueTask DisposeGeneralContextAsync()
    {
        DisposeGeneralContext();

        return new(Task.CompletedTask);
    }

    /// <summary>
    ///     Releases unmanaged and - optionally - managed resources.
    /// </summary>
    /// <param name="disposing">
    ///     <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only
    ///     unmanaged resources.
    /// </param>
    private async ValueTask DisposeAsync(bool disposing)
    {
        try
        {
            if (disposing)
            {
                DisposeAutomatically();

                await DisposeManagedContextAsync()
                    .ConfigureAwait(false);
            }

            await DisposeGeneralContextAsync()
                .ConfigureAwait(false);
        }
        finally
        {
            Disposed = true;
        }
    }
}
#endif