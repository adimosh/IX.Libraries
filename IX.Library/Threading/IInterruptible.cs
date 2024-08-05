using System.Diagnostics.CodeAnalysis;

namespace IX.Library.Threading;

/// <summary>
///     Interface IInterruptible.
/// </summary>
/// <seealso cref="IDisposable" />
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