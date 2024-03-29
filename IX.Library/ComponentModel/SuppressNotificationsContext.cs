using System.Diagnostics.CodeAnalysis;

namespace IX.Library.ComponentModel;

/// <summary>A class that represents a notification suppression context for property and collection changed notifications.</summary>
/// <remarks>
///     <para>
///         <font color="#ff0000">Warning!</font> Due to the lack of AsyncLocal support in .NET Framework less than 4.6 and
///         .NET Standard less than 1.3, for those versions the context is NOT thread-safe. Please take great care in using
///         this context especially in multithreaded environments.
///     </para>
///     <para>
///         <font color="#ff0000">Warning!</font> The context only suppresses notifications that would normally be launched
///         between the moment when the context is created and when the context is destroyed. Even though the context
///         supports asynchronous operations, the operations should be awaited on. Should a notification be started on a
///         task started during the context being active, but the actual notification is only sent at a later time, it will
///         not be caught by the context and will therefore fire.
///     </para>
/// </remarks>
/// <example>
///     The context should be used inside a using block in order to obtain the best results. A context that is not properly
///     disposed of has unpredictable results later on during further execution on the same thread.
///     <code>public void DoSomething(ObservableList&lt;string&gt; objects)
/// {
///     using (SuppressNotificationsContext.New())
///     {
///         // These items will not notify viewers
///         objects.Add("a");
///         objects.Add("b");
///         objects.Add("c");
///     }
///
///     // We refresh all viewers of the observable list so
///     // that they get the newest state of the list.
///     // In case this is omitted, there is a risk that
///     // certain UI frameworks (WPF, for example) will
///     // see that there is lack of synchronization when the
///     // next line notifies, and will crash
///     objects.RefreshViewers();
///
///     // This will notify viewers of the change
///     objects.Add("d");
/// }</code>
/// </example>
public class SuppressNotificationsContext : DisposableBase
{
    [SuppressMessage(
        "StyleCop.CSharp.MaintainabilityRules",
        "SA1401:Fields should be private",
        Justification = "No they shouldn't.")]
    internal static AsyncLocal<bool> AmbientSuppressionActive = new();

    /// <summary>Initializes a new instance of the <see cref="SuppressNotificationsContext" /> class.</summary>
    public SuppressNotificationsContext() => AmbientSuppressionActive.Value = true;

    /// <summary>
    ///     Creates a new context for suppressing notifications. This method is shorthand for manually creating a new
    ///     object.
    /// </summary>
    /// <returns>A new context.</returns>
    public static SuppressNotificationsContext New() => new();

    /// <summary>
    ///     Disposes in the managed context.
    /// </summary>
    protected override void DisposeManagedContext() => AmbientSuppressionActive.Value = false;
}