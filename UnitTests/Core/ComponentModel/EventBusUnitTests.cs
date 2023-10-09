using IX.Library.ComponentModel.Events;

using ManualResetEventSlim = IX.Library.Threading.ManualResetEventSlim;

namespace UnitTests.Core.ComponentModel;

public class EventBusUnitTests
{
    [Fact(DisplayName = "EventBus simple pub/sub scenario on background thread.")]
    public void Test1()
    {
        // ARRANGE
        using EventBus<string> eventBus = new();
        ManualResetEventSlim mre1 = new ManualResetEventSlim();
        ManualResetEventSlim mre2 = new ManualResetEventSlim();
        TestConditionObject testObject = new();

        var @event = eventBus.GetEvent("aaa");

        @event.Subscribe(
            (
                sender,
                args) =>
            {
                mre1.WaitOne();

                testObject.IsTriggered = true;

                mre2.Set();

                // ASSERT 2
                Assert.Same(
                    sender,
                    this);
                Assert.Same(
                    args,
                    EventArgs.Empty);
            });

        // ACT
        @event.Publish(this, EventArgs.Empty);

        // ASSERT 1
        Assert.False(testObject.IsTriggered);
        mre1.Set();
        var notDeadlocked = mre2.WaitOne(TimeSpan.FromMilliseconds(500));
        Assert.True(notDeadlocked);
        Assert.True(testObject.IsTriggered);
    }

    [Fact(DisplayName = "EventBus simple pub/sub scenario on publisher thread.")]
    public void Test2()
    {
        // ARRANGE
        using EventBus<string> eventBus = new();
        TestConditionObject testObject = new();

        var @event = eventBus.GetEvent("aaa");

        @event.Subscribe(
            (
                sender,
                args) =>
            {
                Thread.Sleep(100);

                testObject.IsTriggered = true;

                // ASSERT 1
                Assert.Same(
                    sender,
                    this);
                Assert.Same(
                    args,
                    EventArgs.Empty);
            }, EventSubscriptionSynchronizationOptions.SynchronousWithPublisherThread);

        // ACT
        @event.Publish(this, EventArgs.Empty);

        // ASSERT 2
        Assert.True(testObject.IsTriggered);
    }

    private class TestConditionObject
    {
        public bool IsTriggered { get; set; }
    }
}