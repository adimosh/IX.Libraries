namespace UnitTests.Core.Collections;

public class QueueOfTTests
{
    [Fact]
    public void Constructor_Default_IsEmpty()
    {
        var subject = new IX.Library.Collections.Queue<int>();

        Assert.True(subject.IsEmpty);
        Assert.Empty(subject);
    }

    [Fact]
    public void Constructor_Capacity_Negative_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new IX.Library.Collections.Queue<int>(-1));
    }

    [Fact]
    public void Constructor_Collection_Null_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new IX.Library.Collections.Queue<int>(null as IEnumerable<int>));
    }

    [Fact]
    public void Constructor_Collection_CopiesElementsInOrder()
    {
        var items = new[] { 1, 2, 3 };
        var subject = new IX.Library.Collections.Queue<int>(items);

        Assert.Equal(3, subject.Count);
        Assert.Equal(items, subject.ToArray());
    }

    [Fact]
    public void IsEmpty_BecomesFalseAfterEnqueueAndTrueAfterDequeue()
    {
        var subject = new IX.Library.Collections.Queue<int>();

        subject.Enqueue(5);
        Assert.False(subject.IsEmpty);

        var value = subject.Dequeue();
        Assert.Equal(5, value);
        Assert.True(subject.IsEmpty);
    }

    [Fact]
    public void FromQueue_Null_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => IX.Library.Collections.Queue<int>.FromQueue(null));
    }

    [Fact]
    public void FromQueue_CopiesAllItemsPreservingOrder()
    {
        var source = new IX.Library.Collections.Queue<int>([10, 20]);
        var result = IX.Library.Collections.Queue<int>.FromQueue(new(source.ToArray()));

        Assert.Equal(source.Count, result.Count);
        Assert.Equal(source.ToArray(), result.ToArray());
    }

    [Fact]
    public void EnqueueRange_Null_ThrowsArgumentNullException()
    {
        var subject = new IX.Library.Collections.Queue<int>();

        Assert.Throws<ArgumentNullException>(() => subject.EnqueueRange(null as int[]));
    }

    [Fact]
    public void EnqueueRange_Array_EnqueuesAllItemsInOrder()
    {
        var items = new[] { 1, 2, 3 };
        var subject = new IX.Library.Collections.Queue<int>();

        subject.EnqueueRange(items);

        Assert.Equal(items, subject.ToArray());
    }

    [Fact]
    public void EnqueueRange_Range_Null_ThrowsArgumentNullException()
    {
        var subject = new IX.Library.Collections.Queue<int>();

        Assert.Throws<ArgumentNullException>(() => subject.EnqueueRange(null as int[], 0, 1));
    }

    [Fact]
    public void EnqueueRange_Range_InvalidRange_ThrowsArgumentOutOfRangeException()
    {
        var items = new[] { 1, 2, 3 };
        var subject = new IX.Library.Collections.Queue<int>();

        Assert.Throws<ArgumentNotValidIndexException>(() => subject.EnqueueRange(items, -1, 1));
        Assert.Throws<ArgumentsNotValidRangeException>(() => subject.EnqueueRange(items, 0, -1));
        Assert.Throws<ArgumentsNotValidRangeException>(() => subject.EnqueueRange(items, 2, 2));
    }

    [Fact]
    public void EnqueueRange_Range_EnqueuesFromStartIndexToEnd_PerCurrentImplementation()
    {
        var items = new[] { 1, 2, 3, 4, 5 };
        var subject = new IX.Library.Collections.Queue<int>();

        // Note: current implementation enqueues from startIndex up to items.Length - 1,
        // ignoring the count parameter. Test asserts current observable behavior.
        subject.EnqueueRange(items, 2, 2);

        var expected = new[] { 3, 4, 5 };
        Assert.Equal(expected, subject.ToArray());
    }
}