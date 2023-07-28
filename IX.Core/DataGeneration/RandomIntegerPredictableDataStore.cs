using System.Diagnostics.CodeAnalysis;

namespace IX.Core.DataGeneration;

/// <summary>
///     A data store for storing random integers in a predictable way, such as any iteration through the store will produce
///     the same output. This class is thread-safe, and its internal items container is immutable.
/// </summary>
/// <seealso cref="PredictableDataStore{T}" />
[PublicAPI]
public class RandomIntegerPredictableDataStore : PredictableDataStore<int>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="RandomIntegerPredictableDataStore" /> class.
    /// </summary>
    /// <param name="capacity">The capacity.</param>
    [SuppressMessage(
        "Performance",
        "HAA0603:Delegate allocation from a method group",
        Justification = "Unavoidable.")]
    public RandomIntegerPredictableDataStore(int capacity)
        : base(
            capacity,
            DataGenerator.RandomInteger)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="RandomIntegerPredictableDataStore" /> class.
    /// </summary>
    /// <param name="capacity">The capacity.</param>
    /// <param name="maximumValue">The maximum value.</param>
    [SuppressMessage(
        "Performance",
        "HAA0601:Value type to reference type conversion causing boxing allocation",
        Justification = "Unavoidable.")]
    public RandomIntegerPredictableDataStore(
        int capacity,
        int maximumValue)
        : base(
            capacity,
            state => DataGenerator.RandomInteger((int)state),
            maximumValue)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="RandomIntegerPredictableDataStore" /> class.
    /// </summary>
    /// <param name="capacity">The capacity.</param>
    /// <param name="minimumValue">The minimum value.</param>
    /// <param name="maximumValue">The maximum value.</param>
    [SuppressMessage(
        "Performance",
        "HAA0601:Value type to reference type conversion causing boxing allocation",
        Justification = "Unavoidable.")]
    public RandomIntegerPredictableDataStore(
        int capacity,
        int minimumValue,
        int maximumValue)
        : base(
            capacity,
            state =>
            {
                var (item1, item2) = ((int, int))state;

                return DataGenerator.RandomInteger(
                    item1,
                    item2);
            },
            (minimumValue, maximumValue))
    {
    }
}