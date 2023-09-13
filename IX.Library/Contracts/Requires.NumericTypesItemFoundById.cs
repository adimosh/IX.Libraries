using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using IX.Library.Entities;

namespace IX.Library.Contracts;

/// <summary>
///     Methods for approximating the works of contract-oriented programming.
/// </summary>
public static partial class Requires
{
    /// <summary>
    ///     Called when a contract requires that an item is found by its identifier.
    /// </summary>
    /// <param name="source">The items source.</param>
    /// <param name="id">The identifier to seek.</param>
    /// <param name="sourceName">The name of the source collection to seek in.</param>
    /// <param name="idName">The name of the identifier parameter.</param>
    /// <typeparam name="TItem">The type of keyed item in the collection.</typeparam>
    /// <returns>The item that was found.</returns>
    /// <exception cref="ArgumentNullException">Either the source collection or the identifier are <c>null</c> (<c>Nothing</c> in Visual Basic).</exception>
    /// <exception cref="ArgumentNotPositiveException">The supplied identifier is not, as convention dictates, a positive number.</exception>
    /// <exception cref="IdCorrespondsToNoItemException">There is no usable item in the source collection that can be fetched by the supplied identifier.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("source:null => halt; id:null => halt")]
    [AssertionMethod]
    [SuppressMessage(
        "Performance",
        "HAA0301:Closure Allocation Source",
        Justification = "LINQ used, unavoidable.")]
    [SuppressMessage(
        "Performance",
        "HAA0303:Lambda or anonymous method in a generic method allocates a delegate instance",
        Justification = "LINQ used, unavoidable.")]
    [SuppressMessage(
        "Performance",
        "HAA0302:Display class allocation to capture closure",
        Justification = "LINQ used, unavoidable.")]
    public static TItem ItemFoundById<TItem>(
        IEnumerable<TItem> source,
        byte id,
        [CallerArgumentExpression("source")]
        string sourceName = "source",
        [CallerArgumentExpression("id")]
        string idName = "id")
        where TItem : IKeyedEntity<byte>
    {
        if (source == null)
        {
            throw new ArgumentNullException(sourceName);
        }

        if (id <= 0)
        {
            throw new ArgumentNotPositiveException(idName);
        }

        var item = source.FirstOrDefault(p => p.Id == id);

        if (item is null || EqualityComparer<TItem>.Default.Equals(item, default!))
        {
            throw new IdCorrespondsToNoItemException(idName);
        }

        return item;
    }

    /// <summary>
    ///     Called when a contract requires that an item is found by its identifier.
    /// </summary>
    /// <param name="source">The items source.</param>
    /// <param name="id">The identifier to seek.</param>
    /// <param name="sourceName">The name of the source collection to seek in.</param>
    /// <param name="idName">The name of the identifier parameter.</param>
    /// <typeparam name="TItem">The type of keyed item in the collection.</typeparam>
    /// <returns>The item that was found.</returns>
    /// <exception cref="ArgumentNullException">Either the source collection or the identifier are <c>null</c> (<c>Nothing</c> in Visual Basic).</exception>
    /// <exception cref="ArgumentNotPositiveException">The supplied identifier is not, as convention dictates, a positive number.</exception>
    /// <exception cref="IdCorrespondsToNoItemException">There is no usable item in the source collection that can be fetched by the supplied identifier.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("source:null => halt; id:null => halt")]
    [AssertionMethod]
    [SuppressMessage(
        "Performance",
        "HAA0301:Closure Allocation Source",
        Justification = "LINQ used, unavoidable.")]
    [SuppressMessage(
        "Performance",
        "HAA0303:Lambda or anonymous method in a generic method allocates a delegate instance",
        Justification = "LINQ used, unavoidable.")]
    [SuppressMessage(
        "Performance",
        "HAA0302:Display class allocation to capture closure",
        Justification = "LINQ used, unavoidable.")]
    public static TItem ItemFoundById<TItem>(
        IEnumerable<TItem> source,
        sbyte id,
        [CallerArgumentExpression("source")]
        string sourceName = "source",
        [CallerArgumentExpression("id")]
        string idName = "id")
        where TItem : IKeyedEntity<sbyte>
    {
        if (source == null)
        {
            throw new ArgumentNullException(sourceName);
        }

        if (id <= 0)
        {
            throw new ArgumentNotPositiveException(idName);
        }

        var item = source.FirstOrDefault(p => p.Id == id);

        if (item is null || EqualityComparer<TItem>.Default.Equals(item, default!))
        {
            throw new IdCorrespondsToNoItemException(idName);
        }

        return item;
    }

