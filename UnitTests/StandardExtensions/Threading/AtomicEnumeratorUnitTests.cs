using IX.Core.Collections;

namespace UnitTests.StandardExtensions.Threading;

/// <summary>
/// Unit tests for the atomic enumerator.
/// </summary>
public class AtomicEnumeratorUnitTests
{
    /// <summary>
    /// Unit test for the <see cref="AtomicEnumerator{TItem, TEnumerator}"/> correctness of enumeration.
    /// </summary>
    [Fact(DisplayName = "AtomicEnumerator direct instantiation test")]
    public void Test1()
    {
        // ARRANGE
        var q = new List<int>
        {
            1,
            2,
            3,
            4,
            5
        };

        using List<int>.Enumerator enumerator = q.GetEnumerator();

        List<int> newList1 = new(5), newList2 = new(5);

        using var ae = AtomicEnumerator<int>.FromEnumerator(
            enumerator,
            () => new());

        // ACT
        while (ae.MoveNext())
        {
            newList1.Add(ae.Current);
        }

        ae.Reset();

        while (ae.MoveNext())
        {
            newList2.Add(ae.Current);
        }

        // ASSERT
        Assert.True(q.SequenceEquals(newList1));
        Assert.True(q.SequenceEquals(newList2));
    }

    /// <summary>
    /// Unit test for the <see cref="AtomicEnumerator{TItem, TEnumerator}"/> correctness of enumeration.
    /// </summary>
    [Fact(DisplayName = "AtomicEnumerator FromCollection test")]
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "We're dealing with an AtomicEnumerator.")]
    public void Test2()
    {
        // ARRANGE
        var q = new List<int>
        {
            1,
            2,
            3,
            4,
            5
        };

        List<int> newList1 = new(5), newList2 = new(5);

        // ACT
        using var ae = AtomicEnumerator<int>.FromCollection(
            q,
            () => new());

        while (ae.MoveNext())
        {
            newList1.Add(ae.Current);
        }

        ae.Reset();

        while (ae.MoveNext())
        {
            newList2.Add(ae.Current);
        }

        // ASSERT
        Assert.True(q.SequenceEquals(newList1));
        Assert.True(q.SequenceEquals(newList2));
    }

    /// <summary>
    /// Unit test for the <see cref="AtomicEnumerator{TItem, TEnumerator}"/> correctness of enumeration.
    /// </summary>
    [Fact(DisplayName = "AtomicEnumerator FromEnumerator test")]
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "We're dealing with an AtomicEnumerator.")]
    public void Test3()
    {
        // ARRANGE
        var q = new List<int>
        {
            1,
            2,
            3,
            4,
            5
        };

        using List<int>.Enumerator enumerator = q.GetEnumerator();

        List<int> newList1 = new(5), newList2 = new(5);

        // ACT
        using var ae = AtomicEnumerator<int>.FromEnumerator(
            enumerator,
            () => new());

        while (ae.MoveNext())
        {
            newList1.Add(ae.Current);
        }

        ae.Reset();

        while (ae.MoveNext())
        {
            newList2.Add(ae.Current);
        }

        // ASSERT
        Assert.True(q.SequenceEquals(newList1));
        Assert.True(q.SequenceEquals(newList2));
    }
}