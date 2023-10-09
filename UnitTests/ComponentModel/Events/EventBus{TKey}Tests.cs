using IX.Library.ComponentModel.Events;

using ManualResetEventSlim = IX.Library.Threading.ManualResetEventSlim;

namespace UnitTests.ComponentModel.Events;

/// <summary>
/// Unit tests for the type <see cref="EventBus{TKey}"/>.
/// </summary>
public class EventBus_1Tests
{
    private readonly EventBus<string> _testClass;
    private readonly IFixture _fixture;
    private readonly SynchronizationContext _synchronizationContext;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="EventBus{TKey}"/>.
    /// </summary>
    public EventBus_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        _synchronizationContext = _fixture.Create<SynchronizationContext>();
        _testClass = _fixture.Create<EventBus<string>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [Fact(DisplayName = "EventBus can call constructor.")]
    public void CanConstruct()
    {
        // Act
        var instance = new EventBus<string>();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new(_synchronizationContext);

        // Assert
        instance.Should().NotBeNull();
    }

    [Fact(DisplayName = "EventBus simple pub/sub scenario on background thread.")]
    public void CanDoPubSubOnBackgroundThread()
    {
        // ARRANGE
        ManualResetEventSlim mre1 = new ManualResetEventSlim();
        ManualResetEventSlim mre2 = new ManualResetEventSlim();
        TestConditionObject testObject = new();

        var @event = _testClass.GetEvent(nameof(CanDoPubSubOnBackgroundThread));

        @event.Subscribe(
            (
                sender,
                args) =>
            {
                mre1.WaitOne();

                testObject.IsTriggered = true;

                mre2.Set();

                // ASSERT 2
                sender.Should().BeSameAs(this);
                args.Should().BeSameAs(EventArgs.Empty);
            });

        // ACT
        @event.Publish(this, EventArgs.Empty);

        // ASSERT 1
        testObject.IsTriggered.Should().BeFalse();
        mre1.Set();
        var notDeadlocked = mre2.WaitOne(TimeSpan.FromMilliseconds(500));
        notDeadlocked.Should().BeTrue();
        testObject.IsTriggered.Should().BeTrue();
    }

    [Fact(DisplayName = "EventBus simple pub/sub scenario on publisher thread.")]
    public void CanDoPubSubOnPublisherThread()
    {
        // ARRANGE
        TestConditionObject testObject = new();

        var @event = _testClass.GetEvent(nameof(CanDoPubSubOnPublisherThread));

        @event.Subscribe(
            (
                sender,
                args) =>
            {
                Thread.Sleep(100);

                testObject.IsTriggered = true;

                // ASSERT 1
                sender.Should().BeSameAs(this);
                args.Should().BeSameAs(EventArgs.Empty);
            }, EventSubscriptionSynchronizationOptions.SynchronousWithPublisherThread);

        // ACT
        @event.Publish(this, EventArgs.Empty);

        // ASSERT 2
        testObject.IsTriggered.Should().BeTrue();
    }

    private class TestConditionObject
    {
        public bool IsTriggered { get; set; }
    }
}