    /// <summary>
    ///     Called when a contract requires that an item is found by its identifier.
    /// </summary>
    /// <param name="source">The items source.</param>
    /// <param name="id">The identifier to seek.</param>
    /// <param name="sourceName">The name of the source collection to seek in.</param>
    /// <param name="idName">The name of the identifier parameter.</param>
    /// <typeparam name="TItem">The type of keyed item in the collection.</typeparam>
    /// <returns>The item that was found.</returns>
    /// <exception cref="ArgumentNullException">Either the source collection or the identifier are <c>null</c> (<c>Nothing</c> in Visual Basic).</exception>
    /// <exception cref="ArgumentNotPositiveException">The supplied identifier is not, as convention dictates, a positive number.</exception>
    /// <exception cref="IdCorrespondsToNoItemException">There is no usable item in the source collection that can be fetched by the supplied identifier.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("source:null => halt; id:null => halt")]
    [AssertionMethod]
    [SuppressMessage(
        "Performance",
        "HAA0301:Closure Allocation Source",
        Justification = "LINQ used, unavoidable.")]
    [SuppressMessage(
        "Performance",
        "HAA0303:Lambda or anonymous method in a generic method allocates a delegate instance",
        Justification = "LINQ used, unavoidable.")]
    [SuppressMessage(
        "Performance",
        "HAA0302:Display class allocation to capture closure",
        Justification = "LINQ used, unavoidable.")]
    public static TItem ItemFoundById<TItem>(
        IEnumerable<TItem> source,
        short id,
        [CallerArgumentExpression("source")]
        string sourceName = "source",
        [CallerArgumentExpression("id")]
        string idName = "id")
        where TItem : IKeyedEntity<short>
    {
        if (source == null)
        {
            throw new ArgumentNullException(sourceName);
        }

        if (id <= 0)
        {
            throw new ArgumentNotPositiveException(idName);
        }

        var item = source.FirstOrDefault(p => p.Id == id);

        if (item is null || EqualityComparer<TItem>.Default.Equals(item, default!))
        {
            throw new IdCorrespondsToNoItemException(idName);
        }

        return item;
    }

    /// <summary>
    ///     Called when a contract requires that an item is found by its identifier.
    /// </summary>
    /// <param name="source">The items source.</param>
    /// <param name="id">The identifier to seek.</param>
    /// <param name="sourceName">The name of the source collection to seek in.</param>
    /// <param name="idName">The name of the identifier parameter.</param>
    /// <typeparam name="TItem">The type of keyed item in the collection.</typeparam>
    /// <returns>The item that was found.</returns>
    /// <exception cref="ArgumentNullException">Either the source collection or the identifier are <c>null</c> (<c>Nothing</c> in Visual Basic).</exception>
    /// <exception cref="ArgumentNotPositiveException">The supplied identifier is not, as convention dictates, a positive number.</exception>
    /// <exception cref="IdCorrespondsToNoItemException">There is no usable item in the source collection that can be fetched by the supplied identifier.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("source:null => halt; id:null => halt")]
    [AssertionMethod]
    [SuppressMessage(
        "Performance",
        "HAA0301:Closure Allocation Source",
        Justification = "LINQ used, unavoidable.")]
    [SuppressMessage(
        "Performance",
        "HAA0303:Lambda or anonymous method in a generic method allocates a delegate instance",
        Justification = "LINQ used, unavoidable.")]
    [SuppressMessage(
        "Performance",
        "HAA0302:Display class allocation to capture closure",
        Justification = "LINQ used, unavoidable.")]
    public static TItem ItemFoundById<TItem>(
        IEnumerable<TItem> source,
        ushort id,
        [CallerArgumentExpression("source")]
        string sourceName = "source",
        [CallerArgumentExpression("id")]
        string idName = "id")
        where TItem : IKeyedEntity<ushort>
    {
        if (source == null)
        {
            throw new ArgumentNullException(sourceName);
        }

        if (id <= 0)
        {
            throw new ArgumentNotPositiveException(idName);
        }

        var item = source.FirstOrDefault(p => p.Id == id);

        if (item is null || EqualityComparer<TItem>.Default.Equals(item, default!))
        {
            throw new IdCorrespondsToNoItemException(idName);
        }

        return item;
    }

