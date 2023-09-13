using IX.Library.Contracts;
using IX.Library.DataGeneration;
using IX.Library.Threading;

using Xunit.Abstractions;

using ManualResetEventSlim = System.Threading.ManualResetEventSlim;

namespace UnitTests;

/// <summary>
///     Unit tests for working on thread pool.
/// </summary>
public class WorkOnThreadPoolUnitTests
{
    private const int MaxWaitTime = 5000;
    private const int StandardWaitTime = 300;
    private readonly ITestOutputHelper output;

    /// <summary>
    /// Initializes a new instance of the <see cref="WorkOnThreadPoolUnitTests"/> class.
    /// </summary>
    /// <param name="output">The test output.</param>
    public WorkOnThreadPoolUnitTests(ITestOutputHelper output) => Requires.NotNull(out this.output, output, nameof(output));

    /// <summary>
    ///     Tests running on the thread pool and, because of a lack of a synchronization context, not returning to the same
    ///     thread.
    /// </summary>
    /// <returns>A <see cref="Task" /> representing the asynchronous unit test.</returns>
    [Fact(DisplayName = "Test running on thread pool and not returning to thread context.")]
    public async Task Test1()
    {
        // ARRANGE
        var currentThreadId = Thread.CurrentThread.ManagedThreadId;
        var separateThreadId = currentThreadId;

        void LocalMethod() => separateThreadId = Thread.CurrentThread.ManagedThreadId;

        // ACT
        await Work.OnThreadPoolAsync(LocalMethod);

        // ASSERT
        Assert.NotEqual(
            currentThreadId,
            separateThreadId);
    }

    /// <summary>
    /// Test basic Fire.AndForget mechanism.
    /// </summary>
    [Fact(DisplayName = "Test basic Fire.AndForget mechanism")]
    public void Test2()
    {
        // ARRANGE
        int initialValue = DataGenerator.RandomInteger();
        int floatingValue = initialValue;
        int waitTime = DataGenerator.RandomNonNegativeInteger(StandardWaitTime) + 1;
        bool result;

        // ACT
        using (var mre = new ManualResetEventSlim())
        {
            _ = Work.OnThreadPoolAsync(
                ev =>
                {
                    Thread.Sleep(waitTime);

                    _ = Interlocked.Exchange(
                        ref floatingValue,
                        DataGenerator.RandomInteger());

                    ev.Set();
                },
                mre);

            result = mre.Wait(MaxWaitTime);
        }

        // ASSERT
        try
        {
            Assert.True(result);
            Assert.NotEqual(initialValue, floatingValue);
        }
        catch
        {
            output.WriteLine("Assert phase failed.");
            output.WriteLine($"Test parameters: Expected Value: {initialValue}; Actual Value: {floatingValue}; Wait Time: {waitTime}; Wait Result: {result}.");
            throw;
        }
    }

    /// <summary>
    /// Test Fire.AndForget distinct threading mechanism.
    /// </summary>
    [Fact(DisplayName = "Test Fire.AndForget distinct threading mechanism")]
    public void Test3()
    {
        // ARRANGE
        int initialValue = Thread.CurrentThread.ManagedThreadId;
        int floatingValue = initialValue;
        int waitTime = DataGenerator.RandomNonNegativeInteger(StandardWaitTime) + 1;
        bool result;

        // ACT
        using (var mre = new ManualResetEventSlim())
        {
            _ = Work.OnThreadPoolAsync(
                ev =>
                {
                    Thread.Sleep(waitTime);

                    _ = Interlocked.Exchange(
                        ref floatingValue,
                        Thread.CurrentThread.ManagedThreadId);

                    ev.Set();
                },
                mre);

            result = mre.Wait(MaxWaitTime);
        }

        // ASSERT
        try
        {
            Assert.True(result);
            Assert.NotEqual(initialValue, floatingValue);
        }
        catch
        {
            output.WriteLine("Assert phase failed.");
            output.WriteLine($"Test parameters: Expected Value: {initialValue}; Actual Value: {floatingValue}; Wait Time: {waitTime}; Wait Result: {result}.");
            throw;
        }
    }

    /// <summary>
    /// Test Fire.AndForget exception mechanism.
    /// </summary>
    [Fact(DisplayName = "Test Fire.AndForget exception mechanism")]
    public void Test4()
    {
        // ARRANGE
        string argumentName = DataGenerator.RandomLowercaseString(
            DataGenerator.RandomInteger(
                5,
                10));
        int waitTime = DataGenerator.RandomNonNegativeInteger(StandardWaitTime) + 1;
        bool result;
        Exception ex = null;

        // ACT
        using (var mre = new ManualResetEventSlim())
        {
            #if DEBUG
            DateTime dt = DateTime.UtcNow;
            #endif
            Work.OnThreadPoolAsync(
                () =>
                {
                    #if DEBUG
                    output.WriteLine($"Beginning inner method after {(DateTime.UtcNow - dt).TotalMilliseconds} ms.");
                    #endif
                    Thread.Sleep(waitTime);
                    #if DEBUG
                    output.WriteLine($"Inner method wait finished after {(DateTime.UtcNow - dt).TotalMilliseconds} ms.");
                    #endif

                    throw new ArgumentNotPositiveIntegerException(argumentName);
                }).ContinueWith(
                task =>
                {
                    var exception = task.Exception!.GetBaseException();
                    #if DEBUG
                    output.WriteLine($"Exception handler started after {(DateTime.UtcNow - dt).TotalMilliseconds} ms.");
                    #endif
                    Interlocked.Exchange(
                        ref ex,
                        exception);

                    // ReSharper disable once AccessToDisposedClosure - Guaranteed to either not be disposed or not relevant to context anymore at this point
                    mre.Set();
                },
                TaskContinuationOptions.OnlyOnFaulted);

            result = mre.Wait(MaxWaitTime);
            #if DEBUG
            output.WriteLine($"Outer method unlocked after {(DateTime.UtcNow - dt).TotalMilliseconds} ms.");
            #endif
        }

        // ASSERT
        try
        {
            Assert.True(result);
            Assert.NotNull(ex);
            Assert.IsType<ArgumentNotPositiveIntegerException>(ex);
            Assert.Equal(argumentName, ((ArgumentNotPositiveIntegerException)ex).ParamName);
        }
        catch
        {
            output.WriteLine("Assert phase failed.");
            output.WriteLine($"Test parameters: Wait Time: {waitTime}; Wait Result: {result}; Resulting exception: {ex?.ToString() ?? "null"}.");
            throw;
        }
    }
}