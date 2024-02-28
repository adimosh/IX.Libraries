namespace IX.Math.Generators;

/// <summary>
///     A simple random number generator.
/// </summary>
internal static class RandomNumberGenerator
{
    private static readonly Random RandomGenerator = new();

    public static double Generate() => Generate(
        0D,
        double.MaxValue);

    public static double Generate(double max) => Generate(
        0D,
        max);

    public static double Generate(
        double min,
        double max)
    {
        Requires.ValidNumericNonNegativeRange(min, max);

        return min + (max - min) * RandomGenerator.NextDouble();
    }

    public static long GenerateInt() => GenerateInt(
        0,
        long.MaxValue);

    public static long GenerateInt(long max) => GenerateInt(
        0,
        max);

    public static long GenerateInt(
        long min,
        long max)
    {
        Requires.ValidNumericNonNegativeRange(min, max);

        return min + (long)(((double)max - min) * RandomGenerator.NextDouble());
    }
}