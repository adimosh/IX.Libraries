using IX.Library.Collections;

namespace UnitTests.System.Collections.Generic;

public class WeakReferenceCollectionUnitTests
{
    [Fact(DisplayName = "WeakReferenceCollection auto-cleanup")]
    public void Test1()
    {
        // ARRANGE
        WeakReferenceCollection<Dummy> collection = new WeakReferenceCollection<Dummy>();

        FillDummyList(collection);

        var sum = 0;

        // ACT
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.WaitForFullGCComplete();
        GC.Collect();

        foreach (var dummy in collection)
        {
            sum += dummy.Field;
        }

        // ASSERT
        Assert.Equal(0, sum);
    }

    [Fact(DisplayName = "WeakReferenceCollection auto-cleanup with some references left")]
    public void Test2()
    {
        // ARRANGE
        WeakReferenceCollection<Dummy> collection = new WeakReferenceCollection<Dummy>();

        FillDummyList(collection);

        collection.Add(new() { Field = 6 });

        var sum = 0;

        // ACT
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.WaitForFullGCComplete();
        GC.Collect();

        foreach (var dummy in collection)
        {
            sum += dummy.Field;
        }

        // ASSERT
        Assert.Equal(6, sum);
    }

    [Fact(DisplayName = "WeakReferenceCollection auto-cleanup with some references deleted")]
    public void Test3()
    {
        // ARRANGE
        WeakReferenceCollection<Dummy> collection = new WeakReferenceCollection<Dummy>();

        FillDummyList(collection);

        collection.Add(new() { Field = 6 });
        collection.Add(new() { Field = 7 });
        var toDelete = new Dummy()
        {
            Field = 8
        };
        collection.Add(toDelete);
        collection.Add(new() { Field = 9 });
        collection.Add(new() { Field = 10 });

        var sum = 0;

        // ACT
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.WaitForFullGCComplete();
        GC.Collect();

        collection.Remove(toDelete);

        foreach (var dummy in collection)
        {
            sum += dummy.Field;
        }

        // ASSERT
        Assert.Equal(32, sum);
    }

    [Fact(DisplayName = "WeakReferenceCollection auto-cleanup with Clear")]
    public void Test4()
    {
        // ARRANGE
        WeakReferenceCollection<Dummy> collection = new WeakReferenceCollection<Dummy>();

        FillDummyList(collection);

        collection.Add(new() { Field = 6 });
        collection.Add(new() { Field = 7 });
        collection.Add(new() { Field = 8 });
        collection.Add(new() { Field = 9 });

        collection.Clear();

        var sum = 0;

        // ACT
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.WaitForFullGCComplete();
        GC.Collect();

        foreach (var dummy in collection)
        {
            sum += dummy.Field;
        }

        // ASSERT
        Assert.Equal(0, sum);
    }

    [Fact(DisplayName = "WeakReferenceCollection auto-cleanup with CopyTo")]
    public void Test5()
    {
        // ARRANGE
        WeakReferenceCollection<Dummy> collection = new WeakReferenceCollection<Dummy>();

        FillDummyList(collection);

        collection.Add(new() { Field = 6 });
        collection.Add(new() { Field = 7 });
        collection.Add(new() { Field = 8 });
        collection.Add(new() { Field = 9 });

        var sum = 0;

        Dummy[] collection2 = new Dummy[4];

        // ACT
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.WaitForFullGCComplete();
        GC.Collect();

        collection.CopyTo(collection2, 0);

        foreach (var dummy in collection2)
        {
            sum += dummy.Field;
        }

        // ASSERT
        Assert.Equal(30, sum);
    }

    [Fact(DisplayName = "WeakReferenceCollection Count before and after auto-cleanup")]
    public void Test6()
    {
        // ARRANGE
        WeakReferenceCollection<Dummy> collection = new WeakReferenceCollection<Dummy>();

        FillDummyList(collection);

        Assert.Equal(5, collection.Count);

        // ACT
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.WaitForFullGCComplete();
        GC.Collect();

        // ASSERT
        Assert.Empty(collection);
    }

    [Fact(DisplayName = "WeakReferenceCollection auto-cleanup Contains")]
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Assertions", "xUnit2017:Do not use Contains() to check if a value exists in a collection", Justification = "<Pending>")]
    public void Test7()
    {
        // ARRANGE
        WeakReferenceCollection<Dummy> collection = new WeakReferenceCollection<Dummy>();

        FillDummyList(collection);

        collection.Add(new() { Field = 6 });
        collection.Add(new() { Field = 7 });
        var toSeek = new Dummy()
        {
            Field = 8
        };
        collection.Add(toSeek);
        collection.Add(new() { Field = 9 });
        collection.Add(new() { Field = 10 });

        Assert.True(collection.Contains(toSeek));

        // ACT
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.WaitForFullGCComplete();
        GC.Collect();

        // ASSERT
        Assert.True(collection.Contains(toSeek));
    }

    private void FillDummyList(WeakReferenceCollection<Dummy> collection)
    {
        collection.Add(new() { Field = 1 });
        collection.Add(new() { Field = 2 });
        collection.Add(new() { Field = 3 });
        collection.Add(new() { Field = 4 });
        collection.Add(new() { Field = 5 });
    }

    private class Dummy
    {
        public int Field { get; init; }
    }
}