    /// <summary>
    ///     Called when a contract requires that an item is found by its identifier.
    /// </summary>
    /// <param name="source">The items source.</param>
    /// <param name="id">The identifier to seek.</param>
    /// <param name="sourceName">The name of the source collection to seek in.</param>
    /// <param name="idName">The name of the identifier parameter.</param>
    /// <typeparam name="TItem">The type of keyed item in the collection.</typeparam>
    /// <returns>The item that was found.</returns>
    /// <exception cref="ArgumentNullException">Either the source collection or the identifier are <c>null</c> (<c>Nothing</c> in Visual Basic).</exception>
    /// <exception cref="ArgumentNotPositiveException">The supplied identifier is not, as convention dictates, a positive number.</exception>
    /// <exception cref="IdCorrespondsToNoItemException">There is no usable item in the source collection that can be fetched by the supplied identifier.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("source:null => halt; id:null => halt")]
    [AssertionMethod]
    [SuppressMessage(
        "Performance",
        "HAA0301:Closure Allocation Source",
        Justification = "LINQ used, unavoidable.")]
    [SuppressMessage(
        "Performance",
        "HAA0303:Lambda or anonymous method in a generic method allocates a delegate instance",
        Justification = "LINQ used, unavoidable.")]
    [SuppressMessage(
        "Performance",
        "HAA0302:Display class allocation to capture closure",
        Justification = "LINQ used, unavoidable.")]
    public static TItem ItemFoundById<TItem>(
        IEnumerable<TItem> source,
        char id,
        [CallerArgumentExpression("source")]
        string sourceName = "source",
        [CallerArgumentExpression("id")]
        string idName = "id")
        where TItem : IKeyedEntity<char>
    {
        if (source == null)
        {
            throw new ArgumentNullException(sourceName);
        }

        if (id <= 0)
        {
            throw new ArgumentNotPositiveException(idName);
        }

        var item = source.FirstOrDefault(p => p.Id == id);

        if (item is null || EqualityComparer<TItem>.Default.Equals(item, default!))
        {
            throw new IdCorrespondsToNoItemException(idName);
        }

        return item;
    }

    /// <summary>
    ///     Called when a contract requires that an item is found by its identifier.
    /// </summary>
    /// <param name="source">The items source.</param>
    /// <param name="id">The identifier to seek.</param>
    /// <param name="sourceName">The name of the source collection to seek in.</param>
    /// <param name="idName">The name of the identifier parameter.</param>
    /// <typeparam name="TItem">The type of keyed item in the collection.</typeparam>
    /// <returns>The item that was found.</returns>
    /// <exception cref="ArgumentNullException">Either the source collection or the identifier are <c>null</c> (<c>Nothing</c> in Visual Basic).</exception>
    /// <exception cref="ArgumentNotPositiveException">The supplied identifier is not, as convention dictates, a positive number.</exception>
    /// <exception cref="IdCorrespondsToNoItemException">There is no usable item in the source collection that can be fetched by the supplied identifier.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("source:null => halt; id:null => halt")]
    [AssertionMethod]
    [SuppressMessage(
        "Performance",
        "HAA0301:Closure Allocation Source",
        Justification = "LINQ used, unavoidable.")]
    [SuppressMessage(
        "Performance",
        "HAA0303:Lambda or anonymous method in a generic method allocates a delegate instance",
        Justification = "LINQ used, unavoidable.")]
    [SuppressMessage(
        "Performance",
        "HAA0302:Display class allocation to capture closure",
        Justification = "LINQ used, unavoidable.")]
    public static TItem ItemFoundById<TItem>(
        IEnumerable<TItem> source,
        int id,
        [CallerArgumentExpression("source")]
        string sourceName = "source",
        [CallerArgumentExpression("id")]
        string idName = "id")
        where TItem : IKeyedEntity<int>
    {
        if (source == null)
        {
            throw new ArgumentNullException(sourceName);
        }

        if (id <= 0)
        {
            throw new ArgumentNotPositiveException(idName);
        }

        var item = source.FirstOrDefault(p => p.Id == id);

        if (item is null || EqualityComparer<TItem>.Default.Equals(item, default!))
        {
            throw new IdCorrespondsToNoItemException(idName);
        }

        return item;
    }

