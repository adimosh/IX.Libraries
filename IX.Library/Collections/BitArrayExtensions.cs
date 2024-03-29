using System.Collections;

namespace IX.Library.Collections;

/// <summary>
///     Extensions for the <see cref="BitArray" /> class.
/// </summary>
public static class BitArrayExtensions
{
    /// <summary>
    ///     Adds one from the least significant byte, with carryover up to the most significant byte.
    /// </summary>
    /// <param name="source">The source bit array.</param>
    public static void AddOne(this BitArray source)
    {
        BitArray ba = source ?? throw new ArgumentNullException(nameof(source));

        for (var i = 0; i < ba.Length; i++)
        {
            if (ba[i])
            {
                ba[i] = false;
            }
            else
            {
                break;
            }
        }
    }
}