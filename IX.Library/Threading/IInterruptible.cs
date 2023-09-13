using System.Diagnostics.CodeAnalysis;

namespace IX.Core.Threading;

/// <summary>
///     Interface IInterruptible.
/// </summary>
/// <seealso cref="IDisposable" />
[PublicAPI]
public interface IInterruptible : IDisposable
{
    /// <summary>
    ///     Interrupts this instance.
    /// </summary>
    void Interrupt();

    /// <summary>
    ///     Resumes this instance.
    /// </summary>
    [SuppressMessage(
        "Naming",
        "CA1716:Identifiers should not match keywords",
        Justification = "Not applicable.")]
    void Resume();
}