    /// <summary>
    ///     Called when a contract requires that an item is found by its identifier.
    /// </summary>
    /// <param name="source">The items source.</param>
    /// <param name="id">The identifier to seek.</param>
    /// <param name="sourceName">The name of the source collection to seek in.</param>
    /// <param name="idName">The name of the identifier parameter.</param>
    /// <typeparam name="TItem">The type of keyed item in the collection.</typeparam>
    /// <returns>The item that was found.</returns>
    /// <exception cref="ArgumentNullException">Either the source collection or the identifier are <c>null</c> (<c>Nothing</c> in Visual Basic).</exception>
    /// <exception cref="ArgumentNotPositiveException">The supplied identifier is not, as convention dictates, a positive number.</exception>
    /// <exception cref="IdCorrespondsToNoItemException">There is no usable item in the source collection that can be fetched by the supplied identifier.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("source:null => halt; id:null => halt")]
    [AssertionMethod]
    [SuppressMessage(
        "Performance",
        "HAA0301:Closure Allocation Source",
        Justification = "LINQ used, unavoidable.")]
    [SuppressMessage(
        "Performance",
        "HAA0303:Lambda or anonymous method in a generic method allocates a delegate instance",
        Justification = "LINQ used, unavoidable.")]
    [SuppressMessage(
        "Performance",
        "HAA0302:Display class allocation to capture closure",
        Justification = "LINQ used, unavoidable.")]
    public static TItem ItemFoundById<TItem>(
        IEnumerable<TItem> source,
        uint id,
        [CallerArgumentExpression("source")]
        string sourceName = "source",
        [CallerArgumentExpression("id")]
        string idName = "id")
        where TItem : IKeyedEntity<uint>
    {
        if (source == null)
        {
            throw new ArgumentNullException(sourceName);
        }

        if (id <= 0)
        {
            throw new ArgumentNotPositiveException(idName);
        }

        var item = source.FirstOrDefault(p => p.Id == id);

        if (item is null || EqualityComparer<TItem>.Default.Equals(item, default!))
        {
            throw new IdCorrespondsToNoItemException(idName);
        }

        return item;
    }

    /// <summary>
    ///     Called when a contract requires that an item is found by its identifier.
    /// </summary>
    /// <param name="source">The items source.</param>
    /// <param name="id">The identifier to seek.</param>
    /// <param name="sourceName">The name of the source collection to seek in.</param>
    /// <param name="idName">The name of the identifier parameter.</param>
    /// <typeparam name="TItem">The type of keyed item in the collection.</typeparam>
    /// <returns>The item that was found.</returns>
    /// <exception cref="ArgumentNullException">Either the source collection or the identifier are <c>null</c> (<c>Nothing</c> in Visual Basic).</exception>
    /// <exception cref="ArgumentNotPositiveException">The supplied identifier is not, as convention dictates, a positive number.</exception>
    /// <exception cref="IdCorrespondsToNoItemException">There is no usable item in the source collection that can be fetched by the supplied identifier.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("source:null => halt; id:null => halt")]
    [AssertionMethod]
    [SuppressMessage(
        "Performance",
        "HAA0301:Closure Allocation Source",
        Justification = "LINQ used, unavoidable.")]
    [SuppressMessage(
        "Performance",
        "HAA0303:Lambda or anonymous method in a generic method allocates a delegate instance",
        Justification = "LINQ used, unavoidable.")]
    [SuppressMessage(
        "Performance",
        "HAA0302:Display class allocation to capture closure",
        Justification = "LINQ used, unavoidable.")]
    public static TItem ItemFoundById<TItem>(
        IEnumerable<TItem> source,
        long id,
        [CallerArgumentExpression("source")]
        string sourceName = "source",
        [CallerArgumentExpression("id")]
        string idName = "id")
        where TItem : IKeyedEntity<long>
    {
        if (source == null)
        {
            throw new ArgumentNullException(sourceName);
        }

        if (id <= 0)
        {
            throw new ArgumentNotPositiveException(idName);
        }

        var item = source.FirstOrDefault(p => p.Id == id);

        if (item is null || EqualityComparer<TItem>.Default.Equals(item, default!))
        {
            throw new IdCorrespondsToNoItemException(idName);
        }

        return item;
    }

