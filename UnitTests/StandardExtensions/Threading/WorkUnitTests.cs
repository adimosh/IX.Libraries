using IX.Library.DataGeneration;

using Xunit.Abstractions;

using ManualResetEventSlim = IX.Library.Threading.ManualResetEventSlim;

namespace UnitTests.StandardExtensions.Threading;

/// <summary>
/// Unit tests for <see cref="Work"/>.
/// </summary>
public class WorkUnitTests
{
    private const int MaxWaitTime = 5000;
    private const int StandardWaitTime = 300;
    private readonly ITestOutputHelper _output;

    /// <summary>
    /// Initializes a new instance of the <see cref="WorkUnitTests"/> class.
    /// </summary>
    /// <param name="output">The test output.</param>
    public WorkUnitTests(ITestOutputHelper output) => this._output = output ?? throw new ArgumentNullException(nameof(output));

    /// <summary>
    /// Test basic Fire.AndForget mechanism.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact(DisplayName = "Test basic Fire.AndForget mechanism")]
    public async Task Test1()
    {
        // ARRANGE
        int initialValue = DataGenerator.RandomInteger();
        int floatingValue = initialValue;
        int waitTime = DataGenerator.RandomNonNegativeInteger(StandardWaitTime) + 1;
        bool result;

        // ACT
        await using (var mre = new ManualResetEventSlim())
        {
            _ = Work.OnThreadPoolAsync(
                ev =>
                {
                    Thread.Sleep(waitTime);

                    _ = Interlocked.Exchange(
                        ref floatingValue,
                        DataGenerator.RandomInteger());

                    _ = ev.Set();
                },
                mre);

            result = await mre.WithTimeout(MaxWaitTime);
        }

        // ASSERT
        try
        {
            Assert.True(result);
            Assert.NotEqual(initialValue, floatingValue);
        }
        catch
        {
            _output.WriteLine("Assert phase failed.");
            _output.WriteLine($"Test parameters: Expected Value: {initialValue}; Actual Value: {floatingValue}; Wait Time: {waitTime}; Wait Result: {result}.");
            throw;
        }
    }

    /// <summary>
    /// Test Fire.AndForget distinct threading mechanism.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact(DisplayName = "Test Fire.AndForget distinct threading mechanism")]
    public async Task Test2()
    {
        // ARRANGE
        int initialValue = Thread.CurrentThread.ManagedThreadId;
        int floatingValue = initialValue;
        int waitTime = DataGenerator.RandomNonNegativeInteger(StandardWaitTime) + 1;
        bool result;

        // ACT
        await using (var mre = new ManualResetEventSlim())
        {
            _ = Work.OnThreadPoolAsync(
                ev =>
                {
                    Thread.Sleep(waitTime);

                    _ = Interlocked.Exchange(
                        ref floatingValue,
                        Thread.CurrentThread.ManagedThreadId);

                    _ = ev.Set();
                },
                mre);

            result = await mre.WithTimeout(MaxWaitTime);
        }

        // ASSERT
        try
        {
            Assert.True(result);
            Assert.NotEqual(initialValue, floatingValue);
        }
        catch
        {
            _output.WriteLine("Assert phase failed.");
            _output.WriteLine($"Test parameters: Expected Value: {initialValue}; Actual Value: {floatingValue}; Wait Time: {waitTime}; Wait Result: {result}.");
            throw;
        }
    }

    /// <summary>
    /// Test Fire.AndForget exception mechanism.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact(DisplayName = "Test Fire.AndForget exception mechanism")]
    public async Task Test3()
    {
        // ARRANGE
        string argumentName = DataGenerator.RandomLowercaseString(
            DataGenerator.RandomInteger(
                5,
                10));
        int waitTime = DataGenerator.RandomNonNegativeInteger(StandardWaitTime) + 1;
        bool result;
        Exception? ex = null;

        // ACT
        await using (var mre = new ManualResetEventSlim())
        {
            #if DEBUG
            DateTime dt = DateTime.UtcNow;
            #endif
            _ = Work.OnThreadPoolAsync(
                state =>
                {
                    #if DEBUG
                    var (dt2, wt2) = state;
                    _output.WriteLine($"Beginning inner method after {(DateTime.UtcNow - dt2).TotalMilliseconds} ms.");
                    Thread.Sleep(wt2);
                    _output.WriteLine($"Inner method wait finished after {(DateTime.UtcNow - dt2).TotalMilliseconds} ms.");
                    #else
                        Thread.Sleep(state);
                    #endif

                    throw new ArgumentNotPositiveIntegerException(argumentName);
                },
                #if DEBUG
                (dt, waitTime)).ContinueWith(
                #else
                    waitTime).ContinueWith(
                #endif
                (task, _) =>
                {
                    #if DEBUG
                    _output.WriteLine($"Exception handler started after {(DateTime.UtcNow - dt).TotalMilliseconds} ms.");
                    #endif
                    Interlocked.Exchange(
                        ref ex,
                        task.Exception);

                    // ReSharper disable once AccessToDisposedClosure - Guaranteed to either not be disposed or not relevant to context anymore at this point
                    mre.Set();
                },
                null,
                TaskContinuationOptions.OnlyOnFaulted);

            result = await mre.WithTimeout(MaxWaitTime);
            #if DEBUG
            _output.WriteLine($"Outer method unlocked after {(DateTime.UtcNow - dt).TotalMilliseconds} ms.");
            #endif
        }

        // ASSERT
        try
        {
            Assert.True(result);
            Assert.NotNull(ex);
            var aggregateException = Assert.IsType<AggregateException>(ex);
            var singleException = Assert.Single(aggregateException.InnerExceptions);
            var anpiex = Assert.IsType<ArgumentNotPositiveIntegerException>(singleException);
            Assert.Equal(argumentName, anpiex.ParamName);
        }
        catch
        {
            _output.WriteLine("Assert phase failed.");
            _output.WriteLine($"Test parameters: Wait Time: {waitTime}; Wait Result: {result}; Resulting exception: {ex?.ToString() ?? "null"}.");
            throw;
        }
    }
}