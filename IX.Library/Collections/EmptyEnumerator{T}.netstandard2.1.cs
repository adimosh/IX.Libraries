#if FRAMEWORK_ADVANCED
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace IX.Library.Collections;

[SuppressMessage(
    "StyleCop.CSharp.DocumentationRules",
    "SA1601:Partial elements should be documented",
    Justification = "Already documented.")]
public sealed partial class EmptyEnumerator<T> : IAsyncEnumerator<T>
{
    /// <summary>
    ///     Gets a default value.
    /// </summary>
    T IAsyncEnumerator<T>.Current => default!;

    /// <summary>
    ///     Does nothing.
    /// </summary>
    /// <returns>A default <see cref="ValueTask" />.</returns>
    [SuppressMessage(
        "AsyncUsage.CSharp.Naming",
        "AvoidAsyncSuffix:Avoid Async suffix",
        Justification = "This method was originally meant to actually be async.")]
    ValueTask IAsyncDisposable.DisposeAsync() => default;

    /// <summary>
    ///     Does nothing.
    /// </summary>
    /// <returns>
    ///     Always returns <see langword="false" />.
    /// </returns>
    [SuppressMessage(
        "AsyncUsage.CSharp.Naming",
        "AvoidAsyncSuffix:Avoid Async suffix",
        Justification = "This method was originally meant to actually be async.")]
    ValueTask<bool> IAsyncEnumerator<T>.MoveNextAsync() => new(false);
}

#endif