    /// <summary>
    ///     Called when a contract requires that an item is found by its identifier.
    /// </summary>
    /// <param name="source">The items source.</param>
    /// <param name="id">The identifier to seek.</param>
    /// <param name="sourceName">The name of the source collection to seek in.</param>
    /// <param name="idName">The name of the identifier parameter.</param>
    /// <typeparam name="TItem">The type of keyed item in the collection.</typeparam>
    /// <returns>The item that was found.</returns>
    /// <exception cref="ArgumentNullException">Either the source collection or the identifier are <c>null</c> (<c>Nothing</c> in Visual Basic).</exception>
    /// <exception cref="ArgumentNotPositiveException">The supplied identifier is not, as convention dictates, a positive number.</exception>
    /// <exception cref="IdCorrespondsToNoItemException">There is no usable item in the source collection that can be fetched by the supplied identifier.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("source:null => halt; id:null => halt")]
    [AssertionMethod]
    [SuppressMessage(
        "Performance",
        "HAA0301:Closure Allocation Source",
        Justification = "LINQ used, unavoidable.")]
    [SuppressMessage(
        "Performance",
        "HAA0303:Lambda or anonymous method in a generic method allocates a delegate instance",
        Justification = "LINQ used, unavoidable.")]
    [SuppressMessage(
        "Performance",
        "HAA0302:Display class allocation to capture closure",
        Justification = "LINQ used, unavoidable.")]
    public static TItem ItemFoundById<TItem>(
        IEnumerable<TItem> source,
        ulong id,
        [CallerArgumentExpression("source")]
        string sourceName = "source",
        [CallerArgumentExpression("id")]
        string idName = "id")
        where TItem : IKeyedEntity<ulong>
    {
        if (source == null)
        {
            throw new ArgumentNullException(sourceName);
        }

        if (id <= 0)
        {
            throw new ArgumentNotPositiveException(idName);
        }

        var item = source.FirstOrDefault(p => p.Id == id);

        if (item is null || EqualityComparer<TItem>.Default.Equals(item, default!))
        {
            throw new IdCorrespondsToNoItemException(idName);
        }

        return item;
    }

    /// <summary>
    ///     Called when a contract requires that an item is found by its identifier.
    /// </summary>
    /// <param name="source">The items source.</param>
    /// <param name="id">The identifier to seek.</param>
    /// <param name="sourceName">The name of the source collection to seek in.</param>
    /// <param name="idName">The name of the identifier parameter.</param>
    /// <typeparam name="TItem">The type of keyed item in the collection.</typeparam>
    /// <returns>The item that was found.</returns>
    /// <exception cref="ArgumentNullException">Either the source collection or the identifier are <c>null</c> (<c>Nothing</c> in Visual Basic).</exception>
    /// <exception cref="ArgumentNotPositiveException">The supplied identifier is not, as convention dictates, a positive number.</exception>
    /// <exception cref="IdCorrespondsToNoItemException">There is no usable item in the source collection that can be fetched by the supplied identifier.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("source:null => halt; id:null => halt")]
    [AssertionMethod]
    [SuppressMessage(
        "Performance",
        "HAA0301:Closure Allocation Source",
        Justification = "LINQ used, unavoidable.")]
    [SuppressMessage(
        "Performance",
        "HAA0303:Lambda or anonymous method in a generic method allocates a delegate instance",
        Justification = "LINQ used, unavoidable.")]
    [SuppressMessage(
        "Performance",
        "HAA0302:Display class allocation to capture closure",
        Justification = "LINQ used, unavoidable.")]
    public static TItem ItemFoundById<TItem>(
        IEnumerable<TItem> source,
        float id,
        [CallerArgumentExpression("source")]
        string sourceName = "source",
        [CallerArgumentExpression("id")]
        string idName = "id")
        where TItem : IKeyedEntity<float>
    {
        if (source == null)
        {
            throw new ArgumentNullException(sourceName);
        }

        if (id <= 0)
        {
            throw new ArgumentNotPositiveException(idName);
        }

        var item = source.FirstOrDefault(p => p.Id == id);

        if (item is null || EqualityComparer<TItem>.Default.Equals(item, default!))
        {
            throw new IdCorrespondsToNoItemException(idName);
        }

        return item;
    }

