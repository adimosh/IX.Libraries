using IX.Library.DataGeneration;

using System.Diagnostics.CodeAnalysis;

namespace UnitTests.Math;

/// <summary>
///     Test data for IX.Math tests.
/// </summary>
public static partial class TestData
{
    /// <summary>
    ///     Provides templated random text data for basic operators and parentheses.
    /// </summary>
    /// <returns>Test data.</returns>
    [SuppressMessage(
        "ReSharper",
        "RedundantAssignment",
        Justification = "Not really a concern in this test data generation class.")]
    [SuppressMessage(
        "ReSharper",
        "ArrangeRedundantParentheses",
        Justification = "Not really a concern in this test data generation class.")]
    [SuppressMessage(
        "ReSharper",
        "RedundantStringInterpolation",
        Justification = "Not really a concern in this test data generation class.")]
    [SuppressMessage(
        "ReSharper",
        "RedundantCast",
        Justification = "Not really a concern in this test data generation class.")]
    [SuppressMessage(
        "Style",
        "IDE0047:Remove unnecessary parentheses",
        Justification = "Not really a concern in this test data generation class.")]
    [SuppressMessage(
        "Style",
        "IDE0059:Unnecessary assignment of a value",
        Justification = "Not really a concern in this test data generation class.")]
    [SuppressMessage(
        "ReSharper",
        "JoinDeclarationAndInitializer",
        Justification = "Not really a concern in this test data generation class.")]
    public static List<object?[]> BasicOperatorsWithRandomNumbers()
    {
        // Define and initialize
        const int limit = 1000;
        var tests = new List<object?[]>();
        int operand1, operand2, operand3;

        // Tests
        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} + {operand2}",
            null,
            operand1 + operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} + ({operand1} + {operand2})",
            null,
            operand3 + (operand1 + operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} + {operand2}) + {operand3}",
            null,
            (operand1 + operand2) + operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z + ({operand1} + {operand2})",
            new Dictionary<string, object> { ["z"] = operand3 },
            operand3 + (operand1 + operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} + {operand2}) + z",
            new Dictionary<string, object> { ["z"] = operand3 },
            (operand1 + operand2) + operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x + {operand2}",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand1 + operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} + (x + {operand2})",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand3 + (operand1 + operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x + {operand2}) + {operand3}",
            new Dictionary<string, object> { ["x"] = operand1 },
            (operand1 + operand2) + operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z + (x + {operand2})",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            operand3 + (operand1 + operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x + {operand2}) + z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            (operand1 + operand2) + operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} + y",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand1 + operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} + ({operand1} + y)",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand3 + (operand1 + operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} + y) + {operand3}",
            new Dictionary<string, object> { ["y"] = operand2 },
            (operand1 + operand2) + operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z + ({operand1} + y)",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            operand3 + (operand1 + operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} + y) + z",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            (operand1 + operand2) + operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x + y",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand1 + operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} + (x + y)",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand3 + (operand1 + operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x + y) + {operand3}",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            (operand1 + operand2) + operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z + (x + y)",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            operand3 + (operand1 + operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x + y) + z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            (operand1 + operand2) + operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} - {operand2}",
            null,
            operand1 - operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} + ({operand1} - {operand2})",
            null,
            operand3 + (operand1 - operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} - {operand2}) + {operand3}",
            null,
            (operand1 - operand2) + operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z + ({operand1} - {operand2})",
            new Dictionary<string, object> { ["z"] = operand3 },
            operand3 + (operand1 - operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} - {operand2}) + z",
            new Dictionary<string, object> { ["z"] = operand3 },
            (operand1 - operand2) + operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x - {operand2}",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand1 - operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} + (x - {operand2})",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand3 + (operand1 - operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x - {operand2}) + {operand3}",
            new Dictionary<string, object> { ["x"] = operand1 },
            (operand1 - operand2) + operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z + (x - {operand2})",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            operand3 + (operand1 - operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x - {operand2}) + z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            (operand1 - operand2) + operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} - y",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand1 - operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} + ({operand1} - y)",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand3 + (operand1 - operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} - y) + {operand3}",
            new Dictionary<string, object> { ["y"] = operand2 },
            (operand1 - operand2) + operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z + ({operand1} - y)",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            operand3 + (operand1 - operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} - y) + z",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            (operand1 - operand2) + operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x - y",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand1 - operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} + (x - y)",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand3 + (operand1 - operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x - y) + {operand3}",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            (operand1 - operand2) + operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z + (x - y)",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            operand3 + (operand1 - operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x - y) + z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            (operand1 - operand2) + operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} * {operand2}",
            null,
            operand1 * operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} + ({operand1} * {operand2})",
            null,
            operand3 + (operand1 * operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} * {operand2}) + {operand3}",
            null,
            (operand1 * operand2) + operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z + ({operand1} * {operand2})",
            new Dictionary<string, object> { ["z"] = operand3 },
            operand3 + (operand1 * operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} * {operand2}) + z",
            new Dictionary<string, object> { ["z"] = operand3 },
            (operand1 * operand2) + operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x * {operand2}",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand1 * operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} + (x * {operand2})",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand3 + (operand1 * operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x * {operand2}) + {operand3}",
            new Dictionary<string, object> { ["x"] = operand1 },
            (operand1 * operand2) + operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z + (x * {operand2})",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            operand3 + (operand1 * operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x * {operand2}) + z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            (operand1 * operand2) + operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} * y",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand1 * operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} + ({operand1} * y)",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand3 + (operand1 * operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} * y) + {operand3}",
            new Dictionary<string, object> { ["y"] = operand2 },
            (operand1 * operand2) + operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z + ({operand1} * y)",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            operand3 + (operand1 * operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} * y) + z",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            (operand1 * operand2) + operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x * y",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand1 * operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} + (x * y)",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand3 + (operand1 * operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x * y) + {operand3}",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            (operand1 * operand2) + operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z + (x * y)",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            operand3 + (operand1 * operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x * y) + z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            (operand1 * operand2) + operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} / {operand2}",
            null,
            (double)operand1 / (double)operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x / {operand2}",
            new Dictionary<string, object> { ["x"] = operand1 },
            (double)operand1 / (double)operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} / y",
            new Dictionary<string, object> { ["y"] = operand2 },
            (double)operand1 / (double)operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x / y",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            (double)operand1 / (double)operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} & {operand2}",
            null,
            operand1 & operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} + ({operand1} & {operand2})",
            null,
            operand3 + (operand1 & operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} & {operand2}) + {operand3}",
            null,
            (operand1 & operand2) + operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z + ({operand1} & {operand2})",
            new Dictionary<string, object> { ["z"] = operand3 },
            operand3 + (operand1 & operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} & {operand2}) + z",
            new Dictionary<string, object> { ["z"] = operand3 },
            (operand1 & operand2) + operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x & {operand2}",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand1 & operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} + (x & {operand2})",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand3 + (operand1 & operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x & {operand2}) + {operand3}",
            new Dictionary<string, object> { ["x"] = operand1 },
            (operand1 & operand2) + operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z + (x & {operand2})",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            operand3 + (operand1 & operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x & {operand2}) + z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            (operand1 & operand2) + operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} & y",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand1 & operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} + ({operand1} & y)",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand3 + (operand1 & operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} & y) + {operand3}",
            new Dictionary<string, object> { ["y"] = operand2 },
            (operand1 & operand2) + operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z + ({operand1} & y)",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            operand3 + (operand1 & operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} & y) + z",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            (operand1 & operand2) + operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x & y",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand1 & operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} + (x & y)",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand3 + (operand1 & operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x & y) + {operand3}",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            (operand1 & operand2) + operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z + (x & y)",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            operand3 + (operand1 & operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x & y) + z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            (operand1 & operand2) + operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} | {operand2}",
            null,
            operand1 | operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} + ({operand1} | {operand2})",
            null,
            operand3 + (operand1 | operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} | {operand2}) + {operand3}",
            null,
            (operand1 | operand2) + operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z + ({operand1} | {operand2})",
            new Dictionary<string, object> { ["z"] = operand3 },
            operand3 + (operand1 | operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} | {operand2}) + z",
            new Dictionary<string, object> { ["z"] = operand3 },
            (operand1 | operand2) + operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x | {operand2}",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand1 | operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} + (x | {operand2})",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand3 + (operand1 | operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x | {operand2}) + {operand3}",
            new Dictionary<string, object> { ["x"] = operand1 },
            (operand1 | operand2) + operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z + (x | {operand2})",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            operand3 + (operand1 | operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x | {operand2}) + z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            (operand1 | operand2) + operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} | y",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand1 | operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} + ({operand1} | y)",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand3 + (operand1 | operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} | y) + {operand3}",
            new Dictionary<string, object> { ["y"] = operand2 },
            (operand1 | operand2) + operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z + ({operand1} | y)",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            operand3 + (operand1 | operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} | y) + z",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            (operand1 | operand2) + operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x | y",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand1 | operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} + (x | y)",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand3 + (operand1 | operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x | y) + {operand3}",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            (operand1 | operand2) + operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z + (x | y)",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            operand3 + (operand1 | operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x | y) + z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            (operand1 | operand2) + operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} + {operand2}",
            null,
            operand1 + operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} - ({operand1} + {operand2})",
            null,
            operand3 - (operand1 + operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} + {operand2}) - {operand3}",
            null,
            (operand1 + operand2) - operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z - ({operand1} + {operand2})",
            new Dictionary<string, object> { ["z"] = operand3 },
            operand3 - (operand1 + operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} + {operand2}) - z",
            new Dictionary<string, object> { ["z"] = operand3 },
            (operand1 + operand2) - operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x + {operand2}",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand1 + operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} - (x + {operand2})",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand3 - (operand1 + operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x + {operand2}) - {operand3}",
            new Dictionary<string, object> { ["x"] = operand1 },
            (operand1 + operand2) - operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z - (x + {operand2})",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            operand3 - (operand1 + operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x + {operand2}) - z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            (operand1 + operand2) - operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} + y",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand1 + operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} - ({operand1} + y)",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand3 - (operand1 + operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} + y) - {operand3}",
            new Dictionary<string, object> { ["y"] = operand2 },
            (operand1 + operand2) - operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z - ({operand1} + y)",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            operand3 - (operand1 + operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} + y) - z",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            (operand1 + operand2) - operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x + y",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand1 + operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} - (x + y)",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand3 - (operand1 + operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x + y) - {operand3}",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            (operand1 + operand2) - operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z - (x + y)",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            operand3 - (operand1 + operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x + y) - z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            (operand1 + operand2) - operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} - {operand2}",
            null,
            operand1 - operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} - ({operand1} - {operand2})",
            null,
            operand3 - (operand1 - operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} - {operand2}) - {operand3}",
            null,
            (operand1 - operand2) - operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z - ({operand1} - {operand2})",
            new Dictionary<string, object> { ["z"] = operand3 },
            operand3 - (operand1 - operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} - {operand2}) - z",
            new Dictionary<string, object> { ["z"] = operand3 },
            (operand1 - operand2) - operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x - {operand2}",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand1 - operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} - (x - {operand2})",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand3 - (operand1 - operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x - {operand2}) - {operand3}",
            new Dictionary<string, object> { ["x"] = operand1 },
            (operand1 - operand2) - operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z - (x - {operand2})",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            operand3 - (operand1 - operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x - {operand2}) - z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            (operand1 - operand2) - operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} - y",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand1 - operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} - ({operand1} - y)",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand3 - (operand1 - operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} - y) - {operand3}",
            new Dictionary<string, object> { ["y"] = operand2 },
            (operand1 - operand2) - operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z - ({operand1} - y)",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            operand3 - (operand1 - operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} - y) - z",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            (operand1 - operand2) - operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x - y",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand1 - operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} - (x - y)",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand3 - (operand1 - operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x - y) - {operand3}",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            (operand1 - operand2) - operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z - (x - y)",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            operand3 - (operand1 - operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x - y) - z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            (operand1 - operand2) - operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} * {operand2}",
            null,
            operand1 * operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} - ({operand1} * {operand2})",
            null,
            operand3 - (operand1 * operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} * {operand2}) - {operand3}",
            null,
            (operand1 * operand2) - operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z - ({operand1} * {operand2})",
            new Dictionary<string, object> { ["z"] = operand3 },
            operand3 - (operand1 * operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} * {operand2}) - z",
            new Dictionary<string, object> { ["z"] = operand3 },
            (operand1 * operand2) - operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x * {operand2}",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand1 * operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} - (x * {operand2})",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand3 - (operand1 * operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x * {operand2}) - {operand3}",
            new Dictionary<string, object> { ["x"] = operand1 },
            (operand1 * operand2) - operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z - (x * {operand2})",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            operand3 - (operand1 * operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x * {operand2}) - z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            (operand1 * operand2) - operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} * y",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand1 * operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} - ({operand1} * y)",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand3 - (operand1 * operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} * y) - {operand3}",
            new Dictionary<string, object> { ["y"] = operand2 },
            (operand1 * operand2) - operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z - ({operand1} * y)",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            operand3 - (operand1 * operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} * y) - z",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            (operand1 * operand2) - operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x * y",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand1 * operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} - (x * y)",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand3 - (operand1 * operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x * y) - {operand3}",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            (operand1 * operand2) - operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z - (x * y)",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            operand3 - (operand1 * operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x * y) - z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            (operand1 * operand2) - operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} / {operand2}",
            null,
            (double)operand1 / (double)operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x / {operand2}",
            new Dictionary<string, object> { ["x"] = operand1 },
            (double)operand1 / (double)operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} / y",
            new Dictionary<string, object> { ["y"] = operand2 },
            (double)operand1 / (double)operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x / y",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            (double)operand1 / (double)operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} & {operand2}",
            null,
            operand1 & operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} - ({operand1} & {operand2})",
            null,
            operand3 - (operand1 & operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} & {operand2}) - {operand3}",
            null,
            (operand1 & operand2) - operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z - ({operand1} & {operand2})",
            new Dictionary<string, object> { ["z"] = operand3 },
            operand3 - (operand1 & operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} & {operand2}) - z",
            new Dictionary<string, object> { ["z"] = operand3 },
            (operand1 & operand2) - operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x & {operand2}",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand1 & operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} - (x & {operand2})",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand3 - (operand1 & operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x & {operand2}) - {operand3}",
            new Dictionary<string, object> { ["x"] = operand1 },
            (operand1 & operand2) - operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z - (x & {operand2})",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            operand3 - (operand1 & operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x & {operand2}) - z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            (operand1 & operand2) - operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} & y",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand1 & operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} - ({operand1} & y)",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand3 - (operand1 & operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} & y) - {operand3}",
            new Dictionary<string, object> { ["y"] = operand2 },
            (operand1 & operand2) - operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z - ({operand1} & y)",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            operand3 - (operand1 & operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} & y) - z",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            (operand1 & operand2) - operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x & y",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand1 & operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} - (x & y)",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand3 - (operand1 & operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x & y) - {operand3}",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            (operand1 & operand2) - operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z - (x & y)",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            operand3 - (operand1 & operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x & y) - z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            (operand1 & operand2) - operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} | {operand2}",
            null,
            operand1 | operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} - ({operand1} | {operand2})",
            null,
            operand3 - (operand1 | operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} | {operand2}) - {operand3}",
            null,
            (operand1 | operand2) - operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z - ({operand1} | {operand2})",
            new Dictionary<string, object> { ["z"] = operand3 },
            operand3 - (operand1 | operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} | {operand2}) - z",
            new Dictionary<string, object> { ["z"] = operand3 },
            (operand1 | operand2) - operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x | {operand2}",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand1 | operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} - (x | {operand2})",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand3 - (operand1 | operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x | {operand2}) - {operand3}",
            new Dictionary<string, object> { ["x"] = operand1 },
            (operand1 | operand2) - operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z - (x | {operand2})",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            operand3 - (operand1 | operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x | {operand2}) - z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            (operand1 | operand2) - operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} | y",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand1 | operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} - ({operand1} | y)",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand3 - (operand1 | operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} | y) - {operand3}",
            new Dictionary<string, object> { ["y"] = operand2 },
            (operand1 | operand2) - operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z - ({operand1} | y)",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            operand3 - (operand1 | operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} | y) - z",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            (operand1 | operand2) - operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x | y",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand1 | operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} - (x | y)",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand3 - (operand1 | operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x | y) - {operand3}",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            (operand1 | operand2) - operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z - (x | y)",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            operand3 - (operand1 | operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x | y) - z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            (operand1 | operand2) - operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} + {operand2}",
            null,
            operand1 + operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} * ({operand1} + {operand2})",
            null,
            operand3 * (operand1 + operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} + {operand2}) * {operand3}",
            null,
            (operand1 + operand2) * operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z * ({operand1} + {operand2})",
            new Dictionary<string, object> { ["z"] = operand3 },
            operand3 * (operand1 + operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} + {operand2}) * z",
            new Dictionary<string, object> { ["z"] = operand3 },
            (operand1 + operand2) * operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x + {operand2}",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand1 + operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} * (x + {operand2})",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand3 * (operand1 + operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x + {operand2}) * {operand3}",
            new Dictionary<string, object> { ["x"] = operand1 },
            (operand1 + operand2) * operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z * (x + {operand2})",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            operand3 * (operand1 + operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x + {operand2}) * z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            (operand1 + operand2) * operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} + y",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand1 + operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} * ({operand1} + y)",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand3 * (operand1 + operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} + y) * {operand3}",
            new Dictionary<string, object> { ["y"] = operand2 },
            (operand1 + operand2) * operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z * ({operand1} + y)",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            operand3 * (operand1 + operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} + y) * z",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            (operand1 + operand2) * operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x + y",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand1 + operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} * (x + y)",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand3 * (operand1 + operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x + y) * {operand3}",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            (operand1 + operand2) * operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z * (x + y)",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            operand3 * (operand1 + operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x + y) * z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            (operand1 + operand2) * operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} - {operand2}",
            null,
            operand1 - operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} * ({operand1} - {operand2})",
            null,
            operand3 * (operand1 - operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} - {operand2}) * {operand3}",
            null,
            (operand1 - operand2) * operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z * ({operand1} - {operand2})",
            new Dictionary<string, object> { ["z"] = operand3 },
            operand3 * (operand1 - operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} - {operand2}) * z",
            new Dictionary<string, object> { ["z"] = operand3 },
            (operand1 - operand2) * operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x - {operand2}",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand1 - operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} * (x - {operand2})",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand3 * (operand1 - operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x - {operand2}) * {operand3}",
            new Dictionary<string, object> { ["x"] = operand1 },
            (operand1 - operand2) * operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z * (x - {operand2})",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            operand3 * (operand1 - operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x - {operand2}) * z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            (operand1 - operand2) * operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} - y",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand1 - operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} * ({operand1} - y)",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand3 * (operand1 - operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} - y) * {operand3}",
            new Dictionary<string, object> { ["y"] = operand2 },
            (operand1 - operand2) * operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z * ({operand1} - y)",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            operand3 * (operand1 - operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} - y) * z",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            (operand1 - operand2) * operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x - y",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand1 - operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} * (x - y)",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand3 * (operand1 - operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x - y) * {operand3}",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            (operand1 - operand2) * operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z * (x - y)",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            operand3 * (operand1 - operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x - y) * z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            (operand1 - operand2) * operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} * {operand2}",
            null,
            operand1 * operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} * ({operand1} * {operand2})",
            null,
            operand3 * (operand1 * operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} * {operand2}) * {operand3}",
            null,
            (operand1 * operand2) * operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z * ({operand1} * {operand2})",
            new Dictionary<string, object> { ["z"] = operand3 },
            operand3 * (operand1 * operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} * {operand2}) * z",
            new Dictionary<string, object> { ["z"] = operand3 },
            (operand1 * operand2) * operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x * {operand2}",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand1 * operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} * (x * {operand2})",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand3 * (operand1 * operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x * {operand2}) * {operand3}",
            new Dictionary<string, object> { ["x"] = operand1 },
            (operand1 * operand2) * operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z * (x * {operand2})",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            operand3 * (operand1 * operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x * {operand2}) * z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            (operand1 * operand2) * operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} * y",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand1 * operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} * ({operand1} * y)",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand3 * (operand1 * operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} * y) * {operand3}",
            new Dictionary<string, object> { ["y"] = operand2 },
            (operand1 * operand2) * operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z * ({operand1} * y)",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            operand3 * (operand1 * operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} * y) * z",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            (operand1 * operand2) * operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x * y",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand1 * operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} * (x * y)",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand3 * (operand1 * operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x * y) * {operand3}",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            (operand1 * operand2) * operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z * (x * y)",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            operand3 * (operand1 * operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x * y) * z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            (operand1 * operand2) * operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} / {operand2}",
            null,
            (double)operand1 / (double)operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x / {operand2}",
            new Dictionary<string, object> { ["x"] = operand1 },
            (double)operand1 / (double)operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} / y",
            new Dictionary<string, object> { ["y"] = operand2 },
            (double)operand1 / (double)operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x / y",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            (double)operand1 / (double)operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} & {operand2}",
            null,
            operand1 & operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} * ({operand1} & {operand2})",
            null,
            operand3 * (operand1 & operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} & {operand2}) * {operand3}",
            null,
            (operand1 & operand2) * operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z * ({operand1} & {operand2})",
            new Dictionary<string, object> { ["z"] = operand3 },
            operand3 * (operand1 & operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} & {operand2}) * z",
            new Dictionary<string, object> { ["z"] = operand3 },
            (operand1 & operand2) * operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x & {operand2}",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand1 & operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} * (x & {operand2})",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand3 * (operand1 & operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x & {operand2}) * {operand3}",
            new Dictionary<string, object> { ["x"] = operand1 },
            (operand1 & operand2) * operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z * (x & {operand2})",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            operand3 * (operand1 & operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x & {operand2}) * z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            (operand1 & operand2) * operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} & y",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand1 & operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} * ({operand1} & y)",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand3 * (operand1 & operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} & y) * {operand3}",
            new Dictionary<string, object> { ["y"] = operand2 },
            (operand1 & operand2) * operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z * ({operand1} & y)",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            operand3 * (operand1 & operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} & y) * z",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            (operand1 & operand2) * operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x & y",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand1 & operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} * (x & y)",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand3 * (operand1 & operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x & y) * {operand3}",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            (operand1 & operand2) * operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z * (x & y)",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            operand3 * (operand1 & operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x & y) * z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            (operand1 & operand2) * operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} | {operand2}",
            null,
            operand1 | operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} * ({operand1} | {operand2})",
            null,
            operand3 * (operand1 | operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} | {operand2}) * {operand3}",
            null,
            (operand1 | operand2) * operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z * ({operand1} | {operand2})",
            new Dictionary<string, object> { ["z"] = operand3 },
            operand3 * (operand1 | operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} | {operand2}) * z",
            new Dictionary<string, object> { ["z"] = operand3 },
            (operand1 | operand2) * operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x | {operand2}",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand1 | operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} * (x | {operand2})",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand3 * (operand1 | operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x | {operand2}) * {operand3}",
            new Dictionary<string, object> { ["x"] = operand1 },
            (operand1 | operand2) * operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z * (x | {operand2})",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            operand3 * (operand1 | operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x | {operand2}) * z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            (operand1 | operand2) * operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} | y",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand1 | operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} * ({operand1} | y)",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand3 * (operand1 | operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} | y) * {operand3}",
            new Dictionary<string, object> { ["y"] = operand2 },
            (operand1 | operand2) * operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z * ({operand1} | y)",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            operand3 * (operand1 | operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} | y) * z",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            (operand1 | operand2) * operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x | y",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand1 | operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} * (x | y)",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand3 * (operand1 | operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x | y) * {operand3}",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            (operand1 | operand2) * operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z * (x | y)",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            operand3 * (operand1 | operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x | y) * z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            (operand1 | operand2) * operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} + {operand2}",
            null,
            operand1 + operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x + {operand2}",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand1 + operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} + y",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand1 + operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x + y",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand1 + operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} - {operand2}",
            null,
            operand1 - operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x - {operand2}",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand1 - operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} - y",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand1 - operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x - y",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand1 - operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} * {operand2}",
            null,
            operand1 * operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x * {operand2}",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand1 * operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} * y",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand1 * operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x * y",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand1 * operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} / {operand2}",
            null,
            (double)operand1 / (double)operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} / ({operand1} / {operand2})",
            null,
            (double)operand3 / (double)((double)operand1 / (double)operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} / {operand2}) / {operand3}",
            null,
            (double)((double)operand1 / (double)operand2) / (double)operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z / ({operand1} / {operand2})",
            new Dictionary<string, object> { ["z"] = operand3 },
            (double)operand3 / (double)((double)operand1 / (double)operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} / {operand2}) / z",
            new Dictionary<string, object> { ["z"] = operand3 },
            (double)((double)operand1 / (double)operand2) / (double)operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x / {operand2}",
            new Dictionary<string, object> { ["x"] = operand1 },
            (double)operand1 / (double)operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} / (x / {operand2})",
            new Dictionary<string, object> { ["x"] = operand1 },
            (double)operand3 / (double)((double)operand1 / (double)operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x / {operand2}) / {operand3}",
            new Dictionary<string, object> { ["x"] = operand1 },
            (double)((double)operand1 / (double)operand2) / (double)operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z / (x / {operand2})",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            (double)operand3 / (double)((double)operand1 / (double)operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x / {operand2}) / z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            (double)((double)operand1 / (double)operand2) / (double)operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} / y",
            new Dictionary<string, object> { ["y"] = operand2 },
            (double)operand1 / (double)operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} / ({operand1} / y)",
            new Dictionary<string, object> { ["y"] = operand2 },
            (double)operand3 / (double)((double)operand1 / (double)operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} / y) / {operand3}",
            new Dictionary<string, object> { ["y"] = operand2 },
            (double)((double)operand1 / (double)operand2) / (double)operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z / ({operand1} / y)",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            (double)operand3 / (double)((double)operand1 / (double)operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} / y) / z",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            (double)((double)operand1 / (double)operand2) / (double)operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x / y",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            (double)operand1 / (double)operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} / (x / y)",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            (double)operand3 / (double)((double)operand1 / (double)operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x / y) / {operand3}",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            (double)((double)operand1 / (double)operand2) / (double)operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z / (x / y)",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            (double)operand3 / (double)((double)operand1 / (double)operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x / y) / z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            (double)((double)operand1 / (double)operand2) / (double)operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} & {operand2}",
            null,
            operand1 & operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x & {operand2}",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand1 & operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} & y",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand1 & operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x & y",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand1 & operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} | {operand2}",
            null,
            operand1 | operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x | {operand2}",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand1 | operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} | y",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand1 | operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x | y",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand1 | operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} + {operand2}",
            null,
            operand1 + operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} & ({operand1} + {operand2})",
            null,
            operand3 & (operand1 + operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} + {operand2}) & {operand3}",
            null,
            (operand1 + operand2) & operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z & ({operand1} + {operand2})",
            new Dictionary<string, object> { ["z"] = operand3 },
            operand3 & (operand1 + operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} + {operand2}) & z",
            new Dictionary<string, object> { ["z"] = operand3 },
            (operand1 + operand2) & operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x + {operand2}",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand1 + operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} & (x + {operand2})",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand3 & (operand1 + operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x + {operand2}) & {operand3}",
            new Dictionary<string, object> { ["x"] = operand1 },
            (operand1 + operand2) & operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z & (x + {operand2})",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            operand3 & (operand1 + operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x + {operand2}) & z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            (operand1 + operand2) & operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} + y",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand1 + operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} & ({operand1} + y)",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand3 & (operand1 + operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} + y) & {operand3}",
            new Dictionary<string, object> { ["y"] = operand2 },
            (operand1 + operand2) & operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z & ({operand1} + y)",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            operand3 & (operand1 + operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} + y) & z",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            (operand1 + operand2) & operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x + y",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand1 + operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} & (x + y)",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand3 & (operand1 + operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x + y) & {operand3}",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            (operand1 + operand2) & operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z & (x + y)",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            operand3 & (operand1 + operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x + y) & z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            (operand1 + operand2) & operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} - {operand2}",
            null,
            operand1 - operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} & ({operand1} - {operand2})",
            null,
            operand3 & (operand1 - operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} - {operand2}) & {operand3}",
            null,
            (operand1 - operand2) & operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z & ({operand1} - {operand2})",
            new Dictionary<string, object> { ["z"] = operand3 },
            operand3 & (operand1 - operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} - {operand2}) & z",
            new Dictionary<string, object> { ["z"] = operand3 },
            (operand1 - operand2) & operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x - {operand2}",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand1 - operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} & (x - {operand2})",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand3 & (operand1 - operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x - {operand2}) & {operand3}",
            new Dictionary<string, object> { ["x"] = operand1 },
            (operand1 - operand2) & operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z & (x - {operand2})",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            operand3 & (operand1 - operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x - {operand2}) & z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            (operand1 - operand2) & operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} - y",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand1 - operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} & ({operand1} - y)",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand3 & (operand1 - operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} - y) & {operand3}",
            new Dictionary<string, object> { ["y"] = operand2 },
            (operand1 - operand2) & operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z & ({operand1} - y)",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            operand3 & (operand1 - operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} - y) & z",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            (operand1 - operand2) & operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x - y",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand1 - operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} & (x - y)",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand3 & (operand1 - operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x - y) & {operand3}",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            (operand1 - operand2) & operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z & (x - y)",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            operand3 & (operand1 - operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x - y) & z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            (operand1 - operand2) & operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} * {operand2}",
            null,
            operand1 * operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} & ({operand1} * {operand2})",
            null,
            operand3 & (operand1 * operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} * {operand2}) & {operand3}",
            null,
            (operand1 * operand2) & operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z & ({operand1} * {operand2})",
            new Dictionary<string, object> { ["z"] = operand3 },
            operand3 & (operand1 * operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} * {operand2}) & z",
            new Dictionary<string, object> { ["z"] = operand3 },
            (operand1 * operand2) & operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x * {operand2}",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand1 * operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} & (x * {operand2})",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand3 & (operand1 * operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x * {operand2}) & {operand3}",
            new Dictionary<string, object> { ["x"] = operand1 },
            (operand1 * operand2) & operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z & (x * {operand2})",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            operand3 & (operand1 * operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x * {operand2}) & z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            (operand1 * operand2) & operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} * y",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand1 * operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} & ({operand1} * y)",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand3 & (operand1 * operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} * y) & {operand3}",
            new Dictionary<string, object> { ["y"] = operand2 },
            (operand1 * operand2) & operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z & ({operand1} * y)",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            operand3 & (operand1 * operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} * y) & z",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            (operand1 * operand2) & operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x * y",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand1 * operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} & (x * y)",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand3 & (operand1 * operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x * y) & {operand3}",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            (operand1 * operand2) & operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z & (x * y)",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            operand3 & (operand1 * operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x * y) & z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            (operand1 * operand2) & operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} / {operand2}",
            null,
            (double)operand1 / (double)operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x / {operand2}",
            new Dictionary<string, object> { ["x"] = operand1 },
            (double)operand1 / (double)operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} / y",
            new Dictionary<string, object> { ["y"] = operand2 },
            (double)operand1 / (double)operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x / y",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            (double)operand1 / (double)operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} & {operand2}",
            null,
            operand1 & operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} & ({operand1} & {operand2})",
            null,
            operand3 & (operand1 & operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} & {operand2}) & {operand3}",
            null,
            (operand1 & operand2) & operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z & ({operand1} & {operand2})",
            new Dictionary<string, object> { ["z"] = operand3 },
            operand3 & (operand1 & operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} & {operand2}) & z",
            new Dictionary<string, object> { ["z"] = operand3 },
            (operand1 & operand2) & operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x & {operand2}",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand1 & operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} & (x & {operand2})",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand3 & (operand1 & operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x & {operand2}) & {operand3}",
            new Dictionary<string, object> { ["x"] = operand1 },
            (operand1 & operand2) & operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z & (x & {operand2})",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            operand3 & (operand1 & operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x & {operand2}) & z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            (operand1 & operand2) & operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} & y",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand1 & operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} & ({operand1} & y)",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand3 & (operand1 & operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} & y) & {operand3}",
            new Dictionary<string, object> { ["y"] = operand2 },
            (operand1 & operand2) & operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z & ({operand1} & y)",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            operand3 & (operand1 & operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} & y) & z",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            (operand1 & operand2) & operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x & y",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand1 & operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} & (x & y)",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand3 & (operand1 & operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x & y) & {operand3}",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            (operand1 & operand2) & operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z & (x & y)",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            operand3 & (operand1 & operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x & y) & z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            (operand1 & operand2) & operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} | {operand2}",
            null,
            operand1 | operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} & ({operand1} | {operand2})",
            null,
            operand3 & (operand1 | operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} | {operand2}) & {operand3}",
            null,
            (operand1 | operand2) & operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z & ({operand1} | {operand2})",
            new Dictionary<string, object> { ["z"] = operand3 },
            operand3 & (operand1 | operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} | {operand2}) & z",
            new Dictionary<string, object> { ["z"] = operand3 },
            (operand1 | operand2) & operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x | {operand2}",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand1 | operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} & (x | {operand2})",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand3 & (operand1 | operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x | {operand2}) & {operand3}",
            new Dictionary<string, object> { ["x"] = operand1 },
            (operand1 | operand2) & operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z & (x | {operand2})",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            operand3 & (operand1 | operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x | {operand2}) & z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            (operand1 | operand2) & operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} | y",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand1 | operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} & ({operand1} | y)",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand3 & (operand1 | operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} | y) & {operand3}",
            new Dictionary<string, object> { ["y"] = operand2 },
            (operand1 | operand2) & operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z & ({operand1} | y)",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            operand3 & (operand1 | operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} | y) & z",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            (operand1 | operand2) & operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x | y",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand1 | operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} & (x | y)",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand3 & (operand1 | operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x | y) & {operand3}",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            (operand1 | operand2) & operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z & (x | y)",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            operand3 & (operand1 | operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x | y) & z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            (operand1 | operand2) & operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} + {operand2}",
            null,
            operand1 + operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} | ({operand1} + {operand2})",
            null,
            operand3 | (operand1 + operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} + {operand2}) | {operand3}",
            null,
            (operand1 + operand2) | operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z | ({operand1} + {operand2})",
            new Dictionary<string, object> { ["z"] = operand3 },
            operand3 | (operand1 + operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} + {operand2}) | z",
            new Dictionary<string, object> { ["z"] = operand3 },
            (operand1 + operand2) | operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x + {operand2}",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand1 + operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} | (x + {operand2})",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand3 | (operand1 + operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x + {operand2}) | {operand3}",
            new Dictionary<string, object> { ["x"] = operand1 },
            (operand1 + operand2) | operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z | (x + {operand2})",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            operand3 | (operand1 + operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x + {operand2}) | z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            (operand1 + operand2) | operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} + y",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand1 + operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} | ({operand1} + y)",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand3 | (operand1 + operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} + y) | {operand3}",
            new Dictionary<string, object> { ["y"] = operand2 },
            (operand1 + operand2) | operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z | ({operand1} + y)",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            operand3 | (operand1 + operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} + y) | z",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            (operand1 + operand2) | operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x + y",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand1 + operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} | (x + y)",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand3 | (operand1 + operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x + y) | {operand3}",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            (operand1 + operand2) | operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z | (x + y)",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            operand3 | (operand1 + operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x + y) | z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            (operand1 + operand2) | operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} - {operand2}",
            null,
            operand1 - operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} | ({operand1} - {operand2})",
            null,
            operand3 | (operand1 - operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} - {operand2}) | {operand3}",
            null,
            (operand1 - operand2) | operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z | ({operand1} - {operand2})",
            new Dictionary<string, object> { ["z"] = operand3 },
            operand3 | (operand1 - operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} - {operand2}) | z",
            new Dictionary<string, object> { ["z"] = operand3 },
            (operand1 - operand2) | operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x - {operand2}",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand1 - operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} | (x - {operand2})",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand3 | (operand1 - operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x - {operand2}) | {operand3}",
            new Dictionary<string, object> { ["x"] = operand1 },
            (operand1 - operand2) | operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z | (x - {operand2})",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            operand3 | (operand1 - operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x - {operand2}) | z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            (operand1 - operand2) | operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} - y",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand1 - operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} | ({operand1} - y)",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand3 | (operand1 - operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} - y) | {operand3}",
            new Dictionary<string, object> { ["y"] = operand2 },
            (operand1 - operand2) | operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z | ({operand1} - y)",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            operand3 | (operand1 - operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} - y) | z",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            (operand1 - operand2) | operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x - y",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand1 - operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} | (x - y)",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand3 | (operand1 - operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x - y) | {operand3}",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            (operand1 - operand2) | operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z | (x - y)",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            operand3 | (operand1 - operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x - y) | z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            (operand1 - operand2) | operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} * {operand2}",
            null,
            operand1 * operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} | ({operand1} * {operand2})",
            null,
            operand3 | (operand1 * operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} * {operand2}) | {operand3}",
            null,
            (operand1 * operand2) | operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z | ({operand1} * {operand2})",
            new Dictionary<string, object> { ["z"] = operand3 },
            operand3 | (operand1 * operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} * {operand2}) | z",
            new Dictionary<string, object> { ["z"] = operand3 },
            (operand1 * operand2) | operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x * {operand2}",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand1 * operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} | (x * {operand2})",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand3 | (operand1 * operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x * {operand2}) | {operand3}",
            new Dictionary<string, object> { ["x"] = operand1 },
            (operand1 * operand2) | operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z | (x * {operand2})",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            operand3 | (operand1 * operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x * {operand2}) | z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            (operand1 * operand2) | operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} * y",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand1 * operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} | ({operand1} * y)",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand3 | (operand1 * operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} * y) | {operand3}",
            new Dictionary<string, object> { ["y"] = operand2 },
            (operand1 * operand2) | operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z | ({operand1} * y)",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            operand3 | (operand1 * operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} * y) | z",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            (operand1 * operand2) | operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x * y",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand1 * operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} | (x * y)",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand3 | (operand1 * operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x * y) | {operand3}",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            (operand1 * operand2) | operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z | (x * y)",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            operand3 | (operand1 * operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x * y) | z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            (operand1 * operand2) | operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} / {operand2}",
            null,
            (double)operand1 / (double)operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x / {operand2}",
            new Dictionary<string, object> { ["x"] = operand1 },
            (double)operand1 / (double)operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} / y",
            new Dictionary<string, object> { ["y"] = operand2 },
            (double)operand1 / (double)operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x / y",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            (double)operand1 / (double)operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} & {operand2}",
            null,
            operand1 & operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} | ({operand1} & {operand2})",
            null,
            operand3 | (operand1 & operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} & {operand2}) | {operand3}",
            null,
            (operand1 & operand2) | operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z | ({operand1} & {operand2})",
            new Dictionary<string, object> { ["z"] = operand3 },
            operand3 | (operand1 & operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} & {operand2}) | z",
            new Dictionary<string, object> { ["z"] = operand3 },
            (operand1 & operand2) | operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x & {operand2}",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand1 & operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} | (x & {operand2})",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand3 | (operand1 & operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x & {operand2}) | {operand3}",
            new Dictionary<string, object> { ["x"] = operand1 },
            (operand1 & operand2) | operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z | (x & {operand2})",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            operand3 | (operand1 & operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x & {operand2}) | z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            (operand1 & operand2) | operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} & y",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand1 & operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} | ({operand1} & y)",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand3 | (operand1 & operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} & y) | {operand3}",
            new Dictionary<string, object> { ["y"] = operand2 },
            (operand1 & operand2) | operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z | ({operand1} & y)",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            operand3 | (operand1 & operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} & y) | z",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            (operand1 & operand2) | operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x & y",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand1 & operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} | (x & y)",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand3 | (operand1 & operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x & y) | {operand3}",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            (operand1 & operand2) | operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z | (x & y)",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            operand3 | (operand1 & operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x & y) | z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            (operand1 & operand2) | operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} | {operand2}",
            null,
            operand1 | operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} | ({operand1} | {operand2})",
            null,
            operand3 | (operand1 | operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} | {operand2}) | {operand3}",
            null,
            (operand1 | operand2) | operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z | ({operand1} | {operand2})",
            new Dictionary<string, object> { ["z"] = operand3 },
            operand3 | (operand1 | operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} | {operand2}) | z",
            new Dictionary<string, object> { ["z"] = operand3 },
            (operand1 | operand2) | operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x | {operand2}",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand1 | operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} | (x | {operand2})",
            new Dictionary<string, object> { ["x"] = operand1 },
            operand3 | (operand1 | operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x | {operand2}) | {operand3}",
            new Dictionary<string, object> { ["x"] = operand1 },
            (operand1 | operand2) | operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z | (x | {operand2})",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            operand3 | (operand1 | operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x | {operand2}) | z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1 },
            (operand1 | operand2) | operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand1} | y",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand1 | operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} | ({operand1} | y)",
            new Dictionary<string, object> { ["y"] = operand2 },
            operand3 | (operand1 | operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} | y) | {operand3}",
            new Dictionary<string, object> { ["y"] = operand2 },
            (operand1 | operand2) | operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z | ({operand1} | y)",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            operand3 | (operand1 | operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"({operand1} | y) | z",
            new Dictionary<string, object> { ["z"] = operand3, ["y"] = operand2 },
            (operand1 | operand2) | operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"x | y",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand1 | operand2
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"{operand3} | (x | y)",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            operand3 | (operand1 | operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x | y) | {operand3}",
            new Dictionary<string, object> { ["x"] = operand1, ["y"] = operand2 },
            (operand1 | operand2) | operand3
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"z | (x | y)",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            operand3 | (operand1 | operand2)
        });

        operand1 = DataGenerator.RandomNonNegativeInteger(limit);
        operand2 = DataGenerator.RandomNonNegativeInteger(limit);
        operand3 = DataGenerator.RandomNonNegativeInteger(limit);

        tests.Add(new object?[]
        {
            $"(x | y) | z",
            new Dictionary<string, object> { ["z"] = operand3, ["x"] = operand1, ["y"] = operand2 },
            (operand1 | operand2) | operand3
        });

        // Return
        return tests;
    }
}