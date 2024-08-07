// ReSharper disable once CheckNamespace
namespace IX.Observable;

public abstract partial class ObservableCollectionBase<T>
{
    /// <summary>
    ///     Gets a value indicating whether items are key/value pairs.
    /// </summary>
    /// <value><see langword="true" /> if items are key/value pairs; otherwise, <see langword="false" />.</value>
    [Obsolete("This has never been used, is not assigned, and will be removed in the next version with breaking changes.")]
    // ReSharper disable once UnusedMember.Global
    // ReSharper disable once UnassignedGetOnlyAutoProperty
    public bool ItemsAreKeyValuePairs { get; }
}