    /// <summary>
    ///     Called when a contract requires that an item is found by its identifier.
    /// </summary>
    /// <param name="source">The items source.</param>
    /// <param name="id">The identifier to seek.</param>
    /// <param name="sourceName">The name of the source collection to seek in.</param>
    /// <param name="idName">The name of the identifier parameter.</param>
    /// <typeparam name="TItem">The type of keyed item in the collection.</typeparam>
    /// <returns>The item that was found.</returns>
    /// <exception cref="ArgumentNullException">Either the source collection or the identifier are <c>null</c> (<c>Nothing</c> in Visual Basic).</exception>
    /// <exception cref="ArgumentNotPositiveException">The supplied identifier is not, as convention dictates, a positive number.</exception>
    /// <exception cref="IdCorrespondsToNoItemException">There is no usable item in the source collection that can be fetched by the supplied identifier.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("source:null => halt; id:null => halt")]
    [AssertionMethod]
    [SuppressMessage(
        "Performance",
        "HAA0301:Closure Allocation Source",
        Justification = "LINQ used, unavoidable.")]
    [SuppressMessage(
        "Performance",
        "HAA0303:Lambda or anonymous method in a generic method allocates a delegate instance",
        Justification = "LINQ used, unavoidable.")]
    [SuppressMessage(
        "Performance",
        "HAA0302:Display class allocation to capture closure",
        Justification = "LINQ used, unavoidable.")]
    public static TItem ItemFoundById<TItem>(
        IEnumerable<TItem> source,
        double id,
        [CallerArgumentExpression("source")]
        string sourceName = "source",
        [CallerArgumentExpression("id")]
        string idName = "id")
        where TItem : IKeyedEntity<double>
    {
        if (source == null)
        {
            throw new ArgumentNullException(sourceName);
        }

        if (id <= 0)
        {
            throw new ArgumentNotPositiveException(idName);
        }

        var item = source.FirstOrDefault(p => p.Id == id);

        if (item is null || EqualityComparer<TItem>.Default.Equals(item, default!))
        {
            throw new IdCorrespondsToNoItemException(idName);
        }

        return item;
    }

    /// <summary>
    ///     Called when a contract requires that an item is found by its identifier.
    /// </summary>
    /// <param name="source">The items source.</param>
    /// <param name="id">The identifier to seek.</param>
    /// <param name="sourceName">The name of the source collection to seek in.</param>
    /// <param name="idName">The name of the identifier parameter.</param>
    /// <typeparam name="TItem">The type of keyed item in the collection.</typeparam>
    /// <returns>The item that was found.</returns>
    /// <exception cref="ArgumentNullException">Either the source collection or the identifier are <c>null</c> (<c>Nothing</c> in Visual Basic).</exception>
    /// <exception cref="ArgumentNotPositiveException">The supplied identifier is not, as convention dictates, a positive number.</exception>
    /// <exception cref="IdCorrespondsToNoItemException">There is no usable item in the source collection that can be fetched by the supplied identifier.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("source:null => halt; id:null => halt")]
    [AssertionMethod]
    [SuppressMessage(
        "Performance",
        "HAA0301:Closure Allocation Source",
        Justification = "LINQ used, unavoidable.")]
    [SuppressMessage(
        "Performance",
        "HAA0303:Lambda or anonymous method in a generic method allocates a delegate instance",
        Justification = "LINQ used, unavoidable.")]
    [SuppressMessage(
        "Performance",
        "HAA0302:Display class allocation to capture closure",
        Justification = "LINQ used, unavoidable.")]
    public static TItem ItemFoundById<TItem>(
        IEnumerable<TItem> source,
        decimal id,
        [CallerArgumentExpression("source")]
        string sourceName = "source",
        [CallerArgumentExpression("id")]
        string idName = "id")
        where TItem : IKeyedEntity<decimal>
    {
        if (source == null)
        {
            throw new ArgumentNullException(sourceName);
        }

        if (id <= 0)
        {
            throw new ArgumentNotPositiveException(idName);
        }

        var item = source.FirstOrDefault(p => p.Id == id);

        if (item is null || EqualityComparer<TItem>.Default.Equals(item, default!))
        {
            throw new IdCorrespondsToNoItemException(idName);
        }

        return item;
    }
}