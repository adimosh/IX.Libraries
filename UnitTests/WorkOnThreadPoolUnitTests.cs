using IX.Library.DataGeneration;

using Environment = System.Environment;
using ManualResetEventSlim = System.Threading.ManualResetEventSlim;

namespace UnitTests;

/// <summary>
///     Unit tests for working on thread pool.
/// </summary>
public class WorkOnThreadPoolUnitTests
{
    private const int MaxWaitTime = 5000;
    private const int StandardWaitTime = 300;
    private readonly ITestOutputHelper _output;

    /// <summary>
    ///     Initializes a new instance of the <see cref="WorkOnThreadPoolUnitTests" /> class.
    /// </summary>
    /// <param name="output">The test output.</param>
    public WorkOnThreadPoolUnitTests(ITestOutputHelper output) => _output = output ?? throw new ArgumentNullException(nameof(output));

    /// <summary>
    ///     Tests running on the thread pool and, because of a lack of a synchronization context, not returning to the same
    ///     thread.
    /// </summary>
    /// <returns>A <see cref="Task" /> representing the asynchronous unit test.</returns>
    [Fact(DisplayName = "Test running on thread pool and not returning to thread context.")]
    public async Task Test1()
    {
        // ARRANGE
        var currentThreadId = Environment.CurrentManagedThreadId;
        var separateThreadId = currentThreadId;

        void LocalMethod()
        {
            separateThreadId = Environment.CurrentManagedThreadId;
        }

        // ACT
        await Work.OnThreadPoolAsync(
            LocalMethod,
            TestContext.Current.CancellationToken);

        // ASSERT
        Assert.NotEqual(
            currentThreadId,
            separateThreadId);
    }

    /// <summary>
    ///     Test basic Fire.AndForget mechanism.
    /// </summary>
    [Fact(DisplayName = "Test basic Fire.AndForget mechanism")]
    public void Test2()
    {
        // ARRANGE
        var initialValue = DataGenerator.RandomInteger();
        var floatingValue = initialValue;
        var waitTime = DataGenerator.RandomNonNegativeInteger(StandardWaitTime) + 1;
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
                }, mre,
                TestContext.Current.CancellationToken);

            result = mre.Wait(
                MaxWaitTime,
                TestContext.Current.CancellationToken);
        }

        // ASSERT
        try
        {
            Assert.True(result);
            Assert.NotEqual(
                initialValue,
                floatingValue);
        }
        catch
        {
            _output.WriteLine("Assert phase failed.");
            _output.WriteLine(
                $"Test parameters: Expected Value: {initialValue}; Actual Value: {floatingValue}; Wait Time: {waitTime}; Wait Result: {result}.");
            throw;
        }
    }

    /// <summary>
    ///     Test Fire.AndForget distinct threading mechanism.
    /// </summary>
    [Fact(DisplayName = "Test Fire.AndForget distinct threading mechanism")]
    public void Test3()
    {
        // ARRANGE
        var initialValue = Environment.CurrentManagedThreadId;
        var floatingValue = initialValue;
        var waitTime = DataGenerator.RandomNonNegativeInteger(StandardWaitTime) + 1;
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
                        Environment.CurrentManagedThreadId);

                    ev.Set();
                }, mre,
                TestContext.Current.CancellationToken);

            result = mre.Wait(
                MaxWaitTime,
                TestContext.Current.CancellationToken);
        }

        // ASSERT
        try
        {
            Assert.True(result);
            Assert.NotEqual(
                initialValue,
                floatingValue);
        }
        catch
        {
            _output.WriteLine("Assert phase failed.");
            _output.WriteLine(
                $"Test parameters: Expected Value: {initialValue}; Actual Value: {floatingValue}; Wait Time: {waitTime}; Wait Result: {result}.");
            throw;
        }
    }

    /// <summary>
    ///     Test Fire.AndForget exception mechanism.
    /// </summary>
    [Fact(DisplayName = "Test Fire.AndForget exception mechanism")]
    public void Test4()
    {
        // ARRANGE
        var argumentName = DataGenerator.RandomLowercaseString(
            DataGenerator.RandomInteger(
                5,
                10));
        var waitTime = DataGenerator.RandomNonNegativeInteger(StandardWaitTime) + 1;
        bool result;
        Exception? ex = null;

        // ACT
        using (var mre = new ManualResetEventSlim())
        {
            Work.OnThreadPoolAsync(
                () =>
                {
                    Thread.Sleep(waitTime);

                    throw new ArgumentNotPositiveIntegerException(argumentName);
                }, TestContext.Current.CancellationToken).ContinueWith(
                task =>
                {
                    Exception exception = task.Exception!.GetBaseException();
                    Interlocked.Exchange(
                        ref ex,
                        exception);

                    // ReSharper disable once AccessToDisposedClosure - Guaranteed to either not be disposed or not relevant to context anymore at this point
                    mre.Set();
                }, TaskContinuationOptions.OnlyOnFaulted);

            result = mre.Wait(
                MaxWaitTime,
                TestContext.Current.CancellationToken);
        }

        // ASSERT
        try
        {
            Assert.True(result);
            Assert.NotNull(ex);
            Assert.IsType<ArgumentNotPositiveIntegerException>(ex);
            Assert.Equal(
                argumentName,
                ((ArgumentNotPositiveIntegerException)ex).ParamName);
        }
        catch
        {
            _output.WriteLine("Assert phase failed.");
            _output.WriteLine($"Test parameters: Wait Time: {waitTime}; Wait Result: {result}; Resulting exception: {ex?.ToString() ?? "null"}.");
            throw;
        }
    }
}