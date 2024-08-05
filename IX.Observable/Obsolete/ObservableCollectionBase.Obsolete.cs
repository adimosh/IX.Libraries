namespace IX.Observable;

public abstract partial class ObservableCollectionBase<T>
{
    /// <summary>
    ///     Gets a value indicating whether items are key/value pairs.
    /// </summary>
    /// <value><see langword="true" /> if items are key/value pairs; otherwise, <see langword="false" />.</value>
    [Obsolete("This has never been used, is not assigned, and will be removed in the next version with breaking changes.")]
    public bool ItemsAreKeyValuePairs { get; }
}