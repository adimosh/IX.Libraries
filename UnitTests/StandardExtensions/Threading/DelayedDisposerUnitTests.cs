using Xunit.Abstractions;
using EnvironmentSettings = IX.Library.Threading.EnvironmentSettings;

namespace UnitTests.StandardExtensions.Threading;

/// <summary>
/// Unit tests for <see cref="DelayedDisposer"/>.
/// </summary>
public class DelayedDisposerUnitTests
{
    private readonly ITestOutputHelper _output;

    public DelayedDisposerUnitTests(ITestOutputHelper output)
    {
        _output = output ?? throw new ArgumentNullException(nameof(output));

        EnvironmentSettings.DelayedDisposal.DefaultDisposalDelayInMilliseconds = 300;
        DelayedDisposer.EnsureInitialized();
    }

    /// <summary>
    /// Tests DelayedDisposer one instance.
    /// </summary>
    /// <returns>The task representing this test.</returns>
    [Fact(DisplayName = "DelayedDisposer one instance.")]
    public async Task Test1()
    {
        // ARRANGE
        _output.WriteLine("Starting timed test...");
        var dt = new DisposeTester(_output);

        // ACT
        _output.WriteLine("Adding to safe disposer...");
        DelayedDisposer.SafelyDispose(dt);

        // ASSERT
        _output.WriteLine("Checking negative...");
        dt.CheckNegative();

        _output.WriteLine("Waiting for disposal...");
        await dt.WaitForDisposal();

        _output.WriteLine("Checking positive...");
        dt.Check();
        _output.WriteLine("All done. Test should not hang anymore.");
    }

    /// <summary>
    /// Tests DelayedDisposer one instance cast.
    /// </summary>
    /// <returns>The task representing this test.</returns>
    [Fact(DisplayName = "DelayedDisposer one instance cast.", Timeout = 3000)]
    public async Task Test2()
    {
        // ARRANGE
        var dt = new DisposeTester(_output);

        // ACT
        DelayedDisposer.SafelyDispose((IDisposable)dt);

        // ASSERT
        dt.CheckNegative();

        await dt.WaitForDisposal();

        dt.Check();
    }

    /// <summary>
    /// Tests DelayedDisposer multiple instances.
    /// </summary>
    /// <returns>The task representing this test.</returns>
    [Fact(DisplayName = "DelayedDisposer multiple instances.", Timeout = 3000)]
    public async Task Test3()
    {
        // ARRANGE
        var dt = new List<DisposeTester>
        {
            new(_output),
            new(_output),
            new(_output)
        };

        // ACT
        DelayedDisposer.SafelyDispose(dt);

        // ASSERT
        dt.ForEach(p => p.CheckNegative());

        await Task.WhenAll(dt.Select(p => p.WaitForDisposal()));

        dt.ForEach(p => p.Check());
    }

    /// <summary>
    /// Tests DelayedDisposer multiple instances cast.
    /// </summary>
    /// <returns>The task representing this test.</returns>
    [Fact(DisplayName = "DelayedDisposer multiple instances cast.", Timeout = 3000)]
    public async Task Test4()
    {
        // ARRANGE
        var dt = new List<IDisposable>
        {
            new DisposeTester(_output),
            new DisposeTester(_output),
            new DisposeTester(_output)
        };

        // ACT
        DelayedDisposer.SafelyDispose(dt);

        // ASSERT
        dt.ForEach(p => ((DisposeTester)p).CheckNegative());

        await Task.WhenAll(dt.Select(p => ((DisposeTester)p).WaitForDisposal()));

        dt.ForEach(p => ((DisposeTester)p).Check());
    }

    /// <summary>
    /// Tests DelayedDisposer exchange.
    /// </summary>
    /// <returns>The task representing this test.</returns>
    [Fact(DisplayName = "DelayedDisposer exchange.", Timeout = 3000)]
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "IDisposableAnalyzers.Correctness",
        "IDISP001:Dispose created",
        Justification = "Not observed in this case.")]
    public async Task Test5()
    {
        // ARRANGE
        var dt = new DisposeTester(_output);
        var dt2 = new DisposeTester(_output);
        var dtt = dt;

        // ACT
        DelayedDisposer.AtomicExchange(ref dt, dt2);

        // ASSERT
        dtt.CheckNegative();
        dt2.CheckNegative();
        dt.CheckNegative();

        await dtt.WaitForDisposal();

        dtt.Check();
        dt2.CheckNegative();
        dt.CheckNegative();
        Assert.Equal(dt2, dt);
    }

    [Fact(DisplayName = "DelayedDisposer single null")]
    public void Test6() => DelayedDisposer.SafelyDispose((IDisposable?)null);

    [Fact(DisplayName = "DelayedDisposer single null enumerable")]
    public void Test7() => DelayedDisposer.SafelyDispose((IEnumerable<IDisposable?>?)null);

    [Fact(DisplayName = "DelayedDisposer null enumerable")]
    public void Test8() =>
        DelayedDisposer.SafelyDispose(
            [
                null,
                null,
                null
            ]);

    private sealed class DisposeTester(ITestOutputHelper output) : IDisposable
    {
        private readonly TaskCompletionSource<bool> _tcs = new();
        private bool _disposed;

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            output.WriteLine("Dispose was called.");
            _disposed = true;
            _tcs.SetResult(true);
        }

        /// <summary>
        /// Checks whether this instance has been correctly disposed.
        /// </summary>
        public void Check()
        {
            output.WriteLine("Check was called.");
            Assert.True(
                _disposed,
                "The instance has not been disposed.");
        }

        /// <summary>
        /// Checks whether this instance has NOT been disposed.
        /// </summary>
        public void CheckNegative()
        {
            output.WriteLine("CheckNegative was called.");
            Assert.False(
                _disposed,
                "The instance has been disposed.");
        }

        public Task WaitForDisposal() => _tcs.Task;
    }
}