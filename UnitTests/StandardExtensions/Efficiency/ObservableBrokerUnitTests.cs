using IX.Core.Collections;
using IX.Core.DataGeneration;

namespace UnitTests.StandardExtensions.Efficiency;

public class ObservableBrokerUnitTests
{
    [Fact(DisplayName = "ObservableBroker standard use.")]
    public void Test1()
    {
        // ARRANGE
        TestObservableBroker broker = new();

        IntContainer k = new() { Value = 0 };
        BoolContainer b = new() { Value = false };

        var observer = new TestObserver(
            onNext: i => k.Value = i,
            onCompleted: () => b.Value = true);

        var value = DataGenerator.RandomInteger(
            1,
            int.MaxValue);

        // ACT
        _ = broker.Subscribe(observer);

        broker.SendNext(value);
        broker.SendCompleted();

        // ASSERT
        Assert.Equal(value, k.Value);
        Assert.True(b.Value);
    }

    [Fact(DisplayName = "ObservableBroker completed removal check.")]
    public void Test2()
    {
        // ARRANGE
        TestObservableBroker broker = new();

        IntContainer k = new() { Value = 0 };
        BoolContainer b = new() { Value = false };

        var observer = new TestObserver(
            onNext: i => k.Value = i,
            onCompleted: () => b.Value = true);

        var value = DataGenerator.RandomInteger(
            1,
            int.MaxValue);
        var value2 = DataGenerator.RandomInteger(
            1,
            int.MaxValue);

        while (value == value2)
        {
            value2 = DataGenerator.RandomInteger(
                1,
                int.MaxValue);
        }

        // ACT
        _ = broker.Subscribe(observer);

        broker.SendNext(value);
        broker.SendCompleted();
        broker.SendNext(value2);

        // ASSERT
        Assert.Equal(value, k.Value);
        Assert.True(b.Value);
        Assert.NotEqual(value2, k.Value);
    }

    [Fact(DisplayName = "ObservableBroker dispose removal check.")]
    public void Test3()
    {
        // ARRANGE
        TestObservableBroker broker = new();

        IntContainer k = new() { Value = 0 };
        BoolContainer b = new() { Value = false };

        var observer = new TestObserver(
            onNext: i => k.Value = i,
            onCompleted: () => b.Value = true);

        var value = DataGenerator.RandomInteger(
            1,
            int.MaxValue);

        // ACT
        _ = broker.Subscribe(observer);

        broker.SendNext(value);
        broker.Dispose();

        // ASSERT
        Assert.Equal(value, k.Value);
        Assert.True(b.Value);
    }

    [Fact(DisplayName = "ObservableBroker setting avoid removal check.")]
    public void Test4()
    {
        // ARRANGE
        TestObservableBroker broker = new(
            new()
            {
                KeepObserverReferencesAfterSendingFinished = true
            });

        IntContainer k = new() { Value = 0 };
        BoolContainer b = new() { Value = false };

        var observer = new TestObserver(
            onNext: i => k.Value = i,
            onCompleted: () => b.Value = true);

        var value = DataGenerator.RandomInteger(
            1,
            int.MaxValue);
        var value2 = DataGenerator.RandomInteger(
            1,
            int.MaxValue);

        while (value == value2)
        {
            value2 = DataGenerator.RandomInteger(
                1,
                int.MaxValue);
        }

        // ACT
        _ = broker.Subscribe(observer);

        broker.SendNext(value);
        broker.SendCompleted();
        broker.SendNext(value2);

        // ASSERT
        Assert.NotEqual(value, k.Value);
        Assert.True(b.Value);
        Assert.Equal(value2, k.Value);
    }

    [Fact(DisplayName = "ObservableBroker dispose removal check.")]
    public void Test5()
    {
        // ARRANGE
        TestObservableBroker broker = new(new() { DontSendCompletedWhenDisposing = true});

        IntContainer k = new() { Value = 0 };
        BoolContainer b = new() { Value = false };

        var observer = new TestObserver(
            onNext: i => k.Value = i,
            onCompleted: () => b.Value = true);

        var value = DataGenerator.RandomInteger(
            1,
            int.MaxValue);

        // ACT
        _ = broker.Subscribe(observer);

        broker.SendNext(value);
        broker.Dispose();

        // ASSERT
        Assert.Equal(value, k.Value);
        Assert.False(b.Value);
    }

    [Fact(DisplayName = "ObservableBroker standard error use.")]
    public void Test6()
    {
        // ARRANGE
        TestObservableBroker broker = new();

        var value = DataGenerator.RandomAlphanumericString(20);
        ExceptionContainer ec = new();

        var observer = new TestObserver(
            onError: exception => ec.Value = exception);

        // ACT
        _ = broker.Subscribe(observer);

        broker.SendError(new(value));

        // ASSERT
        Assert.Equal(value, ec.Value?.Message);
    }

    private class TestObservableBroker : ObservableBroker<int>
    {
        public TestObservableBroker()
        {}

        public TestObservableBroker(Settings setting)
        : base(setting)
        {}

        internal new void SendNext(int next) => base.SendNext(next);

        internal new void SendError(Exception ex) => base.SendError(ex);

        internal new void SendCompleted() => base.SendCompleted();
    }

    private class TestObserver : IObserver<int>
    {
        private readonly Action? _onCompleted;
        private readonly Action<Exception>? _onError;
        private readonly Action<int>? _onNext;

        public TestObserver(
            Action? onCompleted = null,
            Action<Exception>? onError = null,
            Action<int>? onNext = null)
        {
            _onCompleted = onCompleted;
            _onError = onError;
            _onNext = onNext;
        }

        /// <summary>Notifies the observer that the provider has finished sending push-based notifications.</summary>
        public void OnCompleted() => _onCompleted?.Invoke();

        /// <summary>Notifies the observer that the provider has experienced an error condition.</summary>
        /// <param name="error">An object that provides additional information about the error.</param>
        public void OnError(Exception error) => _onError?.Invoke(error);

        /// <summary>Provides the observer with new data.</summary>
        /// <param name="value">The current notification information.</param>
        public void OnNext(int value) => _onNext?.Invoke(value);
    }

    private record IntContainer
    {
        public int Value { get; set; }
    }

    private record BoolContainer
    {
        public bool Value { get; set; }
    }

    private record ExceptionContainer
    {
        public Exception? Value { get; set; }
    }
}