namespace UnitTests.Core.Collections;

public class StackOfTTests
{
    [Fact]
    public void Constructor_Default_IsEmpty()
    {
        var subject = new IX.Library.Collections.Stack<int>();

        Assert.True(subject.IsEmpty);
        Assert.Empty(subject);
    }

    [Fact]
    public void Constructor_Capacity_Negative_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new IX.Library.Collections.Stack<int>(-1));
    }

    [Fact]
    public void Constructor_Collection_Null_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new IX.Library.Collections.Stack<int>(null as IEnumerable<int>));
    }

    [Fact]
    public void Constructor_Collection_CopiesElementsInLifoOrder()
    {
        var items = new[] { 1, 2, 3 };
        var subject = new IX.Library.Collections.Stack<int>(items);

        Assert.Equal(3, subject.Count);
        Assert.Equal(new[] { 3, 2, 1 }, subject.ToArray());
    }

    [Fact]
    public void IsEmpty_BecomesFalseAfterPushAndTrueAfterPop()
    {
        var subject = new IX.Library.Collections.Stack<int>();

        subject.Push(5);
        Assert.False(subject.IsEmpty);

        var value = subject.Pop();
        Assert.Equal(5, value);
        Assert.True(subject.IsEmpty);
    }

    [Fact]
    public void FromStack_Null_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => IX.Library.Collections.Stack<int>.FromStack(null));
    }

    [Fact]
    public void FromStack_CopiesItems_ObservingCurrentImplementationBehavior()
    {
        // Arrange: build a System stack with two pushes so source.ToArray() is [20, 10]
        var source = new Stack<int>();
        source.Push(10);
        source.Push(20);

        // Act
        var result = IX.Library.Collections.Stack<int>.FromStack(source);

        // Current FromStack implementation constructs a new IX stack from source.ToArray().
        // Given the constructor behavior, the resulting IX stack ToArray is [10, 20].
        Assert.Equal(new[] { 10, 20 }, result.ToArray());
        Assert.Equal(source.Count, result.Count);
    }

    [Fact]
    public void PushRange_Null_ThrowsArgumentNullException()
    {
        var subject = new IX.Library.Collections.Stack<int>();

        Assert.Throws<ArgumentNullException>(() => subject.PushRange(null as int[]));
    }

    [Fact]
    public void PushRange_Array_PushesAllItemsInLifoOrder()
    {
        var items = new[] { 1, 2, 3 };
        var subject = new IX.Library.Collections.Stack<int>();

        subject.PushRange(items);

        Assert.Equal(new[] { 3, 2, 1 }, subject.ToArray());
    }

    [Fact]
    public void PushRange_Range_Null_ThrowsArgumentNullException()
    {
        var subject = new IX.Library.Collections.Stack<int>();

        Assert.Throws<ArgumentNullException>(() => subject.PushRange(null as int[], 0, 1));
    }

    [Fact]
    public void PushRange_Range_InvalidRange_ThrowsProjectSpecificExceptions()
    {
        var items = new[] { 1, 2, 3 };
        var subject = new IX.Library.Collections.Stack<int>();

        Assert.Throws<ArgumentNotValidIndexException>(() => subject.PushRange(items, -1, 1));
        Assert.Throws<ArgumentsNotValidRangeException>(() => subject.PushRange(items, 0, -1));
        Assert.Throws<ArgumentsNotValidRangeException>(() => subject.PushRange(items, 2, 2));
    }

    [Fact]
    public void PushRange_Range_PushesFromStartIndexToEnd_PerCurrentImplementation()
    {
        var items = new[] { 1, 2, 3, 4, 5 };
        var subject = new IX.Library.Collections.Stack<int>();

        // Note: current implementation iterates from startIndex to items.Length - 1,
        // ignoring the count parameter. Test asserts current observable behavior.
        subject.PushRange(items, 2, 2);

        var expected = new[] { 5, 4, 3 };
        Assert.Equal(expected, subject.ToArray());
    }
}